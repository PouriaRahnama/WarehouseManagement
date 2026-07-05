namespace WarehouseManagement.Application.Dtos.WarehouseDtos
{
    public class CreateWarehouseDto
    {
        [Required(ErrorMessage = "وارد کردن نام انبار الزامی است.")]
        [StringLength(200, ErrorMessage = "نام انبار نمی‌تواند بیشتر از 100 کاراکتر باشد.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "وارد کردن محل انبار الزامی است.")]
        [StringLength(3000, ErrorMessage = "محل انبار نمی‌تواند بیشتر از 250 کاراکتر باشد.")]
        public string Location { get; set; }
    }
}