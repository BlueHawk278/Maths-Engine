using System.Collections.Generic;
using MathsEngine.Modules.Statistics.BivariateAnalysis;
using MathsEngine.Utils;
using Xunit;

namespace MathsEngine.Tests.StatisticsTests
{
    public class BivariateAnalysisTests
    {
        [Fact]
        public void Constructor_NullFirstScoreList_ThrowsNullInputException()
        {
            var scores2 = new List<double> { 1, 2, 3 };
            Assert.Throws<NullInputException>(() => new BivariateAnalysisCalculator(null, scores2));
        }

        [Fact]
        public void Constructor_NullSecondScoreList_ThrowsNullInputException()
        {
            var scores1 = new List<double> { 1, 2, 3 };
            Assert.Throws<NullInputException>(() => new BivariateAnalysisCalculator(scores1, null));
        }

        [Fact]
        public void Constructor_MismatchedListSizes_ThrowsListsNotSameSizeException()
        {
            var scores1 = new List<double> { 1, 2, 3 };
            var scores2 = new List<double> { 1, 2 };
            Assert.Throws<ListsNotSameSizeException>(() => new BivariateAnalysisCalculator(scores1, scores2));
        }

        [Theory]
        [MemberData(nameof(BivariateAnalysisTestData))]
        public void Run_CalculatesCorrectBivariateAnalysisResults(
            List<double> scores1,
            List<double> scores2,
            double expectedSumDifferenceSquared,
            double expectedCorrelationCoefficient,
            Correlation expectedCorrelation)
        {
            // Arrange
            var calculator = new BivariateAnalysisCalculator(scores1, scores2);

            // Act
            calculator.Run();

            // Assert
            Assert.Equal(expectedSumDifferenceSquared, calculator.SumDifferenceSquared, 2);
            Assert.Equal(expectedCorrelationCoefficient, calculator.CorrelationCoefficient, 3);
            Assert.Equal(expectedCorrelation, calculator.Correlation);
        }

        public static IEnumerable<object[]> BivariateAnalysisTestData =>
            new List<object[]>
            {
                // Test Case 1: Perfect positive correlation
                new object[]
                {
                    new List<int> { 10, 20, 30, 40, 50 },
                    new List<int> { 1, 2, 3, 4, 5 },
                    0.0,
                    1.0,
                    Correlation.PerfectPositive
                },
                // Test Case 2: Perfect negative correlation
                new object[]
                {
                    new List<int> { 10, 20, 30, 40, 50 },
                    new List<int> { 5, 4, 3, 2, 1 },
                    40.0,
                    -1.0,
                    Correlation.PerfectNegative
                },
                // Test Case 3: No correlation
                new object[]
                {
                    new List<int> { 1, 2, 3, 4, 5 },
                    new List<int> { 3, 1, 5, 2, 4 },
                    10.0,
                    0.0,
                    Correlation.Invalid
                },
                // Test Case 4: Strong positive correlation with tied ranks
                new object[]
                {
                    new List<int> { 10, 15, 15, 20, 25 },
                    new List<int> { 5, 8, 10, 10, 12 },
                    4.5,
                    0.55,
                    Correlation.StrongPositive
                },
                // Test Case 5: From a textbook example
                new object[]
                {
                    new List<int> { 75, 80, 93, 65, 87, 71, 98, 68, 84, 77 },
                    new List<int> { 82, 78, 86, 72, 91, 80, 95, 75, 89, 74 },
                    34.0,
                    0.794,
                    Correlation.StrongPositive
                }
            };
    }
}