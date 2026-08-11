namespace WarehouseManagement.Domain.Entities;

/// <summary>
/// محصول
/// </summary>
public class Product : BaseEntity
{
    public Product()
    {
        StockBalances = new List<StockBalance>();
        StockDocumentItems = new List<StockDocumentItem>();
    }

    public string Name { get; set; } 
    public string Code { get; set; }
    public int MinimumStock { get; set; } = 0;
    public UnitOfMeasure UnitOfMeasure { get; set; }
    public bool IsActive { get; set; } = false;
    public string? ImagePath { get; set; }

    public ICollection<StockBalance> StockBalances { get; set; }
    public ICollection<StockDocumentItem> StockDocumentItems { get; set; }

}
