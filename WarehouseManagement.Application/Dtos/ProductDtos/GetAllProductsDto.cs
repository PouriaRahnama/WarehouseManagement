namespace WarehouseManagement.Application.Dtos.ProductDtos
{
    public class GetAllProductsDto
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime? CreatedDateTime { get; set; }
    }

    public class GetProductsDto
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
    }
}
