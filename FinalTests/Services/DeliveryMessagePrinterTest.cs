using Final.Domain.Envio;
using Final.Services.Implementaciones;
using Final.Services.Interfaces;
using Final.Services.Messages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace FinalTests.Services
{
    [TestClass]
    public class DeliveryMessagePrinterTest
    {
        private DeliveryMessagePrinter _deliveryMessagePrinter;
        private Mock<IPrintStrategy> _printStrategyMock;
        [TestInitialize]
        public void OnSetup()
        {
            _printStrategyMock = new Mock<IPrintStrategy>();
            _deliveryMessagePrinter = new DeliveryMessagePrinter();

        }

        [TestMethod]
        public void PrintMessage_Method_should_call_strategy_print()
        {
            //Arrange 
            _deliveryMessagePrinter.PrintStrategy = _printStrategyMock.Object;
            _printStrategyMock.Setup(x => x.Print(It.IsAny<Package>(), It.IsAny<PackageStatusResponse>()));
            Package package = new Package();
            PackageStatusResponse packageStatusResponse = new PackageStatusResponse();

            //Act
            _deliveryMessagePrinter.PrintMessage(package, packageStatusResponse);
            //Assert
            _printStrategyMock.Verify(x => x.Print(package, packageStatusResponse), Times.Once);
        }

        [TestMethod]
        public void PrintMessage_Method_should_throw_exception_when_strategy_is_null()
        {
            //Arrange 
            _deliveryMessagePrinter.PrintStrategy = null;
            Package package = new Package();
            PackageStatusResponse packageStatusResponse = new PackageStatusResponse();

            //Act
            Assert.ThrowsException<Exception>( () => _deliveryMessagePrinter.PrintMessage(package, packageStatusResponse));
            //Assert

        }
    }
}
