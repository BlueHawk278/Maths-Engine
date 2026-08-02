namespace MathsEngine.Core.Measurement.Units.Area;

public readonly struct AreaUnit
{
    public string Symbol { get; }
    public double ScaleFactor { get; }

    public AreaUnit(string symbol, double scaleFactor)
    {
        Symbol = symbol;
        ScaleFactor = scaleFactor;
    }

    public static readonly AreaUnit SquareMillimeter = new AreaUnit("mm²", 0.000001);
    public static readonly AreaUnit SquareCentimeter = new AreaUnit("cm²", 0.0001);
    public static readonly AreaUnit SquareMeter = new AreaUnit("m²", 1.0);
    public static readonly AreaUnit SquareKilometer = new AreaUnit("km²", 1_000_000.0);
}