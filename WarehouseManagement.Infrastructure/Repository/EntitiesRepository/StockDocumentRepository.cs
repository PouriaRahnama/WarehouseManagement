namespace WarehouseManagement.Infrastructure.Repository.EntitiesRepository
{
    public class StockDocumentRepository : Repository<StockDocument>, IStockDocumentRepository
    {
        public StockDocumentRepository(IApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
