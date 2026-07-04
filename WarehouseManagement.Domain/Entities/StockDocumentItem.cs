using WarehouseManagement.Domain.Common;

namespace WarehouseManagement.Domain.Entities
{
    public class StockDocumentItem : ICreatedEntity, IModifiedEntity, ISoftDeleted
    {
        public Guid StockDocumentId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }

        public Product Product { get; set; }
        public StockDocument StockDocument { get; set; }
    }
}
