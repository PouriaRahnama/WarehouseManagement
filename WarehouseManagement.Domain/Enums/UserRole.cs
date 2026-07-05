namespace WarehouseManagement.Domain.Enums;

public enum UserRole
{
    [Display(Name = "مدیر سیستم")] Admin = 10,
    [Display(Name = "اپراتور")] Operator = 20,
    [Display(Name = "کاربر عادی‌")] Viewer = 30
}

