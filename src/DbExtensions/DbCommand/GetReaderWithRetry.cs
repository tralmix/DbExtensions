using System.Threading;
using System.Threading.Tasks;

namespace System.Data.Common
{
	public static class GetReaderWithRetry
	{
		private const int _defaultRetryAttempts = 1;
		private const int _firstAttempt = 1;
		private const int _maxExponent = 8;

		///<summary>
		/// Attempts to run <see cref="DbCommand.ExecuteReader()"/> up to <paramref name="retryAttempts"/> times.
		/// Calls will back off exponentionally at a rate of 2^n seconds up to n=8, where n is <paramref name="retryAttempts"/>.
		///</summary>
		///<param name="retryAttempts">Number of attempts before thrown exception is thrown to caller.</param>
		///<param name="behavior">One of the enumeration values that specified the command behavior.</param>
		///<returns>A System.Data.Common.DbDataReader object.</returns>
		///<exception cref="ArgumentException">An invalid System.Data.CommandBehavior value.</exception>
		public static DbDataReader ExecuteReaderWithRetry(this DbCommand dbCommand, int retryAttempts = _defaultRetryAttempts, CommandBehavior behavior = CommandBehavior.Default)
		{
			var attempt = _firstAttempt;
			while (true)
				try
				{
					return dbCommand.ExecuteReader(behavior);
				}
				catch (Exception)
				{
					Task.Delay(((int)Math.Pow(2, Math.Min(attempt, _maxExponent))) * 1000).Wait();
					attempt++;
					if (attempt > retryAttempts) throw;
				}
		}

		///<summary>
		/// Attempts to run <see cref="DbCommand.ExecuteReaderAsync()"/> up to <paramref name="retryAttempts"/> times.
		/// Calls will back off exponentionally at a rate of 2^n seconds up to n=8, where n is <paramref name="retryAttempts"/>.
		///</summary>
		///<param name="retryAttempts">Number of attempts before thrown exception is thrown to caller.</param>
		///<param name="behavior">One of the enumeration values that specified the command behavior.</param>
		///<param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		///<returns>A System.Data.Common.DbDataReader object.</returns>
		///<exception cref="DbException">An error occurred while executing the command text.</exception>
		///<exception cref="ArgumentException">An invalid System.Data.CommandBehavior value.</exception>
		public static async Task<DbDataReader> ExecuteReaderWithRetryAsync(this DbCommand dbCommand, int retryAttempts = _defaultRetryAttempts, CommandBehavior behavior = CommandBehavior.Default, CancellationToken cancellationToken = default)
		{
			var attempt = _firstAttempt;
			while (true)
				try
				{
					return await dbCommand.ExecuteReaderAsync(behavior, cancellationToken);
				}
				catch (Exception)
				{
					await Task.Delay((int)Math.Pow(2, Math.Min(attempt, _maxExponent)) * 1000, cancellationToken: cancellationToken);
					attempt++;

					if (attempt > retryAttempts) throw;
				}
		}
	}
}
