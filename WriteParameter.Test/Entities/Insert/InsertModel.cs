using WriteParameter.Attributes;

namespace WriteParameter.Test.Entities.Insert
{
    internal class InsertModel
    {
        [IdColumn]
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string Continent { get; set; }
        public string Currency { get; set; }
    }
}
