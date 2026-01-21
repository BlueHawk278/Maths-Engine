using MathsEngine.Modules.Pure.Algebra.Factorisation;
using Xunit;

namespace MathsEngine.Tests.PureTests.AlgebraTests.FactorisationTests;

public class CommonFactorsTests
{
    [Theory]
    [InlineData(12, 8, 4)]
    [InlineData(15, 25, 5)]
    [InlineData(7, 13, 1)]
    [InlineData(100, 50, 50)]
    [InlineData(17, 17, 17)]
    public void FindGcf_TwoNumbers_ReturnsCorrectGcf(int a, int b, int expected)
    {
        int result = CommonFactors.FindGcf(a, b);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(-12, 8, 4)]
    [InlineData(12, -8, 4)]
    [InlineData(-12, -8, 4)]
    public void FindGcf_NegativeNumbers_ReturnsPositiveGcf(int a, int b, int expected)
    {
        int result = CommonFactors.FindGcf(a, b);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(0, 5, 5)]
    [InlineData(7, 0, 7)]
    public void FindGcf_WithZero_ReturnsOtherNumber(int a, int b, int expected)
    {
        int result = CommonFactors.FindGcf(a, b);
        Assert.Equal(expected, result);
    }

    [Fact]
    public void FindGcf_MultipleNumbers_ReturnsCorrectGcf()
    {
        int result = CommonFactors.FindGcf(12, 18, 24);
        Assert.Equal(6, result);
    }

    [Fact]
    public void FindGcf_MultipleNumbersWithOne_ReturnsOne()
    {
        int result = CommonFactors.FindGcf(5, 7, 11);
        Assert.Equal(1, result);
    }

    [Fact]
    public void FindGcf_EmptyArray_ThrowsArgumentException()
    {
        Assert.Throws<ArgumentException>(() => CommonFactors.FindGcf());
    }

    [Fact]
    public void FactorOut_SimpleCoefficients_ReturnsGcfAndFactored()
    {
        var (gcf, factored) = CommonFactors.FactorOut(6, 9, 12);
        
        Assert.Equal(3, gcf);
        Assert.Equal(new[] { 2, 3, 4 }, factored);
    }

    [Fact]
    public void FactorOut_NoCommonFactor_ReturnsOneAndOriginal()
    {
        var (gcf, factored) = CommonFactors.FactorOut(5, 7, 11);
        
        Assert.Equal(1, gcf);
        Assert.Equal(new[] { 5, 7, 11 }, factored);
    }

    [Fact]
    public void FactorOut_NegativeCoefficients_HandlesCorrectly()
    {
        var (gcf, factored) = CommonFactors.FactorOut(-6, 9, -12);
        
        Assert.Equal(3, gcf);
        Assert.Equal(new[] { -2, 3, -4 }, factored);
    }
}
