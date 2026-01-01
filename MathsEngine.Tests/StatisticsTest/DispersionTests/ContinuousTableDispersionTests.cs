using MathsEngine.Modules.Statistics.Dispersion;
using MathsEngine.Utils;
using Xunit;

namespace MathsEngine.Tests.StatisticsTest.DispersionTests
{
    public class ContinuousTableDispersionTests
    {
        [Fact]
        public void Constructor_NullLists_ThrowsNullInputException()
        {
            Assert.Throws<NullInputException>(() => new ContinuousTableCalculator(null, new List<int>()));
            Assert.Throws<NullInputException>(() => new ContinuousTableCalculator(new List<string>(), null));
        }

        [Fact]
        public void Constructor_MismatchedLists_ThrowsListsNotSameSizeException()
        {
            var intervals = new List<string> { "10-20", "20-30" };
            var frequencies = new List<int> { 1 };
            Assert.Throws<ListsNotSameSizeException>(() => new ContinuousTableCalculator(intervals, frequencies));
        }

        [Fact]
        public void Constructor_EmptyLists_ThrowsEmptyDataSetException()
        {
            var intervals = new List<string>();
            var frequencies = new List<int>();
            Assert.Throws<EmptyDataSetException>(() => new ContinuousTableCalculator(intervals, frequencies));
        }

        [Fact]
        public void Constructor_NegativeFrequency_ThrowsInvalidFrequencyException()
        {
            var intervals = new List<string> { "10-20", "20-30" };
            var frequencies = new List<int> { 5, -1 };
            Assert.Throws<InvalidFrequencyException>(() => new ContinuousTableCalculator(intervals, frequencies));
        }

        [Fact]
        public void Run_InvalidIntervalFormat_ThrowsInvalidClassIntervalFormatException()
        {
            var intervals = new List<string> { "10-20", "30_40" }; // Invalid format
            var frequencies = new List<int> { 5, 5 };
            var calculator = new ContinuousTableCalculator(intervals, frequencies);
            Assert.Throws<InvalidClassIntervalFormatException>(() => calculator.Run());
        }

        [Theory]
        [MemberData(nameof(DispersionTestData))]
        public void Run_CalculatesCorrectDispersionResults(
            List<string> intervals,
            List<int> frequencies,
            double expectedMean,
            double expectedVariance,
            double expectedStandardDeviation)
        {
            // Arrange
            var calculator = new ContinuousTableCalculator(intervals, frequencies);

            // Act
            calculator.Run();

            // Assert
            Assert.Equal(expectedMean, calculator.Mean, 1); // Rounded to 1 decimal place for this test
            Assert.Equal(expectedVariance, calculator.Variance, 0); // Rounded to integer for this test
            Assert.Equal(expectedStandardDeviation, calculator.StandardDeviation, 1); // Rounded to 1 decimal place for this test
        }

        public static IEnumerable<object[]> DispersionTestData =>
            new List<object[]>
            {
                // Test Case 1: From a textbook
                new object[]
                {
                    new List<string> { "10-20", "20-30", "30-50", "50-90" },
                    new List<int> { 9, 11, 13, 7 },
                    36.0,
                    304.0,
                    17.4
                }
            };
    }
}