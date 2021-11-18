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
#if NET5_0_OR_GREATER
#nullable enable
        ///<summary>
        /// Attempts to run <see cref="DbCommand.ExecuteScalar()"/> with one retry attempt.
        ///</summary>
        ///<returns>The first column of the first row in the result set.</returns>
        public static object? ExecuteScalarWithRetry(this DbCommand dbCommand)
        {
            return dbCommand.ExecuteScalarWithRetry(_defaultRetryAttempts);
        }

        ///<summary>
        /// Attempts to run <see cref="DbCommand.ExecuteScalar()"/> up to <paramref name="retryAttempts"/> times.
        /// Calls will back off exponentionally at a rate of 2^n up to n=8.
        ///</summary>
        ///<param name="retryAttempts">Number of attempts before thrown exception is thrown to caller.</param>
        ///<returns>The first column of the first row in the result set.</returns>
        public static object? ExecuteScalarWithRetry(this DbCommand dbCommand, int retryAttempts)
        {
            var attempt = _firstAttempt;
            while (true)
                try
                {
                    return dbCommand.ExecuteScalar();
                }
                catch (Exception)
                {
                    Task.Delay(((int)Math.Pow(2, Math.Min(attempt, _maxExponent))) * 1000).Wait();
                    attempt++;
                    if (attempt > retryAttempts) throw;
                }
        }
#elif NETSTANDARD1_2_OR_GREATER
		///<summary>
		/// Recursively attempts to run <see cref="DbCommand.ExecuteScalar()"/> with one retry attempt.
		///</summary>
		///<returns>The first column of the first row in the result set.</returns>
		public static object ExecuteScalarWithRetry(this DbCommand dbCommand)
		{
			return dbCommand.ExecuteScalarWithRetry(_defaultRetryAttempts);
		}

		///<summary>
		/// Recursively attempts to run <see cref="DbCommand.ExecuteScalar()"/> up to <paramref name="retryAttempts"/> times.
		/// Calls will back off exponentionally at a rate of 2^n up to n=8.
		///</summary>
		///<param name="retryAttempts">Number of attempts before thrown exception is thrown to caller.</param>
		///<returns>The first column of the first row in the result set.</returns>
		public static object ExecuteScalarWithRetry(this DbCommand dbCommand, int retryAttempts)
		{
            var attempt = _firstAttempt;
            while (true)
                try
                {
                    return dbCommand.ExecuteScalar();
                }
                catch (Exception)
                {
                    Task.Delay(((int)Math.Pow(2, Math.Min(attempt, _maxExponent))) * 1000).Wait();
                    attempt++;
                    if (attempt > retryAttempts) throw;
                }
        }
#endif
        #endregion

        #region Async
#if NET5_0_OR_GREATER
        ///<summary>
        /// Attempts to run <see cref="DbCommand.ExecuteScalarAsync()"/> with one retry attempt.
        ///</summary>
        ///<returns>The first column of the first row in the result set.</returns>
        ///<exception cref="DbException">An error occurred while executing the command text.</exception>
        public static async Task<object?> ExecuteScalarWithRetryAsync(this DbCommand dbCommand)
        {
            return await dbCommand.ExecuteScalarWithRetryAsync(_defaultRetryAttempts);
        }

        ///<summary>
        /// Attempts to run <see cref="DbCommand.ExecuteScalarAsync()"/> with one retry attempt.
        ///</summary>
        ///<param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        ///<returns>The first column of the first row in the result set.</returns>
        ///<exception cref="DbException">An error occurred while executing the command text.</exception>
        public static async Task<object?> ExecuteScalarWithRetryAsync(this DbCommand dbCommand, CancellationToken cancellationToken)
        {
            return await dbCommand.ExecuteScalarWithRetryAsync(_defaultRetryAttempts, cancellationToken);
        }

        ///<summary>
        /// Attempts to run <see cref="DbCommand.ExecuteScalarAsync()"/> up to <paramref name="retryAttempts"/> times.
        /// Calls will back off exponentionally at a rate of 2^n up to n=8.
        ///</summary>
        ///<param name="retryAttempts">Number of attempts before thrown exception is thrown to caller.</param>
        ///<returns>The first column of the first row in the result set.</returns>
        ///<exception cref="DbException">An error occurred while executing the command text.</exception>
        public static async Task<object?> ExecuteScalarWithRetryAsync(this DbCommand dbCommand, int retryAttempts)
        {
            return await dbCommand.ExecuteScalarWithRetryAsync(retryAttempts);
        }

        ///<summary>
        /// Attempts to run <see cref="DbCommand.ExecuteScalarAsync()"/> up to <paramref name="retryAttempts"/> times.
        /// Calls will back off exponentionally at a rate of 2^n up to n=8.
        ///</summary>
        ///<param name="retryAttempts">Number of attempts before thrown exception is thrown to caller.</param>
        ///<param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        ///<returns>The first column of the first row in the result set.</returns>
        ///<exception cref="DbException">An error occurred while executing the command text.</exception>
        public static async Task<object?> ExecuteScalarWithRetryAsync(this DbCommand dbCommand, int retryAttempts, CancellationToken cancellationToken = default)
        {
            var attempt = _firstAttempt;
            while (true)
                try
                {
                    return await dbCommand.ExecuteScalarAsync(cancellationToken);
                }
                catch (Exception)
                {
                    await Task.Delay(((int)Math.Pow(2, Math.Min(attempt, _maxExponent))) * 1000, cancellationToken);
                    attempt++;
                    if (attempt > retryAttempts) throw;
                }
        }
#nullable enable
#elif NETSTANDARD1_2_OR_GREATER
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
			return await dbCommand.ExecuteScalarWithRetryAsync(retryAttempts);
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
            var attempt = _firstAttempt;
            while (true)
                try
                {
                    return await dbCommand.ExecuteScalarAsync(cancellationToken);
                }
                catch (Exception)
                {
                    await Task.Delay(((int)Math.Pow(2, Math.Min(attempt, _maxExponent))) * 1000, cancellationToken);
                    attempt++;
                    if (attempt > retryAttempts) throw;
                }
        }
#endif
        #endregion
    }
}
