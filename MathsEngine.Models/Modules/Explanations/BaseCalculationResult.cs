using System.Text;

namespace MathsEngine.Core.Modules.Explanations;

public abstract class BaseCalculationResult
{
    public IReadOnlyList<string> Steps { get; }

    protected BaseCalculationResult(List<string> steps)
    {
        Steps = steps?.AsReadOnly() ?? new List<string>().AsReadOnly();
    }

    /// <summary>
    /// Returns all steps as a single formatted string.
    /// </summary>
    public string GetStepsAsString()
    {
        var builder = new StringBuilder();
        foreach (var step in Steps)
        {
            builder.AppendLine(step);
        }
        return builder.ToString();
    }
}
