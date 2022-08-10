using WriteParameter.MsSqlWriter;
using WriteParameter.Test.Entities.Update;

namespace WriteParameter.Test.MsSql.Update
{
    public class MsSqlUpdateTest
    {
        public MsSqlUpdateTest()
        {

        }
        [Fact]
        public void MsSql_update()
        {
            string query = new MsSqlQueryGenerate<UpdateModel>()
                .GenerateUpdateQuery();

            string result = "update dbo.UpdateModel set CountryName=@CountryName,Continent=@Continent,Currency=@Currency where CountryId=@CountryId";

            Assert.Equal(query, result);
        }
    }
}
