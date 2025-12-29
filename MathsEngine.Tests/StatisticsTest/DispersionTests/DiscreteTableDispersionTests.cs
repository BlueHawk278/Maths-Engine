using MathsEngine.Modules.Statistics.Dispersion;
using MathsEngine.Modules.Statistics.Dispersion.FrequencyTable;
using MathsEngine.Utils;
using Xunit;

namespace MathsEngine.Tests.StatisticsTest.DispersionTests
{
    public class DiscreteTableDispersionTests
    {
        [Fact]
        public void Constructor_NullTable_ThrowsNullInputException()
        {
            Assert.Throws<NullInputException>(() => new DiscreteTableCalculator(null));
        }

        [Theory]
        [MemberData(nameof(DispersionTestData))]
        public void Run_CalculatesCorrectDispersionResults(
            double[,] table,
            double expectedMean,
            double expectedVariance,
            double expectedStandardDeviation)
        {
            // Arrange
            var calculator = new DiscreteTableCalculator(table);

            // Act
            calculator.Run();

            // Assert
            Assert.Equal(expectedMean, calculator.Mean, 3);
            Assert.Equal(expectedVariance, calculator.Variance, 3);
            Assert.Equal(expectedStandardDeviation, calculator.StandardDeviation, 3);
        }

        public static IEnumerable<object[]> DispersionTestData =>
            new List<object[]>
            {
                // Test Case 1: From a textbook
                new object[]
                {
                    new double[,] { { 0, 1, 0, 0 }, { 1, 9, 0, 0 }, { 2, 12, 0, 0 }, { 3, 5, 0, 0 }, { 4, 3, 0, 0 } },
                    1.967,
                    0.999,
                    0.999
                },
                // Test Case 2: Another textbook example
                new object[]
                {
                    new double[,] { { 11, 1, 0, 0 }, { 12, 5, 0, 0 }, { 13, 10, 0, 0 }, { 14, 11, 0, 0 }, { 15, 7, 0, 0 }, { 16, 4, 0, 0 } },
                    13.65,
                    1.528,
                    1.236
                }
            };
    }
}
