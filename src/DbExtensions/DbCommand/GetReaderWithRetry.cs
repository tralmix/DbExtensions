using System.Threading;
using System.Threading.Tasks;

namespace System.Data.Common
{
	public static class GetReaderWithRetry
	{
		private static readonly int _defaultRetryAttempts = 1;
		private static readonly int _firstAttempt = 1;
		private static readonly int _maxExponent = 8;

		#region Synchronous
		///<summary>
		/// Recursively attempts to run <see cref="DbCommand.ExecuteReader()"/> with one retry attempt.
		///</summary>
		///<returns>A System.Data.Common.DbDataReader object.</returns>
		public static DbDataReader ExecuteReaderWithRetry(this DbCommand dbCommand)
		{
			return dbCommand.ExecuteReaderWithRetry(_defaultRetryAttempts, _firstAttempt);
		}

		///<summary>
		/// Recursively attempts to run <see cref="DbCommand.ExecuteReader()"/> up to <paramref name="retryAttempts"/> times.
		/// Calls will back off exponentionally at a rate of 2^n up to n=8.
		///</summary>
		///<param name="retryAttempts">Number of attempts before thrown exception is thrown to caller.</param>
		///<returns>A System.Data.Common.DbDataReader object.</returns>
		public static DbDataReader ExecuteReaderWithRetry(this DbCommand dbCommand, int retryAttempts)
		{
			return dbCommand.ExecuteReaderWithRetry(retryAttempts, _firstAttempt);
		}

		private static DbDataReader ExecuteReaderWithRetry(this DbCommand dbCommand, int retryAttempts, int attemptNumber)
		{
			try
			{
				return dbCommand.ExecuteReader();
			}
			catch (Exception)
			{
				if (retryAttempts <= 0) throw;

				Task.Delay(((int)Math.Pow(2, Math.Min(attemptNumber, _maxExponent))) * 1000).Wait();
				return dbCommand.ExecuteReaderWithRetry(retryAttempts--, attemptNumber++);
			}
		}
		#endregion

		#region Async
		///<summary>
		/// Recursively attempts to run <see cref="DbCommand.ExecuteReaderAsync()"/> with one retry attempt.
		///</summary>
		///<returns>A System.Data.Common.DbDataReader object.</returns>
		///<exception cref="System.Data.Common.DbException">An error occurred while executing the command text.</exception>
		///<exception cref="System.ArgumentException">An invalid System.Data.CommandBehavior value.</exception>
		public static async Task<DbDataReader> ExecuteReaderWithRetryAsync(this DbCommand dbCommand)
		{
			return await dbCommand.ExecuteReaderWithRetryAsync(_defaultRetryAttempts);
		}

		///<summary>
		/// Recursively attempts to run <see cref="DbCommand.ExecuteReaderAsync()"/> with one retry attempt.
		///</summary>
		///<param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		///<returns>A System.Data.Common.DbDataReader object.</returns>
		///<exception cref="System.Data.Common.DbException">An error occurred while executing the command text.</exception>
		///<exception cref="System.ArgumentException">An invalid System.Data.CommandBehavior value.</exception>
		public static async Task<DbDataReader> ExecuteReaderWithRetryAsync(this DbCommand dbCommand, CancellationToken cancellationToken)
		{
			return await dbCommand.ExecuteReaderWithRetryAsync(_defaultRetryAttempts, cancellationToken);
		}

		///<summary>
		/// Recursively attempts to run <see cref="DbCommand.ExecuteReaderAsync()"/> up to <paramref name="retryAttempts"/> times.
		/// Calls will back off exponentionally at a rate of 2^n up to n=8.
		///</summary>
		///<param name="retryAttempts">Number of attempts before thrown exception is thrown to caller.</param>
		///<returns>A System.Data.Common.DbDataReader object.</returns>
		///<exception cref="System.Data.Common.DbException">An error occurred while executing the command text.</exception>
		///<exception cref="System.ArgumentException">An invalid System.Data.CommandBehavior value.</exception>
		public static async Task<DbDataReader> ExecuteReaderWithRetryAsync(this DbCommand dbCommand, int retryAttempts)
		{
			return await dbCommand.ExecuteReaderWithRetryAsync(retryAttempts, _firstAttempt);
		}

		///<summary>
		/// Recursively attempts to run <see cref="DbCommand.ExecuteReaderAsync()"/> up to <paramref name="retryAttempts"/> times.
		/// Calls will back off exponentionally at a rate of 2^n up to n=8.
		///</summary>
		///<param name="retryAttempts">Number of attempts before thrown exception is thrown to caller.</param>
		///<param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		///<returns>A System.Data.Common.DbDataReader object.</returns>
		///<exception cref="System.Data.Common.DbException">An error occurred while executing the command text.</exception>
		///<exception cref="System.ArgumentException">An invalid System.Data.CommandBehavior value.</exception>
		public static async Task<DbDataReader> ExecuteReaderWithRetryAsync(this DbCommand dbCommand, int retryAttempts, CancellationToken cancellationToken)
		{
			return await dbCommand.ExecuteReaderWithRetryAsync(retryAttempts, _firstAttempt, cancellationToken);
		}

		private static async Task<DbDataReader> ExecuteReaderWithRetryAsync(this DbCommand dbCommand, int retryAttempts, int attemptNumber, CancellationToken cancellationToken = default)
		{
			try
			{
				return await dbCommand.ExecuteReaderAsync(cancellationToken);
			}
			catch (Exception)
			{
				if (retryAttempts <= 0) throw;

				await Task.Delay((int)Math.Pow(2, Math.Min(attemptNumber, _maxExponent)) * 1000, cancellationToken: cancellationToken);
				return await dbCommand.ExecuteReaderWithRetryAsync(retryAttempts--, attemptNumber++, cancellationToken);
			}
		}
		#endregion
	}
}
