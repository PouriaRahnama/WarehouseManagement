namespace WarehouseManagement.Application.Dtos.ProductDtos
{
    public class GetAllStockDocumentsDto
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public Guid? FromWarehouseId { get; set; }
        public Guid? ToWarehouseId { get; set; }
        public DateTime? CreatedDateTime { get; set; }

        public List<GetStockDocumentItemDto> StockDocumentItemsDto { get; set; } = new();

    }
}
