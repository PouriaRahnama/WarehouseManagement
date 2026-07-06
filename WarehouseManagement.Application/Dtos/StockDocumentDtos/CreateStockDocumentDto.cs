namespace WarehouseManagement.Application.Dtos.StockDocumentDtos
{
    public class CreateInStockDocumentDto
    {
        public Guid ToWarehouseId { get; set; }
        public List<CreateStockDocumentItemDto> Items { get; set; }
    }
}
