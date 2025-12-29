using System;
using Xunit;
using MathsEngine.Modules.Mechanics.UniformAcceleration;
using MathsEngine.Utils;

namespace MathsEngine.Tests.MechanicsTests.UniformAccelerationTests
{
    public class UniformAccelerationCalculatorTests
    {
        // Test for v = u + at
        [Fact]
        public void CalculateVUAT_FindV_ReturnsCorrectValue()
        {
            var result = UniformAccelerationCalculator.CalculateVUAT(null, "10", "2", "5"); // v = 10 + 2*5
            Assert.Equal("20", result);
        }

        // Test for s = 0.5 * (u + v) * t
        [Fact]
        public void CalculateSUVT_FindS_ReturnsCorrectValue()
        {
            var result = UniformAccelerationCalculator.CalculateSUVT(null, "10", "20", "5"); // s = 0.5 * (10+20) * 5
            Assert.Equal("75", result);
        }

        // Test for v^2 = u^2 + 2as
        [Fact]
        public void CalculateVUAS_FindV_ReturnsCorrectValue()
        {
            var result = UniformAccelerationCalculator.CalculateVUAS(null, "5", "2", "10"); // v^2 = 5^2 + 2*2*10 = 25 + 40 = 65
            Assert.Equal(Math.Sqrt(65).ToString(), result);
        }

        // Test for s = ut + 0.5at^2
        [Fact]
        public void CalculateSUTAT_FindS_ReturnsCorrectValue()
        {
            var result = UniformAccelerationCalculator.CalculateSUTAT(null, "10", "2", "5"); // s = 10*5 + 0.5*2*5^2 = 50 + 25
            Assert.Equal("75", result);
        }

        [Fact]
        public void CalculateAverageVelocity_WithValidInputs_ReturnsCorrectAverage()
        {
            var result = UniformAccelerationCalculator.CalculateAverageVelocity("10", "20");
            Assert.Equal(15, result);
        }

        [Fact]
        public void CalculateAverageVelocity_WithNullInput_ThrowsNullInputException()
        {
            Assert.Throws<NullInputException>(() => UniformAccelerationCalculator.CalculateAverageVelocity(null, "20"));
        }

        [Fact]
        public void CalculateSUVT_WithDivisionByZero_ThrowsDivideByZeroException()
        {
            // This tests the case where t = 2s / (u + v) and u + v = 0
            Assert.Throws<DivideByZeroException>(() => UniformAccelerationCalculator.CalculateSUVT("10", "10", "-10", null));
        }
    }
}