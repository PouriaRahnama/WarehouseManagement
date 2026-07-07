namespace WarehouseManagement.Application.Mapping
{
    public class WarehouseProfile : Profile
    {
        public WarehouseProfile()
        {
            CreateMap<CreateWarehouseDto, Warehouse>()
                .ForMember(dest => dest.Code, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .AfterMap((src, dest) =>
                {
                    dest.Code = "WRH".GenerateWarehoseCode();
                });

            CreateMap<Warehouse, GetAllWarehousesDto>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.WarehouseId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.CreatedDateTime,
                opt => opt.MapFrom(src => EF.Property<DateTime?>(src, "CreatedDateTime")));

            CreateMap<Warehouse, GetWarehouseNamesDto>()
                .ForMember(dest => dest.WarehouseId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<Warehouse, GetWarehouseDetailsDto>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.WarehoseId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.CreatedDateTime,
                opt => opt.MapFrom(src => EF.Property<DateTime?>(src, "CreatedDateTime")));


            CreateMap<Warehouse, WarehouseStockReportsDto>()
                .ForMember(dest => dest.WarehouseId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.WarehouseName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Products, opt => opt.MapFrom(src => src.StockBalances))
                .ForMember(dest => dest.CreatedDateTime,
                    opt => opt.MapFrom(src => EF.Property<DateTime>(src, "CreatedDateTime").ToPersianDate()));

            CreateMap<StockBalance, WarehouseProductDto>()
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.Name))
                .ForMember(dest => dest.ProductCode, opt => opt.MapFrom(src => src.Product.Code))
                .ForMember(dest => dest.MinimumStock, opt => opt.MapFrom(src => src.Product.MinimumStock));

            CreateMap<UpdateWarehouseDto, Warehouse>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Code, opt => opt.Ignore())
                .ForMember(dest => dest.Location, opt => opt.MapFrom(src => src.Location))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

        }
    }
}
