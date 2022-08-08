# WriteParameter
Kodlar ile beraber sql cümlecikleri yazmak yorucu veya can sıkıcı syntax hatalarına sebep olabilir. Bunları önlemek için geliştirilmiş bir araçtır.
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
