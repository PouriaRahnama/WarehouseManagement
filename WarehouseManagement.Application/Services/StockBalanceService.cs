namespace WarehouseManagement.Application.Services
{
    public class StockBalanceService : IStockBalanceService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStockBalanceRepository _stockBalanceRepository;
        private readonly IMapper _mapper;
        public StockBalanceService(
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IStockBalanceRepository stockBalanceRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _stockBalanceRepository = stockBalanceRepository;
        }

        public async Task IncreaseStockBalanceAsync(ICollection<StockDocumentItem> stockDocumentItems,Guid toWarehouseId)
        {
            var productIds = stockDocumentItems.Select(x => x.ProductId).ToList();

            var stockBalances = await _stockBalanceRepository.Entities
                .Where(x => x.WarehouseId == toWarehouseId && productIds.Contains(x.ProductId)).ToListAsync();

            var newStockBalances = new List<StockBalance>();

            foreach (var item in stockDocumentItems)
            {
                var stock = stockBalances.FirstOrDefault(x => x.ProductId == item.ProductId);

                if (stock == null) newStockBalances.Add(_mapper.Map<StockBalance>((item, toWarehouseId)));
                else stock.Quantity += item.Quantity;
            }

            if (newStockBalances.Any()) await _stockBalanceRepository.CreateRangeAsync(newStockBalances);
        }

        public async Task DecreaseStockBalanceAsync(ICollection<StockDocumentItem> stockDocumentItems, Guid fromWarehouseId)
        {
            var productIds = stockDocumentItems.Select(x => x.ProductId).ToList();

            var stockBalances = await _stockBalanceRepository.Entities
                .Where(x => x.WarehouseId == fromWarehouseId && productIds.Contains(x.ProductId)).ToListAsync();

            var newStockBalances = new List<StockBalance>();

            foreach (var item in stockDocumentItems)
            {
                var stock = stockBalances.FirstOrDefault(x => x.ProductId == item.ProductId);

                if (stock == null) throw new BusinessException($"برای کالا {item.Product.Name} موجودی ثبت نشده است.");
                if (stock.Quantity < item.Quantity) throw new BusinessException($"موجودی کالای {item.Product.Name} کافی نیست.");

                else stock.Quantity -= item.Quantity;
            }

            if (newStockBalances.Any()) await _stockBalanceRepository.CreateRangeAsync(newStockBalances);
        }

        public async Task TransferStockBalanceAsync(ICollection<StockDocumentItem> stockDocumentItems, Guid toWarehouseId, Guid fromWarehouseId)
        {
            var productIds = stockDocumentItems.Select(x => x.ProductId).ToList();

            var stockBalances = await _stockBalanceRepository.Entities
                .Where(x => (x.WarehouseId == fromWarehouseId || x.WarehouseId == toWarehouseId) &&
                    productIds.Contains(x.ProductId)).ToListAsync();

            var newStockBalances = new List<StockBalance>();
            foreach (var item in stockDocumentItems)
            {
                var fromBalance = stockBalances.FirstOrDefault(x => x.WarehouseId == fromWarehouseId &&
                    x.ProductId == item.ProductId);

                if (fromBalance == null) throw new BusinessException("موجودی کالا در انبار مبدا یافت نشد.");
                if (fromBalance.Quantity < item.Quantity) throw new BusinessException($"موجودی کالا {item.ProductId} کافی نیست.");

                fromBalance.Quantity -= item.Quantity;

                var toBalance = stockBalances.FirstOrDefault(x => x.WarehouseId == toWarehouseId &&
                    x.ProductId == item.ProductId);
       
                if (toBalance != null)               
                    toBalance.Quantity += item.Quantity;             
                else
                {
                    toBalance = _mapper.Map<StockBalance>((item, toWarehouseId));
                    newStockBalances.Add(toBalance);
                }
            }

            await _stockBalanceRepository.CreateRangeAsync(newStockBalances);

        }

    }
}
