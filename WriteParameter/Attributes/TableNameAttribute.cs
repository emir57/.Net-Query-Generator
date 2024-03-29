﻿namespace WriteParameter.Attributes;

public class TableNameAttribute : WriteParameterClassAttribute
{
    public readonly string TableName;
    public TableNameAttribute(string tableName)
    {
        TableName = tableName;
    }
}
