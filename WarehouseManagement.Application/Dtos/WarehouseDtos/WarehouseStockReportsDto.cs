namespace WarehouseManagement.Application.Dtos.WarehouseDtos
{
    public class WarehouseStockReportsDto
    {
        public Guid WarehouseId { get; set; }
        public string WarehouseName { get; set; }
        public DateTime? CreatedDateTime { get; set; }

        public IEnumerable<WarehouseProductDto> Products { get; set; } = Enumerable.Empty<WarehouseProductDto>();

    }
    public class WarehouseProductDto
    {
        public Guid ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCode { get; set; }

        public int Quantity { get; set; }
        public int MinimumStock { get; set; }

        public bool IsBelowMinimum => Quantity < MinimumStock;
    }
}
