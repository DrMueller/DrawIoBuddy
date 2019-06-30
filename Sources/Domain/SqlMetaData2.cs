namespace Mmu.DrawIoBuddy.Domain
{
    public class SqlMetaData2
    {
        public string ColumnName { get; }
        public string ColumnSize { get; }
        public string ColumnType { get; }
        public string TableName { get; }

        public SqlMetaData2(string tableName, string columnName, string columnType, string columnSize)
        {
            TableName = tableName;
            ColumnName = columnName;
            ColumnType = columnType;
            ColumnSize = columnSize;
        }
    }
}