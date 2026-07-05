namespace WarehouseManagement.Domain.Enums;

public enum UnitOfMeasure
{
    [Display(Name = "عدد")]
    Piece = 10,
    [Display(Name = "بسته")]
    Pack = 20,
    [Display(Name = "جعبه")]
    Box = 30,
    [Display(Name = "کارتن")]
    Carton = 40,
    [Display(Name = "گرم")]
    Gram = 50,
    [Display(Name = "کیلوگرم")]
    Kilogram = 60,
    [Display(Name = "میلی‌لیتر")]
    Milliliter = 70,
    [Display(Name = "لیتر")]
    Liter = 80,
    [Display(Name = "سانتی‌متر")]
    Centimeter = 90,
    [Display(Name = "متر")]
    Meter = 100,
    [Display(Name = "حلقه")]
    Roll = 110,
    [Display(Name = "ورق")]
    Sheet = 120,
    [Display(Name = "بطری")]
    Bottle = 130,
    [Display(Name = "کیسه")]
    Bag = 140,
    [Display(Name = "پالت")]
    Pallet = 150
}