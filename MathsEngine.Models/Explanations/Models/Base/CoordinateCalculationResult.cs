using MathsEngine.Modules.Pure.CoordinateGeometry;

namespace MathsEngine.Core.Explanations.Models.Base;

public class CoordinateCalculationResult : BaseCalculationResult
{
    public Coordinate CoordinateValue { get; }

    public CoordinateCalculationResult(Coordinate coordinate, List<string> steps) : base(steps)
    {
        CoordinateValue = coordinate;
    }
}