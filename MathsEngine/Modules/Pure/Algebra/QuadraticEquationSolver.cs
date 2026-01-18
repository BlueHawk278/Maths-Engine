using MathsEngine.Utils;
using static MathsEngine.Utils.MathConstants;

namespace MathsEngine.Modules.Pure.Algebra
{
    /// <summary>
    /// Represents the type of solution for a quadratic equation
    /// </summary>
    public enum QuadraticSolutionType
    {
        /// <summary>Two distinct real roots</summary>
        TwoRealRoots,
        /// <summary>One repeated real root</summary>
        OneRepeatedRoot,
        /// <summary>Two complex conjugate roots</summary>
        TwoComplexRoots
    }

    /// <summary>
    /// Represents the solution to a quadratic equation
    /// </summary>
    public class QuadraticSolution
    {
        /// <summary>First real root (if exists)</summary>
        public double? Root1 { get; set; }
        
        /// <summary>Second real root (if exists)</summary>
        public double? Root2 { get; set; }
        
        /// <summary>Discriminant value (b² - 4ac)</summary>
        public double Discriminant { get; set; }
        
        /// <summary>Type of solution</summary>
        public QuadraticSolutionType SolutionType { get; set; }
        
        /// <summary>Real part of complex roots (if applicable)</summary>
        public double? ComplexRealPart { get; set; }
        
        /// <summary>Imaginary part of complex roots (if applicable)</summary>
        public double? ComplexImaginaryPart { get; set; }
    }

    /// <summary>
    /// Provides methods for solving quadratic equations
    /// </summary>
    public static class QuadraticEquationSolver
    {
        /// <summary>
        /// Solves a quadratic equation of the form: ax² + bx + c = 0
        /// Uses the quadratic formula: x = (-b ± √(b² - 4ac)) / 2a
        /// </summary>
        /// <param name="a">Coefficient of x². Must not be zero.</param>
        /// <param name="b">Coefficient of x.</param>
        /// <param name="c">Constant term.</param>
        /// <returns>QuadraticSolution object containing roots and solution type.</returns>
        /// <exception cref="NotQuadraticException">Thrown when coefficient a is zero.</exception>
        /// <example>
        /// To solve x² - 5x + 6 = 0:
        /// <code>
        /// var solution = QuadraticEquationSolver.Solve(1, -5, 6);
        /// // Returns: Root1 = 2, Root2 = 3
        /// </code>
        /// </example>
        public static QuadraticSolution Solve(double a, double b, double c)
        {
            if (a == 0)
                throw new NotQuadraticException("Coefficient 'a' cannot be zero in a quadratic equation.");

            var solution = new QuadraticSolution();
            solution.Discriminant = CalculateDiscriminant(a, b, c);

            if (solution.Discriminant > EQUALITY_TOLERANCE)
            {
                // Two distinct real roots
                solution.SolutionType = QuadraticSolutionType.TwoRealRoots;
                double sqrtDiscriminant = Math.Sqrt(solution.Discriminant);
                solution.Root1 = (-b + sqrtDiscriminant) / (2 * a);
                solution.Root2 = (-b - sqrtDiscriminant) / (2 * a);
            }
            else if (Math.Abs(solution.Discriminant) <= EQUALITY_TOLERANCE)
            {
                // One repeated root
                solution.SolutionType = QuadraticSolutionType.OneRepeatedRoot;
                solution.Root1 = -b / (2 * a);
                solution.Root2 = solution.Root1;
            }
            else
            {
                // Complex roots
                solution.SolutionType = QuadraticSolutionType.TwoComplexRoots;
                solution.ComplexRealPart = -b / (2 * a);
                solution.ComplexImaginaryPart = Math.Sqrt(Math.Abs(solution.Discriminant)) / (2 * a);
            }

            return solution;
        }

        /// <summary>
        /// Calculates the discriminant (b² - 4ac) of a quadratic equation
        /// </summary>
        /// <param name="a">Coefficient of x²</param>
        /// <param name="b">Coefficient of x</param>
        /// <param name="c">Constant term</param>
        /// <returns>The discriminant value</returns>
        public static double CalculateDiscriminant(double a, double b, double c)
        {
            return (b * b) - (4 * a * c);
        }

        /// <summary>
        /// Generates step-by-step solution for a quadratic equation
        /// </summary>
        /// <param name="a">Coefficient of x²</param>
        /// <param name="b">Coefficient of x</param>
        /// <param name="c">Constant term</param>
        /// <returns>List of solution steps as strings</returns>
        public static List<string> GetSolutionSteps(double a, double b, double c)
        {
            var steps = new List<string>();
            
            steps.Add($"Original equation: {FormatQuadratic(a, b, c)} = 0");
            steps.Add("\nUsing the quadratic formula: x = (-b ± √(b² - 4ac)) / 2a");
            
            double discriminant = CalculateDiscriminant(a, b, c);
            steps.Add($"\nStep 1: Calculate discriminant (b² - 4ac)");
            steps.Add($"        Discriminant = ({b})² - 4({a})({c})");
            steps.Add($"        Discriminant = {b * b} - {4 * a * c}");
            steps.Add($"        Discriminant = {discriminant}");
            
            if (discriminant > EQUALITY_TOLERANCE)
            {
                steps.Add($"\nStep 2: Since discriminant > 0, there are two real roots");
                double sqrtDisc = Math.Sqrt(discriminant);
                steps.Add($"        √(discriminant) = √{discriminant:F2} = {sqrtDisc:F2}");
                
                steps.Add($"\nStep 3: Apply quadratic formula");
                steps.Add($"        x = (-({b}) ± {sqrtDisc:F2}) / (2 × {a})");
                steps.Add($"        x = ({-b} ± {sqrtDisc:F2}) / {2 * a}");
                
                var solution = Solve(a, b, c);
                steps.Add($"\nSolutions:");
                steps.Add($"        x₁ = {solution.Root1:F2}");
                steps.Add($"        x₂ = {solution.Root2:F2}");
            }
            else if (Math.Abs(discriminant) <= EQUALITY_TOLERANCE)
            {
                steps.Add($"\nStep 2: Since discriminant = 0, there is one repeated root");
                var solution = Solve(a, b, c);
                steps.Add($"\nSolution: x = {solution.Root1:F2} (repeated root)");
            }
            else
            {
                steps.Add($"\nStep 2: Since discriminant < 0, there are two complex roots");
                var solution = Solve(a, b, c);
                steps.Add($"\nSolutions:");
                steps.Add($"        x₁ = {solution.ComplexRealPart:F2} + {solution.ComplexImaginaryPart:F2}i");
                steps.Add($"        x₂ = {solution.ComplexRealPart:F2} - {solution.ComplexImaginaryPart:F2}i");
            }
            
            return steps;
        }

        /// <summary>
        /// Helper method to format a quadratic equation
        /// </summary>
        private static string FormatQuadratic(double a, double b, double c)
        {
            string result = "";
            
            // x² term
            if (a == 1)
                result = "x²";
            else if (a == -1)
                result = "-x²";
            else
                result = $"{a}x²";
            
            // x term
            if (b != 0)
            {
                if (b > 0)
                    result += " + ";
                else
                    result += " - ";
                
                double absB = Math.Abs(b);
                if (absB == 1)
                    result += "x";
                else
                    result += $"{absB}x";
            }
            
            // constant term
            if (c != 0)
            {
                if (c > 0)
                    result += $" + {c}";
                else
                    result += $" - {Math.Abs(c)}";
            }
            
            return result;
        }
    }
}
