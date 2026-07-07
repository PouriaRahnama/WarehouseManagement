using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using MockQueryable.Moq;
using Moq;
using WarehouseManagement.Application.Services;
using WarehouseManagement.Domain.Entities;
using WarehouseManagement.Framework.Common;
using WarehouseManagement.Infrastructure.Repository.InterfacesRepository;
using WarehouseManagement.Infrastructure.UnitOfWork;
using Xunit;


namespace WarehouseManagement.Test
{

    public class StockBalanceServiceTests
    {
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IStockBalanceRepository> _mockRepo;
        private readonly Mock<IMapper> _mockMapper;
        private readonly StockBalanceService _service;

        public StockBalanceServiceTests()
        {
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockRepo = new Mock<IStockBalanceRepository>();
            _mockMapper = new Mock<IMapper>();

            // تزریق Mockها به سرویس
            _service = new StockBalanceService(
                _mockUnitOfWork.Object,
                _mockMapper.Object,
                _mockRepo.Object);
        }

        [Fact]
        public async Task DecreaseStockBalanceAsync_ShouldDecreaseQuantity_WhenSufficientStockExists()
        {
            // Arrange
            var warehouseId = Guid.NewGuid();
            var productId = Guid.NewGuid();
            var stock = new StockBalance { ProductId = productId, WarehouseId = warehouseId, Quantity = 10 };

            // اصلاح اصلی اینجاست: BuildMock() مستقیماً IQueryable برمی‌گرداند
            var mockData = new List<StockBalance> { stock }.BuildMock();
            _mockRepo.Setup(r => r.Entities).Returns(mockData);

            var items = new List<StockDocumentItem> {
        new StockDocumentItem { ProductId = productId, Quantity = 3, Product = new Product { Name = "Test Product" } }
    };

            // Act
            await _service.DecreaseStockBalanceAsync(items, warehouseId);

            // Assert
            stock.Quantity.Should().Be(7);
        }

        [Fact]
        public async Task DecreaseStockBalanceAsync_ShouldThrowBusinessException_WhenStockIsInsufficient()
        {
            // Arrange
            var warehouseId = Guid.NewGuid();
            var productId = Guid.NewGuid();
            var stock = new StockBalance { ProductId = productId, WarehouseId = warehouseId, Quantity = 2 };

            // اصلاح اصلی اینجاست
            var mockData = new List<StockBalance> { stock }.BuildMock();
            _mockRepo.Setup(r => r.Entities).Returns(mockData);

            var items = new List<StockDocumentItem> {
                new StockDocumentItem { ProductId = productId, Quantity = 5, Product = new Product { Name = "Test Product" } }
            };

            // Act & Assert
            Func<Task> act = async () => await _service.DecreaseStockBalanceAsync(items, warehouseId);

            await act.Should().ThrowAsync<BusinessException>()
                     .WithMessage("*موجودی کالای*");
        }
    }

}
