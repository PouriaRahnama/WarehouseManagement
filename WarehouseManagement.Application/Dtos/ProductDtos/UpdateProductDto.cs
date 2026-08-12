namespace WarehouseManagement.Application.Dtos.ProductDtos
{
    public class UpdateProductDto : CreateProductDto
    {
        public Guid ProductId { get; set; }

        public bool IsActive { get; set; } = false;
    }
}
