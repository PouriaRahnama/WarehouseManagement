namespace WarehouseManagement.Application.Interfaces
{
    public interface IWarehouseService
    {
        Task<SearchQueryResponse<GetAllWarehousesDto>> GetAllAsync(FilterWarehousesDto QueryParams);
        Task<SearchQueryResponse<GetWarehouseNamesDto>> GetWarehouseNamesAsync(FilterWarehousesDto QueryParams);
        Task<GetWarehouseDetailsDto> GetByIdAsync(Guid warehouseId);
        Task<Guid> CreateAsync(CreateWarehouseDto createWarehouseDto);
        Task<bool> UpdateAsync(UpdateWarehouseDto updateWarehouseDto);
        Task<bool> DeleteAsync(Guid warehouseId);
    }
}
