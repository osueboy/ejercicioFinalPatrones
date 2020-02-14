namespace Final.Domain
{
    public interface IMedioTransporte
    {
        string Name { get; }
        double Speed { get; }
        decimal CostPerKilometer { get; }
    }
}
