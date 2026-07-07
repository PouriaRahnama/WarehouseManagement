namespace WarehouseManagement.Application.GridifyMappers
{
    public class GetWarehouseNamesGridifyMapper : GridifyMapper<GetWarehouseNamesDto>
    {
        public GetWarehouseNamesGridifyMapper()
        {
            AddMap("Name", p => p.Name);
            AddMap("WarehoseId", p => p.WarehouseId);
        }
    }
}
