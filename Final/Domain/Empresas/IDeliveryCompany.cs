using System.Collections.Generic;

namespace Final.Domain.Empresas
{
    public interface IDeliveryCompany
    {
        string Name { get; }
        double Margin { get; }
        IReadOnlyList<string> TransportesDisponibles { get; }
    }
}
