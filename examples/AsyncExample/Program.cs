using System.Data.Common;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.Data.Sqlite;

namespace AsyncExample
{
	class Program
	{
		static readonly string inMemoryConnectionString = "Data Source=InMemorySample;Mode=Memory;Cache=Shared";
		static async Task Main(string[] args)
		{
			using var connection = new SqliteConnection(inMemoryConnectionString);

			await connection.EnsureOpenWithRetryAsync(2);
			
			using var command = connection.CreateCommand();

			using var reader = await command.ExecuteReaderWithRetryAsync(2);

			Debug.Assert(true);
		}
	}
}
