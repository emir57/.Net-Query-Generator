# WriteParameter
Kodlar ile beraber sql cümlecikleri yazmak yorucu veya can sıkıcı syntax hatalarına sebep olabilir. Bunları önlemek için geliştirilmiş bir araçtır.<br>
<br>
Desteklenen Veri tabanları:
<ul>
<li>MsSql</li>
<li>PostgreSql</li>
</ul>
<h2>Kullanımı</h2>
İlk öncelikle tablo modeline ihtiyacımız var

 ```csharp
    public class Country
    {
        [IdColumn]
        public int CountryId { get; set; }
        public string CountryName { get; set; }
        public string Continent { get; set; }
        [IgnoreColumn]
        public string Currency { get; set; }
    }
```
<hr>
<h3>Insert</h3>
MsSql için Insert sorgusu oluşturmak

```csharp
string query = new MsSqlQueryGenerate<Country>()
        .GenerateInsertQuery();
```
```diff
+Çıktı: "insert into dbo.Country (CountryName,Continent) values (@CountryName,@Continent)"
```
PostgreSql için Insert sorgusu oluşturmak

```csharp
string query = new NpgQueryGenerate<Country>()
        .GenerateInsertQuery();
```
```diff
+Çıktı: "insert into dbo.Country (\"CountryName\",\"Continent\") values (@CountryName,@Continent)"
```

Dapper ile kullanımı

```csharp
Country country = new() { CountryName = "TURKEY", Continent = "ASIA", Currency = "TRY" };
int row = await conn.ExecuteAsync(
    query,
    country);
```
<hr>

<h3>Update</h3>
MsSql için Update sorgusu oluşturmak

```csharp
string query = new MsSqlQueryGenerate<Country>()
        .GenerateUpdateQuery();
```
```diff
+Çıktı: "update dbo.Country set CountryName=@CountryName,Continent=@Continent where CountryId=@CountryId"
```
PostgreSql için Update sorgusu oluşturmak

```csharp
string query = new NpgQueryGenerate<Country>()
        .GenerateUpdateQuery();
```
```diff
+Çıktı: "update dbo.Country set \"CountryName\"=@CountryName,\"Continent\"=@Continent where \"CountryId\"=@CountryId"
```

Dapper ile kullanımı

```csharp
Country country = new() { CountryId = 1, CountryName = "TURKEY", Continent = "ASIA", Currency = "TRY" };
int row = await conn.ExecuteAsync(
    query,
    country);
```
<hr>

<h3>Delete</h3>
MsSql için Delete sorgusu oluşturmak

```csharp
string query = new MsSqlQueryGenerate<Country>()
        .GenerateDeleteQuery();
```
```diff
+Çıktı: "delete from dbo.Country where CountryId=@CountryId"
```
PostgreSql için Delete sorgusu oluşturmak

```csharp
string query = new NpgQueryGenerate<Country>()
        .GenerateDeleteQuery();
```
```diff
+Çıktı: "delete from dbo.Country where \"CountryId\"=@CountryId"
```

Dapper ile kullanımı

```csharp
Country country = new() { CountryId = 1 };
int row = await conn.ExecuteAsync(
    query,
    country);
```

