using MathsEngine.Core.Modules.Pure.Algebra.Core;
using Xunit;

namespace MathsEngine.Tests.PureTests.AlgebraTests;

public class TermArithmeticTests
{
    [Theory]
    [InlineData(5, 2, 7, 2, 12, 2)]
    [InlineData(7, -1, 3, -1, 10, -1)]
    [InlineData(0, 3, 5, 3, 5, 3)]
    [InlineData(5, 3, 0, 3, 5, 3)]
    [InlineData(-4, 6, 10, 6, 6, 6)]
    [InlineData(10, 6, -4, 6, 6, 6)]
    [InlineData(-2.5, 4, 10.5, 4, 8, 4)]
    [InlineData(2.5, 4, -10.5, 4, -8, 4)]
    [InlineData(1.25, -2, 2.75, -2, 4, -2)]
    [InlineData(-1.25, -2, -2.75, -2, -4, -2)]
    [InlineData(1000, 1, -1, 1, 999, 1)]
    [InlineData(0.1, 8, 0.2, 8, 0.3, 8)]
    [InlineData(-0.1, 8, 0.2, 8, 0.1, 8)]
    public void AddTerms_ShouldOutputCorrectResult(
        double term1Coeff, int term1Expo, 
        double term2Coeff, int term2Expo, 
        double expectedCoeff, int expectedExpo)
    {
        Term term1 = new Term(term1Coeff, term1Expo);
        Term term2 = new Term(term2Coeff, term2Expo);
        Term expectedTerm = new Term(expectedCoeff, expectedExpo);

        var resultTerm = term1 + term2;

        Assert.True(expectedTerm.IsEqualTerm(resultTerm));
    }

    [Theory]
    [InlineData(12, 2, 7, 2, 5, 2)]
    [InlineData(10, -1, 3, -1, 7, -1)]
    [InlineData(5, 3, 0, 3, 5, 3)]
    [InlineData(0, 3, 5, 3, -5, 3)]
    [InlineData(-4, 6, 10, 6, -14, 6)]
    [InlineData(10, 6, -4, 6, 14, 6)]
    [InlineData(-2.5, 4, 10.5, 4, -13, 4)]
    [InlineData(2.5, 4, -10.5, 4, 13, 4)]
    [InlineData(1.25, -2, 2.75, -2, -1.5, -2)]
    [InlineData(-1.25, -2, -2.75, -2, 1.5, -2)]
    [InlineData(1000, 1, -1, 1, 1001, 1)]
    [InlineData(0.3, 8, 0.2, 8, 0.1, 8)]
    [InlineData(-0.1, 8, 0.2, 8, -0.3, 8)]
    public void SubtractTerms_ShouldOutputCorrectResult(
        double term1Coeff, int term1Expo,
        double term2Coeff, int term2Expo,
        double expectedCoeff, int expectedExpo)
    {
        Term term1 = new Term(term1Coeff, term1Expo);
        Term term2 = new Term(term2Coeff, term2Expo);
        Term expectedTerm = new Term(expectedCoeff, expectedExpo);

        var resultTerm = term1 - term2;

        Assert.True(expectedTerm.IsEqualTerm(resultTerm));
    }

    [Theory]
    [InlineData(5, 2, 7, 2, 35, 4)]
    [InlineData(7, -1, 3, -1, 21, -2)]
    [InlineData(2, 3, 4, 5, 8, 8)]
    [InlineData(-2, 3, 4, 5, -8, 8)]
    [InlineData(2, 3, -4, 5, -8, 8)]
    [InlineData(-2, 3, -4, 5, 8, 8)]
    [InlineData(0, 2, 5, 4, 0, 6)]
    [InlineData(5, 4, 0, 2, 0, 6)]
    [InlineData(0.5, 1, 0.25, 3, 0.125, 4)]
    [InlineData(1.25, -2, 2, 4, 2.5, 2)]
    [InlineData(10, 0, 3, 7, 30, 7)]
    [InlineData(3, -5, 2, 5, 6, 0)]
    [InlineData(1000, 1, -0.001, 2, -1, 3)]
    public void MultiplyTerms_ShouldOutputCorrectResult(
        double term1Coeff, int term1Expo,
        double term2Coeff, int term2Expo,
        double expectedCoeff, int expectedExpo)
    {
        Term term1 = new Term(term1Coeff, term1Expo);
        Term term2 = new Term(term2Coeff, term2Expo);
        Term expectedTerm = new Term(expectedCoeff, expectedExpo);

        var resultTerm = term1 * term2;

        Assert.True(expectedTerm.IsEqualTerm(resultTerm));
    }
    
    [Theory]
    public void ScalarMultiply_ShouldOutputCorrectResult(double termCoefficient, int termExponent, int constant, Term expectedTerm)
    {
        Term term = new Term(termCoefficient, termExponent);
        
        var resultTerm = term * constant;
        
        Assert.True(resultTerm.IsEqualTerm(expectedTerm));
    }



    [Theory]
    [InlineData(5, 2, 4, 3)]
    public void AddTerms_ShouldThrowError(
        double term1Coeff, int term1Expo,
        double term2Coeff, int term2Expo)
    {
        Term term1 = new Term(term1Coeff, term1Expo);
        Term term2 = new Term(term2Coeff, term2Expo);

        Assert.Throws<InvalidOperationException>(() => term1 + term2);
    }

    [Theory]
    [InlineData(5, 2, 4, 3)]
    public void SubtractTerms_ShouldThrowError(
        double term1Coeff, int term1Expo,
        double term2Coeff, int term2Expo)
    {
        Term term1 = new Term(term1Coeff, term1Expo);
        Term term2 = new Term(term2Coeff, term2Expo);

        Assert.Throws<InvalidOperationException>(() => term1 - term2);
    }
}