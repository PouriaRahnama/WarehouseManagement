namespace WarehouseManagement.Application.Mapping
{
    public class StockDocumentProfile : Profile
    {
        public StockDocumentProfile()
        {

            CreateMap<(CreateStockDocumentItemDto, Guid id), StockDocumentItem>()
                .ForMember(dest => dest.StockDocumentId, opt => opt.MapFrom((src, dest, _, context) =>
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
                    }); ;

            CreateMap<StockDocumentItem, ProductLedgerItemReportDto>()
                .ForMember(x => x.DocumentNumber, opt => opt.MapFrom(src => src.StockDocument.Number))
                .ForMember(x => x.DocumentType, opt => opt.MapFrom(src => src.StockDocument.Type))
                .ForMember(x => x.OutgoingQuantity, opt => opt.Ignore())
                .ForMember(x => x.RunningBalance, opt => opt.Ignore())
                .ForMember(x => x.IncomingQuantity, opt => opt.Ignore())
                .ForMember(dest => dest.DateTime,
                     opt => opt.MapFrom(src => EF.Property<DateTime?>(src, "CreatedDateTime")));


        }
    }
}
