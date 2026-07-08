namespace WarehouseManagement.Application.Dtos.StockDocumentDtos
{
    public class FilterProductLedgerDto : SearchQueryRequest
    {
        [Required(ErrorMessage = "شناسه محصول مقصد الزامی است.")]
        public Guid? ProductId { get; set; }

        [Required(ErrorMessage = "شناسه انبار  الزامی است.")]
        public Guid? WarehouseId { get; set; }

        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }

    public class ProductLedgerItemReportDto
    {
        public DateTime? DateTime { get; set; }
        public string DocumentNumber { get; set; }
        public StockDocumentType DocumentType { get; set; }
        public int IncomingQuantity { get; set; }
        public int OutgoingQuantity { get; set; }
        public int RunningBalance { get; set; }
    }

}
