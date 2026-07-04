using WarehouseManagement.Domain.Entities;
using WarehouseManagement.Infrastructure.Persistence;
using WarehouseManagement.Infrastructure.Repository.InterfacesRepository;

namespace WarehouseManagement.Infrastructure.Repository.EntitiesRepository
{
    public class StockDocumentRepository : Repository<StockDocument>, IStockDocumentRepository
    {
        public StockDocumentRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
