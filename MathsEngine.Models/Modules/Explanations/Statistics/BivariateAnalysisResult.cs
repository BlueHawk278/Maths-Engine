using System.Text;
namespace MathsEngine.Core.Modules.Explanations.Statistics;

public class BivariateAnalysisResult
{
    public List<double> Ranks1 { get; private set; }
    public List<double> Ranks2 { get; private set; }

    public List<double> Difference { get; private set; }
    public List<double> DifferenceSquared { get; private set; }
    public double SumDifferenceSquared { get; private set; }
    public double Correlation { get; set; }

    public IReadOnlyList<string> Steps { get; }

    public BivariateAnalysisResult(List<double> ranks1, List<double> ranks2, 
        List<double> difference, List<double> differenceSquared, double sumDifferenceSquared, double correlationCoefficient, IReadOnlyList<string> steps)
    {
        Ranks1 = ranks1;
        Ranks2 = ranks2;
        Difference = difference;
        DifferenceSquared = differenceSquared;
        SumDifferenceSquared = sumDifferenceSquared;
        Correlation = correlationCoefficient;
        Steps = steps;
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