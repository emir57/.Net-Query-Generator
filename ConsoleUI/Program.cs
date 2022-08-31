using Dapper;
using DapperTest.Entities;
using Npgsql;
using System.Data.SqlClient;
using WriteParameter;
using WriteParameter.Extensions;
using WriteParameter.MsSqlWriter;
using WriteParameter.NpgWriter;

using (var conn = new NpgsqlConnection("User ID=postgres;Password=123;Host=localhost;Port=5432;Database=PATIKA;"))
{
    string query = new MsSqlQueryGenerate<Country>()
        .GenerateDeleteQuery();
    //.SelectSchema("dbo")
    //.SelectTable("country")
    //.SetLimit(2).SetOffset(2)
    //.GenerateGetAllQuery();

    #region Add or Update
    //if (conn.State != System.Data.ConnectionState.Open)
    //    await conn.OpenAsync();
    var entity = new Country() { CountryId = 7, CountryName = "TURKEY 3", Continent = "ASIA", Currency = "TRY" };
    string query2 = entity.MsSqlAddQuery();
    //int row = await conn.ExecuteAsync(
    //    query,
    //    entity);
    //Console.WriteLine(row);
    #endregion

    #region GetAll
    var countries = await conn.QueryAsync<Country>(query);
    foreach (var country in countries)
    {
        Console.WriteLine($"{country.CountryId} {country.CountryName} {country.Continent}");
    }
    #endregion


    #region FirstOrDefault
    //var entity = new Country { CountryId = 1 };
    //var getCountry = await conn.QueryFirstOrDefaultAsync<Country>(query, entity);
    //Console.WriteLine($"{getCountry?.CountryId} {getCountry?.CountryName} {getCountry?.CountryImageUrl}");
    //Console.WriteLine("-------");
    //var driverTeams = await conn.QueryAsync<DriverTeam>("select d.DriverName,t.Name as TeamName,d.DriverSurname from drivers d, teams t where d.TeamId = t.TeamId order by TeamName asc,DriverName asc");
    //foreach (var driverTeam in driverTeams)
    //    Console.WriteLine($"{driverTeam.DriverName} {driverTeam.DriverSurname} -> {driverTeam.TeamName}");

    #endregion
    await conn.CloseAsync();
}