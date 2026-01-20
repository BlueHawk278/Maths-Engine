using MathsEngine.Modules.Pure.Algebra;
using Xunit;

namespace MathsEngine.Tests.PureTests.AlgebraTests;

/// <summary>
/// Example tests for AlgebraicExpression demonstrating the testing pattern.
/// These are foundational examples showing how calculus operations would be tested.
/// </summary>
public class AlgebraicExpressionTests
{
    [Fact]
    public void Simplify_CombineLikeTerms_ReturnsSimplified()
    {
        // Arrange: 3x² + 2x + x² - x = 4x² + x
        var expr = new AlgebraicExpression();
        expr.AddTerm(3, 2);   // 3x²
        expr.AddTerm(2, 1);   // 2x
        expr.AddTerm(1, 2);   // x²
        expr.AddTerm(-1, 1);  // -x

        // Act
        var simplified = expr.Simplify();

        // Assert
        double result = simplified.Evaluate(2);  // 4(4) + 2 = 18
        Assert.Equal(18, result, precision: 6);
    }

    [Theory]
    [InlineData(2, 13)]    // 2x² + 3x - 1 at x = 2 → 8 + 6 - 1 = 13
    [InlineData(0, -1)]    // at x = 0 → -1
    [InlineData(1, 4)]     // at x = 1 → 2 + 3 - 1 = 4
    public void Evaluate_Polynomial_ReturnsCorrectValue(double x, double expected)
    {
        // Arrange: 2x² + 3x - 1
        var expr = new AlgebraicExpression();
        expr.AddTerm(2, 2);
        expr.AddTerm(3, 1);
        expr.AddTerm(-1, 0);

        // Act
        double result = expr.Evaluate(x);

        // Assert
        Assert.Equal(expected, result, precision: 6);
    }

    [Fact]
    public void Differentiate_Polynomial_ReturnsDerivative()
    {
        // Arrange: f(x) = 3x² + 2x + 1
        var f = new AlgebraicExpression();
        f.AddTerm(3, 2);   // 3x²
        f.AddTerm(2, 1);   // 2x
        f.AddTerm(1, 0);   // 1

        // Act: f'(x) = 6x + 2
        var fPrime = f.Differentiate();

        // Assert: Evaluate at x = 2
        double result = fPrime.Evaluate(2);  // 6(2) + 2 = 14
        Assert.Equal(14, result, precision: 6);
    }

    [Fact]
    public void Differentiate_Constant_ReturnsZero()
    {
        // Arrange: f(x) = 5
        var f = new AlgebraicExpression();
        f.AddTerm(5, 0);

        // Act: f'(x) = 0
        var fPrime = f.Differentiate();

        // Assert
        double result = fPrime.Evaluate(100);  // Should be 0 regardless of x
        Assert.Equal(0, result, precision: 6);
    }

    [Fact]
    public void Integrate_Polynomial_ReturnsAntiderivative()
    {
        // Arrange: f(x) = 6x + 2
        var f = new AlgebraicExpression();
        f.AddTerm(6, 1);   // 6x
        f.AddTerm(2, 0);   // 2

        // Act: F(x) = 3x² + 2x (ignoring constant of integration)
        var F = f.Integrate();

        // Assert: F(2) = 3(4) + 2(2) = 16
        double result = F.Evaluate(2);
        Assert.Equal(16, result, precision: 6);
    }

    [Fact]
    public void Integrate_Constant_ReturnsLinear()
    {
        // Arrange: f(x) = 5
        var f = new AlgebraicExpression();
        f.AddTerm(5, 0);

        // Act: F(x) = 5x
        var F = f.Integrate();

        // Assert: F(3) = 15
        double result = F.Evaluate(3);
        Assert.Equal(15, result, precision: 6);
    }

    [Fact]
    public void FromCoefficients_ValidArray_CreatesExpression()
    {
        // Arrange & Act: 2x² + 3x + 1
        var expr = AlgebraicExpressionHelpers.FromCoefficients(new[] { 2.0, 3.0, 1.0 });

        // Assert
        double result = expr.Evaluate(2);  // 2(4) + 3(2) + 1 = 15
        Assert.Equal(15, result, precision: 6);
    }

    [Fact]
    public void Monomial_CreatesSimpleExpression()
    {
        // Arrange & Act: 5x³
        var expr = AlgebraicExpressionHelpers.Monomial(5, 3);

        // Assert
        double result = expr.Evaluate(2);  // 5(8) = 40
        Assert.Equal(40, result, precision: 6);
    }

    [Theory]
    [InlineData(2, 4)]    // 2(4) = 8
    [InlineData(3, 9)]    // 2(9) = 18
    public void DifferentiateAndEvaluate_FindsSlope(double x, double xSquared)
    {
        // Arrange: f(x) = x²
        var f = new AlgebraicExpression();
        f.AddTerm(1, 2);

        // Act: f'(x) = 2x
        var fPrime = f.Differentiate();
        double slope = fPrime.Evaluate(x);

        // Assert: slope should be 2x
        Assert.Equal(2 * x, slope, precision: 6);
    }

    /// <summary>
    /// Example demonstrating how calculus operations connect together
    /// </summary>
    [Fact]
    public void CalculusExample_FindTangentLine()
    {
        // Given: f(x) = x² + 2x, find tangent line at x = 3

        // Step 1: Create function
        var f = new AlgebraicExpression();
        f.AddTerm(1, 2);   // x²
        f.AddTerm(2, 1);   // 2x

        // Step 2: Find f(3) = 9 + 6 = 15
        double y = f.Evaluate(3);
        Assert.Equal(15, y, precision: 6);

        // Step 3: Find f'(x) = 2x + 2
        var fPrime = f.Differentiate();
        
        // Step 4: Find f'(3) = 8 (slope of tangent)
        double slope = fPrime.Evaluate(3);
        Assert.Equal(8, slope, precision: 6);

        // Step 5: Create tangent line y - 15 = 8(x - 3) → y = 8x - 9
        var tangent = LinearEquations.FromPointAndSlope(3, 15, 8);
        Assert.Equal(8, tangent.Slope, precision: 6);
        Assert.Equal(-9, tangent.Intercept, precision: 6);
    }

    /// <summary>
    /// Example demonstrating definite integration
    /// </summary>
    [Fact]
    public void CalculusExample_DefiniteIntegral()
    {
        // Find area under f(x) = 2x from x = 0 to x = 3

        // Step 1: Create function f(x) = 2x
        var f = new AlgebraicExpression();
        f.AddTerm(2, 1);

        // Step 2: Find antiderivative F(x) = x²
        var F = f.Integrate();

        // Step 3: Evaluate F(3) - F(0) = 9 - 0 = 9
        double area = F.Evaluate(3) - F.Evaluate(0);
        Assert.Equal(9, area, precision: 6);
    }
}
