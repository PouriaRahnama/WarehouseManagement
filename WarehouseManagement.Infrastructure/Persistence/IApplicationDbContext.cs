using Microsoft.EntityFrameworkCore.Infrastructure;
using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.Infrastructure.Persistence;

public interface IApplicationDbContext : IDisposable
{
    #region Structure

    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    int SaveChanges();
    DatabaseFacade Database { get; }
    EntityEntry<TEntity> Entry<TEntity>(TEntity entity)
        where TEntity : class;

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    #endregion
    DbSet<Product> Products { get; set; }
    DbSet<StockBalance> StockBalances { get; set; }
    DbSet<StockDocument> StockDocuments { get; set; }
    DbSet<StockDocumentItem> StockDocumentItems { get; set; }
    DbSet<Warehouse> Warehouses { get; set; }
    DbSet<User> Users { get; set; }
    DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
}
