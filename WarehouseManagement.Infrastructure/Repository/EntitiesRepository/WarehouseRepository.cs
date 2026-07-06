namespace WarehouseManagement.Infrastructure.Repository.EntitiesRepository
{
    public class WarehouseRepository : Repository<Warehouse>, IWarehouseRepository
    {
        public WarehouseRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
