using MathsEngine.Utils;

namespace MathsEngine.Modules.Pure.Algebra
{
    /// <summary>
    /// Provides methods for solving linear equations
    /// </summary>
    public static class LinearEquationSolver
    {
        /// <summary>
        /// Solves a linear equation of the form: ax + b = c
        /// Rearranges to: x = (c - b) / a
        /// </summary>
        /// <param name="a">Coefficient of x. Must not be zero.</param>
        /// <param name="b">Constant term on the left side.</param>
        /// <param name="c">Constant term on the right side.</param>
        /// <returns>The value of x that satisfies the equation.</returns>
        /// <exception cref="ZeroCoefficientException">Thrown when coefficient a is zero.</exception>
        /// <example>
        /// To solve 2x + 5 = 13:
        /// <code>
        /// double x = LinearEquationSolver.SolveSimple(2, 5, 13);
        /// // Returns: 4
        /// </code>
        /// </example>
        public static double SolveSimple(double a, double b, double c)
        {
            if (a == 0)
                throw new ZeroCoefficientException("Coefficient 'a' cannot be zero in a linear equation.");

            // ax + b = c
            // ax = c - b
            // x = (c - b) / a
            return (c - b) / a;
        }

        /// <summary>
        /// Solves a linear equation of the form: ax + b = cx + d
        /// Rearranges to: x = (d - b) / (a - c)
        /// </summary>
        /// <param name="a">Coefficient of x on the left side.</param>
        /// <param name="b">Constant term on the left side.</param>
        /// <param name="c">Coefficient of x on the right side.</param>
        /// <param name="d">Constant term on the right side.</param>
        /// <returns>The value of x that satisfies the equation.</returns>
        /// <exception cref="ZeroCoefficientException">Thrown when (a - c) equals zero (parallel lines).</exception>
        /// <example>
        /// To solve 3x + 7 = 2x + 5:
        /// <code>
        /// double x = LinearEquationSolver.SolveGeneral(3, 7, 2, 5);
        /// // Returns: -2
        /// </code>
        /// </example>
        public static double SolveGeneral(double a, double b, double c, double d)
        {
            double coefficientDifference = a - c;
            
            if (coefficientDifference == 0)
            {
                // Check if it's the same line (infinite solutions) or parallel lines (no solution)
                if (Math.Abs(b - d) < MathConstants.EQUALITY_TOLERANCE)
                    throw new InfiniteSolutionsException("The equations represent the same line (infinite solutions).");
                else
                    throw new NoSolutionException("The equations represent parallel lines (no solution).");
            }

            // ax + b = cx + d
            // ax - cx = d - b
            // (a - c)x = d - b
            // x = (d - b) / (a - c)
            return (d - b) / coefficientDifference;
        }

        /// <summary>
        /// Generates step-by-step solution for a simple linear equation (ax + b = c)
        /// </summary>
        /// <param name="a">Coefficient of x.</param>
        /// <param name="b">Constant on left side.</param>
        /// <param name="c">Constant on right side.</param>
        /// <returns>List of solution steps as strings.</returns>
        public static List<string> GetSolutionSteps(double a, double b, double c)
        {
            var steps = new List<string>();
            
            steps.Add($"Original equation: {FormatTerm(a, "x", true)} {FormatConstant(b)} = {c}");
            
            if (b != 0)
            {
                double newC = c - b;
                string operation = b > 0 ? "Subtract" : "Add";
                steps.Add($"Step 1: {operation} {Math.Abs(b)} from both sides");
                steps.Add($"        {FormatTerm(a, "x", true)} = {newC}");
            }
            
            if (a != 1)
            {
                double result = (c - b) / a;
                steps.Add($"Step 2: Divide both sides by {a}");
                steps.Add($"        x = {result:F2}");
            }
            
            steps.Add($"\nSolution: x = {SolveSimple(a, b, c):F2}");
            
            return steps;
        }

        /// <summary>
        /// Helper method to format a term with coefficient and variable
        /// </summary>
        private static string FormatTerm(double coefficient, string variable, bool isFirst)
        {
            if (coefficient == 0)
                return "";
            
            string sign = "";
            if (!isFirst)
                sign = coefficient > 0 ? " + " : " - ";
            else if (coefficient < 0)
                sign = "-";
            
            double absCoeff = Math.Abs(coefficient);
            
            if (absCoeff == 1)
                return $"{sign}{variable}";
            else
                return $"{sign}{absCoeff}{variable}";
        }

        /// <summary>
        /// Helper method to format a constant term
        /// </summary>
        private static string FormatConstant(double constant)
        {
            if (constant == 0)
                return "";
            
            if (constant > 0)
                return $"+ {constant}";
            else
                return $"- {Math.Abs(constant)}";
        }
    }
}
