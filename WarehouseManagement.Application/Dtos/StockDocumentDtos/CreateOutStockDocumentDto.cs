namespace WarehouseManagement.Application.Dtos.StockDocumentDtos
{
    public class CreateOutStockDocumentDto: CreateInStockDocumentDto
    {
        public Guid FromWarehouseId { get; set; }
    }
}
