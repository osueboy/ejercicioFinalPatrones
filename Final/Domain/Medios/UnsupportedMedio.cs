namespace Final.Domain.Medios
{
    class UnsupportedMedio : IMedioTransporte
    {
        public string Name => "unsupported";
        public double Speed => 0;
        public decimal CostPerKilometer => 0;
    }
}
