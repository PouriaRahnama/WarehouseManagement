namespace WarehouseManagement.Application.Dtos.StockDocumentDtos
{
    public class GetStockDocumentItemDto
    {
        public Guid StockDocumentId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
    }
}
