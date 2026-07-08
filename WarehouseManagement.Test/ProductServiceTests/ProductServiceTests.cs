namespace WarehouseManagement.Test.ProductServiceTests
{
    public class ProductServiceTests
    {

        private readonly Mock<IProductRepository> _productRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly IMapper _mapper;
        private readonly ProductService _service;
        public ProductServiceTests()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<CreateProductDto, Product>()
                    .ForMember(dest => dest.Code, opt => opt.Ignore())
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.UnitOfMeasure, opt => opt.MapFrom(src => src.UnitOfMeasure))
                    .ForMember(dest => dest.MinimumStock, opt => opt.MapFrom(src => src.MinimumStock))
                    .ForMember(dest => dest.IsActive, opt => opt.Ignore())
                    .AfterMap((src, dest) =>
                    {
                        dest.Code = "PRD".GenerateProductCode();
                    });

                cfg.CreateMap<UpdateProductDto, Product>()
                    .ForMember(dest => dest.Id, opt => opt.Ignore())
                    .ForMember(dest => dest.Code, opt => opt.Ignore())
                    .ForMember(dest => dest.UnitOfMeasure, opt => opt.MapFrom(src => src.UnitOfMeasure))
                    .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));


                cfg.CreateMap<Product, GetAllProductsDto>()
                    .ForMember(dest => dest.Code, opt => opt.MapFrom(src => src.Code))
                    .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dest => dest.UnitOfMeasure, opt => opt.MapFrom(src => src.UnitOfMeasure.GetDisplayName()))
                    .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                    .ForMember(dest => dest.CreatedDateTime,
                    opt => opt.MapFrom(src => EF.Property<DateTime?>(src, "CreatedDateTime")));
            });

            _mapper = config.CreateMapper();

            _productRepositoryMock = new Mock<IProductRepository>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();

            _service = new ProductService(
                _productRepositoryMock.Object,
                _unitOfWorkMock.Object,
                _mapper
            );
        }

        [Fact]
        public async Task CreateAsync_Should_Create_Product_With_Generated_Code()
        {

            // Arrange
            var dto = new CreateProductDto
            {
                Name = "Laptop",
                UnitOfMeasure = Domain.Enums.UnitOfMeasure.Piece,
                MinimumStock = 10
            };

            Product createdProduct = null;

            _productRepositoryMock.Setup(x => x.CreateAsync(It.IsAny<Product>()))
                .Callback<Product>(p =>
                {
                    createdProduct = p;
                })
                .Returns(Task.CompletedTask);

            _unitOfWorkMock.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);

            // Act
            var result = await _service.CreateAsync(dto);

            // Assert
            createdProduct.Should().NotBeNull();
            result.Should().Be(createdProduct.Id);
            _productRepositoryMock.Verify(x => x.CreateAsync(createdProduct), Times.Once);
            _unitOfWorkMock.Verify(x => x.SaveChangesAsync(), Times.Once);
            createdProduct.Code.Should().NotBeNullOrEmpty();
            createdProduct.Code.Should().StartWith("PRD");
        }

        [Fact]
        public async Task DeleteAsync_Should_Delete_Product_When_Product_Exists()
        {
            // Arrange
            var productId = Guid.NewGuid();
            var product = new Product
            {
                Id = productId,
                Name = "Laptop"
            };

            _productRepositoryMock.Setup(x => x.GetByIdAsync(productId)).ReturnsAsync(product);

            _productRepositoryMock.Setup(x => x.DeleteAsync(productId)).Returns(Task.CompletedTask);

            _unitOfWorkMock.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);

            // Act
            var result = await _service.DeleteAsync(productId);


            // Assert

            result.Should().BeTrue();

            _productRepositoryMock.Verify(x => x.GetByIdAsync(productId), Times.Once);

            _productRepositoryMock.Verify(x => x.DeleteAsync(productId), Times.Once);

            _unitOfWorkMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task DeleteAsync_Should_Throw_NotFoundException_When_Product_Not_Exists()
        {
            // Arrange
            var productId = Guid.NewGuid();

            _productRepositoryMock.Setup(x => x.GetByIdAsync(productId)).ReturnsAsync((Product)null);

            // Act
            Func<Task> action = async () => await _service.DeleteAsync(productId);

            // Assert
            await action.Should().ThrowAsync<NotFoundException>().WithMessage("محصول مورد نظر یافت نشد");

            _productRepositoryMock.Verify(x => x.DeleteAsync(It.IsAny<Guid>()), Times.Never);

            _unitOfWorkMock.Verify(x => x.SaveChangesAsync(), Times.Never);
        }

        [Fact]
        public async Task UpdateAsync_Should_Update_Product_When_Product_Exists()
        {
            // Arrange
            var productId = Guid.NewGuid();

            var existingProduct = new Product
            {
                Id = productId,
                Name = "Old Name",
                MinimumStock = 5,
                UnitOfMeasure = UnitOfMeasure.Piece
            };


            var dto = new UpdateProductDto
            {
                ProductId = productId,
                Name = "New Name",
                MinimumStock = 20,
                UnitOfMeasure = UnitOfMeasure.Box,
                IsActive = true
            };

            _productRepositoryMock.Setup(x => x.GetByIdAsync(productId)).ReturnsAsync(existingProduct);

            _productRepositoryMock.Setup(x => x.Update(It.IsAny<Product>()));

            _unitOfWorkMock.Setup(x => x.SaveChangesAsync()).ReturnsAsync(1);

            // Act
            var result = await _service.UpdateAsync(dto);

            // Assert
            result.Should().BeTrue();

            _productRepositoryMock.Verify(x => x.GetByIdAsync(productId), Times.Once);

            _productRepositoryMock.Verify(x => x.Update(existingProduct), Times.Once);

            _unitOfWorkMock.Verify(x => x.SaveChangesAsync(), Times.Once);
        }

        [Fact]
        public async Task UpdateAsync_Should_Throw_NotFoundException_When_Product_Not_Exists()
        {
            // Arrange
            var dto = new UpdateProductDto
            {
                ProductId = Guid.NewGuid(),
                Name = "New Name"
            };

            _productRepositoryMock.Setup(x => x.GetByIdAsync(dto.ProductId)).ReturnsAsync((Product)null);

            // Act
            Func<Task> action = async () => await _service.UpdateAsync(dto);

            // Assert
            await action.Should().ThrowAsync<NotFoundException>().WithMessage("محصول مورد نظر یافت نشد");

            _productRepositoryMock.Verify(x => x.Update(It.IsAny<Product>()), Times.Never);

            _unitOfWorkMock.Verify(x => x.SaveChangesAsync(), Times.Never);
        }

    }



}
