namespace WriteParameter.Attributes
{
    public class ColumnNameAttribute : WriteParameterPropertyAttribute
    {
        public readonly string ColumnName;
        public ColumnNameAttribute(string columnName)
        {
            ColumnName = columnName;
        }
    }
}
