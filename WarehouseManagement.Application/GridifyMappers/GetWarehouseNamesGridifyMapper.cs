namespace WarehouseManagement.Application.GridifyMappers
{
    public class GetWarehouseNamesGridifyMapper : GridifyMapper<GetWarehouseNamesDto>
    {
        public GetWarehouseNamesGridifyMapper()
        {
            AddMap("name", p => p.Name);
            AddMap("warehoseId", p => p.WarehouseId);
        }
    }
}
