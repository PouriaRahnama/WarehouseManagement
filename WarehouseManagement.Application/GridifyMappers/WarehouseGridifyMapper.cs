namespace WarehouseManagement.Application.GridifyMappers
{
    public class WarehouseGridifyMapper : GridifyMapper<GetAllWarehousesDto>
    {
        public WarehouseGridifyMapper()
        {
            AddMap("code", p => p.Code);
            AddMap("name", p => p.Name);
            AddMap("warehouseId", p => p.WarehouseId);
            AddMap("location", p => p.Location);
        }
    }
}
