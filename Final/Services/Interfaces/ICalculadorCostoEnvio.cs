using Final.Domain.Envio;

namespace Final.Services.Interfaces
{
    public interface ICalculadorCostoEnvio
    {
        decimal ObtenerCostoEnvio(Package package);
    }
}
