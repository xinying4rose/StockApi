using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using StockApi.Controllers;
using StockApi.Models;
using StockApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StockApi.UnitTests
{
    public class WarehouseControllerTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetAll_WhenSuccessful_ReturnsResult()
        {
            // Arrange
            var boxes = new List<Box>
            {
                new Box(),
                new Box(),
                new Box(),
            };

            Mock<ILogger<WarehouseController>> mockLogger = new Mock<ILogger<WarehouseController>>();

            Mock<IWarehouseRepository> mockRepository = new Mock<IWarehouseRepository>();
            mockRepository.Setup(_ => _.GetAllBoxes()).Returns(boxes);

            var sut = new WarehouseController(mockLogger.Object, mockRepository.Object);

            // Act
            var result = sut.GetAll();

            //Assert
            Assert.NotNull(result);
            Assert.AreEqual(3, result.Count(), "Received incorrect number of boxex");
        }

        [Test]
        public void GetAll_WhenRepositoryThrowsException_ThrowsException()
        {
            // Arrange
            Mock<ILogger<WarehouseController>> mockLogger = new Mock<ILogger<WarehouseController>>();

            string errorMessage = "some error";
            Mock<IWarehouseRepository> mockRepository = new Mock<IWarehouseRepository>();
            mockRepository.Setup(_ => _.GetAllBoxes()).Throws(new Exception(errorMessage));

            var sut = new WarehouseController(mockLogger.Object, mockRepository.Object);

            // Act
            var act = () => sut.GetAll();

            //Assert
            Assert.That(() => act(), Throws.TypeOf<Exception>().With.Message.EqualTo(errorMessage));
        }

        [Test]
        public void Post_WhenSuccessful_Ok()
        {
            // Arrange
            var boxes = new List<Box>
            {
                new Box(),
                new Box(),
                new Box(),
            };

            Mock<ILogger<WarehouseController>> mockLogger = new Mock<ILogger<WarehouseController>>();

            Mock<IWarehouseRepository> mockRepository = new Mock<IWarehouseRepository>();
            mockRepository.Setup(_ => _.AddBox(It.IsAny<Box>()));

            var sut = new WarehouseController(mockLogger.Object, mockRepository.Object);

            // Act & Assert
            sut.Post(new Box());
        }

        [Test]
        public void Post_WhenRepositoryThrowsException_ThrowsException()
        {
            // Arrange
            Mock<ILogger<WarehouseController>> mockLogger = new Mock<ILogger<WarehouseController>>();

            string errorMessage = "some error";
            Mock<IWarehouseRepository> mockRepository = new Mock<IWarehouseRepository>();
            mockRepository.Setup(_ => _.AddBox(It.IsAny<Box>())).Throws(new Exception(errorMessage));

            var sut = new WarehouseController(mockLogger.Object, mockRepository.Object);

            // Act
            var act = () => sut.Post(new Box());

            //Assert
            Assert.That(() => act(), Throws.TypeOf<Exception>().With.Message.EqualTo(errorMessage));
        }

        [Test]
        public void GetById_WhenSuccessful_ReturnsResult()
        {
           // Arrange
           var actualBox = new Box
           {
               Id = 99,
               WeightKg = 56,
               LengthCm = 78,
               HeightCm = 9,
               WidthCm = 88,
               Content = BoxContentType.Books,
               ItemCount = 5
           };

            var expectedBox = new Box
            {
                Id = 99,
                WeightKg = 56,
                LengthCm = 78,
                HeightCm = 9,
                WidthCm = 88,
                Content = BoxContentType.Books,
                ItemCount = 5
            };

            Mock<ILogger<WarehouseController>> mockLogger = new Mock<ILogger<WarehouseController>>();

            Mock<IWarehouseRepository> mockRepository = new Mock<IWarehouseRepository>();
            mockRepository.Setup(_ => _.GetById(It.IsAny<int>())).Returns(actualBox);

            var sut = new WarehouseController(mockLogger.Object, mockRepository.Object);

            // Act
            var result = sut.GetById(expectedBox.Id);

            //Assert
            Assert.NotNull(result);
            result.Should().BeEquivalentTo(expectedBox, "Received incorrect number of boxex");
        }

        [Test]
        public void GetById_WhenRepositoryThrowsException_ThrowsException()
        {
            // Arrange
            Mock<ILogger<WarehouseController>> mockLogger = new Mock<ILogger<WarehouseController>>();

            string errorMessage = "some error";
            Mock<IWarehouseRepository> mockRepository = new Mock<IWarehouseRepository>();
            mockRepository.Setup(_ => _.GetById(It.IsAny<int>())).Throws(new Exception(errorMessage));

            var sut = new WarehouseController(mockLogger.Object, mockRepository.Object);

            // Act
            var act = () => sut.GetById(20000);

            //Assert
            Assert.That(() => act(), Throws.TypeOf<Exception>().With.Message.EqualTo(errorMessage));
        }


        [Test]
        public void DeleteById_WhenSuccessful_ReturnsResult()
        {
            // Arrange
            Mock<ILogger<WarehouseController>> mockLogger = new Mock<ILogger<WarehouseController>>();

            Mock<IWarehouseRepository> mockRepository = new Mock<IWarehouseRepository>();
            mockRepository.Setup(_ => _.DeleteById(It.IsAny<int>()));

            var sut = new WarehouseController(mockLogger.Object, mockRepository.Object);

            // Act & Assert
            sut.DeleteById(100);
        }

        [Test]
        public void DeleteById_WhenRepositoryThrowsException_ThrowsException()
        {
            // Arrange
            Mock<ILogger<WarehouseController>> mockLogger = new Mock<ILogger<WarehouseController>>();

            string errorMessage = "some error";
            Mock<IWarehouseRepository> mockRepository = new Mock<IWarehouseRepository>();
            mockRepository.Setup(_ => _.DeleteById(It.IsAny<int>())).Throws(new Exception(errorMessage));

            var sut = new WarehouseController(mockLogger.Object, mockRepository.Object);

            // Act
            var act = () => sut.DeleteById(20000);

            //Assert
            Assert.That(() => act(), Throws.TypeOf<Exception>().With.Message.EqualTo(errorMessage));
        }
    }
}