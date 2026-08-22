namespace MathsEngine.Core.Explanations.Steps;

public class CalculationStep
{
    public string Title { get; set; }
    public string? Formula { get; set; }
    public string? Substitution { get; set; }
    public string? Result { get; set; }
    public string? Note { get; set; }

    public CalculationStep(string title, string? formula = null, string? substitution = null, string? result = null, string? note = null)
    {
        Title = title;
        Formula = formula;
        Substitution = substitution;
        Result = result;
        Note = note;
    }
}