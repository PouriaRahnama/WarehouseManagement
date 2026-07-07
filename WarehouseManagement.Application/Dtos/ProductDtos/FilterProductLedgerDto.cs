namespace WarehouseManagement.Application.Dtos.ProductDtos
{
    public class FilterProductLedgerDto : SearchQueryRequest
    {
        public Guid ProductId { get; set; }
        public Guid WarehouseId { get; set; }
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
