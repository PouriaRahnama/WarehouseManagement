namespace WarehouseManagement.Application.GridifyMappers
{
    public class GetProductNamesGridifyMapper : GridifyMapper<GetProductNamesDto>
    {
        public GetProductNamesGridifyMapper()
        {
            AddMap("Name", p => p.Name);
            AddMap("ProductId", p => p.ProductId);
        }
    }


}
