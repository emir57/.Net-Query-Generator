using WriteParameter.MsSqlWriter;
using WriteParameter.Test.Entities.Insert;

namespace WriteParameter.Test.MsSql.Insert
{
    public class MsSqlInsertTest
    {
        public MsSqlInsertTest()
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
