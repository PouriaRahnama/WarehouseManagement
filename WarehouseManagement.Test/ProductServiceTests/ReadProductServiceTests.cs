namespace WarehouseManagement.Test.ProductServiceTests
{
    public class ReadProductServiceTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly IMapper _mapper;
        private readonly ProductService _service;
        private TestApplicationDbContext _context;

        public ReadProductServiceTests()
        {
            var config = new MapperConfiguration(cfg =>
            {

                cfg.CreateMap<Product, GetAllProductsDto>()
                    .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                    .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.UnitOfMeasure, opt => opt.MapFrom(src => src.UnitOfMeasure))
                    .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                     .ForMember(dest => dest.CreatedDateTime,
                             opt => opt.MapFrom(src => EF.Property<DateTime?>(src, "CreatedDateTime")));
            });

            _mapper = config.CreateMapper();

            var options = new DbContextOptionsBuilder<SqlServerApplicationDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            _context = new TestApplicationDbContext(options);

            var productRepository = new ProductRepository(_context);

            _unitOfWorkMock = new Mock<IUnitOfWork>();

            _service = new ProductService(productRepository, _unitOfWorkMock.Object, _mapper);
        }


        [Fact]
        public async Task GetAllAsync_Should_Return_Products()
        {
            // Arrange
            var products = new List<Product>
             {
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Laptop",
                    MinimumStock = 8,
                    UnitOfMeasure = UnitOfMeasure.Piece,
                    IsActive = true,
                    Code = "PRD-"
                },
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Mouse",
                    MinimumStock = 10,
                    UnitOfMeasure = UnitOfMeasure.Box,
                    IsActive = true,
                    Code = "PRD-"
                }
           };

            foreach (var product in products)
            {
                _context.Entry(product)
                    .Property("CreatedDateTime")
                    .CurrentValue = DateTime.Now;

                _context.Entry(product)
                    .Property("IsDeleted")
                    .CurrentValue = false;
            }

            await _context.Products.AddRangeAsync(products);
            await _context.SaveChangesAsync();


            var queryParams = new FilterProductsDto
            {
                Page = 1,
                PageSize = 1
            };


            // Act
            var result = await _service.GetAllAsync(queryParams);


            // Assert
            result.Should().NotBeNull();
            result.Items.Should().HaveCount(1);
        }
    }



}
