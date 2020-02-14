using Final.Domain.Empresas;
using Final.Domain.Envio;
using Final.Domain.Medios;
using Final.Services.Implementaciones;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FinalTests.Services
{
    [TestClass]
    public class EstafetaEnviosFactoryTest
    {
        private EstafetaEnviosFactory _estafetaEnviosFactory;

        private const string _origen = "Mérida";
        private const string _destino = "Cancún";
        private const int _distancia = 1000;
        private DateTime _fecha = new DateTime(2020, 01, 01);
        [TestInitialize]
        public void OnSetup()
        {
            Estafeta estafeta = new Estafeta();
            _estafetaEnviosFactory = new EstafetaEnviosFactory(estafeta);

        }
        [TestMethod]
        public void CreateBarcoPackage_Method_should_assign_barco_to_package()
        {
            //Arrange 
            string origen, destino;
            int distancia;
            DateTime fecha;
            SetGeneralData(out origen, out destino, out distancia, out fecha);
            //Act
            Package package = _estafetaEnviosFactory.CreateBarcoPackage(origen, destino, distancia, fecha);
            //Assert
            Assert.IsTrue(package.MedioTransporte is Barco);
        }

        [TestMethod]
        public void CreateBarcoPackage_Method_should_assign_tren_to_package()
        {
            //Arrange 
            string origen, destino;
            int distancia;
            DateTime fecha;
            SetGeneralData(out origen, out destino, out distancia, out fecha);
            //Act
            Package package = _estafetaEnviosFactory.CreateTrenPackage(origen, destino, distancia, fecha);
            //Assert
            Assert.IsTrue(package.MedioTransporte is Tren);
        }

        private static void SetGeneralData(out string origen, out string destino, out int distancia, out DateTime fecha)
        {
            origen = "Mérida";
            destino = "Cancún";
            distancia = 1000;
            fecha = new DateTime(2020, 01, 01);
        }
    }
}
