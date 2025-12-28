using Xunit;
using MathsEngine.Modules.Pure.PythagorasTheorem;
using MathsEngine.Utils;

namespace MathsEngine.Tests.PureTests;

public class PythagorasTests
{
    /// <summary>
    /// Tests to check for correct results from calculating the hypotenuse.
    /// </summary>
    [Fact]
    public void CalculateHypotenuse_3_4_Returns5()
    {
        double result = PythagorasTheorem.calculateHypotenuse(3, 4);

        Assert.Equal(5, result, precision: 9);
    }

    [Fact]
    public void CalculateHypotenuse_5_12_returns13()
    {
        double result = PythagorasTheorem.calculateHypotenuse(5, 12);

        Assert.Equal(13, result, precision: 9);
    }

    [Fact]
    public void CalculateHypotenuse_AB_BA()
    {
        double AB = PythagorasTheorem.calculateHypotenuse(5, 12);
        double BA = PythagorasTheorem.calculateHypotenuse(12, 5);

        Assert.Equal(AB, BA);
    }

    [Fact]
    public void CheckInvalidInput()
    {

    }
}