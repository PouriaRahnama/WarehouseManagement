using WarehouseManagement.Domain.Entities;
using WarehouseManagement.Infrastructure.Persistence;
using WarehouseManagement.Infrastructure.Repository.InterfacesRepository;

namespace WarehouseManagement.Infrastructure.Repository.EntitiesRepository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
