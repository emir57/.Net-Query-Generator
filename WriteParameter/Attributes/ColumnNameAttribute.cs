namespace WriteParameter.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ColumnNameAttribute : Attribute
    {
        public readonly string ColumnName;
        public ColumnNameAttribute(string columnName)
        {
            ColumnName = columnName;
        }
    }
}
