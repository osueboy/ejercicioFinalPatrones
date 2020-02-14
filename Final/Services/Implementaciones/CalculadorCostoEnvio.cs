using Final.Domain.Envio;
using Final.Services.Interfaces;

namespace Final.Services.Implementaciones
{
    public class CalculadorCostoEnvio : ICalculadorCostoEnvio
    {
        public decimal ObtenerCostoEnvio(Package package)
        {
            //Costo de envío = (Costo por km del [Medio de Transporte] * [Distancia]) * (1 + Margen de utilidad
            //de la[Paquetería]/ 100)

            return ((decimal)package.Distancia * package.MedioTransporte.CostPerKilometer) *
                (decimal)(1 + (package.Empresa.Margin/100));

        }
    }
}
