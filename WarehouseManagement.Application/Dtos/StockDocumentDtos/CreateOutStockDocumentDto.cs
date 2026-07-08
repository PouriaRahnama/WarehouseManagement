namespace WarehouseManagement.Application.Dtos.StockDocumentDtos
{
    public class CreateOutStockDocumentDto
    {
        [Required(ErrorMessage = "شناسه انبار مبدا الزامی است.")]
        public Guid FromWarehouseId { get; set; }

        [Required(ErrorMessage = "آیتم‌ها الزامی است.")]
        [MinLength(1, ErrorMessage = "حداقل یک آیتم باید وارد شود.")]
        public List<CreateStockDocumentItemDto> Items { get; set; }
    }
}
