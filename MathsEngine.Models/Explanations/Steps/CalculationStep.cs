namespace MathsEngine.Core.Explanations.Steps;

public class CalculationStep
{
    public string Title { get; set; }
    public string Formula { get; set; }
    public string Substitution { get; set; }
    public string Result { get; set; }
    public string? Note { get; set; }
    
    public CalculationStep(string title, string formula, string substitution, string result,  string note)
    {
        Title = title;
        Formula = formula;
        Substitution = substitution;
        Result = result;
        Note = note;
    }
    
    public CalculationStep(string title, string formula, string substitution, string result)
    {
        Title = title;
        Formula = formula;
        Substitution = substitution;
        Result = result;
    }
}