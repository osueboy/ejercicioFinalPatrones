using Final.Services.Messages;
using System;

namespace Final.Services.Interfaces
{
    public interface IRangoDeTiempoProvider
    {
        RangoResponse GetValorPorRango(TimeSpan timeSpan);
    }
}
