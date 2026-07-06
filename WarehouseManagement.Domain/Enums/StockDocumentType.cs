namespace WarehouseManagement.Domain.Enums;

public enum StockDocumentType
{
    [Display(Name = "سند ورود کالا")]
    In = 10,

    [Display(Name = "سند خروج کالا")]
    Out = 20,

    [Display(Name = "سند انتقال بین انبارها")]
    Transfer = 30
}

