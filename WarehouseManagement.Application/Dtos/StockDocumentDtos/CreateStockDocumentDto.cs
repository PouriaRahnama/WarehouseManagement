namespace WarehouseManagement.Application.Dtos.StockDocumentDtos
{
    public class CreateInStockDocumentDto
    {
        public Guid ToWarehouseId { get; set; }
        public List<CreateStockDocumentItemDto> Items { get; set; }
    }
    public class CreateOutStockDocumentDto: CreateInStockDocumentDto
    {
        public Guid FromWarehouseId { get; set; }
    }
    public class CreateTransferStockDocumentDto: CreateInStockDocumentDto
    {
        public Guid FromWarehouseId { get; set; }
    }
    public class CreateStockDocumentItemDto
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
