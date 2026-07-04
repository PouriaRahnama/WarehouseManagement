using WarehouseManagement.Domain.Common;

namespace WarehouseManagement.Domain.Entities;

/// <summary>
/// محصول
/// </summary>
public class Product : BaseEntity
{
    public Product()
    {
        StockBalances = new List<StockBalance>();
    }

    public string Name { get; set; } 
    public string Code { get; set; }
    public int MinimumStock { get; set; } = 0;
    public UnitOfMeasure UnitOfMeasure { get; set; }
    public bool IsActive { get; set; } = false;

    public ICollection<StockBalance> StockBalances { get; set; }
    public ICollection<StockDocumentItem> StockDocumentItems { get; set; }

}
