using MathsEngine.Modules.Statistics.Dispersion;
using MathsEngine.Utils;
using Xunit;

namespace MathsEngine.Tests.StatisticsTest.DispersionTests
{
    public class DiscreteTableDispersionTests
    {
        [Fact]
        public void Constructor_NullLists_ThrowsNullInputException()
        {
            Assert.Throws<NullInputException>(() => new FrequencyTableCalculator(null, new List<int>()));
            Assert.Throws<NullInputException>(() => new FrequencyTableCalculator(new List<double>(), null));
        }

        [Fact]
        public void Constructor_MismatchedLists_ThrowsListsNotSameSizeException()
        {
            var values = new List<double> { 1, 2 };
            var frequencies = new List<int> { 1 };
            Assert.Throws<ListsNotSameSizeException>(() => new FrequencyTableCalculator(values, frequencies));
        }

        [Fact]
        public void Constructor_EmptyLists_ThrowsEmptyDataSetException()
        {
            var values = new List<double>();
            var frequencies = new List<int>();
            Assert.Throws<EmptyDataSetException>(() => new FrequencyTableCalculator(values, frequencies));
        }

        [Fact]
        public void Constructor_NegativeFrequency_ThrowsInvalidFrequencyException()
        {
            var values = new List<double> { 1, 2 };
            var frequencies = new List<int> { 5, -1 };
            Assert.Throws<InvalidFrequencyException>(() => new FrequencyTableCalculator(values, frequencies));
        }

        [Theory]
        [MemberData(nameof(DispersionTestData))]
        public void Run_CalculatesCorrectDispersionResults(
            List<double> values,
            List<int> frequencies,
            double expectedMean,
            double expectedVariance,
            double expectedStandardDeviation)
        {
            // Arrange
            var calculator = new FrequencyTableCalculator(values, frequencies);

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
                    new List<double> { 0, 1, 2, 3, 4 },
                    new List<int> { 1, 9, 12, 5, 3 },
                    1.967,
                    0.999,
                    0.999
                },
                // Test Case 2: Another textbook example
                new object[]
                {
                    new List<double> { 11, 12, 13, 14, 15, 16 },
                    new List<int> { 1, 5, 10, 11, 7, 4 },
                    13.65,
                    1.528,
                    1.236
                }
            };
    }
}