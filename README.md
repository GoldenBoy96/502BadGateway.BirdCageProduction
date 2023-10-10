# 502BadGateway.BirdCaseProduction

## Setup

In BirdCageProduction.Web folder, create `appsettings.json` with your database's username and password:

```
{
  "ConnectionStrings": {
    "BirdCageProduction": "Server=(local);uid=your-username;pwd=your-password;database=Bird_Cage_Production;TrustServerCertificate=true"
  }
}
```

Make sure `BirdCageProduction.Web.csproj` has the following lines:

```
<ItemGroup>
  <None Update="appsettings.json">
    <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
  </None>
</ItemGroup>
```
