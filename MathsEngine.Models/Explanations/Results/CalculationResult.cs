using MathsEngine.Core.Explanations.Enums;
using MathsEngine.Core.Explanations.Inputs;
using MathsEngine.Core.Explanations.Steps;

namespace MathsEngine.Core.Explanations.Results;

public class CalculationResult<T>
{
    public CalculationType CalculationType { get; set; }
    public T Value { get; set; }
    public string Unit { get; set; }
    public int? DisplayedPrecision { get; set; }
    public List<CalculationInput> Inputs { get; set; }
    public List<CalculationStep> Steps { get; set; }
    public string? Summary {get; set; }

    public CalculationResult (CalculationType type, T value, string unit, int displayedPrecision,List<CalculationInput> inputs, List<CalculationStep> steps, string summary)
    {
        CalculationType =  type;
        Value = value;
        Unit = unit;
        DisplayedPrecision = displayedPrecision;
        Inputs = inputs;
        Steps = steps;
        Summary = summary;
    }
    
    public CalculationResult (CalculationType type, T value, string unit, List<CalculationInput> inputs, List<CalculationStep> steps)
    {
        CalculationType =  type;
        Value = value;
        Unit = unit;
        Inputs = inputs;
        Steps = steps;
    }
}