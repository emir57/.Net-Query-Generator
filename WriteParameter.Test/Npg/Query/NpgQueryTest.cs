using WriteParameter.NpgWriter;
using WriteParameter.Test.Entities;

namespace WriteParameter.Test.Npg.Query
{
    public class NpgQueryTest
    {
        public NpgQueryTest()
        {

        }

        [Fact]
        public void Npg_get_list_query()
        {
            string query = new NpgQueryGenerate<BaseModel>()
                .GenerateGetAllQuery();

            string result = "select \"CountryId\" as CountryId,\"CountryName\" as CountryName,\"Continent\" as Continent,\"Currency\" as Currency from dbo.BaseModel order by \"CountryId\"";

            Assert.Equal(query, result);
        }
    }
}
