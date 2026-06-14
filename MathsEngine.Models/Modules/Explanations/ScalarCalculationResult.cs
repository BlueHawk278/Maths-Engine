namespace MathsEngine.Core.Modules.Explanations;

public class ScalarCalculationResult : BaseCalculationResult
{
    public double Value { get; }

    public ScalarCalculationResult(double value, List<string> steps) : base(steps)
    {
        Value = value;
    }
}