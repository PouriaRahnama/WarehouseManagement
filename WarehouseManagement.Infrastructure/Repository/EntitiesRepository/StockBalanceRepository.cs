using WarehouseManagement.Domain.Entities;
using WarehouseManagement.Infrastructure.Persistence;
using WarehouseManagement.Infrastructure.Repository.InterfacesRepository;

namespace WarehouseManagement.Infrastructure.Repository.EntitiesRepository
{
    public class StockBalanceRepository : Repository<StockBalance>, IStockBalanceRepository
    {
        public StockBalanceRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
