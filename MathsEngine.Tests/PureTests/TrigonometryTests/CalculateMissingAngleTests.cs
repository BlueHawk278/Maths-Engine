using Xunit;
using MathsEngine.Modules.Pure.Trigonometry;
using MathsEngine.Utils;

namespace MathsEngine.Tests.PureTests.TrigonometryTests;

public class CalculateMissingAngleTests
{
    /*
     *  EXCEPTION TESTS
     */

    [Theory]
    [InlineData(0.0, SideType.Adjacent, 1.0, SideType.Hypotenuse)]
    [InlineData(-1.0, SideType.Adjacent, 1.0, SideType.Hypotenuse)]
    [InlineData(1.0, SideType.Adjacent, 0.0, SideType.Opposite)]
    [InlineData(0.0, SideType.Adjacent, -1.0, SideType.Opposite)]
    public void NegativeSideLengthException_Throw(
        double side1Length,
        SideType side1Type,
        double side2Length,
        SideType side2Type)
    {
        Assert.Throws<NegativeSideLengthException>(() =>
            Trigonometry.CalculateMissingAngle(side1Length, side1Type, side2Length, side2Type));
    }

    [Theory]
    [InlineData(2.0, SideType.Hypotenuse, 3.0, SideType.Adjacent)]
    [InlineData(4.0, SideType.Opposite, 2.0, SideType.Hypotenuse)]
    public void HypotenuseNotLongestSideException_Throw(
        double side1Length,
        SideType side1Type,
        double side2Length,
        SideType side2Type)
    {
        Assert.Throws<HypotenuseNotLongestSideException>(() =>
            Trigonometry.CalculateMissingAngle(side1Length, side1Type, side2Length, side2Type));
    }
}