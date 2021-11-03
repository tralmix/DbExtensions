using System.Threading;
using System.Threading.Tasks;

namespace System.Data.Common
{
	public static partial class GetNullables
	{
		/// <summary>
		/// Gets the value of the specified column as a nullable instance of System.String.
		/// </summary>
		/// <param name="columnName">Name of the column.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>
		/// <exception cref="InvalidOperationException">
		///     The connection was dropped or closed during the data retrieval. -or- The data
		///     reader is closed during the data retrieval. -or- There is no data ready to be
		///     read (for example, the first System.Data.Common.DbDataReader.Read hasn't been
		///     called, or returned false). -or- Trying to read a previously read column in sequential
		///     mode. -or- There was an asynchronous operation in progress. This applies to all
		///     Get* methods when running in sequential mode, as they could be called while reading
		///     a stream.
		/// </exception>
		public static async Task<string> GetNullableStringAsync (this DbDataReader dbDataReader, string columnName, CancellationToken cancellationToken = default)
		{
			if (await dbDataReader.IsDBNullAsync(columnName, cancellationToken: cancellationToken)) return null;
			
			return dbDataReader.GetString(columnName);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable instance of System.String.
		/// </summary>
		/// <param name="ordinal">The zero-based column ordinal.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>
		/// <exception cref="InvalidOperationException">
		///     The connection was dropped or closed during the data retrieval. -or- The data
		///     reader is closed during the data retrieval. -or- There is no data ready to be
		///     read (for example, the first System.Data.Common.DbDataReader.Read hasn't been
		///     called, or returned false). -or- Trying to read a previously read column in sequential
		///     mode. -or- There was an asynchronous operation in progress. This applies to all
		///     Get* methods when running in sequential mode, as they could be called while reading
		///     a stream.
		/// </exception>
		public static async Task<string> GetNullableStringAsync(this DbDataReader dbDataReader, int ordinal, CancellationToken cancellationToken = default)
		{
			if (await dbDataReader.IsDBNullAsync(ordinal, cancellationToken)) return null;

			return dbDataReader.GetString(ordinal);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable 16-bit signed integer.
		/// </summary>
		/// <param name="columnName">Name of the column.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>
		/// <exception cref="InvalidOperationException">
		///     The connection was dropped or closed during the data retrieval. -or- The data
		///     reader is closed during the data retrieval. -or- There is no data ready to be
		///     read (for example, the first System.Data.Common.DbDataReader.Read hasn't been
		///     called, or returned false). -or- Trying to read a previously read column in sequential
		///     mode. -or- There was an asynchronous operation in progress. This applies to all
		///     Get* methods when running in sequential mode, as they could be called while reading
		///     a stream.
		/// </exception>
		public static async Task<short?> GetNullableInt16Async(this DbDataReader dbDataReader, string columnName, CancellationToken cancellationToken = default)
		{
			if (await dbDataReader.IsDBNullAsync(columnName, cancellationToken: cancellationToken)) return null;

			return dbDataReader.GetInt16(columnName);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable 16-bit signed integer.
		/// </summary>
		/// <param name="ordinal">The zero-based column ordinal.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>
		/// <exception cref="InvalidOperationException">
		///     The connection was dropped or closed during the data retrieval. -or- The data
		///     reader is closed during the data retrieval. -or- There is no data ready to be
		///     read (for example, the first System.Data.Common.DbDataReader.Read hasn't been
		///     called, or returned false). -or- Trying to read a previously read column in sequential
		///     mode. -or- There was an asynchronous operation in progress. This applies to all
		///     Get* methods when running in sequential mode, as they could be called while reading
		///     a stream.
		/// </exception>
		public static async Task<short?> GetNullableInt16Async(this DbDataReader dbDataReader, int ordinal, CancellationToken cancellationToken = default)
		{
			if (await dbDataReader.IsDBNullAsync(ordinal, cancellationToken)) return null;

			return dbDataReader.GetInt16(ordinal);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable 32-bit signed integer.
		/// </summary>
		/// <param name="columnName">Name of the column.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>
		/// <exception cref="InvalidOperationException">
		///     The connection was dropped or closed during the data retrieval. -or- The data
		///     reader is closed during the data retrieval. -or- There is no data ready to be
		///     read (for example, the first System.Data.Common.DbDataReader.Read hasn't been
		///     called, or returned false). -or- Trying to read a previously read column in sequential
		///     mode. -or- There was an asynchronous operation in progress. This applies to all
		///     Get* methods when running in sequential mode, as they could be called while reading
		///     a stream.
		/// </exception>
		public static async Task<int?> GetNullableInt32Async(this DbDataReader dbDataReader, string columnName, CancellationToken cancellationToken = default)
		{
			if (await dbDataReader.IsDBNullAsync(columnName, cancellationToken: cancellationToken)) return null;

			return dbDataReader.GetInt32(columnName);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable 32-bit signed integer.
		/// </summary>
		/// <param name="ordinal">The zero-based column ordinal.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>
		/// <exception cref="InvalidOperationException">
		///     The connection was dropped or closed during the data retrieval. -or- The data
		///     reader is closed during the data retrieval. -or- There is no data ready to be
		///     read (for example, the first System.Data.Common.DbDataReader.Read hasn't been
		///     called, or returned false). -or- Trying to read a previously read column in sequential
		///     mode. -or- There was an asynchronous operation in progress. This applies to all
		///     Get* methods when running in sequential mode, as they could be called while reading
		///     a stream.
		/// </exception>
		public static async Task<int?> GetNullableInt32Async(this DbDataReader dbDataReader, int ordinal, CancellationToken cancellationToken = default)
		{
			if (await dbDataReader.IsDBNullAsync(ordinal, cancellationToken)) return null;

			return dbDataReader.GetInt32(ordinal);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable 64-bit signed integer.
		/// </summary>
		/// <param name="columnName">Name of the column.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>
		/// <exception cref="InvalidOperationException">
		///     The connection was dropped or closed during the data retrieval. -or- The data
		///     reader is closed during the data retrieval. -or- There is no data ready to be
		///     read (for example, the first System.Data.Common.DbDataReader.Read hasn't been
		///     called, or returned false). -or- Trying to read a previously read column in sequential
		///     mode. -or- There was an asynchronous operation in progress. This applies to all
		///     Get* methods when running in sequential mode, as they could be called while reading
		///     a stream.
		/// </exception>
		public static async Task<long?> GetNullableInt64Async(this DbDataReader dbDataReader, string columnName, CancellationToken cancellationToken = default)
		{
			if (await dbDataReader.IsDBNullAsync(columnName, cancellationToken: cancellationToken)) return null;

			return dbDataReader.GetInt64(columnName);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable 64-bit signed integer.
		/// </summary>
		/// <param name="ordinal">The zero-based column ordinal.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>
		/// <exception cref="InvalidOperationException">
		///     The connection was dropped or closed during the data retrieval. -or- The data
		///     reader is closed during the data retrieval. -or- There is no data ready to be
		///     read (for example, the first System.Data.Common.DbDataReader.Read hasn't been
		///     called, or returned false). -or- Trying to read a previously read column in sequential
		///     mode. -or- There was an asynchronous operation in progress. This applies to all
		///     Get* methods when running in sequential mode, as they could be called while reading
		///     a stream.
		/// </exception>
		public static async Task<long?> GetNullableInt64Async(this DbDataReader dbDataReader, int ordinal, CancellationToken cancellationToken = default)
		{
			if (await dbDataReader.IsDBNullAsync(ordinal, cancellationToken)) return null;

			return dbDataReader.GetInt64(ordinal);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable byte.
		/// </summary>
		/// <param name="columnName">Name of the column.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>
		/// <exception cref="InvalidOperationException">
		///     The connection was dropped or closed during the data retrieval. -or- The data
		///     reader is closed during the data retrieval. -or- There is no data ready to be
		///     read (for example, the first System.Data.Common.DbDataReader.Read hasn't been
		///     called, or returned false). -or- Trying to read a previously read column in sequential
		///     mode. -or- There was an asynchronous operation in progress. This applies to all
		///     Get* methods when running in sequential mode, as they could be called while reading
		///     a stream.
		/// </exception>
		public static async Task<byte?> GetNullableByteAsync(this DbDataReader dbDataReader, string columnName, CancellationToken cancellationToken = default)
		{
			if (await dbDataReader.IsDBNullAsync(columnName, cancellationToken: cancellationToken)) return null;

			return dbDataReader.GetByte(columnName);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable byte.
		/// </summary>
		/// <param name="ordinal">The zero-based column ordinal.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>
		/// <exception cref="InvalidOperationException">
		///     The connection was dropped or closed during the data retrieval. -or- The data
		///     reader is closed during the data retrieval. -or- There is no data ready to be
		///     read (for example, the first System.Data.Common.DbDataReader.Read hasn't been
		///     called, or returned false). -or- Trying to read a previously read column in sequential
		///     mode. -or- There was an asynchronous operation in progress. This applies to all
		///     Get* methods when running in sequential mode, as they could be called while reading
		///     a stream.
		/// </exception>
		public static async Task<byte?> GetNullableByteAsync(this DbDataReader dbDataReader, int ordinal, CancellationToken cancellationToken = default)
		{
			if (await dbDataReader.IsDBNullAsync(ordinal, cancellationToken)) return null;

			return dbDataReader.GetByte(ordinal);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable Boolean.
		/// </summary>
		/// <param name="columnName">Name of the column.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>
		/// <exception cref="InvalidOperationException">
		///     The connection was dropped or closed during the data retrieval. -or- The data
		///     reader is closed during the data retrieval. -or- There is no data ready to be
		///     read (for example, the first System.Data.Common.DbDataReader.Read hasn't been
		///     called, or returned false). -or- Trying to read a previously read column in sequential
		///     mode. -or- There was an asynchronous operation in progress. This applies to all
		///     Get* methods when running in sequential mode, as they could be called while reading
		///     a stream.
		/// </exception>
		public static async Task<bool?> GetNullableBooleanAsync(this DbDataReader dbDataReader, string columnName, CancellationToken cancellationToken = default)
		{
			if (await dbDataReader.IsDBNullAsync(columnName, cancellationToken: cancellationToken)) return null;

			return dbDataReader.GetBoolean(columnName);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable Boolean.
		/// </summary>
		/// <param name="ordinal">The zero-based column ordinal.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>
		/// <exception cref="InvalidOperationException">
		///     The connection was dropped or closed during the data retrieval. -or- The data
		///     reader is closed during the data retrieval. -or- There is no data ready to be
		///     read (for example, the first System.Data.Common.DbDataReader.Read hasn't been
		///     called, or returned false). -or- Trying to read a previously read column in sequential
		///     mode. -or- There was an asynchronous operation in progress. This applies to all
		///     Get* methods when running in sequential mode, as they could be called while reading
		///     a stream.
		/// </exception>
		public static async Task<bool?> GetNullableBooleanAsync(this DbDataReader dbDataReader, int ordinal, CancellationToken cancellationToken = default)
		{
			if (await dbDataReader.IsDBNullAsync(ordinal, cancellationToken)) return null;

			return dbDataReader.GetBoolean(ordinal);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable single character.
		/// </summary>
		/// <param name="columnName">Name of the column.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>
		/// <exception cref="InvalidOperationException">
		///     The connection was dropped or closed during the data retrieval. -or- The data
		///     reader is closed during the data retrieval. -or- There is no data ready to be
		///     read (for example, the first System.Data.Common.DbDataReader.Read hasn't been
		///     called, or returned false). -or- Trying to read a previously read column in sequential
		///     mode. -or- There was an asynchronous operation in progress. This applies to all
		///     Get* methods when running in sequential mode, as they could be called while reading
		///     a stream.
		/// </exception>
		public static async Task<char?> GetNullableCharAsync(this DbDataReader dbDataReader, string columnName, CancellationToken cancellationToken = default)
		{
			if (await dbDataReader.IsDBNullAsync(columnName, cancellationToken: cancellationToken)) return null;

			return dbDataReader.GetChar(columnName);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable single character.
		/// </summary>
		/// <param name="ordinal">The zero-based column ordinal.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>
		/// <exception cref="InvalidOperationException">
		///     The connection was dropped or closed during the data retrieval. -or- The data
		///     reader is closed during the data retrieval. -or- There is no data ready to be
		///     read (for example, the first System.Data.Common.DbDataReader.Read hasn't been
		///     called, or returned false). -or- Trying to read a previously read column in sequential
		///     mode. -or- There was an asynchronous operation in progress. This applies to all
		///     Get* methods when running in sequential mode, as they could be called while reading
		///     a stream.
		/// </exception>
		public static async Task<char?> GetNullableCharAsync(this DbDataReader dbDataReader, int ordinal, CancellationToken cancellationToken = default)
		{
			if (await dbDataReader.IsDBNullAsync(ordinal, cancellationToken)) return null;

			return dbDataReader.GetChar(ordinal);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable System.DateTime object.
		/// </summary>
		/// <param name="columnName">Name of the column.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>
		/// <exception cref="InvalidOperationException">
		///     The connection was dropped or closed during the data retrieval. -or- The data
		///     reader is closed during the data retrieval. -or- There is no data ready to be
		///     read (for example, the first System.Data.Common.DbDataReader.Read hasn't been
		///     called, or returned false). -or- Trying to read a previously read column in sequential
		///     mode. -or- There was an asynchronous operation in progress. This applies to all
		///     Get* methods when running in sequential mode, as they could be called while reading
		///     a stream.
		/// </exception>
		public static async Task<DateTime?> GetNullableDateTimeAsync(this DbDataReader dbDataReader, string columnName, CancellationToken cancellationToken = default)
		{
			if (await dbDataReader.IsDBNullAsync(columnName, cancellationToken: cancellationToken)) return null;

			return dbDataReader.GetDateTime(columnName);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable System.DateTime object.
		/// </summary>
		/// <param name="ordinal">The zero-based column ordinal.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>
		/// <exception cref="InvalidOperationException">
		///     The connection was dropped or closed during the data retrieval. -or- The data
		///     reader is closed during the data retrieval. -or- There is no data ready to be
		///     read (for example, the first System.Data.Common.DbDataReader.Read hasn't been
		///     called, or returned false). -or- Trying to read a previously read column in sequential
		///     mode. -or- There was an asynchronous operation in progress. This applies to all
		///     Get* methods when running in sequential mode, as they could be called while reading
		///     a stream.
		/// </exception>
		public static async Task<DateTime?> GetNullableDateTimeAsync(this DbDataReader dbDataReader, int ordinal, CancellationToken cancellationToken = default)
		{
			if (await dbDataReader.IsDBNullAsync(ordinal, cancellationToken)) return null;

			return dbDataReader.GetDateTime(ordinal);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable System.Decimal.
		/// </summary>
		/// <param name="columnName">Name of the column.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>
		/// <exception cref="InvalidOperationException">
		///     The connection was dropped or closed during the data retrieval. -or- The data
		///     reader is closed during the data retrieval. -or- There is no data ready to be
		///     read (for example, the first System.Data.Common.DbDataReader.Read hasn't been
		///     called, or returned false). -or- Trying to read a previously read column in sequential
		///     mode. -or- There was an asynchronous operation in progress. This applies to all
		///     Get* methods when running in sequential mode, as they could be called while reading
		///     a stream.
		/// </exception>
		public static async Task<decimal?> GetNullableDecimalAsync(this DbDataReader dbDataReader, string columnName, CancellationToken cancellationToken = default)
		{
			if (await dbDataReader.IsDBNullAsync(columnName, cancellationToken: cancellationToken)) return null;

			return dbDataReader.GetDecimal(columnName);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable System.Decimal.
		/// </summary>
		/// <param name="ordinal">The zero-based column ordinal.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>
		/// <exception cref="InvalidOperationException">
		///     The connection was dropped or closed during the data retrieval. -or- The data
		///     reader is closed during the data retrieval. -or- There is no data ready to be
		///     read (for example, the first System.Data.Common.DbDataReader.Read hasn't been
		///     called, or returned false). -or- Trying to read a previously read column in sequential
		///     mode. -or- There was an asynchronous operation in progress. This applies to all
		///     Get* methods when running in sequential mode, as they could be called while reading
		///     a stream.
		/// </exception>
		public static async Task<decimal?> GetNullableDecimalAsync(this DbDataReader dbDataReader, int ordinal, CancellationToken cancellationToken = default)
		{
			if (await dbDataReader.IsDBNullAsync(ordinal, cancellationToken)) return null;

			return dbDataReader.GetDecimal(ordinal);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable double-precision floating point number.
		/// </summary>
		/// <param name="columnName">Name of the column.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>
		/// <exception cref="InvalidOperationException">
		///     The connection was dropped or closed during the data retrieval. -or- The data
		///     reader is closed during the data retrieval. -or- There is no data ready to be
		///     read (for example, the first System.Data.Common.DbDataReader.Read hasn't been
		///     called, or returned false). -or- Trying to read a previously read column in sequential
		///     mode. -or- There was an asynchronous operation in progress. This applies to all
		///     Get* methods when running in sequential mode, as they could be called while reading
		///     a stream.
		/// </exception>
		public static async Task<double?> GetNullableDoubleAsync(this DbDataReader dbDataReader, string columnName, CancellationToken cancellationToken = default)
		{
			if (await dbDataReader.IsDBNullAsync(columnName, cancellationToken: cancellationToken)) return null;


			return dbDataReader.GetDouble(columnName);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable double-precision floating point number.
		/// </summary>
		/// <param name="ordinal">The zero-based column ordinal.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>
		/// <exception cref="InvalidOperationException">
		///     The connection was dropped or closed during the data retrieval. -or- The data
		///     reader is closed during the data retrieval. -or- There is no data ready to be
		///     read (for example, the first System.Data.Common.DbDataReader.Read hasn't been
		///     called, or returned false). -or- Trying to read a previously read column in sequential
		///     mode. -or- There was an asynchronous operation in progress. This applies to all
		///     Get* methods when running in sequential mode, as they could be called while reading
		///     a stream.
		/// </exception>
		public static async Task<double?> GetNullableDoubleAsync(this DbDataReader dbDataReader, int ordinal, CancellationToken cancellationToken = default)
		{
			if (await dbDataReader.IsDBNullAsync(ordinal, cancellationToken)) return null;

			return dbDataReader.GetDouble(ordinal);
		}
	}
}
