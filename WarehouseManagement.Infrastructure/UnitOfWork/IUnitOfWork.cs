using System.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace WarehouseManagement.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync();

        Task BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted);

        Task CommitAsync();

        Task RollbackAsync();
    }
}
