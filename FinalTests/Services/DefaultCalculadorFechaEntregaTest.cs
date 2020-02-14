using Final.Domain.Envio;
using Final.Services.Implementaciones;
using Final.Services.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace FinalTests.Services
{
    [TestClass]
    public class DefaultCalculadorFechaEntregaTest
    {
        private DefaultCalculadorFechaEntrega _defaultCalculadorFechaEntrega;
        private Mock<ICalculadorTiempoTraslado> _calculadorTiempoTraslado;
        [TestInitialize]
        public void OnSetup()
        {
            _calculadorTiempoTraslado = new Mock<ICalculadorTiempoTraslado>();
            _defaultCalculadorFechaEntrega = new DefaultCalculadorFechaEntrega(_calculadorTiempoTraslado.Object);
            _calculadorTiempoTraslado.Setup(x => x.Calcular(It.IsAny<Package>())).Returns(new TimeSpan(10, 0, 0));
        }
        [TestMethod]
        public void GetFechaEntrega_Method_throws_null_argument_exception_when_receives_null_package()
        {
            //Arrange
            Package package = null; 
            //Act - Assert
            Assert.ThrowsException<ArgumentNullException>(() => _defaultCalculadorFechaEntrega.GetFechaEntrega(package));

        }
        [TestMethod]
        public void GetFechaEntrega_Method_calls_calcular_with_package()
        {

            //Arrange
            Package package = new Package() { FechaRecepcion = new DateTime() };
            //Act
            _defaultCalculadorFechaEntrega.GetFechaEntrega(package);
            //Assert
            _calculadorTiempoTraslado.Verify(x => x.Calcular(package), Times.Once);
        }
        [TestMethod]
        public void GetFechaEntrega_Method_adds_timespan_to_date()
        {
            //Arrange
            DateTime fechaRecepcion = new DateTime(2020, 2, 10, 0, 0, 0);
            int horasAdicionales = 10;
            _calculadorTiempoTraslado.Setup(x => x.Calcular(It.IsAny<Package>())).Returns(new TimeSpan(horasAdicionales, 0, 0));
            Package package = new Package() { FechaRecepcion = fechaRecepcion };
            //Act
            DateTime fechaEntrega = _defaultCalculadorFechaEntrega.GetFechaEntrega(package);
            //Assert
            Assert.AreEqual(new DateTime(2020, 2, 10, 10, 0, 0), fechaEntrega);

        }
    }
}
