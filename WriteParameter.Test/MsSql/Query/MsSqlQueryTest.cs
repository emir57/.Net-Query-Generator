using WriteParameter.MsSqlWriter;
using WriteParameter.Test.Entities;

namespace WriteParameter.Test.MsSql.Query
{
    public class MsSqlQueryTest
    {
        public MsSqlQueryTest()
        {

        }

        [Fact]
        public void MsSql_get_list_query()
        {
            string query = new MsSqlQueryGenerate<BaseModel>()
                .GenerateGetAllQuery();

            string result = "select CountryId as CountryId,CountryName as CountryName,Continent as Continent,Currency as Currency from dbo.BaseModel order by CountryId";

            Assert.Equal(query, result);
        }
    }
}
