namespace WarehouseManagement.Application.Dtos.StockDocumentDtos
{
    public class StockDocumentIdDto
    {
        [Required(ErrorMessage = "شناسه سند الزامی است.")]
        public Guid StockDocumentId { get; set; }
    }
}
