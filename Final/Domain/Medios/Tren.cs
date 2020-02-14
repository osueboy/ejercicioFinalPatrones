namespace Final.Domain.Medios
{
    public class Tren : IMedioTransporte
    {
        public string Name => TiposTransporte.Tren;
        public double Speed => 80;
        public decimal CostPerKilometer => 5;
    }
}
