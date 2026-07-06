namespace WarehouseManagement.Application.GridifyMappers
{
    public class WarehouseStockReportsGridifyMapper : GridifyMapper<WarehouseStockReportsDto>
    {
        public WarehouseStockReportsGridifyMapper()
        {
            AddMap("WarehouseName", x => x.WarehouseName);
        }
    }
}
