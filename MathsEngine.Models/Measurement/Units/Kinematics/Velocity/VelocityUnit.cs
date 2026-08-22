namespace MathsEngine.Core.Measurement.Units.Kinematics.Velocity;

public readonly struct VelocityUnit
{
    public string Symbol { get; }
    public double ScaleFactor { get; }

    public VelocityUnit(string symbol, double scaleFactor)
    {
        Symbol = symbol;
        ScaleFactor = scaleFactor;
    }

    public static readonly VelocityUnit MetersPerSecond = new VelocityUnit("m/s", 1);
}