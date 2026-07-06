namespace WarehouseManagement.Domain.Enums;

public enum StockDocumentStatus
{
    [Display(Name = "در انتظار ثبت")]
    Wait = 10,

    [Display(Name = "ثبت شده")]
    Posted = 20,
}

