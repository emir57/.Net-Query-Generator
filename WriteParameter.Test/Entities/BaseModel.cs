using WriteParameter.Attributes;

namespace WriteParameter.Test.Entities
{
    internal class BaseModel
    {
        [IdColumn]
        public int CountryId { get; set; }
        public virtual string CountryName { get; set; }
        public virtual string Continent { get; set; }
        public virtual string Currency { get; set; }
    }
}
