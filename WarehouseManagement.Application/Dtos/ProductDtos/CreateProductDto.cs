namespace WarehouseManagement.Application.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        [Required(ErrorMessage = "وارد کردن نام محصول الزامی است.")]
        [StringLength(350, ErrorMessage = "نام محصول نمی‌تواند بیشتر از ۳۵۰ کاراکتر باشد.")]
        public string Name { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "حداقل موجودی نمی‌تواند منفی باشد.")]
        public int MinimumStock { get; set; } = 0;

        [Range(1, int.MaxValue, ErrorMessage = "واحد اندازه‌گیری معتبر نیست.")]
        public UnitOfMeasure UnitOfMeasure { get; set; }
    }
}
