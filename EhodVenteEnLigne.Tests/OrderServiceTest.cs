using EhodBoutiqueEnLigne.Models;
using EhodBoutiqueEnLigne.Models.Repositories;
using EhodBoutiqueEnLigne.Models.Services;
using EhodBoutiqueEnLigne.Models.ViewModels;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace EhodBoutiqueEnLigne.Tests
{
    public class OrderServiceTests
    {
        private readonly Mock<ICart> _mockCart;
        private readonly Mock<IOrderRepository> _mockOrderRepository;
        private readonly Mock<IProductService> _mockProductService;
        private readonly OrderService _orderService;

        public OrderServiceTests()
        {
            // Arrange
            _mockCart = new Mock<ICart>();
            _mockOrderRepository = new Mock<IOrderRepository>();
            _mockProductService = new Mock<IProductService>();

            _orderService = new OrderService(_mockCart.Object, _mockOrderRepository.Object, _mockProductService.Object);
        }

        [Fact]
        public void Test_SaveOrder_WithMissingName_ShouldReturnErrorMessage()
        {
            // Arrange
            var orderViewModel = new OrderViewModel
            {
                Address = "Keur Massar",
                City = "Dakar",
                Zip = "10001",
                Country = "Senegal",
                Lines = new List<CartLine>()
            };

            // Act
            _orderService.SaveOrder(orderViewModel);
            var modelErrors = _orderService.CheckOrderModelErrors(orderViewModel);

            // Assert
            Assert.Contains("ErrorMissingName", modelErrors);
        }

        [Fact]
        public void Test_SaveOrder_WithMissingAddress_ShouldReturnErrorMessage()
        {
            // Arrange
            var orderViewModel = new OrderViewModel
            {
                Name = "Padam",
                City = "Keur Massar",
                Zip = "10001",
                Country = "Senegal",
                Lines = new List<CartLine>(),
            };

            // Act
            _orderService.SaveOrder(orderViewModel);
            var modelErrors = _orderService.CheckOrderModelErrors(orderViewModel);

            // Assert
            Assert.Contains("ErrorMissingAddress", modelErrors);
        }

        [Fact]
        public void Test_SaveOrder_WithMissingCity_ShouldReturnErrorMessage()
        {
            // Arrange
            var orderViewModel = new OrderViewModel
            {
                Name = "Padam",
                Address = "Keur Massar",
                Zip = "10001",
                Country = "Senegal",
                Lines = new List<CartLine>(),
            };

            // Act
            _orderService.SaveOrder(orderViewModel);
            var modelErrors = _orderService.CheckOrderModelErrors(orderViewModel);

            // Assert
            Assert.Contains("ErrorMissingCity", modelErrors);
        }

        [Fact]
        public void Test_SaveOrder_WithMissingZip_ShouldReturnErrorMessage()
        {
            // Arrange
            var orderViewModel = new OrderViewModel
            {
                Name = "Padam",
                Address = "Keur Massar",
                City = "Dakar",
                Country = "Senegal",
                Lines = new List<CartLine>(),
            };

            // Act
            _orderService.SaveOrder(orderViewModel);
            var modelErrors = _orderService.CheckOrderModelErrors(orderViewModel);

            // Assert
            Assert.Contains("ErrorMissingZipCode", modelErrors);
        }

        [Fact]
        public void Test_SaveOrder_WithMissingCountry_ShouldReturnErrorMessage()
        {
            // Arrange
            var orderViewModel = new OrderViewModel
            {
                Name = "Padam",
                Address = "Keur Massar",
                Zip = "10001",
                City = "Dakar",
                Lines = new List<CartLine>(),
            };

            // Act
            _orderService.SaveOrder(orderViewModel);
            var modelErrors = _orderService.CheckOrderModelErrors(orderViewModel);

            // Assert
            Assert.Contains("ErrorMissingCountry", modelErrors);
        }

        [Fact]
        public void Test_CheckOrderModelErrors_WithAllFieldsFilled_ShouldReturnEmptyList()
        {
            // Arrange
            var orderViewModel = new OrderViewModel
            {
                Name = "Padam",
                Address = "Keur Massar",
                City = "Dakar",
                Zip = "10001",
                Country = "Senegal",
                Lines = new List<CartLine>(),
            };

            // Act
            var modelErrors = _orderService.CheckOrderModelErrors(orderViewModel);

            // Assert
            Assert.Empty(modelErrors);
        }
    }
}
