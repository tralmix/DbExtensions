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
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>"
		public static async Task<string> GetNullableStringAsync (this DbDataReader dbDataReader, string columnName)
		{
			var ordinal = dbDataReader.GetOrdinal(columnName);

			return await dbDataReader.GetNullableStringAsync(ordinal);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable instance of System.String.
		/// </summary>
		/// <param name="ordinal">The zero-based column ordinal.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>"
		public static async Task<string> GetNullableStringAsync(this DbDataReader dbDataReader, int ordinal)
		{
			if (await dbDataReader.IsDBNullAsync(ordinal)) return null;

			return dbDataReader.GetString(ordinal);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable 16-bit signed integer.
		/// </summary>
		/// <param name="columnName">Name of the column.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>"
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>"
		public static async Task<short?> GetNullableInt16Async(this DbDataReader dbDataReader, string columnName)
		{
			var ordinal = dbDataReader.GetOrdinal(columnName);

			return await dbDataReader.GetNullableInt16Async(ordinal);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable 16-bit signed integer.
		/// </summary>
		/// <param name="ordinal">The zero-based column ordinal.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>"
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>"
		public static async Task<short?> GetNullableInt16Async(this DbDataReader dbDataReader, int ordinal)
		{
			if (await dbDataReader.IsDBNullAsync(ordinal)) return null;

			return dbDataReader.GetInt16(ordinal);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable 32-bit signed integer.
		/// </summary>
		/// <param name="columnName">Name of the column.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>"
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>"
		public static async Task<int?> GetNullableInt32Async(this DbDataReader dbDataReader, string columnName)
		{
			var ordinal = dbDataReader.GetOrdinal(columnName);

			return await dbDataReader.GetNullableInt32Async(ordinal);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable 32-bit signed integer.
		/// </summary>
		/// <param name="ordinal">The zero-based column ordinal.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>"
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>"
		public static async Task<int?> GetNullableInt32Async(this DbDataReader dbDataReader, int ordinal)
		{
			if (await dbDataReader.IsDBNullAsync(ordinal)) return null;

			return dbDataReader.GetInt32(ordinal);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable 64-bit signed integer.
		/// </summary>
		/// <param name="columnName">Name of the column.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>"
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>"
		public static async Task<long?> GetNullableInt64Async(this DbDataReader dbDataReader, string columnName)
		{
			var ordinal = dbDataReader.GetOrdinal(columnName);

			return await dbDataReader.GetNullableInt64Async(ordinal);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable 64-bit signed integer.
		/// </summary>
		/// <param name="ordinal">The zero-based column ordinal.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>"
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>"
		public static async Task<long?> GetNullableInt64Async(this DbDataReader dbDataReader, int ordinal)
		{
			if (await dbDataReader.IsDBNullAsync(ordinal)) return null;

			return dbDataReader.GetInt64(ordinal);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable byte.
		/// </summary>
		/// <param name="columnName">Name of the column.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>"
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>"
		public static async Task<byte?> GetNullableByteAsync(this DbDataReader dbDataReader, string columnName)
		{
			var ordinal = dbDataReader.GetOrdinal(columnName);

			return await dbDataReader.GetNullableByteAsync(ordinal);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable byte.
		/// </summary>
		/// <param name="ordinal">The zero-based column ordinal.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>"
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>"
		public static async Task<byte?> GetNullableByteAsync(this DbDataReader dbDataReader, int ordinal)
		{
			if (await dbDataReader .IsDBNullAsync(ordinal)) return null;

			return dbDataReader.GetByte(ordinal);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable Boolean.
		/// </summary>
		/// <param name="columnName">Name of the column.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>"
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>"
		public static async Task<bool?> GetNullableBooleanAsync(this DbDataReader dbDataReader, string columnName)
		{
			var ordinal = dbDataReader.GetOrdinal(columnName);

			return await dbDataReader.GetNullableBooleanAsync(ordinal);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable Boolean.
		/// </summary>
		/// <param name="ordinal">The zero-based column ordinal.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>"
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>"
		public static async Task<bool?> GetNullableBooleanAsync(this DbDataReader dbDataReader, int ordinal)
		{
			if (await dbDataReader .IsDBNullAsync(ordinal)) return null;

			return dbDataReader.GetBoolean(ordinal);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable single character.
		/// </summary>
		/// <param name="columnName">Name of the column.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>"
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>"
		public static async Task<char?> GetNullableCharAsync(this DbDataReader dbDataReader, string columnName)
		{
			var ordinal = dbDataReader.GetOrdinal(columnName);

			return await dbDataReader.GetNullableCharAsync(ordinal);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable single character.
		/// </summary>
		/// <param name="ordinal">The zero-based column ordinal.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>"
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>"
		public static async Task<char?> GetNullableCharAsync(this DbDataReader dbDataReader, int ordinal)
		{
			if (await dbDataReader.IsDBNullAsync(ordinal)) return null;

			return dbDataReader.GetChar(ordinal);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable System.DateTime object.
		/// </summary>
		/// <param name="columnName">Name of the column.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>"
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>"
		public static async Task<DateTime?> GetNullableDateTimeAsync(this DbDataReader dbDataReader, string columnName)
		{
			var ordinal = dbDataReader.GetOrdinal(columnName);

			return await dbDataReader.GetNullableDateTimeAsync(ordinal);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable System.DateTime object.
		/// </summary>
		/// <param name="ordinal">The zero-based column ordinal.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>"
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>"
		public static async Task<DateTime?> GetNullableDateTimeAsync(this DbDataReader dbDataReader, int ordinal)
		{
			if (await dbDataReader.IsDBNullAsync(ordinal)) return null;

			return dbDataReader.GetDateTime(ordinal);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable System.Decimal.
		/// </summary>
		/// <param name="columnName">Name of the column.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>"
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>"
		public static async Task<decimal?> GetNullableDecimalAsync(this DbDataReader dbDataReader, string columnName)
		{
			var ordinal = dbDataReader.GetOrdinal(columnName);

			return await dbDataReader.GetNullableDecimalAsync(ordinal);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable System.Decimal.
		/// </summary>
		/// <param name="ordinal">The zero-based column ordinal.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>"
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>"
		public static async Task<decimal?> GetNullableDecimalAsync(this DbDataReader dbDataReader, int ordinal)
		{
			if (await dbDataReader.IsDBNullAsync(ordinal)) return null;

			return dbDataReader.GetDecimal(ordinal);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable double-precision floating point number.
		/// </summary>
		/// <param name="columnName">Name of the column.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>"
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>"
		public static async Task<double?> GetNullableDoubleAsync(this DbDataReader dbDataReader, string columnName)
		{
			var ordinal = dbDataReader.GetOrdinal(columnName);

			return await dbDataReader.GetNullableDoubleAsync(ordinal);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable double-precision floating point number.
		/// </summary>
		/// <param name="ordinal">The zero-based column ordinal.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>"
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>"
		public static async Task<double?> GetNullableDoubleAsync(this DbDataReader dbDataReader, int ordinal)
		{
			if (await dbDataReader.IsDBNullAsync(ordinal)) return null;

			return dbDataReader.GetDouble(ordinal);
		}
	}
}
