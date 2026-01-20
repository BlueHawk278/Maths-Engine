using MathsEngine.Modules.Pure.Algebra;
using Xunit;

namespace MathsEngine.Tests.PureTests.AlgebraTests;

/// <summary>
/// Example tests for LinearEquations demonstrating the testing pattern.
/// These are foundational examples - a full implementation would have more comprehensive tests.
/// </summary>
public class LinearEquationsTests
{
    [Theory]
    [InlineData(1, 2, 3, 6, 2, 0)]   // Points (1, 2) and (3, 6) → y = 2x
    [InlineData(0, 5, 2, 5, 0, 5)]   // Points (0, 5) and (2, 5) → y = 5 (horizontal)
    [InlineData(0, 0, 1, 3, 3, 0)]   // Points (0, 0) and (1, 3) → y = 3x
    public void FromTwoPoints_ValidPoints_ReturnsCorrectLine(
        double x1, double y1, double x2, double y2,
        double expectedSlope, double expectedIntercept)
    {
        var line = LinearEquations.FromTwoPoints(x1, y1, x2, y2);

        Assert.False(line.IsVertical);
        Assert.Equal(expectedSlope, line.Slope, precision: 6);
        Assert.Equal(expectedIntercept, line.Intercept, precision: 6);
    }

    [Theory]
    [InlineData(2, 5, 3, 3, -1)]     // Point (2, 5), slope 3 → y = 3x - 1
    [InlineData(0, 0, 2, 2, 0)]      // Point (0, 0), slope 2 → y = 2x
    [InlineData(1, 4, -1, -1, 5)]    // Point (1, 4), slope -1 → y = -x + 5
    public void FromPointAndSlope_ValidInput_ReturnsCorrectLine(
        double x, double y, double slope,
        double expectedSlope, double expectedIntercept)
    {
        var line = LinearEquations.FromPointAndSlope(x, y, slope);

        Assert.Equal(expectedSlope, line.Slope, precision: 6);
        Assert.Equal(expectedIntercept, line.Intercept, precision: 6);
    }

    [Theory]
    [InlineData(2, 3, -1, 9, 2, 7)]  // y = 2x + 3 and y = -x + 9 intersect at (2, 7)
    [InlineData(1, 0, -1, 2, 1, 1)]  // y = x and y = -x + 2 intersect at (1, 1)
    public void FindIntersection_IntersectingLines_ReturnsCorrectPoint(
        double m1, double c1, double m2, double c2,
        double expectedX, double expectedY)
    {
        var line1 = new LinearEquation(m1, c1);
        var line2 = new LinearEquation(m2, c2);

        var intersection = LinearEquations.FindIntersection(line1, line2);

        Assert.Equal(expectedX, intersection.x, precision: 6);
        Assert.Equal(expectedY, intersection.y, precision: 6);
    }

    [Fact]
    public void FindIntersection_ParallelLines_ThrowsException()
    {
        var line1 = new LinearEquation(2, 3);  // y = 2x + 3
        var line2 = new LinearEquation(2, 5);  // y = 2x + 5 (parallel)

        Assert.Throws<ParallelLinesException>(() =>
            LinearEquations.FindIntersection(line1, line2));
    }

    [Fact]
    public void FindIntersection_IdenticalLines_ThrowsException()
    {
        var line1 = new LinearEquation(2, 3);  // y = 2x + 3
        var line2 = new LinearEquation(2, 3);  // y = 2x + 3 (identical)

        Assert.Throws<IdenticalLinesException>(() =>
            LinearEquations.FindIntersection(line1, line2));
    }

    [Theory]
    [InlineData(2, 3, 2, 5, true)]   // y = 2x + 3 and y = 2x + 5 are parallel
    [InlineData(1, 0, -1, 0, false)] // y = x and y = -x are not parallel
    [InlineData(2, 3, 2, 3, false)]  // Same line (not parallel, identical)
    public void AreParallel_VariousLines_ReturnsCorrectValue(
        double m1, double c1, double m2, double c2,
        bool expected)
    {
        var line1 = new LinearEquation(m1, c1);
        var line2 = new LinearEquation(m2, c2);

        bool result = LinearEquations.AreParallel(line1, line2);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(2, 0, -0.5, 3, true)]    // y = 2x and y = -0.5x + 3 are perpendicular
    [InlineData(1, 0, -1, 0, true)]      // y = x and y = -x are perpendicular
    [InlineData(3, 1, 3, 2, false)]      // y = 3x + 1 and y = 3x + 2 are not perpendicular
    public void ArePerpendicular_VariousLines_ReturnsCorrectValue(
        double m1, double c1, double m2, double c2,
        bool expected)
    {
        var line1 = new LinearEquation(m1, c1);
        var line2 = new LinearEquation(m2, c2);

        bool result = LinearEquations.ArePerpendicular(line1, line2);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(2, 1, 1, 3, -0.5, 3.5)]  // Perpendicular to y = 2x + 1 through (1, 3) → y = -0.5x + 3.5
    public void PerpendicularThrough_ValidInput_ReturnsCorrectLine(
        double slope, double intercept, double x, double y,
        double expectedSlope, double expectedIntercept)
    {
        var line = new LinearEquation(slope, intercept);
        
        var perpendicular = LinearEquations.PerpendicularThrough(line, x, y);

        Assert.Equal(expectedSlope, perpendicular.Slope, precision: 6);
        Assert.Equal(expectedIntercept, perpendicular.Intercept, precision: 6);
    }

    [Theory]
    [InlineData(1, 0, 3, 0, 2.121)]  // Distance from (3, 0) to y = x
    [InlineData(0, 2, 4, 2, 0)]      // Distance from (4, 2) to y = 2 (on the line)
    public void DistanceFromPoint_ValidInput_ReturnsCorrectDistance(
        double slope, double intercept, double x, double y,
        double expected)
    {
        var line = new LinearEquation(slope, intercept);
        
        double distance = LinearEquations.DistanceFromPoint(line, x, y);

        Assert.Equal(expected, distance, precision: 3);
    }

    [Theory]
    [InlineData(2, 3, 0, 3)]    // y = 2x + 3 at x = 0 → y = 3
    [InlineData(1, 0, 5, 5)]    // y = x at x = 5 → y = 5
    [InlineData(-2, 4, 1, 2)]   // y = -2x + 4 at x = 1 → y = 2
    public void Evaluate_ValidInput_ReturnsCorrectValue(
        double slope, double intercept, double x,
        double expected)
    {
        var line = new LinearEquation(slope, intercept);
        
        double? result = line.Evaluate(x);

        Assert.NotNull(result);
        Assert.Equal(expected, result.Value, precision: 6);
    }
}
