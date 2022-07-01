using Dapper;
using DapperTest.Entities;
using System.Data.SqlClient;

using (var conn = new SqlConnection("Server=DESKTOP-HVLQH67\\SQLEXPRESS;Database=F1Project;integrated security=true"))
{
    if (conn.State != System.Data.ConnectionState.Open)
        await conn.OpenAsync();
    conn.Execute(
        "insert into drivers(drivername,driversurname,drivernumber)values(@driverName,@driverSurname,@driverNumber)",
        new Driver() { DriverName = "Emir", DriverSurname = "Gürbüz", DriverNumber = 57 });
}