namespace WarehouseManagement.Application.Dtos.StockDocumentDtos
{
    public class CreateOutStockDocumentDto
    {
        public Guid FromWarehouseId { get; set; }
        public List<CreateStockDocumentItemDto> Items { get; set; }
    }
}
