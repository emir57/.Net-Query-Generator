using Dapper;
using DapperTest.Entities;
using System.Data.SqlClient;
using WriteParameter;

using (var conn = new SqlConnection("Server=DESKTOP-HVLQH67\\SQLEXPRESS;Database=F1Project;integrated security=true"))
{
    string query = new QueryGenerate<Country>()
        .SelectTable("countries")
        .GenerateGetByIdQuery();
    if (conn.State != System.Data.ConnectionState.Open)
        await conn.OpenAsync();
    var entity = new Country() { CountryId = 13, CountryName = "Türkiye 3", CountryImageUrl = "turkey.jpg" };
    //int row = await conn.ExecuteAsync(
    //    query,
    //    entity);
    //Console.WriteLine(row);
    //var countries = await conn.QueryAsync<Country>(query);
    //foreach (var country in countries)
    //{
    //    Console.WriteLine($"{country.CountryId} {country.CountryName} {country.CountryImageUrl}");
    //}
    Console.WriteLine("-------");
    var getCountry = await conn.QueryFirstOrDefaultAsync<Country>(query,entity);
    Console.WriteLine($"{getCountry?.CountryId} {getCountry?.CountryName} {getCountry?.CountryImageUrl}");
    Console.WriteLine("-------");
    var driverTeams = await conn.QueryAsync<DriverTeam>("select d.DriverName,t.Name as TeamName,d.DriverSurname from drivers d, teams t where d.TeamId = t.TeamId order by TeamName asc,DriverName asc");
    foreach (var driverTeam in driverTeams)
        Console.WriteLine($"{driverTeam.DriverName} {driverTeam.DriverSurname} -> {driverTeam.TeamName}");
    await conn.CloseAsync();
}