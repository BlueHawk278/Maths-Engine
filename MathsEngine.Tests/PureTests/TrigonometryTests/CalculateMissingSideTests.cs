using Xunit;
using MathsEngine.Modules.Pure.Trigonometry;
using MathsEngine.Utils;

namespace MathsEngine.Tests.PureTests.TrigonometryTests;

public class CalculateMissingSideTests
{
    /*
     *  EXCEPTION TESTS
     */

    [Theory]
    [InlineData(-3.0, 50.0, SideType.Adjacent, SideType.Hypotenuse)]
    [InlineData(0, 50.0, SideType.Hypotenuse, SideType.Adjacent)]
    public void NegativeSideException_Throw(
        double knownSideLength,
        double angle,
        SideType knownSideType,
        SideType sideToFind)
    {
        Assert.Throws<NegativeSideLengthException>(() =>
            Trigonometry.CalculateMissingSide(knownSideLength, angle, knownSideType, sideToFind));
    }

    [Theory]
    [InlineData(7, 0.0, SideType.Adjacent, SideType.Hypotenuse)]
    [InlineData(7, -1.5, SideType.Adjacent, SideType.Hypotenuse)]
    [InlineData(7, 90.0, SideType.Adjacent, SideType.Hypotenuse)]
    [InlineData(7, 100.0, SideType.Adjacent, SideType.Hypotenuse)]
    public void AcuteAngleException_Throw(
        double knownSideLength,
        double angle,
        SideType knownSideType,
        SideType sideToFind)
    {
        Assert.Throws<AcuteAngleException>(() =>
            Trigonometry.CalculateMissingSide(knownSideLength, angle, knownSideType, sideToFind));
    }

    [Theory]
    [InlineData(7, 45, SideType.Hypotenuse, SideType.Hypotenuse)]
    [InlineData(7, 45, SideType.Adjacent, SideType.Adjacent)]
    [InlineData(7, 45, SideType.Opposite, SideType.Opposite)]
    public void DuplicateSideException_Throw(
        double knownSideLength,
        double angle,
        SideType knownSideType,
        SideType sideToFind)
    {
        Assert.Throws<DuplicateSideException>(() =>
            Trigonometry.CalculateMissingSide(knownSideLength, angle, knownSideType, sideToFind));
    }
}