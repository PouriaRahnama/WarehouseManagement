using WarehouseManagement.Application.Dtos.StockDocumentDtos;

namespace WarehouseManagement.Application.Interfaces
{
    public interface IStockDocumentService
    {
        Task<Guid> CreateEntryAsync(CreateInStockDocumentDto createInStockDocumentDto);
        Task<Guid> CreateExitAsync(CreateOutStockDocumentDto createOutStockDocumentDto);
        Task<Guid> CreateTransferAsync(CreateTransferStockDocumentDto createTransferStockDocumentDto);

       Task<bool> PostAsync(Guid stockDocumentId);
    }
}
