# WriteParameter
Query Generator Tool<br>
<br>
Supported Databases:
<ul>
<li>MsSql</li>
<li>PostgreSql</li>
</ul>
<br>
Features
<ul>
 <li>Finding Automatic Id Column</li>
</ul>

<h3>Attributes</h3>
<h5>[TableName("")]<h5>
For Table Name Column

 ```csharp
   [TableName("Countries")]
    public sealed class Country
    {
        .
        .
        .
    }
```

<h5>[IdColumn]<h5>
For Select Id Column

 ```csharp
   [IdColumn]
   public int CountryId { get; set; }
```
<h5>[IgnoreColumn]<h5>
For Ignore Column

 ```csharp
   [IgnoreColumn]
   public string Currency { get; set; }
```
<h5>[ColumnName("")]<h5>
For Different Column Name

 ```csharp
   [ColumnName("Name")]
   public string CountryName { get; set; }
```

<hr>

<h2>Using</h2>
Example Table Model

 ```csharp
    [TableName("Countries")]
public sealed class Country
{
    [IdColumn]
    public int CountryId { get; set; }
    [ColumnName("Name")]
    public string CountryName { get; set; }
    public string Continent { get; set; }
    public string Currency { get; set; }
    [IgnoreColumn]
    public string CountryNameAndContinent
        => String.Format("{0} - {1}", CountryName, Continent);
}
```
<hr>


<h3>Insert</h3>
Insert Query For MsSql

```csharp
string query = new MsSqlQueryGenerate<Country>()
        .GenerateInsertQuery();
```
```diff
+Output: "insert into dbo.Country (CountryName,Continent) values (@CountryName,@Continent)"
```
Insert Query For PostgreSql

```csharp
string query = new NpgQueryGenerate<Country>()
        .GenerateInsertQuery();
```
```diff
+Output: "insert into dbo.Country (\"CountryName\",\"Continent\") values (@CountryName,@Continent)"
```

Using With Dapper

```csharp
Country country = new() { CountryName = "TURKEY", Continent = "ASIA", Currency = "TRY" };
int row = await conn.ExecuteAsync(
    query,
    country);
```
<hr>

<h3>Update</h3>
Update Query For MsSql

```csharp
string query = new MsSqlQueryGenerate<Country>()
        .GenerateUpdateQuery();
```
```diff
+Output: "update dbo.Country set CountryName=@CountryName,Continent=@Continent where CountryId=@CountryId"
```
Update Query For PostgreSql

```csharp
string query = new NpgQueryGenerate<Country>()
        .GenerateUpdateQuery();
```
```diff
+Output: "update dbo.Country set \"CountryName\"=@CountryName,\"Continent\"=@Continent where \"CountryId\"=@CountryId"
```

Using With Dapper

```csharp
Country country = new() { CountryId = 1, CountryName = "TURKEY", Continent = "ASIA", Currency = "TRY" };
int row = await conn.ExecuteAsync(
    query,
    country);
```
<hr>

<h3>Delete</h3>
Delete Query For MsSql

```csharp
string query = new MsSqlQueryGenerate<Country>()
        .GenerateDeleteQuery();
```
```diff
+Output: "delete from dbo.Country where CountryId=@CountryId"
```
Delete Query For PostgreSql

```csharp
string query = new NpgQueryGenerate<Country>()
        .GenerateDeleteQuery();
```
```diff
+Output: "delete from dbo.Country where \"CountryId\"=@CountryId"
```

Using With Dapper

```csharp
Country country = new() { CountryId = 1 };
int row = await conn.ExecuteAsync(
    query,
    country);
```
<hr>

<h3>Get All</h3>
Select Query For MsSql
 
```csharp
string query = new MsSqlQueryGenerate<Country>()
        .GenerateGetAllQuery();
```
```diff
+Output: "select CountryId as CountryId,CountryName as CountryName,Continent as Continent,Currency as Currency from dbo.Country order by CountryId"
```
Select Query For PostgreSql

```csharp
string query = new NpgQueryGenerate<Country>()
        .GenerateGetAllQuery();
```
```diff
+Output: "select \"CountryId\" as CountryId,\"CountryName\" as CountryName,\"Continent\" as Continent,\"Currency\" as Currency from dbo.BaseModel order by \"CountryId\""
```

Using With Dapper

```csharp
var result = await conn.QueryAsync<Country>(query);
```
<hr>
<h3>Get By Id</h3>
Select Where Query For MsSql

```csharp
string query = new MsSqlQueryGenerate<Country>()
        .GenerateGetByIdQuery(1);
```
```diff
+Output: "select CountryId as CountryId,CountryName as CountryName,Continent as Continent,Currency as Currency from dbo.Country where CountryId=1"
```
Select Where Query For PostgreSql

```csharp
string query = new NpgQueryGenerate<Country>()
        .GenerateGetByIdQuery(1);
```
```diff
+Output: "select \"CountryId\" as CountryId,\"CountryName\" as CountryName,\"Continent\" as Continent,\"Currency\" as Currency from dbo.Country where \"CountryId\"=1"
```

Using With Dapper

```csharp
var result = await conn.QuerySingleOrDefaultAsync<Country>(query);
```
<hr>
