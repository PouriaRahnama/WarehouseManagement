namespace WarehouseManagement.Domain.Entities;

/// <summary>
/// سند انبار
/// </summary>
public class StockDocument : BaseEntity
{
    public StockDocument()
    {
        StockDocumentItems = new List<StockDocumentItem>();
    }

    public string Number { get; set; }
    public StockDocumentType Type { get; set; }
    public StockDocumentStatus Status { get; set; }
    public Guid? FromWarehouseId { get; set; }
    public Guid? ToWarehouseId { get; set; }

    public ICollection<StockDocumentItem> StockDocumentItems { get; set; }
    public Warehouse? FromWarehouse { get; set; }
    public Warehouse? ToWarehouse { get; set; }
}

