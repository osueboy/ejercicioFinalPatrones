using Final.Domain.Envio;
using System;

namespace Final.Services.Interfaces
{
    public interface IDeliveryService
    {
        DateTime FechaEsperada(Package package);
        TimeSpan TiempoDeEntrega(Package package);


    }
}
