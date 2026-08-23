using MathsEngine.Core.Explanations.Results;
using MathsEngine.Core.Measurement.Units.Geometry.Area;
using MathsEngine.Core.Measurement.Units.Geometry.Length;

namespace MathsEngine.Core.Geometry.Abstractions;

public abstract class Shape2D : Shape
{
    public abstract CalculationResult<Area> CalculateArea();

    public abstract CalculationResult<Length> CalculatePerimeter();
}