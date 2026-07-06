namespace WarehouseManagement.Application.Services
{
    public class StockDocumentService : IStockDocumentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStockBalanceService _stockBalanceService;
        private readonly IStockDocumentRepository _stockDocumentRepository;
        private readonly IStockDocumentItemRepository _stockDocumentItemRepository;
        private readonly IMapper _mapper;
        public StockDocumentService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IStockBalanceService stockBalanceService,
            IStockDocumentRepository stockDocumentRepository,
            IStockDocumentItemRepository stockDocumentItemRepository
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _stockBalanceService = stockBalanceService;
            _stockDocumentRepository = stockDocumentRepository;
            _stockDocumentItemRepository = stockDocumentItemRepository;
        }
     

        public async Task<Guid> CreateInStockDocumentAsync(CreateInStockDocumentDto createInStockDocumentDto)
        {
            var document = _mapper.Map<StockDocument>(createInStockDocumentDto);
            await _stockDocumentRepository.CreateAsync(document);

            var items = _mapper.Map<List<StockDocumentItem>>(createInStockDocumentDto.Items, opt =>
            { opt.Items["StockDocumentId"] = document.Id;});
            await _stockDocumentItemRepository.CreateRangeAsync(items);

            await _unitOfWork.SaveChangesAsync();
            return document.Id;
        }

        public async Task<Guid> CreateOutStockDocumentAsync(CreateOutStockDocumentDto createOutStockDocumentDto)
        {
            var document = _mapper.Map<StockDocument>(createOutStockDocumentDto);
            await _stockDocumentRepository.CreateAsync(document);

            var items = _mapper.Map<List<StockDocumentItem>>(createOutStockDocumentDto.Items, opt =>
            {
                opt.Items["StockDocumentId"] = document.Id;
            });
            await _stockDocumentItemRepository.CreateRangeAsync(items);
            await _unitOfWork.SaveChangesAsync();
            return document.Id;
        }

        public async Task<Guid> CreateTransferStockDocumentAsync(CreateTransferStockDocumentDto createTransferStockDocumentDto)
        {
            var document = _mapper.Map<StockDocument>(createTransferStockDocumentDto);
            await _stockDocumentRepository.CreateAsync(document);

            var items = _mapper.Map<List<StockDocumentItem>>(createTransferStockDocumentDto.Items, opt =>
            {
                opt.Items["StockDocumentId"] = document.Id;
            });

            await _stockDocumentItemRepository.CreateRangeAsync(items);
            await _unitOfWork.SaveChangesAsync();
            return document.Id;
        }

        public async Task<bool> PostAsync(StockDocumentIdDto stockDocumentIdDto)
        {
            var document = await _stockDocumentRepository.EntitiesAsNoTracking
                .FirstOrDefaultAsync(x => x.Id == stockDocumentIdDto.StockDocumentId);

            if (document == null) throw new NotFoundException("سند یافت نشد.");
            if (document.Status != StockDocumentStatus.Wait) throw new BusinessException("سند قبلاً ثبت شده است.");

            switch (document.Type)
            {
                case StockDocumentType.In:
                    await IncreaseWarehouseStockWhenPostedAsync(stockDocumentIdDto.StockDocumentId);
                    break;

                case StockDocumentType.Out:
                    await DecreaseWarehouseStockWhenPostedAsync(stockDocumentIdDto.StockDocumentId);
                    break;

                case StockDocumentType.Transfer:
                    await TransferWarehouseStockWhenPostedAsync(stockDocumentIdDto.StockDocumentId);
                    break;

                default:
                    throw new BusinessException("نوع سند نامعتبر است.");
            }

            return true;
        }

        private async Task TransferWarehouseStockWhenPostedAsync(Guid stockDocumentId)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var document = await _stockDocumentRepository.Entities
                     .Include(x => x.StockDocumentItems)
                     .FirstOrDefaultAsync(x => x.Id == stockDocumentId);

                if (document == null) throw new NotFoundException("سند یافت نشد.");
                if (document.Status != StockDocumentStatus.Wait) throw new BusinessException("سند قبلاً پردازش شده است.");
                if (!document.ToWarehouseId.HasValue) throw new BusinessException("انبار مقصد مشخص نشده است.");
                if (!document.FromWarehouseId.HasValue) throw new BusinessException("انبار مبدا مشخص نشده است.");

                await _stockBalanceService.TransferStockBalanceAsync(document.StockDocumentItems,
                    document.ToWarehouseId.Value, document.FromWarehouseId.Value);

                document.Status = StockDocumentStatus.Posted;

                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                await _unitOfWork.RollbackAsync();
                throw new BusinessException("موجودی همزمان تغییر کرده، دوباره تلاش کنید.");
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                throw new BusinessException($"عملیات با خطا مواجه شد.");
            }
        }

        private async Task IncreaseWarehouseStockWhenPostedAsync(Guid stockDocumentId)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var document = await _stockDocumentRepository.Entities
                     .Include(x => x.StockDocumentItems)
                     .FirstOrDefaultAsync(x => x.Id == stockDocumentId);

                if (document == null) throw new NotFoundException("سند یافت نشد.");
                if (document.Status != StockDocumentStatus.Wait) throw new BusinessException("سند قبلاً پردازش شده است.");
                if (!document.ToWarehouseId.HasValue) throw new BusinessException("انبار مقصد مشخص نشده است.");

                await _stockBalanceService.IncreaseStockBalanceAsync(document.StockDocumentItems,document.ToWarehouseId.Value);

                document.Status = StockDocumentStatus.Posted;

                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                await _unitOfWork.RollbackAsync();
                throw new BusinessException("موجودی همزمان تغییر کرده، دوباره تلاش کنید.");
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                throw new BusinessException($"عملیات با خطا مواجه شد.");
            }
        }

        private async Task DecreaseWarehouseStockWhenPostedAsync(Guid stockDocumentId)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var document = await _stockDocumentRepository.Entities
                     .Include(x => x.StockDocumentItems)
                     .FirstOrDefaultAsync(x => x.Id == stockDocumentId);

                if (document == null) throw new NotFoundException("سند یافت نشد.");
                if (document.Status != StockDocumentStatus.Wait) throw new BusinessException("سند قبلاً پردازش شده است.");
                if (!document.FromWarehouseId.HasValue) throw new BusinessException("انبار مبدا مشخص نشده است.");

                await _stockBalanceService.DecreaseStockBalanceAsync(document.StockDocumentItems, document.FromWarehouseId.Value);

                document.Status = StockDocumentStatus.Posted;

                await _unitOfWork.SaveChangesAsync();
                await _unitOfWork.CommitAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                await _unitOfWork.RollbackAsync();
                throw new BusinessException("موجودی همزمان تغییر کرده، دوباره تلاش کنید.");
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                throw new BusinessException($"عملیات با خطا مواجه شد.");
            }
        }

    }
}
