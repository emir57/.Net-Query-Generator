using WriteParameter.NpgWriter;
using WriteParameter.Test.Entities.Insert;

namespace WriteParameter.Test.Npg.Insert
{
    public class NpgInsertTest
    {
        public NpgInsertTest()
        {

        }
        [Fact]
        public void Npg_insert()
        {
            string query = new NpgQueryGenerate<InsertModel>()
                .GenerateInsertQuery();

            string result = "insert into dbo.InsertModel (\"CountryName\",\"Continent\",\"Currency\") values (@CountryName,@Continent,@Currency)";

            Assert.Equal(query, result);
        }
    }
}
