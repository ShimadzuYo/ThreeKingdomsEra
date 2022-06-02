using Core;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EntityFramework;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Officer> Officers { get; set; }




    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
// Create migration:
// dotnet-ef migrations add InitialCreate -s .\ThreeKingdomsEraApp\ThreeKingdomsEraApp.csproj -p .\Infrastructure\Infrastructure.csproj
// Remove unapplied migration
// dotnet ef migrations remove

// rollback to migration
// dotnet ef database update InitialCreate -p .\Infrastructure\Infrastructure.csproj -s .\ThreeKingdomsEraApp\ThreeKingdomsEraApp.csproj