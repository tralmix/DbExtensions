using System.Threading;
using System.Threading.Tasks;

namespace System.Data.Common
{
	public static class OpenConnectionWithRetry
	{
		private const int _defaultRetryAttempts = 1;
		private const int _firstAttempt = 1;
		private const int _maxExponent = 8;

		/// <summary>
		/// Attempts to call <see cref="DbConnection.OpenAsync()"/> if connection is not already in <see cref="ConnectionState.Open"/> state
		/// with <paramref name="retryAttempts"/> retry attempts.
		/// Calls will back off exponentionally at a rate of 2^n seconds up to n=8, where n is <paramref name="retryAttempts"/>.
		/// </summary>
		/// <param name="retryAttempts">Number of times to attempt openning connection before returning thrown error.</param>
		/// <returns></returns>
		public static void EnsureOpenWithRetry(this DbConnection connection, int retryAttempts)
		{
			if (connection.State == ConnectionState.Open) return;

			var attempt = _firstAttempt;
			while (true)
				try
				{
					connection.Open();
					return;
				}
				catch (Exception)
				{
					Task.Delay(((int)Math.Pow(2, Math.Min(attempt, _maxExponent))) * 1000).Wait();
					attempt++;
					if (attempt > retryAttempts) throw;
				}
		}

		/// <summary>
		/// Attempts to call <see cref="DbConnection.OpenAsync()"/> if connection is not already in <see cref="ConnectionState.Open"/> state
		/// with <paramref name="retryAttempts"/> retry attempts.
		/// Calls will back off exponentionally at a rate of 2^n seconds up to n=8, where n is <paramref name="retryAttempts"/>.
		/// </summary>
		/// <param name="retryAttempts">Number of times to attempt openning connection before returning thrown error.</param>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		/// <returns></returns>
		public static async Task EnsureOpenWithRetryAsync(this DbConnection connection, int retryAttempts = _defaultRetryAttempts, CancellationToken cancellationToken = default)
		{
			if (connection.State == ConnectionState.Open) return;

			var attempt = _firstAttempt;
			while (true)
				try
				{
					await connection.OpenAsync(cancellationToken);
					return;
				}
				catch (Exception)
				{
					await Task.Delay(((int)Math.Pow(2, Math.Min(attempt, _maxExponent))) * 1000, cancellationToken);
					attempt++;
					if (attempt > retryAttempts) throw;
				}
		}
	}
}
