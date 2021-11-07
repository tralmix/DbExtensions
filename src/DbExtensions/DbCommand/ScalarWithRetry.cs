using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Data.Common
{
	public static class ScalarWithRetry
	{
		private static readonly int _defaultRetryAttempts = 1;
		private static readonly int _firstAttempt = 1;
		private static readonly int _maxExponent = 8;

		#region Synchronous
		///<summary>
		/// Recursively attempts to run <see cref="DbCommand.ExecuteScalar()"/> with one retry attempt.
		///</summary>
		///<returns>The first column of the first row in the result set.</returns>
		public static object ExecuteScalarWithRetry(this DbCommand dbCommand)
		{
			return dbCommand.ExecuteScalarWithRetry(_defaultRetryAttempts, _firstAttempt);
		}

		///<summary>
		/// Recursively attempts to run <see cref="DbCommand.ExecuteScalar()"/> up to <paramref name="retryAttempts"/> times.
		/// Calls will back off exponentionally at a rate of 2^n up to n=8.
		///</summary>
		///<param name="retryAttempts">Number of attempts before thrown exception is thrown to caller.</param>
		///<returns>The first column of the first row in the result set.</returns>
		public static object ExecuteScalarWithRetry(this DbCommand dbCommand, int retryAttempts)
		{
			return dbCommand.ExecuteScalarWithRetry(retryAttempts, _firstAttempt);
		}

		private static object ExecuteScalarWithRetry(this DbCommand dbCommand, int retryAttempts, int attemptNumber)
		{
			try
			{
				return dbCommand.ExecuteScalar();
			}
			catch (Exception)
			{
				if (retryAttempts <= 0) throw;

				Task.Delay(((int)Math.Pow(2, Math.Min(attemptNumber, _maxExponent))) * 1000).Wait();
				return dbCommand.ExecuteScalarWithRetry(retryAttempts--, attemptNumber++);
			}
		}
		#endregion

		#region Async
		///<summary>
		/// Recursively attempts to run <see cref="DbCommand.ExecuteScalarAsync()"/> with one retry attempt.
		///</summary>
		///<returns>The first column of the first row in the result set.</returns>
		///<exception cref="DbException">An error occurred while executing the command text.</exception>
		public static async Task<object> ExecuteScalarWithRetryAsync(this DbCommand dbCommand)
		{
			return await dbCommand.ExecuteScalarWithRetryAsync(_defaultRetryAttempts);
		}

		///<summary>
		/// Recursively attempts to run <see cref="DbCommand.ExecuteScalarAsync()"/> with one retry attempt.
		///</summary>
		///<param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		///<returns>The first column of the first row in the result set.</returns>
		///<exception cref="DbException">An error occurred while executing the command text.</exception>
		public static async Task<object> ExecuteScalarWithRetryAsync(this DbCommand dbCommand, CancellationToken cancellationToken)
		{
			return await dbCommand.ExecuteScalarWithRetryAsync(_defaultRetryAttempts, cancellationToken);
		}

		///<summary>
		/// Recursively attempts to run <see cref="DbCommand.ExecuteScalarAsync()"/> up to <paramref name="retryAttempts"/> times.
		/// Calls will back off exponentionally at a rate of 2^n up to n=8.
		///</summary>
		///<param name="retryAttempts">Number of attempts before thrown exception is thrown to caller.</param>
		///<returns>The first column of the first row in the result set.</returns>
		///<exception cref="DbException">An error occurred while executing the command text.</exception>
		public static async Task<object> ExecuteScalarWithRetryAsync(this DbCommand dbCommand, int retryAttempts)
		{
			return await dbCommand.ExecuteScalarWithRetryAsync(retryAttempts, _firstAttempt);
		}

		///<summary>
		/// Recursively attempts to run <see cref="DbCommand.ExecuteScalarAsync()"/> up to <paramref name="retryAttempts"/> times.
		/// Calls will back off exponentionally at a rate of 2^n up to n=8.
		///</summary>
		///<param name="retryAttempts">Number of attempts before thrown exception is thrown to caller.</param>
		///<param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		///<returns>The first column of the first row in the result set.</returns>
		///<exception cref="DbException">An error occurred while executing the command text.</exception>
		public static async Task<object> ExecuteScalarWithRetryAsync(this DbCommand dbCommand, int retryAttempts, CancellationToken cancellationToken)
		{
			return await dbCommand.ExecuteScalarWithRetryAsync(retryAttempts, _firstAttempt, cancellationToken);
		}

		private static async Task<object> ExecuteScalarWithRetryAsync(this DbCommand dbCommand, int retryAttempts, int attemptNumber, CancellationToken cancellationToken = default)
		{
			try
			{
				return await dbCommand.ExecuteScalarAsync(cancellationToken);
			}
			catch (Exception)
			{
				if (retryAttempts <= 0) throw;

				await Task.Delay((int)Math.Pow(2, Math.Min(attemptNumber, _maxExponent)) * 1000, cancellationToken: cancellationToken);
				return await dbCommand.ExecuteScalarWithRetryAsync(retryAttempts--, attemptNumber++, cancellationToken);
			}
		}
		#endregion
	}
}
