using System.Collections.Generic;

namespace Final.Domain.Empresas
{
    public class Fedex : IDeliveryCompany
    {
        public double Margin => 50;
        private List<string> _transportesDisponibles = new List<string>();
        public IReadOnlyList<string> TransportesDisponibles => _transportesDisponibles;

        public string Name => EmpresasDeTransporte.Fedex;

        public Fedex()
        {
            _transportesDisponibles.Add(TiposTransporte.Barco);
        }
    }
}
