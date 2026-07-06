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
    public DbSet<StockBalance> StockBalances { get; set; }
    public DbSet<StockDocument> StockDocuments { get; set; }
    public DbSet<StockDocumentItem> StockDocumentItems { get; set; }
    public DbSet<Warehouse> Warehouses { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
}
