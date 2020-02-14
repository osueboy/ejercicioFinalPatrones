using Final.Domain.Empresas;

namespace Final.Services.Interfaces
{
    public interface IEnvioFactory
    {
        IDeliveryCompany DeliveryCompany { get; }
    }
}
