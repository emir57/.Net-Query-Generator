using DapperTest.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WriteParameter.MsSqlWriter;

namespace WriteParameter.Test.MsSql.Insert
{
    public class InsertTest
    {
        public InsertTest()
        {

        }
        [Fact]
        public void MsSql_insert()
        {
            string query = new MsSqlQueryGenerate<InsertModel>()
                .GenerateInsertQuery();

            string result = "insert into dbo.InsertModel (CountryName,Continent,Currency) values (@CountryName,@Continent,@Currency)";

            Assert.Equal(query, result);
        }
    }
}
