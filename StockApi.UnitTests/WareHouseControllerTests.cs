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
        public void GetAll_WhenOk_ReturnsResult()
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
            //Assert.Throws<Exception>(() => act(), "some other error message");
            Assert.That(() => act(), Throws.TypeOf<Exception>().With.Message.EqualTo(errorMessage));
        }
    }
}