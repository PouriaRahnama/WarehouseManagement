namespace WarehouseManagement.Application.Dtos.StockDocumentDtos
{
    public class CreateStockDocumentItemDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
