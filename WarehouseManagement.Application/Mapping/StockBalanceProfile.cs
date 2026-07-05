namespace WarehouseManagement.Application.Mapping
{
    public class StockBalanceProfile : Profile
    {
        public StockBalanceProfile()
        {
            CreateMap<(StockDocumentItem item, Guid warehouseId), StockBalance>()
                .ForMember(dest => dest.WarehouseId, opt => opt.MapFrom(src => src.warehouseId))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.item.ProductId))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.item.Quantity));
        }
    }
}
