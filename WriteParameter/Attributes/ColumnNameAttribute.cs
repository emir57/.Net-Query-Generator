namespace WriteParameter.Attributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class ColumnNameAttribute : Attribute
    {
        private readonly string _columnName;
        public ColumnNameAttribute(string columnName)
        {
            _columnName = columnName;
        }
    }
}
