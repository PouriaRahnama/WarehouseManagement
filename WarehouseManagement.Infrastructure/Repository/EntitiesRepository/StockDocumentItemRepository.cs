using WarehouseManagement.Domain.Entities;
using WarehouseManagement.Infrastructure.Persistence;
using WarehouseManagement.Infrastructure.Repository.InterfacesRepository;

namespace WarehouseManagement.Infrastructure.Repository.EntitiesRepository
{
    public class StockDocumentItemRepository : Repository<StockDocumentItem>, IStockDocumentItemRepository
    {
        public StockDocumentItemRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
