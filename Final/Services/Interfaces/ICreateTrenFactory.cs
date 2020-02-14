using Final.Domain.Envio;
using System;

namespace Final.Services.Interfaces
{
    public interface ICreateTrenFactory : IEnvioFactory
    {
        Package CreateTrenPackage(string origen, string destino, int distancia, DateTime fecha);
    }
}
