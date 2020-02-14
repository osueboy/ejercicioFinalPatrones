using Final.Domain.Empresas;
using Final.Domain.Envio;
using Final.Domain.Medios;
using Final.Services.Interfaces;
using System;

namespace Final.Services.Implementaciones
{
    public class FedexEnviosFactory : ICreateBarcoFactory
    {
        public IDeliveryCompany DeliveryCompany { get; }

        public FedexEnviosFactory(Fedex fedex)
        {
            DeliveryCompany = fedex;
        }
        public Package CreateBarcoPackage(string origen, string destino, int distancia, DateTime fecha)
        {
            return new Package()
            {
                Origen = origen,
                Destino = destino,
                Distancia = distancia,
                FechaRecepcion = fecha,
                Empresa = DeliveryCompany,
                MedioTransporte = new Barco()
            };
        }
    }
}
