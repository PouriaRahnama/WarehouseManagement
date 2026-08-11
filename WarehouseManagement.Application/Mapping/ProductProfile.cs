namespace WarehouseManagement.Application.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductDto, Product>()
                .ForMember(dest => dest.Code, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.UnitOfMeasure, opt => opt.MapFrom(src => src.UnitOfMeasure))
                .ForMember(dest => dest.MinimumStock, opt => opt.MapFrom(src => src.MinimumStock))
                .ForMember(dest => dest.IsActive,opt => opt.Ignore())
                .AfterMap((src, dest) =>
                {
                    dest.Code = "PRD".GenerateProductCode();
                });

            CreateMap<Product, GetAllProductsDto>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.UnitOfMeasure, opt => opt.MapFrom(src => src.UnitOfMeasure.GetDisplayName()))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.CreatedDateTime,
                     opt => opt.MapFrom(src => EF.Property<DateTime?>(src, "CreatedDateTime")))
                .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.ImagePath == null
                    ? null
                    : FilePaths.ProductImages + src.ImagePath)); ;

            CreateMap<Product, GetProductNamesDto>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<Product, GetProductDetailsDto>()
                .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.UnitOfMeasure, opt => opt.MapFrom(s => s.UnitOfMeasure.GetDisplayName()))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.CreatedDateTime,
                    opt => opt.MapFrom(src => EF.Property<DateTime?>(src, "CreatedDateTime")))
                .ForMember(dest => dest.ImagePath, opt => opt.MapFrom(src => src.ImagePath == null
                    ? null
                    : FilePaths.ProductImages + src.ImagePath)); ;

            CreateMap<UpdateProductDto, Product>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Code, opt => opt.Ignore())
                .ForMember(dest => dest.UnitOfMeasure, opt => opt.MapFrom(src => src.UnitOfMeasure))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
