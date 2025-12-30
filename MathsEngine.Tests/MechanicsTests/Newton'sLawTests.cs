using System;
using MathsEngine.Modules.Mechanics.Dynamics;
using MathsEngine.Utils;
using Xunit;

namespace MathsEngine.Tests.MechanicsTests
{
    public class NewtonsLawTests
    {
        // Tests for CalculateFma

        [Fact]
        public void CalculateFma_ForceUnknown_CalculatesForce()
        {
            var result = NewtonsLawsCalculator.CalculateFma(null, 10, 5);
            Assert.Equal(50, result);
        }

        [Fact]
        public void CalculateFma_MassUnknown_CalculatesMass()
        {
            var result = NewtonsLawsCalculator.CalculateFma(100, null, 10);
            Assert.Equal(10, result);
        }

        [Fact]
        public void CalculateFma_AccelerationUnknown_CalculatesAcceleration()
        {
            var result = NewtonsLawsCalculator.CalculateFma(100, 20, null);
            Assert.Equal(5, result);
        }

        [Fact]
        public void CalculateFma_AllValuesProvided_ThrowsException()
        {
            Assert.Throws<NullValuesException>(() => NewtonsLawsCalculator.CalculateFma(100, 10, 10));
        }

        [Fact]
        public void CalculateFma_TooFewValues_ThrowsException()
        {
            Assert.Throws<NullValuesException>(() => NewtonsLawsCalculator.CalculateFma(100, null, null));
        }

        [Fact]
        public void CalculateFma_MassUnknownWithZeroAcceleration_ThrowsException()
        {
            Assert.Throws<DivideByZeroException>(() => NewtonsLawsCalculator.CalculateFma(100, null, 0));
        }

        [Fact]
        public void CalculateFma_AccelerationUnknownWithZeroMass_ThrowsException()
        {
            Assert.Throws<DivideByZeroException>(() => NewtonsLawsCalculator.CalculateFma(100, 0, null));
        }

        // Tests for CheckValidCalculation

        [Fact]
        public void CheckValidCalculation_ValidInputs_ReturnsTrue()
        {
            var result = NewtonsLawsCalculator.CheckValidCalculation(100, 10, 5);
            Assert.True(result);
        }

        [Fact]
        public void CheckValidCalculation_InvalidInputs_ReturnsFalse()
        {
            var result = NewtonsLawsCalculator.CheckValidCalculation(100, 10, 5);
            Assert.False(result);
        }

        [Fact]
        public void CheckValidCalculation_MissingValue_ThrowsException()
        {
            Assert.Throws<NullValuesException>(() => NewtonsLawsCalculator.CheckValidCalculation(100, 10, 5));
        }
    }
}