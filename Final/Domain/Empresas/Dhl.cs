using System.Collections.Generic;

namespace Final.Domain.Empresas
{
    public class Dhl : IDeliveryCompany
    {
        public double Margin => 40;
        private List<string> _transportesDisponibles = new List<string>();
        public IReadOnlyList<string> TransportesDisponibles => _transportesDisponibles;

        public string Name => EmpresasDeTransporte.Dhl;

        public Dhl()
        {
            _transportesDisponibles.Add(TiposTransporte.Avion);
            _transportesDisponibles.Add(TiposTransporte.Barco);
        }
    }
}
