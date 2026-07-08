namespace WarehouseManagement.Application.GridifyMappers
{
    public class StockDocumentsGridifyMapper : GridifyMapper<GetAllStockDocumentsDto>
    {
        public StockDocumentsGridifyMapper()
        {
            AddMap("number", p => p.Number);
            AddMap("status", p => p.Status);
            AddMap("type", p => p.Type);
        }
    }

}
