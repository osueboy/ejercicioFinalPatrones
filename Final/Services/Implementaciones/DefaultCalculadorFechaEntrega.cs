using Final.Domain.Envio;
using Final.Services.Interfaces;
using System;

namespace Final.Services.Implementaciones
{
    public class DefaultCalculadorFechaEntrega : ICalculadorDeFechaDeEntrega
    {
        ICalculadorTiempoTraslado _calculadorTiempoTraslado;
        public DefaultCalculadorFechaEntrega(ICalculadorTiempoTraslado calculadorTiempoTraslado)
        {
            _calculadorTiempoTraslado = calculadorTiempoTraslado;
        }
        public DateTime GetFechaEntrega(Package package)
        {
            if(package == null)
            {
                throw new ArgumentNullException(typeof(Package).Name);
            }
            //= [Fecha y hora de pedido] + Tiempo de traslado
            DateTime fechaRecepcion = package.FechaRecepcion;
            TimeSpan tiempoTraslado = _calculadorTiempoTraslado.Calcular(package);
            return fechaRecepcion.Add(tiempoTraslado);
        }
    }
}
