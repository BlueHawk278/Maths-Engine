namespace MathsEngine.Core.Measurement.Units;

public interface IUnit
{
    string Symbol { get; }
    double ScaleFactor { get; }
}