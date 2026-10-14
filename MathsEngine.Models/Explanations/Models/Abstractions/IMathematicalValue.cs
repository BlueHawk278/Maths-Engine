using MathsEngine.Core.Measurement.Units;

namespace MathsEngine.Core.Explanations.Models.Abstractions;

public interface IMathematicalValue
{
    public double Value { get; }
    public IUnit Unit { get; }
}