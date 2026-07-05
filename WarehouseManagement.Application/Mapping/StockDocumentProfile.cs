using WarehouseManagement.Application.Dtos.StockDocumentDtos;

namespace WarehouseManagement.Application.Mapping
{
    public class StockDocumentProfile : Profile
    {
        public StockDocumentProfile()
        {        //document.Number = GenerateDocumentNumber();

            CreateMap<(CreateStockDocumentItemDto,Guid id), StockDocumentItem>()
                   .ForMember(dest => dest.StockDocumentId,
                         opt => opt.MapFrom((src, dest, _, context) =>
                         (Guid)context.Items["StockDocumentId"]));

            CreateMap<CreateInStockDocumentDto, StockDocument>()
                    .ForMember(x => x.Type, opt => opt.MapFrom(_ => StockDocumentType.In))
                    .ForMember(x => x.ToWarehouseId, opt => opt.MapFrom(src => src.ToWarehouseId))
                    .ForMember(x => x.FromWarehouseId, opt => opt.Ignore())
                    .ForMember(x => x.StockDocumentItems, opt => opt.MapFrom(src => src.Items))
                    .ForMember(dest => dest.Status, opt => opt.MapFrom(src => StockDocumentStatus.Wait));

            CreateMap<CreateOutStockDocumentDto, StockDocument>()
                .ForMember(x => x.Type, opt => opt.MapFrom(_ => StockDocumentType.Out))
                .ForMember(x => x.FromWarehouseId, opt => opt.MapFrom(src => src.FromWarehouseId))
                .ForMember(x => x.ToWarehouseId, opt => opt.Ignore())
                .ForMember(x => x.StockDocumentItems, opt => opt.MapFrom(src => src.Items))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => StockDocumentStatus.Wait));

            CreateMap<CreateTransferStockDocumentDto, StockDocument>()
                .ForMember(x => x.Type, opt => opt.MapFrom(_ => StockDocumentType.Transfer))
                .ForMember(x => x.FromWarehouseId, opt => opt.MapFrom(src => src.FromWarehouseId))
                .ForMember(x => x.ToWarehouseId, opt => opt.MapFrom(src => src.ToWarehouseId))
                .ForMember(x => x.StockDocumentItems, opt => opt.MapFrom(src => src.Items))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => StockDocumentStatus.Wait));


        }
    }
}
