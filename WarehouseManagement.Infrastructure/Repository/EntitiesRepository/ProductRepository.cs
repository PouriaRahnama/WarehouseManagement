namespace WarehouseManagement.Infrastructure.Repository.EntitiesRepository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
