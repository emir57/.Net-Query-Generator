namespace WriteParameter.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class TableNameAttribute : Attribute
{
    public readonly string TableName;
    public TableNameAttribute(string tableName)
    {
        TableName = tableName;
    }
}
