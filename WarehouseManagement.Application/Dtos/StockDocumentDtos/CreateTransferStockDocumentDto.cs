namespace WarehouseManagement.Application.Dtos.StockDocumentDtos
{
    public class CreateTransferStockDocumentDto: CreateInStockDocumentDto
    {
        public Guid FromWarehouseId { get; set; }
    }
}
