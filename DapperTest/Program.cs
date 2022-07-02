using Dapper;
using DapperTest.Entities;
using System.Data.SqlClient;
using WriteParameter;

using (var conn = new SqlConnection("Server=DESKTOP-HVLQH67\\SQLEXPRESS;Database=F1Project;integrated security=true"))
{
    if (conn.State != System.Data.ConnectionState.Open)
        await conn.OpenAsync();
    var entity = new Country() { CountryId = 14, CountryName = "Türkiye 4", CountryImageUrl = "turkey.jpg" };
    int row = await conn.ExecuteAsync(
        $"insert into countries {entity.InsertIntoWriteParameters()}",
        entity);
    Console.WriteLine(row);
    var countries = await conn.QueryAsync<Country>("select * from countries where countryImageUrl like '%g'");
    foreach (var country in countries)
    {
        Console.WriteLine($"{country.CountryId} {country.CountryName} {country.CountryImageUrl}");
    }
    Console.WriteLine("-------");
    var getCountry = await conn.QueryFirstOrDefaultAsync<Country>($"select * from countries where CountryId>{5}");
    Console.WriteLine($"{getCountry?.CountryId} {getCountry?.CountryName} {getCountry?.CountryImageUrl}");
    Console.WriteLine("-------");
    var driverTeams = await conn.QueryAsync<DriverTeam>("select d.DriverName,t.Name as TeamName,d.DriverSurname from drivers d, teams t where d.TeamId = t.TeamId order by TeamName asc,DriverName asc");
    foreach (var driverTeam in driverTeams)
        Console.WriteLine($"{driverTeam.DriverName} {driverTeam.DriverSurname} -> {driverTeam.TeamName}");
    await conn.CloseAsync();
}