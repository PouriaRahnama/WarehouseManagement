namespace WarehouseManagement.Application.GridifyMappers
{
    public class GetProductNamesGridifyMapper : GridifyMapper<GetProductNamesDto>
    {
        public GetProductNamesGridifyMapper()
        {
            AddMap("name", p => p.Name);
            AddMap("productId", p => p.ProductId);
        }
    }


}
