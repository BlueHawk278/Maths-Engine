using MathsEngine.Core.Explanations.Models.Abstractions;

namespace MathsEngine.Core.Explanations.Models.Components;

public class CalculationInput : ICalculationItem
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

    public string ToString()
    {
        return string.IsNullOrWhiteSpace(Unit) ? $"{Name}: {Value}" : $"{Name}: {Value} {Unit}";
    }
}