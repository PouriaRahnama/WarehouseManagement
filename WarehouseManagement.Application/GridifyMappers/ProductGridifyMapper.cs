namespace WarehouseManagement.Application.GridifyMappers
{
    public class ProductGridifyMapper : GridifyMapper<GetAllProductsDto>
    {
        public ProductGridifyMapper()
        {
            AddMap("name", p => p.Name);
            AddMap("productId", p => p.ProductId);
            AddMap("code", p => p.Code);
        }
    }

}
