using WarehouseManagement.Domain.Entities;
using WarehouseManagement.Infrastructure.Persistence;
using WarehouseManagement.Infrastructure.Repository.InterfacesRepository;

namespace WarehouseManagement.Infrastructure.Repository.EntitiesRepository
{
    public class WarehouseRepository : Repository<Warehouse>, IWarehouseRepository
    {
        public WarehouseRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
