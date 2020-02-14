using Final.Domain.Empresas;
using Final.Domain.Envio;
using System;

namespace Final.Services.Interfaces
{
    public interface ICalculadorTiempoTraslado
    {
        TimeSpan Calcular(Package package);
    }
}
