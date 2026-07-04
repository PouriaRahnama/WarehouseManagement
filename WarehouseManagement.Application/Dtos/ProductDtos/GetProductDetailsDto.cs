namespace WarehouseManagement.Application.Dtos.ProductDtos
{
    public class GetProductDetailsDto
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime? CreatedDateTime { get; set; }
    }
}
