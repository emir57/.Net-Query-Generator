using Dapper;
using DapperTest.Entities;
using System.Data.SqlClient;

using (var conn = new SqlConnection("Server=DESKTOP-HVLQH67\\SQLEXPRESS;Database=F1Project;integrated security=true"))
{
    if (conn.State != System.Data.ConnectionState.Open)
        await conn.OpenAsync();
    int row = conn.Execute(
        "update countries set countryName=@countryName,countryImageUrl=@countryImageUrl where countryId=@countryId",
        new Country() { CountryId = 14, CountryName = "Türkiye 2", CountryImageUrl = "turkey.jpg" });
    Console.WriteLine(row);
    var countries = await conn.QueryAsync<Country>("select * from countries where countryImageUrl like '%g'");
    foreach (var country in countries)
    {
        Console.WriteLine($"{country.CountryId} {country.CountryName} {country.CountryImageUrl}");
    }
    await conn.CloseAsync();
}