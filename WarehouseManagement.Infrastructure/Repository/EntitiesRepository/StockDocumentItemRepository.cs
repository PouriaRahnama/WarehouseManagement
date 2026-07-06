namespace WarehouseManagement.Infrastructure.Repository.EntitiesRepository
{
    public class StockDocumentItemRepository : Repository<StockDocumentItem>, IStockDocumentItemRepository
    {
        public StockDocumentItemRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
