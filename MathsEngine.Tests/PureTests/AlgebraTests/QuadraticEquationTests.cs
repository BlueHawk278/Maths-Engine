using MathsEngine.Modules.Pure.Algebra;
using MathsEngine.Utils;
using Xunit;

namespace MathsEngine.Tests.PureTests.AlgebraTests
{
    public class QuadraticEquationTests
    {
        [Theory]
        [InlineData(1, -5, 6, 2, 3)]        // x² - 5x + 6 = 0 → x = 2, 3
        [InlineData(1, -3, 2, 1, 2)]        // x² - 3x + 2 = 0 → x = 1, 2
        [InlineData(1, -7, 12, 3, 4)]       // x² - 7x + 12 = 0 → x = 3, 4
        [InlineData(2, -8, 6, 1, 3)]        // 2x² - 8x + 6 = 0 → x = 1, 3
        public void Solve_TwoRealRoots_ReturnsCorrectSolutions(
            double a, double b, double c, double expectedRoot1, double expectedRoot2)
        {
            var solution = QuadraticEquationSolver.Solve(a, b, c);

            Assert.Equal(QuadraticSolutionType.TwoRealRoots, solution.SolutionType);
            Assert.NotNull(solution.Root1);
            Assert.NotNull(solution.Root2);

            // Check both roots are present (order may vary)
            var roots = new[] { solution.Root1.Value, solution.Root2.Value };
            Assert.Contains(expectedRoot1, roots, new ApproximateDoubleComparer());
            Assert.Contains(expectedRoot2, roots, new ApproximateDoubleComparer());
        }

        [Theory]
        [InlineData(1, -2, 1, 1)]           // x² - 2x + 1 = 0 → x = 1 (repeated)
        [InlineData(1, 4, 4, -2)]           // x² + 4x + 4 = 0 → x = -2 (repeated)
        [InlineData(4, -12, 9, 1.5)]        // 4x² - 12x + 9 = 0 → x = 1.5 (repeated)
        public void Solve_RepeatedRoot_ReturnsSingleRoot(
            double a, double b, double c, double expectedRoot)
        {
            var solution = QuadraticEquationSolver.Solve(a, b, c);

            Assert.Equal(QuadraticSolutionType.OneRepeatedRoot, solution.SolutionType);
            Assert.NotNull(solution.Root1);
            Assert.NotNull(solution.Root2);
            Assert.Equal(expectedRoot, solution.Root1.Value, precision: 6);
            Assert.Equal(expectedRoot, solution.Root2.Value, precision: 6);
        }

        [Theory]
        [InlineData(1, 0, 1)]               // x² + 1 = 0 → Complex roots
        [InlineData(1, 2, 5)]               // x² + 2x + 5 = 0 → Complex roots
        [InlineData(2, 1, 3)]               // 2x² + x + 3 = 0 → Complex roots
        public void Solve_NegativeDiscriminant_ReturnsComplexRoots(
            double a, double b, double c)
        {
            var solution = QuadraticEquationSolver.Solve(a, b, c);

            Assert.Equal(QuadraticSolutionType.TwoComplexRoots, solution.SolutionType);
            Assert.Null(solution.Root1);
            Assert.Null(solution.Root2);
            Assert.NotNull(solution.ComplexRealPart);
            Assert.NotNull(solution.ComplexImaginaryPart);
            Assert.True(solution.ComplexImaginaryPart > 0);
        }

        [Fact]
        public void Solve_ZeroLeadingCoefficient_ThrowsException()
        {
            Assert.Throws<NotQuadraticException>(() =>
                QuadraticEquationSolver.Solve(0, 2, 1));
        }

        [Theory]
        [InlineData(1, -5, 6, 1)]           // x² - 5x + 6 = 0 → Discriminant = 1
        [InlineData(1, -2, 1, 0)]           // x² - 2x + 1 = 0 → Discriminant = 0
        [InlineData(1, 0, 1, -4)]           // x² + 1 = 0 → Discriminant = -4
        [InlineData(2, -7, 3, 25)]          // 2x² - 7x + 3 = 0 → Discriminant = 25
        public void CalculateDiscriminant_ValidInputs_ReturnsCorrectValue(
            double a, double b, double c, double expected)
        {
            double discriminant = QuadraticEquationSolver.CalculateDiscriminant(a, b, c);
            Assert.Equal(expected, discriminant, precision: 6);
        }

        [Fact]
        public void GetSolutionSteps_ReturnsNonEmptyList()
        {
            var steps = QuadraticEquationSolver.GetSolutionSteps(1, -5, 6);
            
            Assert.NotNull(steps);
            Assert.NotEmpty(steps);
            Assert.Contains(steps, s => s.Contains("discriminant"));
        }

        [Theory]
        [InlineData(-1, 5, -6, 2, 3)]       // -x² + 5x - 6 = 0 → x = 2, 3
        [InlineData(3, -12, 12, 2, 2)]      // 3x² - 12x + 12 = 0 → x = 2 (repeated)
        public void Solve_NegativeLeadingCoefficient_Works(
            double a, double b, double c, double expectedRoot1, double expectedRoot2)
        {
            var solution = QuadraticEquationSolver.Solve(a, b, c);

            Assert.NotNull(solution.Root1);
            Assert.NotNull(solution.Root2);

            var roots = new[] { solution.Root1.Value, solution.Root2.Value };
            Assert.Contains(expectedRoot1, roots, new ApproximateDoubleComparer());
            Assert.Contains(expectedRoot2, roots, new ApproximateDoubleComparer());
        }

        // Helper class for comparing doubles with tolerance
        private class ApproximateDoubleComparer : IEqualityComparer<double>
        {
            public bool Equals(double x, double y)
            {
                return Math.Abs(x - y) < 0.000001;
            }

            public int GetHashCode(double obj)
            {
                return obj.GetHashCode();
            }
        }
    }
}
