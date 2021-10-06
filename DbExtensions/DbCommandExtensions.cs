using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace System.Data.Common
{
    public static class DbCommandExtensions
	{

		public static async Task<DbDataReader> ExecuteReaderWithRetryAsync(this DbCommand dbCommand, int retryAttempts)
		{
			return await ExecuteReaderWithRetryAsync(dbCommand, retryAttempts, 1);
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

				await Task.Delay(((int)Math.Pow(2, attemptNumber)) * 1000);
				return await ExecuteReaderWithRetryAsync(dbCommand, retryAttempts--, attemptNumber++);
			}
		}
	}
}
