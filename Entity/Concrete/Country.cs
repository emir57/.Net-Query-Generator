using WriteParameter.Attributes;

namespace DapperTest.Entities;

[TableName("Countries")]
public sealed class Country
{
    [IdColumn]
    public int CountryId { get; set; }
    [ColumnName("Name")]
    public string CountryName { get; set; }
    public string Continent { get; set; }
    [IgnoreColumn]
    public string Currency { get; set; }
}
