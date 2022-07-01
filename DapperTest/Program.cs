using Dapper;
using DapperTest.Entities;
using System.Data.SqlClient;

using (var conn = new SqlConnection("Server=DESKTOP-HVLQH67\\SQLEXPRESS;Database=F1Project;integrated security=true"))
{
    if (conn.State != System.Data.ConnectionState.Open)
        await conn.OpenAsync();
    int row = conn.Execute(
        "insert into countries(countryName,countryImageUrl)values(@countryName,@countryImageUrl)",
        new Country() { CountryName = "Türkiye", CountryImageUrl = "turkey.jpg" });
    Console.WriteLine(row);
    await conn.CloseAsync();
}