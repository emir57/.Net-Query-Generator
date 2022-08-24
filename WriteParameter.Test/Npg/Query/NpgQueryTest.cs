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

        [Theory, InlineData(1)]
        public void Npg_get_by_id_query(int id)
        {
            string query = new NpgQueryGenerate<BaseModel>()
                .GenerateGetByIdQuery(id);

            string result = "select \"CountryId\" as CountryId,\"CountryName\" as CountryName,\"Continent\" as Continent,\"Currency\" as Currency from dbo.BaseModel where \"CountryId\"=1";

            Assert.Equal(query, result);
        }
    }
}
