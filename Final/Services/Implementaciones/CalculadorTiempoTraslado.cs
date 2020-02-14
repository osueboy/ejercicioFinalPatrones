using Final.Domain.Envio;
using Final.Services.Interfaces;
using System;

namespace Final.Services.Implementaciones
{
    public class CalculadorTiempoTraslado : ICalculadorTiempoTraslado
    {
        public const string ExceptionMessageNonPositiveDistance = "La distancia debe ser positiva";
        public const string ExceptionMessageNonPositiveSpeed = "La velocidad debe ser positiva";
        public TimeSpan Calcular(Package package)
        {
            if(package == null)
            {
                throw new ArgumentNullException(typeof(Package).Name);
            }
            //[Distancia] / la velocidad del[Medio de Transporte]
            //Los medios estan en kilometros por hora
            return Calcular(package.Distancia, package.MedioTransporte.Speed);
        }

        public TimeSpan Calcular(double distancia, double speed)
        {
            if(distancia <= 0)
            {
                throw new Exception(ExceptionMessageNonPositiveDistance);
            }

            if(speed <= 0)
            {
                throw new Exception(ExceptionMessageNonPositiveSpeed);
            }

            double horas = distancia / speed;
            int minutos = (int)horas * 60;
            return new TimeSpan(0, 0, minutos, 0, 0);
        }
    }
}
