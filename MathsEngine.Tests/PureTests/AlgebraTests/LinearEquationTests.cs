using MathsEngine.Modules.Pure.Algebra;
using MathsEngine.Utils;
using Xunit;

namespace MathsEngine.Tests.PureTests.AlgebraTests
{
    public class LinearEquationTests
    {
        [Theory]
        [InlineData(2, 5, 13, 4)]           // 2x + 5 = 13 → x = 4
        [InlineData(3, -7, 8, 5)]           // 3x - 7 = 8 → x = 5
        [InlineData(5, 0, 20, 4)]           // 5x = 20 → x = 4
        [InlineData(-2, 10, 4, 3)]          // -2x + 10 = 4 → x = 3
        [InlineData(1, 0, 7, 7)]            // x = 7 → x = 7
        [InlineData(4, -8, 4, 3)]           // 4x - 8 = 4 → x = 3
        public void SolveSimple_ValidInputs_ReturnsCorrectSolution(
            double a, double b, double c, double expected)
        {
            double result = LinearEquationSolver.SolveSimple(a, b, c);
            Assert.Equal(expected, result, precision: 6);
        }

        [Fact]
        public void SolveSimple_ZeroCoefficient_ThrowsException()
        {
            Assert.Throws<ZeroCoefficientException>(() =>
                LinearEquationSolver.SolveSimple(0, 5, 10));
        }

        [Theory]
        [InlineData(3, 7, 2, 5, -2)]        // 3x + 7 = 2x + 5 → x = -2
        [InlineData(5, 3, 2, 10, 7.0 / 3)]  // 5x + 3 = 2x + 10 → x = 7/3
        [InlineData(4, 1, 3, 5, 4)]         // 4x + 1 = 3x + 5 → x = 4
        [InlineData(2, -3, 1, 4, 7)]        // 2x - 3 = x + 4 → x = 7
        public void SolveGeneral_ValidInputs_ReturnsCorrectSolution(
            double a, double b, double c, double d, double expected)
        {
            double result = LinearEquationSolver.SolveGeneral(a, b, c, d);
            Assert.Equal(expected, result, precision: 6);
        }

        [Fact]
        public void SolveGeneral_ParallelLines_ThrowsNoSolutionException()
        {
            // 2x + 1 = 2x + 5 → No solution (parallel lines)
            Assert.Throws<NoSolutionException>(() =>
                LinearEquationSolver.SolveGeneral(2, 1, 2, 5));
        }

        [Fact]
        public void SolveGeneral_SameLines_ThrowsInfiniteSolutionsException()
        {
            // 3x + 6 = 3x + 6 → Infinite solutions (same line)
            Assert.Throws<InfiniteSolutionsException>(() =>
                LinearEquationSolver.SolveGeneral(3, 6, 3, 6));
        }

        [Fact]
        public void GetSolutionSteps_ReturnsNonEmptyList()
        {
            var steps = LinearEquationSolver.GetSolutionSteps(2, 5, 13);
            
            Assert.NotNull(steps);
            Assert.NotEmpty(steps);
            Assert.Contains("Solution", steps[steps.Count - 1]);
        }

        [Theory]
        [InlineData(-3, 9, 0, 3)]           // -3x + 9 = 0 → x = 3
        [InlineData(0.5, 2.5, 5, 5)]        // 0.5x + 2.5 = 5 → x = 5
        public void SolveSimple_EdgeCases_ReturnsCorrectSolution(
            double a, double b, double c, double expected)
        {
            double result = LinearEquationSolver.SolveSimple(a, b, c);
            Assert.Equal(expected, result, precision: 6);
        }
    }
}
