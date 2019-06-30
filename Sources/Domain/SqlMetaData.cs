using Mmu.Mlh.DomainExtensions.Areas.DomainModeling;

namespace Mmu.DrawIoBuddy.Domain
{
    public class SqlMetaData : ValueObject<SqlMetaData>
    {
        public string TableName { get; }
        public string ColumnName { get; }
        public string ColumnSize { get; }
        public string ColumnType { get; }

        public SqlMetaData(string tableName, string columnName, string columnType, string columnSize)
        {
            TableName = tableName;
            ColumnName = columnName;
            ColumnType = columnType;
            ColumnSize = columnSize;
        }
    }
}