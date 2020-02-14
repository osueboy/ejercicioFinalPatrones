using Final.Domain.Empresas;
using Final.Domain.Envio;
using Final.Services.Interfaces;
using System;
using System.Linq;

namespace Final.Services.Implementaciones
{
    public class RecomendacionReporteadorPedidosDecorator : BaseReporteadorDePedidos
    {
        private readonly IReporteadorDePedidos _principal;
        private readonly IPackageRepository _packageRepository;
        private readonly ICalculadorCostoEnvio _calculadorCostoEnvio;
        public RecomendacionReporteadorPedidosDecorator(IReporteadorDePedidos principal, IPackageRepository packageRepository, ICalculadorCostoEnvio calculadorCostoEnvio)
        {
            _principal = principal;
            _packageRepository = packageRepository;
            _calculadorCostoEnvio = calculadorCostoEnvio;
        }
        public override void ReportAll()
        {
            SetPackages(_packageRepository.GetPackages());
            foreach (Package package in _packages)
            {
                ReportPackage(package);
            }
        }

        public override void ReportPackage(Package package)
        {
            _principal.ReportPackage(package);
            //Recomendacion

            decimal lowestPrice = _calculadorCostoEnvio.ObtenerCostoEnvio(package);
            IDeliveryCompany lowestCompany = package.Empresa;
            foreach(IDeliveryCompany empresa in _deliveryCompanies.Values)
            {
                if(package.Empresa.Name != empresa.Name && empresa.TransportesDisponibles.Contains(package.MedioTransporte.Name))
                {
                    decimal price = _calculadorCostoEnvio.ObtenerCostoEnvio(new Package()
                    {
                        Distancia = package.Distancia,
                        Empresa = empresa,
                        MedioTransporte = package.MedioTransporte
                    });
                    if(price < lowestPrice)
                    {
                        lowestCompany = empresa;
                        lowestPrice = price;
                    }
                }
            }
            if(lowestCompany.Name != package.Empresa.Name)
            {
                Console.WriteLine(string.Format("Si hubieras pedido en {0} te hubiera costado({1})", lowestCompany.Name, lowestPrice));
            }
        }
    }
}
