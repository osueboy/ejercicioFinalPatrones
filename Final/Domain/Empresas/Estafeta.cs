using System.Collections.Generic;

namespace Final.Domain.Empresas
{
    public class Estafeta : IDeliveryCompany
    {
        public double Margin => 20;

        private List<string> _transportesDisponibles = new List<string>();
        public IReadOnlyList<string> TransportesDisponibles => _transportesDisponibles;

        public string Name => EmpresasDeTransporte.Estafeta;

        public Estafeta()
        {
            _transportesDisponibles.Add(TiposTransporte.Tren);
            _transportesDisponibles.Add(TiposTransporte.Barco);
        }
    }
}
