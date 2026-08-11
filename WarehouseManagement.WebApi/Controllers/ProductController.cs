namespace WarehouseManagement.WebApi.Controllers
{
    public class ProductController : ApiBaseController
    {
        public ProductController(ILogger<ApiBaseController> logger) : base(logger) { }

        /// <summary>
        /// واکشی تمام محصولات
        /// </summary>
        [HttpGet]
        [DisplayName("واکشی تمام محصولات")]
        [Authorize(Policy = Policies.Viewer)]
        public async Task<OkApiResult<SearchQueryResponse<GetAllProductsDto>>> GetAll([FromQuery] FilterProductsDto QueryParams)
        {
            return OkApiResult<SearchQueryResponse<GetAllProductsDto>>.Ok(await _productService.GetAllAsync(QueryParams));
        }

        /// <summary>
        /// واکشی نام تمام محصولات
        /// </summary>
        [HttpGet]
        [DisplayName("واکشی نام تمام محصولات ")]
        [Authorize(Policy = Policies.Viewer)]
        public async Task<OkApiResult<SearchQueryResponse<GetProductNamesDto>>> GetProductNames([FromQuery] FilterProductsDto QueryParams)
        {
            return OkApiResult<SearchQueryResponse<GetProductNamesDto>>.Ok(await _productService.GetProductNamesAsync(QueryParams));
        }

        /// <summary>
        /// واکشی محصول توسط شناسه
        /// </summary>
        [HttpGet]
        [DisplayName("واکشی محصول توسط شناسه")]
        [Authorize(Policy = Policies.Viewer)]
        public async Task<OkApiResult<GetProductDetailsDto>> GetById([FromQuery] Guid id)
        {
            return OkApiResult<GetProductDetailsDto>.Ok(await _productService.GetByIdAsync(id));
        }

        /// <summary>
        /// ایجاد محصول
        /// </summary>
        [HttpPost]
        [DisplayName("ایجاد محصول")]
        //[Authorize(Policy = Policies.Admin)]
        public async Task<OkApiResult<Guid>> Create([FromForm] CreateProductDto createProductDto)
        {
            return OkApiResult<Guid>.Ok(await _productService.CreateAsync(createProductDto));
        }

        /// <summary>
        /// ویرایش محصول
        /// </summary>
        [HttpPut]
        [DisplayName("ویرایش محصول")]
        [Authorize(Policy = Policies.Admin)]
        public async Task<OkApiResult<bool>> Update([FromForm] UpdateProductDto updateProductDto)
        {
            return OkApiResult<bool>.Ok(await _productService.UpdateAsync(updateProductDto));
        }

        /// <summary>
        /// حذف محصول
        /// </summary>
        [HttpDelete]
        [DisplayName("حذف محصول")]
        [Authorize(Policy = Policies.Admin)]
        public async Task<OkApiResult<bool>> Delete([FromQuery] Guid id)
        {
            return OkApiResult<bool>.Ok(await _productService.DeleteAsync(id));
        }
    }
}
