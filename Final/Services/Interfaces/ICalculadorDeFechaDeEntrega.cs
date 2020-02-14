using Final.Domain.Envio;
using System;

namespace Final.Services.Interfaces
{
    public interface ICalculadorDeFechaDeEntrega
    {
        DateTime GetFechaEntrega(Package package);
    }
}
