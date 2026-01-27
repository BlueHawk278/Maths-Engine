using Xunit;
using MathsEngine.Modules.Explanations;
using MathsEngine.Modules.Explanations.Statistics;

namespace MathsEngine.Tests.ExplanationsTests.StatisticsTests;

public class StandardDeviationTutorTests
{
    [Fact]
    public void CalculateStandardDeviationWithSteps_SimpleDataSet_ReturnsCorrectValue()
    {
        // Arrange
        var values = new List<double> { 2, 4, 4, 4, 5, 5, 7, 9 };

        // Act
        var result = StandardDeviationTutor.CalculateStandardDeviationWithSteps(values);

        // Assert
        Assert.Equal(2.0, result.Value, 1); // Standard deviation is 2.0
        Assert.False(result.IsMatrix);
    }

    [Fact]
    public void CalculateStandardDeviationWithSteps_GeneratesSteps()
    {
        // Arrange
        var values = new List<double> { 2, 4, 4, 4, 5, 5, 7, 9 };

        // Act
        var result = StandardDeviationTutor.CalculateStandardDeviationWithSteps(values);

        // Assert
        Assert.NotEmpty(result.Steps);
        string stepsText = result.GetStepsAsString();
        Assert.Contains("Step 1", stepsText);
        Assert.Contains("mean", stepsText, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("deviation", stepsText, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("variance", stepsText, StringComparison.OrdinalIgnoreCase);
        Assert.Contains("Standard Deviation", stepsText);
    }

    [Fact]
    public void CalculateVarianceWithSteps_SimpleDataSet_ReturnsCorrectValue()
    {
        // Arrange
        var values = new List<double> { 2, 4, 4, 4, 5, 5, 7, 9 };

        // Act
        var result = StandardDeviationTutor.CalculateVarianceWithSteps(values);

        // Assert
        Assert.Equal(4.0, result.Value, 1); // Variance is 4.0
        Assert.False(result.IsMatrix);
    }
}
