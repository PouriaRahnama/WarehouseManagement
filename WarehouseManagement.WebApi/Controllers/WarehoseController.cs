namespace WarehouseManagement.WebApi.Controllers
{
    public class WarehoseController : ApiBaseController
    {
        public WarehoseController(ILogger<ApiBaseController> logger) : base(logger) { }


        /// <summary>
        /// واکشی تمام انبارها
        /// </summary>
        [HttpGet]
        [DisplayName("واکشی تمام انبارها")]
        [Authorize(Policy = Policies.Viewer)]
        public async Task<OkApiResult<SearchQueryResponse<GetAllWarehousesDto>>> GetAll([FromQuery] FilterWarehousesDto QueryParams)
        {
            return OkApiResult<SearchQueryResponse<GetAllWarehousesDto>>.Ok(await _warehoseService.GetAllAsync(QueryParams));
        }

        /// <summary>
        /// واکشی نام تمام انبارها
        /// </summary>
        [HttpGet]
        [DisplayName("واکشی نام تمام انبارها ")]
        [Authorize(Policy = Policies.Viewer)]
        public async Task<OkApiResult<SearchQueryResponse<GetWarehouseNamesDto>>> GetWarehouseNames([FromQuery] FilterWarehousesDto QueryParams)
        {
            return OkApiResult<SearchQueryResponse<GetWarehouseNamesDto>>.Ok(await _warehoseService.GetWarehouseNamesAsync(QueryParams));
        }


        /// <summary>
        /// واکشی انبار توسط شناسه
        /// </summary>
        [HttpGet]
        [DisplayName("واکشی انبار توسط شناسه")]
        [Authorize(Policy = Policies.Viewer)]
        public async Task<OkApiResult<GetWarehouseDetailsDto>> GetById([FromQuery] Guid id)
        {
            return OkApiResult<GetWarehouseDetailsDto>.Ok(await _warehoseService.GetByIdAsync(id));
        }

        /// <summary>
        /// ایجاد انبار
        /// </summary>
        [HttpPost]
        [DisplayName("ایجاد انبار")]
        [Authorize(Policy = Policies.Admin)]
        public async Task<OkApiResult<Guid>> Create([FromBody] CreateWarehouseDto createWarehouseDto)
        {
            return OkApiResult<Guid>.Ok(await _warehoseService.CreateAsync(createWarehouseDto));
        }

        /// <summary>
        /// ویرایش انبار
        /// </summary>
        [HttpPost]
        [DisplayName("ویرایش انبار")]
        [Authorize(Policy = Policies.Admin)]
        public async Task<OkApiResult<bool>> Update([FromBody] UpdateWarehouseDto updateWarehouseDto)
        {
            return OkApiResult<bool>.Ok(await _warehoseService.UpdateAsync(updateWarehouseDto));
        }

        /// <summary>
        /// حذف انبار
        /// </summary>
        [HttpPost]
        [DisplayName("حذف انبار")]
        [Authorize(Policy = Policies.Admin)]
        public async Task<OkApiResult<bool>> Delete([FromQuery] Guid id)
        {
            return OkApiResult<bool>.Ok(await _warehoseService.DeleteAsync(id));
        }
    }
}
