using Final.Domain.Empresas;
using Final.Domain.Envio;
using Final.Domain.Medios;
using Final.Services.Interfaces;
using System;

namespace Final.Services.Implementaciones
{
    public class EstafetaEnviosFactory : ICreateTrenFactory, ICreateBarcoFactory
    {
        public IDeliveryCompany DeliveryCompany { get; }
        public EstafetaEnviosFactory(Estafeta estafeta)
        {
            DeliveryCompany = estafeta;
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

        public Package CreateTrenPackage(string origen, string destino, int distancia, DateTime fecha)
        {
            return new Package()
            {
                Origen = origen,
                Destino = destino,
                Distancia = distancia,
                FechaRecepcion = fecha,
                Empresa = DeliveryCompany,
                MedioTransporte = new Tren()
            };
        }
    }
}
