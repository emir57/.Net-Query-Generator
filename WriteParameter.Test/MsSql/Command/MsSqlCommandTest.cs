using WriteParameter.MsSqlWriter;
using WriteParameter.Test.Entities.Delete;
using WriteParameter.Test.Entities.Insert;
using WriteParameter.Test.Entities.Update;

namespace WriteParameter.Test.MsSql.Command
{
    public class MsSqlCommandTest
    {
        public MsSqlCommandTest()
        {

        }
        [Fact]
        public void MsSql_insert_command()
        {
            string query = new MsSqlQueryGenerate<InsertModel>()
                .GenerateInsertQuery();

            string result = "insert into dbo.InsertModel (CountryName,Continent,Currency) values (@CountryName,@Continent,@Currency)";

            Assert.Equal(query, result);
        }
        [Fact]
        public void MsSql_update_command()
        {
            string query = new MsSqlQueryGenerate<UpdateModel>()
                .GenerateUpdateQuery();

            string result = "update dbo.UpdateModel set CountryName=@CountryName,Continent=@Continent,Currency=@Currency where CountryId=@CountryId";

            Assert.Equal(query, result);
        }
        [Fact]
        public void MsSql_delete_command()
        {
            string query = new MsSqlQueryGenerate<DeleteModel>()
                .GenerateDeleteQuery();

            string result = "delete from dbo.DeleteModel where CountryId=@CountryId";

            Assert.Equal(query, result);
        }

    }
}
