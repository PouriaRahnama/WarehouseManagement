namespace WarehouseManagement.Application.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IMapper _mapper;
        public WarehouseService(IWarehouseRepository warehouseRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _warehouseRepository = warehouseRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Guid> CreateAsync(CreateWarehouseDto createWarehouseDto)
        {
            var warehose = _mapper.Map<Warehouse>(createWarehouseDto);

            await _warehouseRepository.CreateAsync(warehose);
            await _unitOfWork.SaveChangesAsync();

            return warehose.Id;
        }

        public async Task<bool> DeleteAsync(Guid warehouseId)
        {
            var existingProduct = await _warehouseRepository.GetByIdAsync(warehouseId);

            if (existingProduct == null)
                throw new NotFoundException("انبار مورد نظر یافت نشد");

            await _warehouseRepository.DeleteAsync(warehouseId);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }

        public async Task<SearchQueryResponse<GetAllWarehousesDto>> GetAllAsync(FilterWarehousesDto QueryParams)
        {
            var mapper = new WarehouseGridifyMapper();

            var query = _warehouseRepository.EntitiesAsNoTracking
                    .ProjectTo<GetAllWarehousesDto>(_mapper.ConfigurationProvider)
                    .OrderByDescending(x => EF.Property<DateTime>(x, "CreatedDateTime"))
                    .AsQueryable();

            var qp = await query.GridifyQueryableAsync(QueryParams, mapper);

            var pq = new Paging<GetAllWarehousesDto>(qp.Count, qp.Query);
            return new SearchQueryResponse<GetAllWarehousesDto>(QueryParams, pq);
        }

        public async Task<GetWarehouseDetailsDto> GetByIdAsync(Guid warehouseId)
        {
            var warehose = await _warehouseRepository
               .EntitiesAsNoTracking.Where(p => p.Id == warehouseId)
               .ProjectTo<GetWarehouseDetailsDto>(_mapper.ConfigurationProvider)
               .FirstOrDefaultAsync();

            if (warehose == null) throw new NotFoundException("انبار مورد نظر یافت نشد");

            return warehose;

        }

        public async Task<SearchQueryResponse<GetWarehouseNamesDto>> GetWarehouseNamesAsync(FilterWarehousesDto QueryParams)
        {
            var mapper = new GetWarehouseNamesGridifyMapper();

            var query = _warehouseRepository.EntitiesAsNoTracking
                    .ProjectTo<GetWarehouseNamesDto>(_mapper.ConfigurationProvider)
                    .AsQueryable();

            QueryParams.Page = 1;
            var totalCount = await query.CountAsync();
            QueryParams.PageSize = totalCount;
            var qp = await query.GridifyQueryableAsync(QueryParams, mapper);

            var pq = new Paging<GetWarehouseNamesDto>(qp.Count, qp.Query);
            return new SearchQueryResponse<GetWarehouseNamesDto>(QueryParams, pq);
        }

        public async Task<bool> UpdateAsync(UpdateWarehouseDto updateWarehouseDto)
        {
            var existingWarehose = await _warehouseRepository.GetByIdAsync(updateWarehouseDto.WarehouseId);
            if (existingWarehose == null) throw new NotFoundException("انبار مورد نظر یافت نشد");

            _mapper.Map(updateWarehouseDto, existingWarehose);

            _warehouseRepository.Update(existingWarehose);
            await _unitOfWork.SaveChangesAsync();

            return true;
        }
    }
}
