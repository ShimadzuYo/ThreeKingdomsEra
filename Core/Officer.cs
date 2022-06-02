namespace Core;

public class Officer
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public int Birth { get; set; }
    public int Death { get; set; }
    public string Kingdom { get; set; }
    public string Bio { get; set; }
}
// dotnet-ef migrations add InitialCreate -s .\ThreeKingdomsEraApp\ThreeKingdomsEraApp.csproj -p .\Infrastructure\Infrastructure.csproj