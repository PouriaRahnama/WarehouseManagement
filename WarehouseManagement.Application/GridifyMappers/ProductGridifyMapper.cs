namespace WarehouseManagement.Application.GridifyMappers
{
    public class ProductGridifyMapper : GridifyMapper<GetAllProductsDto>
    {
        public ProductGridifyMapper()
        {
            AddMap("Name", p => p.Name);
            AddMap("ProductId", p => p.ProductId);
            AddMap("Code", p => p.Code);
        }
    }
    public class GetProductNamesGridifyMapper : GridifyMapper<GetProductNamesDto>
    {
        public GetProductNamesGridifyMapper()
        {
            AddMap("Name", p => p.Name);
            AddMap("ProductId", p => p.ProductId);
        }
    }
}
