using WriteParameter.NpgWriter;
using WriteParameter.Test.Entities.Delete;
using WriteParameter.Test.Entities.Insert;
using WriteParameter.Test.Entities.Update;

namespace WriteParameter.Test.Npg.Command
{
    public class NpgCommandTest
    {
        public NpgCommandTest()
        {

        }
        [Fact]
        public void Npg_insert_command()
        {
            string query = new NpgQueryGenerate<InsertModel>()
                .GenerateInsertQuery();

            string result = "insert into dbo.InsertModel (\"CountryName\",\"Continent\",\"Currency\") values (@CountryName,@Continent,@Currency)";

            Assert.Equal(query, result);
        }
        [Fact]
        public void Npg_update_command()
        {
            string query = new NpgQueryGenerate<UpdateModel>()
                .GenerateUpdateQuery();

            string result = "update dbo.UpdateModel set \"CountryName\"=@CountryName,\"Continent\"=@Continent,\"Currency\"=@Currency where \"CountryId\"=@CountryId";

            Assert.Equal(query, result);
        }
        [Fact]
        public void Npg_delete_command()
        {
            string query = new NpgQueryGenerate<DeleteModel>()
                .GenerateDeleteQuery();

            string result = "delete from dbo.DeleteModel where \"CountryId\"=@CountryId";

            Assert.Equal(query, result);
        }
    }
}
