namespace WarehouseManagement.Application.Dtos.ProductDtos
{
    public class CreateProductDto
    {
        [Required(ErrorMessage = "وارد کردن نام محصول الزامی است.")]
        [StringLength(100, ErrorMessage = "نام محصول نمی‌تواند بیشتر از ۱۰۰ کاراکتر باشد.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "وارد کردن تعداد الزامی است.")]
        [Range(1, int.MaxValue, ErrorMessage = "تعداد محصول نمی‌تواند عدد منفی باشد.")]
        public int Quantity { get; set; }

    }
}
