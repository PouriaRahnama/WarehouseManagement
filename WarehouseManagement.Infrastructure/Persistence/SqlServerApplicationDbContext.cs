using WarehouseManagement.Domain.Entities;
using WarehouseManagement.Infrastructure.Common;
using WarehouseManagement.Infrastructure.MapConfig;

namespace WarehouseManagement.Infrastructure.Persistence;

public class SqlServerApplicationDbContext : DbContext, IApplicationDbContext
{
    public SqlServerApplicationDbContext(DbContextOptions<SqlServerApplicationDbContext> options) : base(options)
    {
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("WarehouseManagement");
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
        modelBuilder.OnCreated();
        modelBuilder.OnModified();
        modelBuilder.OnDeleted();
        modelBuilder.Entity<User>().HasData(SeedData.DefaultUsers);
    }

    // Implementation DbSet
    public DbSet<Product> Products { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
}
