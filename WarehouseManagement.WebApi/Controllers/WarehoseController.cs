using WarehouseManagement.Application.Dtos.WarehouseDtos;

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
        [AllowAnonymous]
        public async Task<OkApiResult<SearchQueryResponse<GetAllWarehousesDto>>> GetAll([FromQuery] FilterWarehousesDto QueryParams)
        {
            return OkApiResult<SearchQueryResponse<GetAllWarehousesDto>>.Ok(await _warehoseService.GetAllAsync(QueryParams));
        }

        /// <summary>
        ///(کلی) واکشی تمام انبارها
        /// </summary>
        [HttpGet]
        [DisplayName("واکشی تمام انبارها (کلی )")]
        [AllowAnonymous]
        public async Task<OkApiResult<SearchQueryResponse<GetWarehousesDto>>> GetWarehouses([FromQuery] FilterWarehousesDto QueryParams)
        {
            return OkApiResult<SearchQueryResponse<GetWarehousesDto>>.Ok(await _warehoseService.GetWarehousesAsync(QueryParams));
        }


        /// <summary>
        /// واکشی انبار توسط شناسه
        /// </summary>
        [HttpGet]
        [DisplayName("واکشی انبار توسط شناسه")]
        [AllowAnonymous]
        public async Task<OkApiResult<GetWarehouseDetailsDto>> GetById([FromQuery] Guid id)
        {
            return OkApiResult<GetWarehouseDetailsDto>.Ok(await _warehoseService.GetByIdAsync(id));
        }

        /// <summary>
        /// ایجاد انبار
        /// </summary>
        [HttpPost]
        [DisplayName("ایجاد انبار")]
        public async Task<OkApiResult<Guid>> Create([FromForm] CreateWarehouseDto createWarehouseDto)
        {
            return OkApiResult<Guid>.Ok(await _warehoseService.CreateAsync(createWarehouseDto));
        }

        /// <summary>
        /// ویرایش انبار
        /// </summary>
        [HttpPost]
        [DisplayName("ویرایش انبار")]
        public async Task<OkApiResult<bool>> Update([FromForm] UpdateWarehouseDto updateWarehouseDto)
        {
            return OkApiResult<bool>.Ok(await _warehoseService.UpdateAsync(updateWarehouseDto));
        }

        /// <summary>
        /// حذف انبار
        /// </summary>
        [HttpPost]
        [DisplayName("حذف انبار")]
        public async Task<OkApiResult<bool>> Delete([FromQuery] Guid id)
        {
            return OkApiResult<bool>.Ok(await _warehoseService.DeleteAsync(id));
        }
    }
}
