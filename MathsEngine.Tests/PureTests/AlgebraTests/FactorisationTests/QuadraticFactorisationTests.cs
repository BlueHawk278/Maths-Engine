using MathsEngine.Modules.Pure.Algebra.Factorisation;
using Xunit;

namespace MathsEngine.Tests.PureTests.AlgebraTests.FactorisationTests;

public class QuadraticFactorisationTests
{
    [Fact]
    public void CalculateDiscriminant_SimpleCase_ReturnsCorrectValue()
    {
        // x² + 5x + 6, discriminant = 25 - 24 = 1
        int result = QuadraticFactorisation.CalculateDiscriminant(1, 5, 6);
        Assert.Equal(1, result);
    }

    [Fact]
    public void CalculateDiscriminant_PerfectSquare_ReturnsZero()
    {
        // x² + 2x + 1, discriminant = 4 - 4 = 0
        int result = QuadraticFactorisation.CalculateDiscriminant(1, 2, 1);
        Assert.Equal(0, result);
    }

    [Fact]
    public void CalculateDiscriminant_NoRealRoots_ReturnsNegative()
    {
        // x² + 1, discriminant = 0 - 4 = -4
        int result = QuadraticFactorisation.CalculateDiscriminant(1, 0, 1);
        Assert.Equal(-4, result);
    }

    [Fact]
    public void Factorise_SimpleQuadratic_ReturnsCorrectFactors()
    {
        // x² + 5x + 6 = (x + 2)(x + 3)
        var factors = QuadraticFactorisation.Factorise(1, 5, 6);
        
        Assert.NotNull(factors);
        var (coeff1, const1, coeff2, const2) = factors.Value;
        
        // Verify expansion: (coeff1*x + const1)(coeff2*x + const2) = x² + 5x + 6
        Assert.Equal(1, coeff1 * coeff2); // coefficient of x²
        Assert.Equal(5, coeff1 * const2 + coeff2 * const1); // coefficient of x
        Assert.Equal(6, const1 * const2); // constant term
    }

    [Fact]
    public void Factorise_NegativeConstant_ReturnsCorrectFactors()
    {
        // x² + x - 6 = (x + 3)(x - 2)
        var factors = QuadraticFactorisation.Factorise(1, 1, -6);
        
        Assert.NotNull(factors);
        var (coeff1, const1, coeff2, const2) = factors.Value;
        
        Assert.Equal(1, coeff1 * coeff2);
        Assert.Equal(1, coeff1 * const2 + coeff2 * const1);
        Assert.Equal(-6, const1 * const2);
    }

    [Fact]
    public void Factorise_LeadingCoefficientNotOne_ReturnsCorrectFactors()
    {
        // 2x² + 7x + 3 = (2x + 1)(x + 3)
        var factors = QuadraticFactorisation.Factorise(2, 7, 3);
        
        Assert.NotNull(factors);
        var (coeff1, const1, coeff2, const2) = factors.Value;
        
        Assert.Equal(2, coeff1 * coeff2);
        Assert.Equal(7, coeff1 * const2 + coeff2 * const1);
        Assert.Equal(3, const1 * const2);
    }

    [Fact]
    public void Factorise_PerfectSquare_ReturnsCorrectFactors()
    {
        // x² + 2x + 1 = (x + 1)²
        var factors = QuadraticFactorisation.Factorise(1, 2, 1);
        
        Assert.NotNull(factors);
        var (coeff1, const1, coeff2, const2) = factors.Value;
        
        Assert.Equal(1, coeff1 * coeff2);
        Assert.Equal(2, coeff1 * const2 + coeff2 * const1);
        Assert.Equal(1, const1 * const2);
    }

    [Fact]
    public void Factorise_NegativePerfectSquare_ReturnsCorrectFactors()
    {
        // x² - 2x + 1 = (x - 1)²
        var factors = QuadraticFactorisation.Factorise(1, -2, 1);
        
        Assert.NotNull(factors);
        var (coeff1, const1, coeff2, const2) = factors.Value;
        
        Assert.Equal(1, coeff1 * coeff2);
        Assert.Equal(-2, coeff1 * const2 + coeff2 * const1);
        Assert.Equal(1, const1 * const2);
    }

    [Fact]
    public void Factorise_NotFactorisable_ReturnsNull()
    {
        // x² + x + 1 cannot be factorised with integers
        var factors = QuadraticFactorisation.Factorise(1, 1, 1);
        Assert.Null(factors);
    }

    [Fact]
    public void Factorise_ZeroLeadingCoefficient_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => QuadraticFactorisation.Factorise(0, 5, 6));
    }

    [Theory]
    [InlineData(1, 5, 6, true)]    // x² + 5x + 6
    [InlineData(1, 2, 1, true)]    // x² + 2x + 1
    [InlineData(2, 7, 3, true)]    // 2x² + 7x + 3
    [InlineData(1, 1, 1, false)]   // x² + x + 1
    [InlineData(1, 0, 1, false)]   // x² + 1
    public void IsFactorisable_VariousExpressions_ReturnsCorrectResult(int a, int b, int c, bool expected)
    {
        bool result = QuadraticFactorisation.IsFactorisable(a, b, c);
        Assert.Equal(expected, result);
    }
}
