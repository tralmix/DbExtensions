using System.Threading;
using System.Threading.Tasks;

namespace System.Data.Common
{
    public static class NonQueryWithRetry
    {
        private static readonly int _defaultRetryAttempts = 1;
        private static readonly int _firstAttempt = 1;
        private static readonly int _maxExponent = 8;

        #region Synchronous
        ///<summary>
        /// Attempts to run <see cref="DbCommand.ExecuteNonQuery()"/> with one retry attempt.
        ///</summary>
        ///<returns>The number of rows affected.</returns>
        public static int ExecuteNonQueryWithRetry(this DbCommand dbCommand)
        {
            return dbCommand.ExecuteNonQueryWithRetry(_defaultRetryAttempts);
        }

        ///<summary>
        /// Attempts to run <see cref="DbCommand.ExecuteNonQuery()"/> up to <paramref name="retryAttempts"/> times.
        /// Calls will back off exponentionally at a rate of 2^n up to n=8.
        ///</summary>
        ///<param name="retryAttempts">Number of attempts before thrown exception is thrown to caller.</param>
        ///<returns>The number of rows affected.</returns>
        public static int ExecuteNonQueryWithRetry(this DbCommand dbCommand, int retryAttempts)
        {
            var attempt = _firstAttempt;
            while (true)
                try
                {
                    return dbCommand.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    Task.Delay(((int)Math.Pow(2, Math.Min(attempt, _maxExponent))) * 1000).Wait();
                    attempt++;
                    if (attempt > retryAttempts) throw;
                }
        }
        #endregion

        #region Async
        ///<summary>
        /// Attempts to run <see cref="DbCommand.ExecuteNonQueryAsync()"/> with one retry attempt.
        ///</summary>
        ///<returns>The number of rows affected.</returns>
        ///<exception cref="DbException">An error occurred while executing the command text.</exception>
        public static async Task<int> ExecuteNonQueryWithRetryAsync(this DbCommand dbCommand)
        {
            return await dbCommand.ExecuteNonQueryWithRetryAsync(_defaultRetryAttempts);
        }

        ///<summary>
        /// Attempts to run <see cref="DbCommand.ExecuteNonQueryAsync()"/> with one retry attempt.
        ///</summary>
        ///<param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        ///<returns>The number of rows affected.</returns>
        ///<exception cref="DbException">An error occurred while executing the command text.</exception>
        public static async Task<int> ExecuteNonQueryWithRetryAsync(this DbCommand dbCommand, CancellationToken cancellationToken)
        {
            return await dbCommand.ExecuteNonQueryWithRetryAsync(_defaultRetryAttempts, cancellationToken);
        }

        ///<summary>
        /// Attempts to run <see cref="DbCommand.ExecuteNonQueryAsync()"/> up to <paramref name="retryAttempts"/> times.
        /// Calls will back off exponentionally at a rate of 2^n up to n=8.
        ///</summary>
        ///<param name="retryAttempts">Number of attempts before thrown exception is thrown to caller.</param>
        ///<returns>The number of rows affected.</returns>
        ///<exception cref="DbException">An error occurred while executing the command text.</exception>
        public static async Task<int> ExecuteNonQueryWithRetryAsync(this DbCommand dbCommand, int retryAttempts)
        {
            return await dbCommand.ExecuteNonQueryWithRetryAsync(retryAttempts);
        }

        ///<summary>
        /// Attempts to run <see cref="DbCommand.ExecuteNonQueryAsync()"/> up to <paramref name="retryAttempts"/> times.
        /// Calls will back off exponentionally at a rate of 2^n up to n=8.
        ///</summary>
        ///<param name="retryAttempts">Number of attempts before thrown exception is thrown to caller.</param>
        ///<param name="cancellationToken">A token to cancel the asynchronous operation.</param>
        ///<returns>The number of rows affected.</returns>
        ///<exception cref="DbException">An error occurred while executing the command text.</exception>
        public static async Task<int> ExecuteNonQueryWithRetryAsync(this DbCommand dbCommand, int retryAttempts, CancellationToken cancellationToken)
        {
            var attempt = _firstAttempt;
            while (true)
                try
                {
                    return await dbCommand.ExecuteNonQueryAsync(cancellationToken);
                }
                catch (Exception)
                {
                    await Task.Delay((int)Math.Pow(2, Math.Min(attempt, _maxExponent)) * 1000, cancellationToken: cancellationToken);
                    attempt++;
                    if (attempt > retryAttempts) throw;
                }
        }
        #endregion
    }
}
