using MathsEngine.Core.Explanations.Results;
using MathsEngine.Core.Measurement.Units.Geometry.Area;
using MathsEngine.Core.Measurement.Units.Geometry.Volume;

namespace MathsEngine.Core.Geometry.Abstractions;

public abstract class Shape3D : Shape
{
    public abstract CalculationResult<Volume> CalculateVolume();

    public abstract CalculationResult<Area> CalculateSurfaceArea();
}