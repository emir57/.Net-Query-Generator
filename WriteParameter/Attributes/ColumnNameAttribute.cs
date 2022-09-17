namespace WriteParameter.Attributes
{
    public class ColumnNameAttribute
    {
        public readonly string ColumnName;
        public ColumnNameAttribute(string columnName)
        {
            ColumnName = columnName;
        }
    }
}
