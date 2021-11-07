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
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>"
		public static string GetNullableString (this DbDataReader dbDataReader, string columnName)
		{
#if NET5_0_OR_GREATER
			if (dbDataReader.IsDBNull(columnName)) return null;

			return dbDataReader.GetString(columnName);
#elif NETSTANDARD1_2_OR_GREATER
			var ordinal = dbDataReader.GetOrdinal(columnName);
			return dbDataReader.GetNullableString(ordinal);
#endif
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable instance of System.String.
		/// </summary>
		/// <param name="ordinal">The zero-based column ordinal.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>"
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>"
		public static string GetNullableString(this DbDataReader dbDataReader, int ordinal)
		{
			if (dbDataReader.IsDBNull(ordinal)) return null;

			return dbDataReader.GetString(ordinal);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable 16-bit signed integer.
		/// </summary>
		/// <param name="columnName">Name of the column.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>"
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>"
		public static short? GetNullableInt16(this DbDataReader dbDataReader, string columnName)
		{
#if NET5_0_OR_GREATER
			if (dbDataReader.IsDBNull(columnName)) return null;

			return dbDataReader.GetInt16(columnName);
#elif NETSTANDARD1_2_OR_GREATER
			var ordinal = dbDataReader.GetOrdinal(columnName);
			return dbDataReader.GetNullableInt16(ordinal);
#endif
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable 16-bit signed integer.
		/// </summary>
		/// <param name="ordinal">The zero-based column ordinal.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>"
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>"
		public static short? GetNullableInt16(this DbDataReader dbDataReader, int ordinal)
		{
			if (dbDataReader.IsDBNull(ordinal)) return null;

			return dbDataReader.GetInt16(ordinal);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable 32-bit signed integer.
		/// </summary>
		/// <param name="columnName">Name of the column.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>"
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>"
		public static int? GetNullableInt32(this DbDataReader dbDataReader, string columnName)
		{
#if NET5_0_OR_GREATER
			if (dbDataReader.IsDBNull(columnName)) return null;

			return dbDataReader.GetInt32(columnName);
#elif NETSTANDARD1_2_OR_GREATER
			var ordinal = dbDataReader.GetOrdinal(columnName);
			return dbDataReader.GetNullableInt32(ordinal);
#endif
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable 32-bit signed integer.
		/// </summary>
		/// <param name="ordinal">The zero-based column ordinal.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>"
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>"
		public static int? GetNullableInt32(this DbDataReader dbDataReader, int ordinal)
		{
			if (dbDataReader.IsDBNull(ordinal)) return null;

			return dbDataReader.GetInt32(ordinal);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable 64-bit signed integer.
		/// </summary>
		/// <param name="columnName">Name of the column.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>"
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>"
		public static long? GetNullableInt64(this DbDataReader dbDataReader, string columnName)
		{
#if NET5_0_OR_GREATER
			if (dbDataReader.IsDBNull(columnName)) return null;

			return dbDataReader.GetInt64(columnName);
#elif NETSTANDARD1_2_OR_GREATER
			var ordinal = dbDataReader.GetOrdinal(columnName);
			return dbDataReader.GetNullableInt64(ordinal);
#endif
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable 64-bit signed integer.
		/// </summary>
		/// <param name="ordinal">The zero-based column ordinal.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>"
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>"
		public static long? GetNullableInt64(this DbDataReader dbDataReader, int ordinal)
		{
			if (dbDataReader.IsDBNull(ordinal)) return null;

			return dbDataReader.GetInt64(ordinal);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable byte.
		/// </summary>
		/// <param name="columnName">Name of the column.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>"
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>"
		public static byte? GetNullableByte(this DbDataReader dbDataReader, string columnName)
		{
#if NET5_0_OR_GREATER
			if (dbDataReader.IsDBNull(columnName)) return null;

			return dbDataReader.GetByte(columnName);
#elif NETSTANDARD1_2_OR_GREATER
			var ordinal = dbDataReader.GetOrdinal(columnName);
			return dbDataReader.GetNullableByte(ordinal);
#endif
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable byte.
		/// </summary>
		/// <param name="ordinal">The zero-based column ordinal.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>"
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>"
		public static byte? GetNullableByte(this DbDataReader dbDataReader, int ordinal)
		{
			if (dbDataReader.IsDBNull(ordinal)) return null;

			return dbDataReader.GetByte(ordinal);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable Boolean.
		/// </summary>
		/// <param name="columnName">Name of the column.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>"
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>"
		public static bool? GetNullableBoolean(this DbDataReader dbDataReader, string columnName)
		{
#if NET5_0_OR_GREATER
			if (dbDataReader.IsDBNull(columnName)) return null;

			return dbDataReader.GetBoolean(columnName);
#elif NETSTANDARD1_2_OR_GREATER
			var ordinal = dbDataReader.GetOrdinal(columnName);
			return dbDataReader.GetNullableBoolean(ordinal);
#endif
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable Boolean.
		/// </summary>
		/// <param name="ordinal">The zero-based column ordinal.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>"
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>"
		public static bool? GetNullableBoolean(this DbDataReader dbDataReader, int ordinal)
		{
			if (dbDataReader.IsDBNull(ordinal)) return null;

			return dbDataReader.GetBoolean(ordinal);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable single character.
		/// </summary>
		/// <param name="columnName">Name of the column.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>"
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>"
		public static char? GetNullableChar(this DbDataReader dbDataReader, string columnName)
		{
#if NET5_0_OR_GREATER
			if (dbDataReader.IsDBNull(columnName)) return null;

			return dbDataReader.GetChar(columnName);
#elif NETSTANDARD1_2_OR_GREATER
			var ordinal = dbDataReader.GetOrdinal(columnName);
			return dbDataReader.GetNullableChar(ordinal);
#endif
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable single character.
		/// </summary>
		/// <param name="ordinal">The zero-based column ordinal.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>"
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>"
		public static char? GetNullableChar(this DbDataReader dbDataReader, int ordinal)
		{
			if (dbDataReader.IsDBNull(ordinal)) return null;

			return dbDataReader.GetChar(ordinal);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable System.DateTime object.
		/// </summary>
		/// <param name="columnName">Name of the column.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>"
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>"
		public static DateTime? GetNullableDateTime(this DbDataReader dbDataReader, string columnName)
		{
#if NET5_0_OR_GREATER
			if (dbDataReader.IsDBNull(columnName)) return null;

			return dbDataReader.GetDateTime(columnName);
#elif NETSTANDARD1_2_OR_GREATER
			var ordinal = dbDataReader.GetOrdinal(columnName);
			return dbDataReader.GetNullableDateTime(ordinal);
#endif
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable System.DateTime object.
		/// </summary>
		/// <param name="ordinal">The zero-based column ordinal.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>"
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>"
		public static DateTime? GetNullableDateTime(this DbDataReader dbDataReader, int ordinal)
		{
			if (dbDataReader.IsDBNull(ordinal)) return null;

			return dbDataReader.GetDateTime(ordinal);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable System.Decimal.
		/// </summary>
		/// <param name="columnName">Name of the column.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>"
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>"
		public static decimal? GetNullableDecimal(this DbDataReader dbDataReader, string columnName)
		{
#if NET5_0_OR_GREATER
			if (dbDataReader.IsDBNull(columnName)) return null;

			return dbDataReader.GetDecimal(columnName);
#elif NETSTANDARD1_2_OR_GREATER
			var ordinal = dbDataReader.GetOrdinal(columnName);
			return dbDataReader.GetNullableDecimal(ordinal);
#endif
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable System.Decimal.
		/// </summary>
		/// <param name="ordinal">The zero-based column ordinal.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>"
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>"
		public static decimal? GetNullableDecimal(this DbDataReader dbDataReader, int ordinal)
		{
			if (dbDataReader.IsDBNull(ordinal)) return null;

			return dbDataReader.GetDecimal(ordinal);
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable double-precision floating point number.
		/// </summary>
		/// <param name="columnName">Name of the column.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>"
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>"
		public static double? GetNullableDouble(this DbDataReader dbDataReader, string columnName)
		{
#if NET5_0_OR_GREATER
			if (dbDataReader.IsDBNull(columnName)) return null;

			return dbDataReader.GetDouble(columnName);
#elif NETSTANDARD1_2_OR_GREATER
			var ordinal = dbDataReader.GetOrdinal(columnName);
			return dbDataReader.GetNullableDouble(ordinal);
#endif
		}

		/// <summary>
		/// Gets the value of the specified column as a nullable double-precision floating point number.
		/// </summary>
		/// <param name="ordinal">The zero-based column ordinal.</param>
		/// <returns>The nullable value of the specified column.</returns>
		/// <exception cref="IndexOutOfRangeException">The column index is out of range.</exception>"
		/// <exception cref="InvalidCastException">The specified cast is not valid.</exception>"
		public static double? GetNullableDouble(this DbDataReader dbDataReader, int ordinal)
		{
			if (dbDataReader.IsDBNull(ordinal)) return null;

			return dbDataReader.GetDouble(ordinal);
		}
	}
}
