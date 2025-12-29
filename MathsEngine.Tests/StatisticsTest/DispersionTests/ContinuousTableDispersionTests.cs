using MathsEngine.Modules.Statistics.Dispersion.ContinuousTable;
using MathsEngine.Utils;
using Xunit;

namespace MathsEngine.Tests.StatisticsTest.DispersionTests
{
    public class ContinuousTableDispersionTests
    {
        [Fact]
        public void Constructor_NullTable_ThrowsNullInputException()
        {
            Assert.Throws<NullInputException>(() => new ContinuousTableCalculator(null));
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
            var calculator = new ContinuousTableCalculator(table);

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
                    new double[,] { { 10, 20, 9, 15, 0, 0 }, { 20, 30, 11, 25, 0, 0 }, { 30, 50, 13, 40, 0, 0 }, { 50, 90, 7, 70, 0, 0 } },
                    36.0,
                    304.0,
                    17.4
                }
            };
    }
}
