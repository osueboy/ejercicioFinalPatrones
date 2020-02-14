using Final.Domain.Envio;
using System;

namespace Final.Services.Interfaces
{
    public interface ICreateAvionFactory : IEnvioFactory
    {
        Package CreateAvionPackage(string origen, string destino, int distancia, DateTime fecha);
    }
}
