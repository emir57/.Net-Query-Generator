using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
