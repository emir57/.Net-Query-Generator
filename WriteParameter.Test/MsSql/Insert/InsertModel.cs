using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WriteParameter.Attributes;

namespace WriteParameter.Test.MsSql.Insert
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
