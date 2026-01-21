using MathsEngine.Modules.Pure.Algebra.Factorisation;
using Xunit;

namespace MathsEngine.Tests.PureTests.AlgebraTests.FactorisationTests;

public class DifferenceOfSquaresTests
{
    [Theory]
    [InlineData(0, true)]
    [InlineData(1, true)]
    [InlineData(4, true)]
    [InlineData(9, true)]
    [InlineData(16, true)]
    [InlineData(25, true)]
    [InlineData(100, true)]
    public void IsPerfectSquare_PerfectSquares_ReturnsTrue(int n, bool expected)
    {
        bool result = DifferenceOfSquares.IsPerfectSquare(n);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(2, false)]
    [InlineData(3, false)]
    [InlineData(5, false)]
    [InlineData(10, false)]
    [InlineData(-1, false)]
    public void IsPerfectSquare_NonPerfectSquares_ReturnsFalse(int n, bool expected)
    {
        bool result = DifferenceOfSquares.IsPerfectSquare(n);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(1, 0, -1, true)]   // x² - 1
    [InlineData(4, 0, -9, true)]   // 4x² - 9
    [InlineData(1, 0, -4, true)]   // x² - 4
    [InlineData(9, 0, -16, true)]  // 9x² - 16
    public void IsDifferenceOfSquares_ValidExpressions_ReturnsTrue(int a, int b, int c, bool expected)
    {
        bool result = DifferenceOfSquares.IsDifferenceOfSquares(a, b, c);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(1, 1, -1, false)]   // x² + x - 1 (has middle term)
    [InlineData(1, 0, 1, false)]    // x² + 1 (same sign)
    [InlineData(2, 0, -3, false)]   // 2x² - 3 (2 is not perfect square)
    public void IsDifferenceOfSquares_InvalidExpressions_ReturnsFalse(int a, int b, int c, bool expected)
    {
        bool result = DifferenceOfSquares.IsDifferenceOfSquares(a, b, c);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void Factorise_SimpleCase_ReturnsCorrectFactors()
    {
        // x² - 1 = (x + 1)(x - 1)
        var (coeff1, const1, coeff2, const2) = DifferenceOfSquares.Factorise(1, -1);
        
        Assert.Equal(1, coeff1);
        Assert.Equal(1, const1);
        Assert.Equal(1, coeff2);
        Assert.Equal(-1, const2);
    }

    [Fact]
    public void Factorise_FourXSquaredMinusNine_ReturnsCorrectFactors()
    {
        // 4x² - 9 = (2x + 3)(2x - 3)
        var (coeff1, const1, coeff2, const2) = DifferenceOfSquares.Factorise(4, -9);
        
        Assert.Equal(2, coeff1);
        Assert.Equal(3, const1);
        Assert.Equal(2, coeff2);
        Assert.Equal(-3, const2);
    }

    [Fact]
    public void Factorise_XSquaredMinusFour_ReturnsCorrectFactors()
    {
        // x² - 4 = (x + 2)(x - 2)
        var (coeff1, const1, coeff2, const2) = DifferenceOfSquares.Factorise(1, -4);
        
        Assert.Equal(1, coeff1);
        Assert.Equal(2, const1);
        Assert.Equal(1, coeff2);
        Assert.Equal(-2, const2);
    }

    [Fact]
    public void Factorise_NotDifferenceOfSquares_ThrowsArgumentException()
    {
        // x² + 1 is not a difference of squares
        Assert.Throws<ArgumentException>(() => DifferenceOfSquares.Factorise(1, 1));
    }

    [Fact]
    public void Factorise_HasMiddleTerm_ThrowsArgumentException()
    {
        // 2x² - 3 where 2 is not a perfect square
        Assert.Throws<ArgumentException>(() => DifferenceOfSquares.Factorise(2, -3));
    }
}
