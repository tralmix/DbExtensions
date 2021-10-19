using System.Threading.Tasks;

namespace System.Data.Common
{
    public static class DbCommandExtensions
	{
		private static int _defaultRetryAttempts = 1;
		private static int _firstAttempt = 1;
		private static int _maxExponent = 8;
		
        ///<summary>
        /// Recursively attempts to run <cref>DbCommand.ExecuteReaderAsync()</cref> with one retry attempt.
        ///</summary>
		public static async Task<DbDataReader> ExecuteReaderWithRetryAsync(this DbCommand dbCommand)
		{
			return await dbCommand.ExecuteReaderWithRetryAsync(_defaultRetryAttempts);
		}

        ///<summary>
        /// Recursively attempts to run <cref>DbCommand.ExecuteReaderAsync()</cref> up to <paramref name="retryAttempts"> times.
        /// Calls will back off exponentionally at a rate of 2^n up to n=8.
        ///</summary>
        ///<param name="retryAttempts">Number of attempts before exception thrown.</param>
		public static async Task<DbDataReader> ExecuteReaderWithRetryAsync(this DbCommand dbCommand, int retryAttempts)
		{
			return await ExecuteReaderWithRetryAsync(dbCommand, retryAttempts, _firstAttempt);
		}

		private static async Task<DbDataReader> ExecuteReaderWithRetryAsync(DbCommand dbCommand, int retryAttempts, int attemptNumber)
		{
			try
			{
				return await dbCommand.ExecuteReaderAsync();
			}
			catch (Exception)
			{
				if (retryAttempts <= 0) throw;

				await Task.Delay(((int)Math.Pow(2, Math.Min(attemptNumber, _maxExponent)) * 1000));
				return await ExecuteReaderWithRetryAsync(dbCommand, retryAttempts--, attemptNumber++);
			}
		}
	}
}
