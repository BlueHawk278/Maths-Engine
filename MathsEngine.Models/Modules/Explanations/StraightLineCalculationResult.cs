using MathsEngine.Modules.Pure.CoordinateGeometry;

namespace MathsEngine.Core.Modules.Explanations;

public class StraightLineCalculationResult : BaseCalculationResult
{
    public StraightLine StraightLineValue { get; }

    public StraightLineCalculationResult(StraightLine straightLine, List<string> steps) : base(steps)
    {
        StraightLineValue = straightLine;
    }
}