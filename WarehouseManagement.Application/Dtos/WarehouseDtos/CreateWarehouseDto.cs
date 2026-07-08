namespace WarehouseManagement.Application.Dtos.WarehouseDtos
{
    public class CreateWarehouseDto
    {
        [Required(ErrorMessage = "وارد کردن نام انبار الزامی است.")]
        [StringLength(200, ErrorMessage = "نام انبار نمی‌تواند بیشتر از 200 کاراکتر باشد.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "وارد کردن محل انبار الزامی است.")]
        [StringLength(300, ErrorMessage = "محل انبار نمی‌تواند بیشتر از 300 کاراکتر باشد.")]
        public string Location { get; set; }
    }
}