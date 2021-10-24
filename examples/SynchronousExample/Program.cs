using Microsoft.Data.Sqlite;
using System.Data.Common;
using System.Diagnostics;

namespace SynchronousExample
{
    class Program
	{
		static readonly string inMemoryConnectionString = "Data Source=InMemorySample;Mode=Memory;Cache=Shared";
		static void Main(string[] args)
		{
			using var connection = new SqliteConnection(inMemoryConnectionString);

			connection.EnsureOpenWithRetry(2);

			using var command = connection.CreateCommand();

			using var reader = command.ExecuteReaderWithRetry(2);

			Debug.Assert(true);
		}
	}
}
