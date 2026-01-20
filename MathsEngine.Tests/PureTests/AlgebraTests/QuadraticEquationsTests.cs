using MathsEngine.Modules.Pure.Algebra;
using Xunit;

namespace MathsEngine.Tests.PureTests.AlgebraTests;

/// <summary>
/// Example tests for QuadraticEquations demonstrating the testing pattern.
/// These are foundational examples - a full implementation would have more comprehensive tests.
/// </summary>
public class QuadraticEquationsTests
{
    [Theory]
    [InlineData(1, -5, 6, 3, 2)]        // x² - 5x + 6 = 0 → x = 3, x = 2
    [InlineData(1, -7, 10, 5, 2)]       // x² - 7x + 10 = 0 → x = 5, x = 2
    [InlineData(2, 3, -2, 0.5, -2)]     // 2x² + 3x - 2 = 0
    public void Solve_QuadraticWithTwoRoots_ReturnsCorrectRoots(
        double a, double b, double c,
        double expectedRoot1, double expectedRoot2)
    {
        var result = QuadraticEquations.Solve(a, b, c);

        Assert.Equal(2, result.NumberOfRealRoots);
        Assert.True(result.Root1.HasValue);
        Assert.True(result.Root2.HasValue);
        
        // Check both orderings since roots can be in either order
        bool correctOrder = 
            (Math.Abs(result.Root1.Value - expectedRoot1) < 1e-9 && 
             Math.Abs(result.Root2.Value - expectedRoot2) < 1e-9) ||
            (Math.Abs(result.Root1.Value - expectedRoot2) < 1e-9 && 
             Math.Abs(result.Root2.Value - expectedRoot1) < 1e-9);
        
        Assert.True(correctOrder);
    }

    [Theory]
    [InlineData(1, -4, 4, 2)]    // x² - 4x + 4 = 0 → x = 2 (repeated)
    [InlineData(1, 2, 1, -1)]    // x² + 2x + 1 = 0 → x = -1 (repeated)
    public void Solve_QuadraticWithRepeatedRoot_ReturnsSingleRoot(
        double a, double b, double c,
        double expectedRoot)
    {
        var result = QuadraticEquations.Solve(a, b, c);

        Assert.Equal(1, result.NumberOfRealRoots);
        Assert.True(result.HasRepeatedRoot);
        Assert.Equal(expectedRoot, result.Root1.Value, precision: 6);
    }

    [Theory]
    [InlineData(1, 0, 1)]    // x² + 1 = 0 (no real roots)
    [InlineData(1, 1, 1)]    // x² + x + 1 = 0 (no real roots)
    public void Solve_QuadraticWithNoRealRoots_ReturnsComplexIndicator(
        double a, double b, double c)
    {
        var result = QuadraticEquations.Solve(a, b, c);

        Assert.Equal(0, result.NumberOfRealRoots);
        Assert.True(result.HasComplexRoots);
        Assert.Null(result.Root1);
        Assert.Null(result.Root2);
    }

    [Fact]
    public void Solve_ZeroCoefficient_ThrowsNotQuadraticException()
    {
        Assert.Throws<NotQuadraticException>(() =>
            QuadraticEquations.Solve(0, 2, 1));
    }

    [Theory]
    [InlineData(1, 6, 5, 1, -3, -4)]     // x² + 6x + 5 → (x + 3)² - 4
    [InlineData(1, 4, 4, 1, -2, 0)]      // x² + 4x + 4 → (x + 2)²
    [InlineData(2, -8, 3, 2, 2, -5)]     // 2x² - 8x + 3 → 2(x - 2)² - 5
    public void CompleteTheSquare_ValidQuadratic_ReturnsCorrectForm(
        double a, double b, double c,
        double expectedA, double expectedH, double expectedK)
    {
        var result = QuadraticEquations.CompleteTheSquare(a, b, c);

        Assert.Equal(expectedA, result.A, precision: 6);
        Assert.Equal(expectedH, result.H, precision: 6);
        Assert.Equal(expectedK, result.K, precision: 6);
    }

    [Theory]
    [InlineData(1, -4, 3, 2, -1)]    // x² - 4x + 3, vertex at (2, -1)
    [InlineData(1, 0, 0, 0, 0)]      // x², vertex at origin
    public void FindVertex_ValidQuadratic_ReturnsCorrectVertex(
        double a, double b, double c,
        double expectedX, double expectedY)
    {
        var vertex = QuadraticEquations.FindVertex(a, b, c);

        Assert.Equal(expectedX, vertex.x, precision: 6);
        Assert.Equal(expectedY, vertex.y, precision: 6);
    }

    [Theory]
    [InlineData(1, 5, 6, true)]      // x² + 5x + 6, discriminant = 1 > 0
    [InlineData(1, 2, 3, false)]     // x² + 2x + 3, discriminant = -8 < 0
    [InlineData(1, 2, 1, true)]      // x² + 2x + 1, discriminant = 0
    public void HasRealRoots_VariousQuadratics_ReturnsCorrectValue(
        double a, double b, double c,
        bool expectedHasRoots)
    {
        bool result = QuadraticEquations.HasRealRoots(a, b, c);

        Assert.Equal(expectedHasRoots, result);
    }

    [Theory]
    [InlineData(2, -3, 1, 2, 3)]     // 2x² - 3x + 1 at x = 2 → 2(4) - 3(2) + 1 = 3
    [InlineData(1, 0, 0, 5, 25)]     // x² at x = 5 → 25
    public void Evaluate_ValidInput_ReturnsCorrectValue(
        double a, double b, double c, double x,
        double expected)
    {
        double result = QuadraticEquations.Evaluate(a, b, c, x);

        Assert.Equal(expected, result, precision: 6);
    }
}
