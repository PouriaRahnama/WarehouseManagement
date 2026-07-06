namespace WarehouseManagement.Application.Interfaces
{
    public interface IStockBalanceService
    {
        Task IncreaseStockBalanceAsync(ICollection<StockDocumentItem> stockDocumentItems, Guid toWarehouseId);
        Task DecreaseStockBalanceAsync(ICollection<StockDocumentItem> stockDocumentItems, Guid fromWarehouseId);
        Task TransferStockBalanceAsync(ICollection<StockDocumentItem> stockDocumentItems, Guid toWarehouseId, Guid fromWarehouseId);
    }
}
