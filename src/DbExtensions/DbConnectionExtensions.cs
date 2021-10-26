using System.Threading;
using System.Threading.Tasks;

namespace System.Data.Common
{
	public static class DbConnectionExtensions
	{
		private static readonly int _defaultRetryAttempts = 1;
		private static readonly int _firstAttempt = 1;
		private static readonly int _maxExponent = 8;
		private static readonly int _noRetryAttempts = 0;

		#region Synchronous
		///<summary>
		/// Attempts to call <see cref="DbConnection.Open()"/> if connection is not already in <see cref="ConnectionState.Open"/> state.
		///</summary>
		public static void EnsureOpen(this DbConnection connection)
		{
			connection.EnsureOpenWithRetry(_noRetryAttempts, _firstAttempt);
		}

		///<summary>
		/// Recursively attempts to call <see cref="DbConnection.Open()"/> if connection is not already in <see cref="ConnectionState.Open"/> state with one retry attempt.
		///</summary>
		public static void EnsureOpenWithRetry(this DbConnection connection)
		{
			connection.EnsureOpenWithRetry(_defaultRetryAttempts, _firstAttempt);
		}

		/// <summary>
		/// Recursively attempts to call <see cref="DbConnection.OpenAsync()"/> if connection is not already in <see cref="ConnectionState.Open"/> state
		/// with <paramref name="retryAttempts"/> retry attempts.
		/// </summary>
		/// <param name="retryAttempts">Number of times to attempt openning connection before returning thrown error.</param>
		/// <returns></returns>
		public static void EnsureOpenWithRetry(this DbConnection connection, int retryAttempts)
		{
			connection.EnsureOpenWithRetry(retryAttempts, _firstAttempt);
		}

		private static void EnsureOpenWithRetry(this DbConnection connection, int retryAttempts, int attemptNumber)
		{
			if (connection.State == ConnectionState.Open) return;

			try
			{
				connection.Open();
			}
			catch (Exception)
			{
				if (retryAttempts <= 0) throw;

				Thread.Sleep(((int)Math.Pow(2, Math.Min(attemptNumber, _maxExponent))) * 1000);
				connection.EnsureOpenWithRetry(retryAttempts--, attemptNumber++);
			}
		}
		#endregion

		#region Async
		///<summary>
		/// Recursively attempts to call <see cref="DbConnection.OpenAsync()"/> if connection is not already in <see cref="ConnectionState.Open"/> state.
		///</summary>
		public static async Task EnsureOpenAsync(this DbConnection connection)
		{
			await connection.EnsureOpenWithRetryAsync(_noRetryAttempts);
		}

		///<summary>
		/// Recursively attempts to call <see cref="DbConnection.OpenAsync()"/> if connection is not already in <see cref="ConnectionState.Open"/> state with one retry attempt.
		///</summary>
		public static async Task EnsureOpenWithRetryAsync(this DbConnection connection)
		{
			await connection.EnsureOpenWithRetryAsync(_defaultRetryAttempts, _firstAttempt);
		}

		///<summary>
		/// Recursively attempts to call <see cref="DbConnection.OpenAsync()"/> if connection is not already in <see cref="ConnectionState.Open"/> state with one retry attempt.
		///</summary>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		public static async Task EnsureOpenWithRetryAsync(this DbConnection connection, CancellationToken cancellationToken)
		{
			await connection.EnsureOpenWithRetryAsync(_defaultRetryAttempts, _firstAttempt, cancellationToken);
		}

		/// <summary>
		/// Recursively attempts to call <see cref="DbConnection.OpenAsync()"/> if connection is not already in <see cref="ConnectionState.Open"/> state
		/// with <paramref name="retryAttempts"/> retry attempts.
		/// </summary>
		/// <param name="retryAttempts">Number of times to attempt openning connection before returning thrown error.</param>
		/// <returns></returns>
		public static async Task EnsureOpenWithRetryAsync(this DbConnection connection, int retryAttempts)
		{
			await connection.EnsureOpenWithRetryAsync(retryAttempts, _firstAttempt);
		}

		/// <summary>
		/// Recursively attempts to call <see cref="DbConnection.OpenAsync()"/> if connection is not already in <see cref="ConnectionState.Open"/> state
		/// with <paramref name="retryAttempts"/> retry attempts.
		/// </summary>
		/// <param name="retryAttempts">Number of times to attempt openning connection before returning thrown error.</param>
		/// <param name="cancellationToken">A token to cancel the asynchronous operation.</param>
		/// <returns></returns>
		public static async Task EnsureOpenWithRetryAsync(this DbConnection connection, int retryAttempts, CancellationToken cancellationToken)
		{
			await connection.EnsureOpenWithRetryAsync(retryAttempts, _firstAttempt, cancellationToken);
		}

		private static async Task EnsureOpenWithRetryAsync(this DbConnection connection, int retryAttempts, int attemptNumber, CancellationToken cancellationToken = default)
		{
			if (connection.State == ConnectionState.Open) return;

			try
			{
				await connection.OpenAsync(cancellationToken);
			}
			catch (Exception)
			{
				if (retryAttempts <= 0) throw;

				await Task.Delay(((int)Math.Pow(2, Math.Min(attemptNumber, _maxExponent))) * 1000, cancellationToken);
				await connection.EnsureOpenWithRetryAsync(retryAttempts--, attemptNumber++, cancellationToken: cancellationToken);
			}
		}
		#endregion
	}
}
