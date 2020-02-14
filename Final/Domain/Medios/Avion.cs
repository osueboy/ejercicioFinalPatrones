namespace Final.Domain
{
    public class Avion : IMedioTransporte
    {
        public string Name => TiposTransporte.Avion;
        public double Speed => 600;
        public decimal CostPerKilometer => 10;
    }
}
