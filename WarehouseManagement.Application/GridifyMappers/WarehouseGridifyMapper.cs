namespace WarehouseManagement.Application.GridifyMappers
{
    public class WarehouseGridifyMapper : GridifyMapper<GetAllWarehousesDto>
    {
        public WarehouseGridifyMapper()
        {
            AddMap("Name", p => p.Name);
            AddMap("WarehoseId", p => p.WarehouseId);
            AddMap("Location", p => p.Location);
        }
    }
    public class GetWarehouseNamesGridifyMapper : GridifyMapper<GetWarehouseNamesDto>
    {
        public GetWarehouseNamesGridifyMapper()
        {
            AddMap("Name", p => p.Name);
            AddMap("WarehoseId", p => p.WarehouseId);
        }
    }
}
