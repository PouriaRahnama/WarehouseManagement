namespace WarehouseManagement.Application.Dtos.ProductDtos
{
    public class GetProductDetailsDto
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Price { get; set; }
        public DateTime? CreatedDateTime { get; set; }
        public int UnitOfMeasure { get; set; }

        public int MinimumStock { get; set; }
        public bool IsActive { get; set; }
        public string? ImagePath { get; set; }
    }
}
