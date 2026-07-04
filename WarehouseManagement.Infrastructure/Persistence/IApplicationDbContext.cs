using WarehouseManagement.Domain.Entities;

namespace WarehouseManagement.Infrastructure.Persistence;

public interface IApplicationDbContext : IDisposable
{
    #region Structure

    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    int SaveChanges();

    EntityEntry<TEntity> Entry<TEntity>(TEntity entity)
        where TEntity : class;

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

    #endregion
    DbSet<Product> Products { get; set; }
    DbSet<User> Users { get; set; }
    DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
}
