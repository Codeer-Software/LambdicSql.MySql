using LambdicSql.ConverterServices;
using LambdicSql.ConverterServices.SymbolConverters;

namespace LambdicSql.MySql
{
    /// <summary>
    /// Data type.
    /// It can only be used within methods of the LambdicSql.Db class.
    /// </summary>
    public static class DataType
    {
        /// <summary>
        /// BIGINT
        /// </summary>
        /// <returns>BIGINT</returns>
        [ClauseStyleConverter]
        public static DataTypeElement BigInt() { throw new InvalitContextException(nameof(BigInt)); }

        /// <summary>
        /// BLOB
        /// </summary>
        /// <returns>BLOB</returns>
        [ClauseStyleConverter]
        public static DataTypeElement Blob() { throw new InvalitContextException(nameof(Blob)); }

        /// <summary>
        /// CHAR
        /// </summary>
        /// <returns>CHAR</returns>
        [ClauseStyleConverter]
        public static DataTypeElement Char() { throw new InvalitContextException(nameof(Char)); }

        /// <summary>
        /// CHAR
        /// </summary>
        /// <param name="n">n</param>
        /// <returns>CHAR</returns>
        [FuncStyleConverter]
        public static DataTypeElement Char(int n) { throw new InvalitContextException(nameof(Char)); }

        /// <summary>
        /// DATE
        /// </summary>
        /// <returns>DATE</returns>
        [ClauseStyleConverter]
        public static DataTypeElement Date() { throw new InvalitContextException(nameof(Date)); }

        /// <summary>
        /// DATETIME
        /// </summary>
        /// <returns>DATETIME</returns>
        [ClauseStyleConverter]
        public static DataTypeElement DateTime() { throw new InvalitContextException(nameof(DateTime)); }
        
        /// <summary>
        /// DECIMAL
        /// </summary>
        /// <returns>DECIMAL</returns>
        [ClauseStyleConverter]
        public static DataTypeElement Decimal() { throw new InvalitContextException(nameof(Decimal)); }

        /// <summary>
        /// DECIMAL
        /// </summary>
        /// <param name="precision">precision</param>
        /// <returns>DECIMAL</returns>
        [ClauseStyleConverter]
        public static DataTypeElement Decimal(int precision) { throw new InvalitContextException(nameof(Decimal)); }


        /// <summary>
        /// DECIMAL
        /// </summary>
        /// <param name="precision">precision</param>
        /// <param name="scale">scale</param>
        /// <returns>DECIMAL</returns>
        [ClauseStyleConverter]
        public static DataTypeElement Decimal(int precision, int scale) { throw new InvalitContextException(nameof(Decimal)); }

        /// <summary>
        /// DOUBLE
        /// </summary>
        /// <returns>DOUBLE</returns>
        [ClauseStyleConverter]
        public static DataTypeElement Double() { throw new InvalitContextException(nameof(Double)); }

        /// <summary>
        /// ENUM
        /// </summary>
        /// <returns>ENUM</returns>
        [ClauseStyleConverter]
        public static DataTypeElement Enum() { throw new InvalitContextException(nameof(Enum)); }

        /// <summary>
        /// ENUM
        /// </summary>
        /// <param name="elements">Elements</param>
        /// <returns>ENUM</returns>
        [FuncStyleConverter]
        public static DataTypeElement Enum(params object[] elements) { throw new InvalitContextException(nameof(Enum)); }

        /// <summary>
        /// FLOAT
        /// </summary>
        /// <returns>FLOAT</returns>
        [ClauseStyleConverter]
        public static DataTypeElement Float() { throw new InvalitContextException(nameof(Float)); }

        /// <summary>
        /// FLOAT
        /// </summary>
        /// <param name="n">n</param>
        /// <returns>FLOAT</returns>
        [FuncStyleConverter]
        public static DataTypeElement Float(int n) { throw new InvalitContextException(nameof(Float)); }
       
        /// <summary>
        /// INT
        /// </summary>
        /// <returns>INT</returns>
        [ClauseStyleConverter]
        public static DataTypeElement Int() { throw new InvalitContextException(nameof(Int)); }

        /// <summary>
        /// LONGBLOB
        /// </summary>
        /// <returns>LONGBLOB</returns>
        [ClauseStyleConverter]
        public static DataTypeElement LongBlob() { throw new InvalitContextException(nameof(LongBlob)); }

        /// <summary>
        /// LONGTEXT
        /// </summary>
        /// <returns>LONGTEXT</returns>
        [ClauseStyleConverter]
        public static DataTypeElement LongText() { throw new InvalitContextException(nameof(LongText)); }

        /// <summary>
        /// MEDIUMBLOB
        /// </summary>
        /// <returns>MEDIUMBLOB</returns>
        [ClauseStyleConverter]
        public static DataTypeElement MediumBlob() { throw new InvalitContextException(nameof(MediumBlob)); }

        /// <summary>
        /// MEDIUMINT
        /// </summary>
        /// <returns>MEDIUMINT</returns>
        [ClauseStyleConverter]
        public static DataTypeElement MediumInt() { throw new InvalitContextException(nameof(MediumInt)); }

        /// <summary>
        /// MEDIUMTEXT
        /// </summary>
        /// <returns>MEDIUMTEXT</returns>
        [ClauseStyleConverter]
        public static DataTypeElement MediumText() { throw new InvalitContextException(nameof(MediumText)); }

        /// <summary>
        /// SET
        /// </summary>
        /// <returns>SET</returns>
        [ClauseStyleConverter]
        public static DataTypeElement Set() { throw new InvalitContextException(nameof(Set)); }

        /// <summary>
        /// SET
        /// </summary>
        /// <param name="elements">Elements</param>
        /// <returns>SET</returns>
        [FuncStyleConverter]
        public static DataTypeElement Set(params object[] elements) { throw new InvalitContextException(nameof(Set)); }

        /// <summary>
        /// SMALLINT
        /// </summary>
        /// <returns>SMALLINT</returns>
        [ClauseStyleConverter]
        public static DataTypeElement SmallInt() { throw new InvalitContextException(nameof(SmallInt)); }

        /// <summary>
        /// TEXT
        /// </summary>
        /// <returns>TEXT</returns>
        [ClauseStyleConverter]
        public static DataTypeElement Text() { throw new InvalitContextException(nameof(Text)); }

        /// <summary>
        /// TIME
        /// </summary>
        /// <returns>TIME</returns>
        [ClauseStyleConverter]
        public static DataTypeElement Time() { throw new InvalitContextException(nameof(Time)); }

        /// <summary>
        /// TIME
        /// </summary>
        /// <param name="n">n</param>
        /// <returns>TIME</returns>
        [FuncStyleConverter]
        public static DataTypeElement Time(int n) { throw new InvalitContextException(nameof(Time)); }

        /// <summary>
        /// TIMESTAMP
        /// </summary>
        /// <returns>TIMESTAMP</returns>
        [ClauseStyleConverter]
        public static DataTypeElement TimeStamp() { throw new InvalitContextException(nameof(TimeStamp)); }

        /// <summary>
        /// TIMESTAMP
        /// </summary>
        /// <param name="n">n</param>
        /// <returns>TIMESTAMP</returns>
        [FuncStyleConverter]
        public static DataTypeElement TimeStamp(int n) { throw new InvalitContextException(nameof(TimeStamp)); }

        /// <summary>
        /// TINYBLOB
        /// </summary>
        /// <returns>TINYBLOB</returns>
        [ClauseStyleConverter]
        public static DataTypeElement TinyBlob() { throw new InvalitContextException(nameof(TinyBlob)); }

        /// <summary>
        /// TINYINT
        /// </summary>
        /// <returns>TINYINT</returns>
        [ClauseStyleConverter]
        public static DataTypeElement TinyInt() { throw new InvalitContextException(nameof(TinyInt)); }

        /// <summary>
        /// TINYTEXT
        /// </summary>
        /// <returns>TINYTEXT</returns>
        [ClauseStyleConverter]
        public static DataTypeElement TinyText() { throw new InvalitContextException(nameof(TinyText)); }

        /// <summary>
        /// VARCHAR
        /// </summary>
        /// <returns>VARCHAR</returns>
        [ClauseStyleConverter]
        public static DataTypeElement VarChar() { throw new InvalitContextException(nameof(VarChar)); }

        /// <summary>
        /// VARCHAR
        /// </summary>
        /// <param name="n">n</param>
        /// <returns>VARCHAR</returns>
        [FuncStyleConverter]
        public static DataTypeElement VarChar(int n) { throw new InvalitContextException(nameof(VarChar)); }

        /// <summary>
        /// VARCHAR2
        /// </summary>
        /// <returns>VARCHAR2</returns>
        [ClauseStyleConverter]
        public static DataTypeElement VarChar2() { throw new InvalitContextException(nameof(VarChar2)); }

        /// <summary>
        /// VARCHAR2
        /// </summary>
        /// <param name="n">n</param>
        /// <returns>VARCHAR2</returns>
        [FuncStyleConverter]
        public static DataTypeElement VarChar2(int n) { throw new InvalitContextException(nameof(VarChar2)); }

        /// <summary>
        /// YEAR
        /// </summary>
        /// <returns>YEAR</returns>
        [ClauseStyleConverter]
        public static DataTypeElement Year() { throw new InvalitContextException(nameof(Year)); }
    }
}
