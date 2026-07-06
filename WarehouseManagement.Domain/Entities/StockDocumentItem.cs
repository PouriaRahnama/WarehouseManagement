namespace WarehouseManagement.Domain.Entities;

/// <summary>
/// اقلام سند 
/// </summary>
public class StockDocumentItem : ICreatedEntity, IModifiedEntity, ISoftDeleted
{
    public StockDocumentItem()
    {

    }
    public Guid StockDocumentId { get; set; }
    public Guid ProductId { get; set; }
    public int Quantity { get; set; }

    public Product Product { get; set; }
    public StockDocument StockDocument { get; set; }
}

