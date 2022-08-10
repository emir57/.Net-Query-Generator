using WriteParameter.NpgWriter;
using WriteParameter.Test.Entities.Update;

namespace WriteParameter.Test.Npg.Update
{
    public class NpgUpdateTest
    {
        public NpgUpdateTest()
        {

        }
        [Fact]
        public void Npg_update()
        {
            string query = new NpgQueryGenerate<UpdateModel>()
                .GenerateUpdateQuery();

            string result = "update dbo.UpdateModel set \"CountryName\"=@CountryName,\"Continent\"=@Continent,\"Currency\"=@Currency where \"CountryId\"=@CountryId";

            Assert.Equal(query, result);
        }
    }
}
