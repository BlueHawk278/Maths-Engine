namespace MathsEngine.Core.Explanations.Inputs;

public class CalculationInput
{
    public string Name { get; set; }
    public IMathematicalValue Value { get; set; }
    public string? Unit { get; set; }
    public string? Symbol { get; set; }

    public CalculationInput(string name, IMathematicalValue value, string? unit = null, string? symbol = null)
    {
        Name = name;
        Value = value;
        Unit = unit;
        Symbol = symbol;
    }
}