namespace WarehouseManagement.Application.GridifyMappers
{
    public class StockDocumentsGridifyMapper : GridifyMapper<GetAllStockDocumentsDto>
    {
        public StockDocumentsGridifyMapper()
        {
            AddMap("Name", p => p.Status);
            AddMap("ProductId", p => p.Type);
            AddMap("Code", p => p.Number);
        }
    }

}
