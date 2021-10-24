using System.Threading;
using System.Threading.Tasks;

namespace System.Data.Common
{
	public static class DbCommandExtensions
	{
		private static readonly int _defaultRetryAttempts = 1;
		private static readonly int _firstAttempt = 1;
		private static readonly int _maxExponent = 8;

		///<summary>
		/// Recursively attempts to run <see cref="DbCommand.ExecuteReaderAsync()"/> with one retry attempt.
		///</summary>
		public static async Task<DbDataReader> ExecuteReaderWithRetryAsync(this DbCommand dbCommand)
		{
			return await dbCommand.ExecuteReaderWithRetryAsync(_defaultRetryAttempts);
		}

		/// <summary>
		/// Recursively attempts to run <see cref="DbCommand.ExecuteReaderAsync()"/> with one retry attempt.
		/// </summary>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		/// <returns></returns>
		public static async Task<DbDataReader> ExecuteReaderWithRetryAsync(this DbCommand dbCommand, CancellationToken cancellationToken)
		{
			return await dbCommand.ExecuteReaderWithRetryAsync(_defaultRetryAttempts, cancellationToken);
		}

		///<summary>
		/// Recursively attempts to run <see cref="DbCommand.ExecuteReaderAsync()"/> up to <paramref name="retryAttempts"/> times.
		/// Calls will back off exponentionally at a rate of 2^n up to n=8.
		///</summary>
		///<param name="retryAttempts">Number of attempts before thrown exception is thrown to caller.</param>
		public static async Task<DbDataReader> ExecuteReaderWithRetryAsync(this DbCommand dbCommand, int retryAttempts)
		{
			return await dbCommand.ExecuteReaderWithRetryAsync(retryAttempts, _firstAttempt);
		}

		///<summary>
		/// Recursively attempts to run <see cref="DbCommand.ExecuteReaderAsync()"/> up to <paramref name="retryAttempts"/> times.
		/// Calls will back off exponentionally at a rate of 2^n up to n=8.
		///</summary>
		///<param name="retryAttempts">Number of attempts before thrown exception is thrown to caller.</param>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
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
	}
}
