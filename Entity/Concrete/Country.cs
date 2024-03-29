﻿using WriteParameter.Attributes;

namespace DapperTest.Entities;

[TableName("Countries")]
public sealed class Country
{
    [IdColumn]
    public int CountryId { get; set; }
    [ColumnName("Name")]
    public string CountryName { get; set; }
    public string Continent { get; set; }
    public string Currency { get; set; }
    [IgnoreColumn]
    public string CountryNameAndContinent
        => String.Format("{0} - {1}", CountryName, Continent);
}
