namespace WarehouseManagement.WebApi.Controllers
{

    public class StockDocumentController : ApiBaseController
    {
        public StockDocumentController(ILogger<ApiBaseController> logger) : base(logger)
        {
        }

        /// <summary>
        /// ایجاد سند ورود کالا
        /// </summary>
        [HttpPost]
        [DisplayName(" ایجاد سند ورود کالا")]
        [Authorize(Policy = Policies.Operator)]
        public async Task<OkApiResult<Guid>> CreateIn([FromBody] CreateInStockDocumentDto createInStockDocumentDto)
        {
            return OkApiResult<Guid>.Ok(await _stockDocumentService.CreateInStockDocumentAsync(createInStockDocumentDto));
        }

        /// <summary>
        /// ایجاد سند خروج کالا
        /// </summary>
        [HttpPost]
        [DisplayName(" ایجاد سند خروج کالا")]
        [Authorize(Policy = Policies.Operator)]
        public async Task<OkApiResult<Guid>> CreateOut([FromBody] CreateOutStockDocumentDto createOutStockDocumentDto)
        {
            return OkApiResult<Guid>.Ok(await _stockDocumentService.CreateOutStockDocumentAsync(createOutStockDocumentDto));
        }

        /// <summary>
        /// ایجاد سند انتقال کالا
        /// </summary>
        [HttpPost]
        [DisplayName(" ایجاد سند انتقال کالا")]
        [Authorize(Policy = Policies.Operator)]
        public async Task<OkApiResult<Guid>> CreateTransfer([FromBody] CreateTransferStockDocumentDto createTransferStockDocumentDto)
        {
            return OkApiResult<Guid>.Ok(await _stockDocumentService.CreateTransferStockDocumentAsync(createTransferStockDocumentDto));
        }

        /// <summary>
        /// ثبت نهایی سند
        /// </summary>
        [HttpPost]
        [DisplayName(" ثبت نهایی سند ")]
        [Authorize(Policy = Policies.Operator)]
        public async Task<OkApiResult<bool>> Confirm([FromBody] StockDocumentIdDto stockDocumentIdDto)
        {
            return OkApiResult<bool>.Ok(await _stockDocumentService.PostAsync(stockDocumentIdDto));
        }



    }
}
