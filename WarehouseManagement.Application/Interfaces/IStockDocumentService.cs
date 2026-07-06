using WarehouseManagement.Application.Dtos.StockDocumentDtos;

namespace WarehouseManagement.Application.Interfaces
{
    public interface IStockDocumentService
    {
        Task<Guid> CreateInStockDocumentAsync(CreateInStockDocumentDto createInStockDocumentDto);
        Task<Guid> CreateOutStockDocumentAsync(CreateOutStockDocumentDto createOutStockDocumentDto);
        Task<Guid> CreateTransferStockDocumentAsync(CreateTransferStockDocumentDto createTransferStockDocumentDto);

       Task<bool> PostAsync(Guid stockDocumentId);
    }
}
