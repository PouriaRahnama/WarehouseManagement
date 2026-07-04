using WarehouseManagement.Domain.Common;

namespace WarehouseManagement.Domain.Entities
{
    public class Warehouse : BaseEntity
    {
        public Warehouse()
        {
            StockBalances = new List<StockBalance>();
            IncomingDocuments = new List<StockDocument>();
            OutgoingDocuments = new List<StockDocument>();
        }

        public string Code { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }

        public ICollection<StockBalance> StockBalances { get; set; }
        public ICollection<StockDocument> IncomingDocuments { get; set; }
        public ICollection<StockDocument> OutgoingDocuments { get; set; }
    }
}
