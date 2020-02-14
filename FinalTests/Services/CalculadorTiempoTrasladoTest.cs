using Final.Domain;
using Final.Domain.Envio;
using Final.Domain.Medios;
using Final.Services.Implementaciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FinalTests.Services
{
    [TestClass]
    public class CalculadorTiempoTrasladoTest
    {
        private CalculadorTiempoTraslado _calculadorTiempoTraslado;

        [TestInitialize]
        public void OnSetup()
        {
            _calculadorTiempoTraslado = new CalculadorTiempoTraslado();
        }
        [TestMethod]
        public void Calcular_Method_with_package_should_return_datespan_according_to_formula()
        {
            IMedioTransporte transporte = new Barco();
            //Velocidad del barco, 46 km/hora
            //Distancia 92 (46 x 2)
            double distance = 92;
            Package package = new Package()
            {
                Distancia = distance,
                MedioTransporte = transporte
            };

            TimeSpan response = _calculadorTiempoTraslado.Calcular(package);
            //Tiempo de traslado debe ser 2 horas
            Assert.AreEqual(new TimeSpan(2, 0, 0), response);
        }

        [TestMethod]
        public void Calcular_Method_with_package_should_throw_exception_when_package_is_null()
        {
            //Arrange
            Package package = null;
            //Act - Assert
            Assert.ThrowsException<ArgumentNullException>(() => _calculadorTiempoTraslado.Calcular(package));
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        public void Calcular_Method_with_values_should_throw_exception_when_distance_is_not_positive(double distance)
        {
            //Arrange
            double speed = 100;
            //Act 
            Exception exception = Assert.ThrowsException<Exception>(() => _calculadorTiempoTraslado.Calcular(distance, speed));
            //Assert
            Assert.AreEqual(CalculadorTiempoTraslado.ExceptionMessageNonPositiveDistance, exception.Message);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        public void Calcular_Method_with_values_should_throw_exception_when_speed_is_not_positive(double speed)
        {
            //Arrange
            double distance = 100;
            //Act 
            Exception exception = Assert.ThrowsException<Exception>(() => _calculadorTiempoTraslado.Calcular(distance, speed));
            //Assert
            Assert.AreEqual(CalculadorTiempoTraslado.ExceptionMessageNonPositiveSpeed, exception.Message);
        }
    }
}
