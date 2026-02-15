using Xunit;
using MathsEngine.Modules.Explanations;
using MathsEngine.Modules.Explanations.Statistics;

namespace MathsEngine.Tests.ExplanationsTests.StatisticsTests;

public class BivariateAnalysisTutorTests
{
    [Fact]
    public void CalculateSpearmanRankWithSteps_PerfectPositiveCorrelation_ReturnsOne()
    {
        // Arrange
        var scores1 = new List<double> { 10, 20, 30, 40, 50 };
        var scores2 = new List<double> { 15, 25, 35, 45, 55 };

        // Act
        var result = BivariateAnalysisTutor.CalculateSpearmanRankWithSteps(scores1, scores2);

        // Assert
        Assert.Equal(1.0, result.Value, 2);
        Assert.False(result.IsMatrix);
    }

    [Fact]
    public void CalculateSpearmanRankWithSteps_PerfectNegativeCorrelation_ReturnsNegativeOne()
    {
        // Arrange
        var scores1 = new List<double> { 10, 20, 30, 40, 50 };
        var scores2 = new List<double> { 50, 40, 30, 20, 10 };

        // Act
        var result = BivariateAnalysisTutor.CalculateSpearmanRankWithSteps(scores1, scores2);

        // Assert
        Assert.Equal(-1.0, result.Value, 2);
        Assert.False(result.IsMatrix);
    }

    [Fact]
    public void CalculateSpearmanRankWithSteps_GeneratesSteps()
    {
        // Arrange
        var scores1 = new List<double> { 10, 20, 30 };
        var scores2 = new List<double> { 15, 25, 35 };

        // Act
        var result = BivariateAnalysisTutor.CalculateSpearmanRankWithSteps(scores1, scores2);

        // Assert
        Assert.NotEmpty(result.Steps);
        string stepsText = result.GetStepsAsString();
        Assert.Contains("Step 1", stepsText);
        Assert.Contains("Rank", stepsText);
        Assert.Contains("difference", stepsText, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("Spearman", stepsText);
    }

    [Fact]
    public void CalculateSpearmanRankWithSteps_IncludesRankingDetails()
    {
        // Arrange
        var scores1 = new List<double> { 5, 10, 15 };
        var scores2 = new List<double> { 8, 12, 16 };

        // Act
        var result = BivariateAnalysisTutor.CalculateSpearmanRankWithSteps(scores1, scores2);

        // Assert
        string stepsText = result.GetStepsAsString();
        Assert.Contains("Ranks for Data Set 1", stepsText);
        Assert.Contains("Ranks for Data Set 2", stepsText);
    }

    [Fact]
    public void CalculateSpearmanRankWithSteps_ShowsDifferenceCalculations()
    {
        // Arrange
        var scores1 = new List<double> { 1, 2, 3 };
        var scores2 = new List<double> { 3, 2, 1 };

        // Act
        var result = BivariateAnalysisTutor.CalculateSpearmanRankWithSteps(scores1, scores2);

        // Assert
        string stepsText = result.GetStepsAsString();
        Assert.Contains("difference in ranks", stepsText, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("d²", stepsText);
    }

    [Fact]
    public void CalculateSpearmanRankWithSteps_IncludesFormula()
    {
        // Arrange
        var scores1 = new List<double> { 10, 20, 30 };
        var scores2 = new List<double> { 12, 22, 32 };

        // Act
        var result = BivariateAnalysisTutor.CalculateSpearmanRankWithSteps(scores1, scores2);

        // Assert
        string stepsText = result.GetStepsAsString();
        Assert.Contains("rs = 1 -", stepsText);
        Assert.Contains("6Σd²", stepsText);
    }

    [Fact]
    public void CalculateSpearmanRankWithSteps_IncludesInterpretation()
    {
        // Arrange
        var scores1 = new List<double> { 10, 20, 30, 40 };
        var scores2 = new List<double> { 15, 25, 35, 45 };

        // Act
        var result = BivariateAnalysisTutor.CalculateSpearmanRankWithSteps(scores1, scores2);

        // Assert
        string stepsText = result.GetStepsAsString();
        Assert.Contains("Interpret", stepsText);
        Assert.Contains("correlation", stepsText, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void CalculateSpearmanRankWithSteps_WeakCorrelation()
    {
        // Arrange - specific values
        var scores1 = new List<double> { 1, 2, 3, 4, 5 };
        var scores2 = new List<double> { 3, 1, 5, 2, 4 };

        // Act
        var result = BivariateAnalysisTutor.CalculateSpearmanRankWithSteps(scores1, scores2);

        // Assert - just verify it returns a valid correlation coefficient
        Assert.InRange(result.Value, -1.0, 1.0);
        Assert.NotEmpty(result.Steps);
    }
}
