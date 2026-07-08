namespace WarehouseManagement.Application.Mapping
{
    public class StockDocumentProfile : Profile
    {
        public StockDocumentProfile()
        {
            CreateMap<CreateStockDocumentItemDto, StockDocumentItem>()
                    .ForMember(dest => dest.StockDocumentId,
                        opt => opt.MapFrom((src, dest, _, context) =>
                            (Guid)context.Items["StockDocumentId"]));


            CreateMap<CreateInStockDocumentDto, StockDocument>()
                    .ForMember(x => x.Type, opt => opt.MapFrom(_ => StockDocumentType.In))
                    .ForMember(x => x.ToWarehouseId, opt => opt.MapFrom(src => src.ToWarehouseId))
                    .ForMember(x => x.FromWarehouseId, opt => opt.Ignore())
                    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => StockDocumentStatus.Wait))
                    .AfterMap((src, dest) =>
                        {
                            dest.Number = "DOC".GenerateDocumentNumber();
                        });

            CreateMap<CreateOutStockDocumentDto, StockDocument>()
                .ForMember(x => x.Type, opt => opt.MapFrom(_ => StockDocumentType.Out))
                .ForMember(x => x.FromWarehouseId, opt => opt.MapFrom(src => src.FromWarehouseId))
                .ForMember(x => x.ToWarehouseId, opt => opt.Ignore())
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => StockDocumentStatus.Wait))
                .AfterMap((src, dest) =>
                    {
                        dest.Number = "DOC".GenerateDocumentNumber();
                    });

            CreateMap<CreateTransferStockDocumentDto, StockDocument>()
                .ForMember(x => x.Type, opt => opt.MapFrom(_ => StockDocumentType.Transfer))
                .ForMember(x => x.FromWarehouseId, opt => opt.MapFrom(src => src.FromWarehouseId))
                .ForMember(x => x.ToWarehouseId, opt => opt.MapFrom(src => src.ToWarehouseId))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => StockDocumentStatus.Wait))
                .AfterMap((src, dest) =>
                    {
                        dest.Number = "DOC".GenerateDocumentNumber();
                    });


            CreateMap<StockDocument, GetAllStockDocumentsDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ToWarehouseId, opt => opt.MapFrom(src => src.ToWarehouseId))
                .ForMember(dest => dest.FromWarehouseId, opt => opt.MapFrom(src =>src.FromWarehouseId))
                .ForMember(dest => dest.Number, opt => opt.MapFrom(src => src.Number))
                .ForMember(dest => dest. Status, opt => opt.MapFrom(src => src.Status))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type))
                .ForMember(dest => dest.StockDocumentItemsDto, opt => opt.MapFrom(src => src.StockDocumentItems))
                .ForMember(dest => dest.CreatedDateTime,
                    opt => opt.MapFrom(src => EF.Property<DateTime?>(src, "CreatedDateTime")));


            CreateMap<StockDocumentItem, GetStockDocumentItemDto>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity));

        }
    }
}
