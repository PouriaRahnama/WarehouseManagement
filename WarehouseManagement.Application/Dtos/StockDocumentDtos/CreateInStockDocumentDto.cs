namespace WarehouseManagement.Application.Dtos.StockDocumentDtos
{
    public class CreateInStockDocumentDto
    {
        [Required(ErrorMessage = "شناسه انبار مقصد الزامی است.")]
        public Guid ToWarehouseId { get; set; }

        [Required(ErrorMessage = "آیتم‌ها الزامی است.")]
        [MinLength(1, ErrorMessage = "حداقل یک آیتم باید وارد شود.")]
        public List<CreateStockDocumentItemDto> Items { get; set; } = new();
    }
}
