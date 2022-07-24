using WriteParameter.Attributes;

namespace DapperTest.Entities
{
    public class Country
    {
        [IdColumn]
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string CountryImageUrl { get; set; }
    }
}
