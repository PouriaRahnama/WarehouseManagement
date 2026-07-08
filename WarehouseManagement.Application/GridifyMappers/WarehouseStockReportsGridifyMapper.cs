namespace WarehouseManagement.Application.GridifyMappers
{
    public class WarehouseStockReportsGridifyMapper : GridifyMapper<WarehouseStockReportsDto>
    {
        public WarehouseStockReportsGridifyMapper()
        {
            AddMap("warehouseName", x => x.WarehouseName);
        }
    }
}
