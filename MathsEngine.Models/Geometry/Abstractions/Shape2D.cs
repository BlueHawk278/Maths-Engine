using MathsEngine.Core.Explanations.Results;
using MathsEngine.Core.Measurement.Units.Area;
using MathsEngine.Core.Measurement.Units.Length;

namespace MathsEngine.Core.Geometry.Abstractions;

public abstract class Shape2D : Shape
{
    public abstract CalculationResult<Area> CalculateArea();

    public abstract CalculationResult<Length> CalculatePerimeter();
}