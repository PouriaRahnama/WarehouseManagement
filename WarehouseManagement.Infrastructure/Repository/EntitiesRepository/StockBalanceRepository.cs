namespace WarehouseManagement.Infrastructure.Repository.EntitiesRepository
{
    public class StockBalanceRepository : Repository<StockBalance>, IStockBalanceRepository
    {
        public StockBalanceRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
