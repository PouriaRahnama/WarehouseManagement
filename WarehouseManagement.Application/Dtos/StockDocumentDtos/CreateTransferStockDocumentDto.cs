namespace WarehouseManagement.Application.Dtos.StockDocumentDtos
{
    public class CreateTransferStockDocumentDto: CreateInStockDocumentDto
    {
        [Required(ErrorMessage = "شناسه انبار مبدا الزامی است.")]
        public Guid FromWarehouseId { get; set; }
    }
}
