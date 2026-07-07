namespace WarehouseManagement.Application.Interfaces
{
    public interface IStockDocumentService
    {
        Task<SearchQueryResponse<GetAllStockDocumentsDto>> GetAllAsync(FilterStockDocumentsDto QueryParams);
        Task<SearchQueryResponse<ProductLedgerItemReportDto>> GetProductLedgerReportAsync(FilterProductLedgerDto queryParams);
        Task<Guid> CreateInStockDocumentAsync(CreateInStockDocumentDto createInStockDocumentDto);
        Task<Guid> CreateOutStockDocumentAsync(CreateOutStockDocumentDto createOutStockDocumentDto);
        Task<Guid> CreateTransferStockDocumentAsync(CreateTransferStockDocumentDto createTransferStockDocumentDto);
        Task<bool> PostAsync(StockDocumentIdDto stockDocumentIdDto);
    }
}
