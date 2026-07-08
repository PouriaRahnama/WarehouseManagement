namespace WarehouseManagement.Application.Dtos.StockDocumentDtos
{
    public class CreateStockDocumentItemDto
    {
        [Required(ErrorMessage = "شناسه محصول الزامی است.")]
        public Guid ProductId { get; set; }

        [Required(ErrorMessage = "تعداد محصول الزامی است.")]
        public int Quantity { get; set; }
    }
}
