using Final.Domain;
using Final.Domain.Empresas;
using Final.Domain.Envio;
using Final.Domain.Medios;
using Final.Services.Interfaces;
using System;

namespace Final.Services.Implementaciones
{
    public class DhlEnviosFactory : ICreateAvionFactory, ICreateBarcoFactory
    {
        public IDeliveryCompany DeliveryCompany { get; }

        public DhlEnviosFactory(Dhl dhl)
        {
            DeliveryCompany = dhl;
        }
        public Package CreateAvionPackage(string origen, string destino, int distancia, DateTime fecha)
        {
            return new Package()
            {
                Origen = origen,
                Destino = destino,
                Distancia = distancia,
                FechaRecepcion = fecha,
                Empresa = DeliveryCompany,
                MedioTransporte = new Avion()
            };
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
