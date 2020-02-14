using Final.Domain.Envio;
using System;

namespace Final.Services.Interfaces
{
    public interface ICreateBarcoFactory : IEnvioFactory
    {
        Package CreateBarcoPackage(string origen, string destino, int distancia, DateTime fecha);
    }
}
