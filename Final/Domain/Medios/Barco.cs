namespace Final.Domain.Medios
{
    public class Barco : IMedioTransporte
    {
        public string Name => TiposTransporte.Barco;
        public double Speed =>46;
        public decimal CostPerKilometer => 1;
    }
}
