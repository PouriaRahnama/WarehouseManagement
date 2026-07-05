using WarehouseManagement.Domain.Common;

namespace WarehouseManagement.Domain.Entities
{
    public class StockBalance: ICreatedEntity, IModifiedEntity, ISoftDeleted
    {
        public StockBalance()
        {

        }

        public Guid WarehouseId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public byte[] RowVersion { get; set; }

        public Product Product { get; set; }
        public Warehouse Warehouse { get; set; }
    }
}
