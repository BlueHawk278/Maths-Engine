using System;

namespace MathsEngine.Modules.Pure.Algebra
{
    /// <summary>
    /// Represents the result of solving a quadratic equation.
    /// </summary>
    public class QuadraticResult
    {
        /// <summary>
        /// The discriminant (b² - 4ac) of the quadratic equation.
        /// </summary>
        public double Discriminant { get; }

        /// <summary>
        /// Indicates the number of real roots (0, 1, or 2).
        /// </summary>
        public int NumberOfRealRoots { get; }

        /// <summary>
        /// The first real root (if it exists).
        /// </summary>
        public double? Root1 { get; }

        /// <summary>
        /// The second real root (if it exists).
        /// </summary>
        public double? Root2 { get; }

        /// <summary>
        /// Indicates whether the equation has complex roots.
        /// </summary>
        public bool HasComplexRoots => Discriminant < 0;

        /// <summary>
        /// Indicates whether the equation has a repeated root.
        /// </summary>
        public bool HasRepeatedRoot => Math.Abs(Discriminant) < 1e-9;

        internal QuadraticResult(double discriminant, double? root1, double? root2, int numberOfRealRoots)
        {
            Discriminant = discriminant;
            Root1 = root1;
            Root2 = root2;
            NumberOfRealRoots = numberOfRealRoots;
        }
    }

    /// <summary>
    /// Represents a quadratic in completed square form: a(x - h)² + k
    /// </summary>
    public class CompletedSquareForm
    {
        /// <summary>
        /// The coefficient 'a' in a(x - h)² + k
        /// </summary>
        public double A { get; }

        /// <summary>
        /// The horizontal shift 'h' in a(x - h)² + k (vertex x-coordinate)
        /// </summary>
        public double H { get; }

        /// <summary>
        /// The vertical shift 'k' in a(x - h)² + k (vertex y-coordinate)
        /// </summary>
        public double K { get; }

        /// <summary>
        /// The vertex of the parabola (h, k)
        /// </summary>
        public (double x, double y) Vertex => (H, K);

        /// <summary>
        /// The axis of symmetry x = h
        /// </summary>
        public double AxisOfSymmetry => H;

        internal CompletedSquareForm(double a, double h, double k)
        {
            A = a;
            H = h;
            K = k;
        }

        /// <summary>
        /// Returns the equation in completed square form as a string.
        /// </summary>
        public override string ToString()
        {
            string aStr = Math.Abs(A - 1) < 1e-9 ? "" : $"{A}";
            string hStr = H >= 0 ? $"(x - {H})" : $"(x + {-H})";
            string kStr = K >= 0 ? $" + {K}" : $" - {-K}";
            return $"{aStr}{hStr}²{kStr}";
        }
    }

    /// <summary>
    /// Provides static methods for solving and manipulating quadratic equations.
    /// </summary>
    /// <remarks>
    /// A quadratic equation has the form ax² + bx + c = 0 where a ≠ 0.
    /// This class provides multiple solution methods and forms the basis for:
    /// - Optimization problems (finding maxima/minima via derivatives)
    /// - Integration of polynomial functions
    /// - Curve fitting and regression analysis
    /// </remarks>
    public static class QuadraticEquations
    {
        /// <summary>
        /// Solves a quadratic equation ax² + bx + c = 0 using the quadratic formula.
        /// </summary>
        /// <param name="a">The coefficient of x² (cannot be zero).</param>
        /// <param name="b">The coefficient of x.</param>
        /// <param name="c">The constant term.</param>
        /// <returns>A QuadraticResult containing the discriminant and roots.</returns>
        /// <exception cref="NotQuadraticException">Thrown when a = 0.</exception>
        /// <example>
        /// <code>
        /// // Solve x² - 5x + 6 = 0
        /// var result = QuadraticEquations.Solve(1, -5, 6);
        /// // result.Root1 = 3, result.Root2 = 2
        /// 
        /// // Solve 2x² + 3x - 2 = 0
        /// var result2 = QuadraticEquations.Solve(2, 3, -2);
        /// // result2.Root1 = 0.5, result2.Root2 = -2
        /// 
        /// // Equation with no real roots: x² + 1 = 0
        /// var result3 = QuadraticEquations.Solve(1, 0, 1);
        /// // result3.HasComplexRoots = true, result3.NumberOfRealRoots = 0
        /// </code>
        /// </example>
        public static QuadraticResult Solve(double a, double b, double c)
        {
            if (Math.Abs(a) < 1e-9)
                throw new NotQuadraticException();

            // Calculate discriminant: b² - 4ac
            double discriminant = b * b - 4 * a * c;

            if (discriminant < -1e-9)
            {
                // Complex roots (no real solutions)
                return new QuadraticResult(discriminant, null, null, 0);
            }
            else if (Math.Abs(discriminant) < 1e-9)
            {
                // One repeated root: -b / 2a
                double root = -b / (2 * a);
                return new QuadraticResult(discriminant, root, root, 1);
            }
            else
            {
                // Two distinct real roots
                double sqrtDiscriminant = Math.Sqrt(discriminant);
                double root1 = (-b + sqrtDiscriminant) / (2 * a);
                double root2 = (-b - sqrtDiscriminant) / (2 * a);
                return new QuadraticResult(discriminant, root1, root2, 2);
            }
        }

        /// <summary>
        /// Completes the square for a quadratic ax² + bx + c, converting it to a(x - h)² + k form.
        /// </summary>
        /// <param name="a">The coefficient of x² (cannot be zero).</param>
        /// <param name="b">The coefficient of x.</param>
        /// <param name="c">The constant term.</param>
        /// <returns>A CompletedSquareForm object representing a(x - h)² + k.</returns>
        /// <exception cref="NotQuadraticException">Thrown when a = 0.</exception>
        /// <remarks>
        /// Completing the square is fundamental for:
        /// 1. Finding vertex form of a parabola
        /// 2. Deriving the quadratic formula
        /// 3. Integration techniques (particularly when integrating 1/(x² + bx + c))
        /// 4. Optimization problems
        /// 
        /// The transformation follows these steps:
        /// 1. ax² + bx + c
        /// 2. a(x² + (b/a)x) + c
        /// 3. a(x² + (b/a)x + (b/2a)² - (b/2a)²) + c
        /// 4. a(x + b/2a)² - a(b/2a)² + c
        /// 5. a(x - h)² + k where h = -b/2a, k = c - b²/4a
        /// </remarks>
        /// <example>
        /// <code>
        /// // Complete the square for x² + 6x + 5
        /// var result = QuadraticEquations.CompleteTheSquare(1, 6, 5);
        /// // Returns: (x + 3)² - 4
        /// // Vertex at (-3, -4)
        /// 
        /// // Complete the square for 2x² - 8x + 3
        /// var result2 = QuadraticEquations.CompleteTheSquare(2, -8, 3);
        /// // Returns: 2(x - 2)² - 5
        /// // Vertex at (2, -5)
        /// 
        /// // Complete the square for x² + 4x + 4
        /// var result3 = QuadraticEquations.CompleteTheSquare(1, 4, 4);
        /// // Returns: (x + 2)²
        /// // Vertex at (-2, 0) - this is a perfect square!
        /// </code>
        /// </example>
        public static CompletedSquareForm CompleteTheSquare(double a, double b, double c)
        {
            if (Math.Abs(a) < 1e-9)
                throw new NotQuadraticException();

            // Calculate h = -b / 2a (x-coordinate of vertex)
            double h = -b / (2 * a);

            // Calculate k = c - b² / 4a (y-coordinate of vertex)
            // Alternative: k = c - a * h²
            double k = c - (b * b) / (4 * a);

            return new CompletedSquareForm(a, h, k);
        }

        /// <summary>
        /// Calculates the vertex of a parabola from the quadratic ax² + bx + c.
        /// </summary>
        /// <param name="a">The coefficient of x².</param>
        /// <param name="b">The coefficient of x.</param>
        /// <param name="c">The constant term.</param>
        /// <returns>The vertex (h, k) of the parabola.</returns>
        /// <exception cref="NotQuadraticException">Thrown when a = 0.</exception>
        /// <remarks>
        /// The vertex represents the minimum (if a > 0) or maximum (if a &lt; 0) point of the parabola.
        /// This is directly related to calculus: the vertex occurs where the derivative equals zero.
        /// For f(x) = ax² + bx + c, f'(x) = 2ax + b, which equals 0 when x = -b/2a.
        /// </remarks>
        /// <example>
        /// <code>
        /// // Find vertex of y = x² - 4x + 3
        /// var vertex = QuadraticEquations.FindVertex(1, -4, 3);
        /// // Returns (2, -1) - minimum point at x = 2
        /// </code>
        /// </example>
        public static (double x, double y) FindVertex(double a, double b, double c)
        {
            if (Math.Abs(a) < 1e-9)
                throw new NotQuadraticException();

            double x = -b / (2 * a);
            double y = a * x * x + b * x + c;  // or use y = c - b²/4a
            return (x, y);
        }

        /// <summary>
        /// Determines whether a quadratic has real roots by checking the discriminant.
        /// </summary>
        /// <param name="a">The coefficient of x².</param>
        /// <param name="b">The coefficient of x.</param>
        /// <param name="c">The constant term.</param>
        /// <returns>True if the equation has real roots, false otherwise.</returns>
        /// <exception cref="NotQuadraticException">Thrown when a = 0.</exception>
        /// <example>
        /// <code>
        /// bool hasRoots = QuadraticEquations.HasRealRoots(1, 2, 3);
        /// // Returns false (discriminant = 4 - 12 = -8)
        /// 
        /// bool hasRoots2 = QuadraticEquations.HasRealRoots(1, 5, 6);
        /// // Returns true (discriminant = 25 - 24 = 1)
        /// </code>
        /// </example>
        public static bool HasRealRoots(double a, double b, double c)
        {
            if (Math.Abs(a) < 1e-9)
                throw new NotQuadraticException();

            double discriminant = b * b - 4 * a * c;
            return discriminant >= -1e-9;  // Allow small negative values due to floating-point errors
        }

        /// <summary>
        /// Evaluates a quadratic function at a given x value.
        /// </summary>
        /// <param name="a">The coefficient of x².</param>
        /// <param name="b">The coefficient of x.</param>
        /// <param name="c">The constant term.</param>
        /// <param name="x">The x value at which to evaluate.</param>
        /// <returns>The value of ax² + bx + c at the given x.</returns>
        /// <example>
        /// <code>
        /// // Evaluate y = 2x² - 3x + 1 at x = 2
        /// double y = QuadraticEquations.Evaluate(2, -3, 1, 2);
        /// // Returns 2(4) - 3(2) + 1 = 8 - 6 + 1 = 3
        /// </code>
        /// </example>
        public static double Evaluate(double a, double b, double c, double x)
        {
            return a * x * x + b * x + c;
        }

        // TODO: Future enhancements for calculus integration
        // - Factor quadratic (when possible)
        // - Find axis of symmetry
        // - Convert between different forms (standard, vertex, factored)
        // - Integration methods for quadratic functions
        // - Differentiation (connects to finding vertex, optimization)
        // - Applications: projectile motion, optimization problems
        // - Quadratic regression / curve fitting
    }
}
