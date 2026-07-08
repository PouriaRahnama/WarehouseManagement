using Microsoft.EntityFrameworkCore;
using WarehouseManagement.Infrastructure.Common;
using WarehouseManagement.Infrastructure.MapConfig;
using WarehouseManagement.Infrastructure.Persistence;

namespace WarehouseManagement.Test.ProductServiceTests
{
    public class TestApplicationDbContext : SqlServerApplicationDbContext
    {
        public TestApplicationDbContext(
            DbContextOptions<SqlServerApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserConfiguration).Assembly);
            modelBuilder.OnCreated();
            modelBuilder.OnModified();
            modelBuilder.OnDeleted();

        }
    }
}
