namespace MathsEngine.Core.Explanations.Inputs;

public class CalculationInput
{
    public string Name { get; set; }
    public double Value { get; set; }
    public string? Unit { get; set; }
    public string? Symbol { get; set; }

    public CalculationInput(string name, double value, string unit, string symbol)
    {
        Name = name;
        Value = value;
        Unit = unit;
        Symbol = symbol;
    }
    
    public CalculationInput(string name, double value, string unit)
    {
        Name = name;
        Value = value;
    }
}