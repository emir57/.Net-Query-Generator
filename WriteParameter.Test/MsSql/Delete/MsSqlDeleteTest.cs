using WriteParameter.MsSqlWriter;
using WriteParameter.Test.Entities.Delete;

namespace WriteParameter.Test.MsSql.Delete
{
    public class MsSqlDeleteTest
    {
        public MsSqlDeleteTest()
        {

        }
        [Fact]
        public void MsSql_delete()
        {
            string query = new MsSqlQueryGenerate<DeleteModel>()
                .GenerateDeleteQuery();

            string result = "delete from dbo.DeleteModel where CountryId=@CountryId";

            Assert.Equal(query, result);
        }
    }
}
