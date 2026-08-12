namespace WarehouseManagement.Application.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public int? MinimumStock { get; set; }
        public UnitOfMeasure UnitOfMeasure { get; set; }

        public IFormFile? Image { get; set; }
    }
}
