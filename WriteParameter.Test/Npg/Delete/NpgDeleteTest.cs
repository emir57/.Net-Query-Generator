using WriteParameter.NpgWriter;
using WriteParameter.Test.Entities.Delete;

namespace WriteParameter.Test.Npg.Delete
{
    public class NpgDeleteTest
    {
        public NpgDeleteTest()
        {

        }
        [Fact]
        public void Npg_delete()
        {
            string query = new NpgQueryGenerate<DeleteModel>()
                .GenerateDeleteQuery();

            string result = "delete from dbo.DeleteModel where \"CountryId\"=@CountryId";

            Assert.Equal(query, result);
        }
    }
}
