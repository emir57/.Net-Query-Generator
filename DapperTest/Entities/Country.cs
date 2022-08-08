using WriteParameter.Attributes;

namespace DapperTest.Entities
{
    public class Country
    {
        [IdColumn]
        public int CountryId { get; set; }
        [ColumnName("CountryNamee")]
        public string CountryName { get; set; }
        public string Continent { get; set; }
        [IgnoreColumn]
        public string Currency { get; set; }
    }
}
