namespace WriteParameter.Attributes;

public class TableNameAttribute : Attribute
{
    public readonly string TableName;
    public TableNameAttribute(string tableName)
    {
        TableName = tableName;
    }
}
