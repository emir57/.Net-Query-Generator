using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperTest.Entities
{
    public class Driver
    {
        public int Id { get; set; }
        public string DriverName { get; set; }
        public string DriverSurname { get; set; }
        public byte DriverNumber { get; set; }
    }
}
