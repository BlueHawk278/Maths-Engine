using System;

namespace MathsEngine.Modules.Pure.Algebra
{
    /// <summary>
    /// Represents a linear equation in slope-intercept form: y = mx + c
    /// </summary>
    /// <remarks>
    /// This immutable struct represents a line in 2D space.
    /// Linear equations are fundamental to calculus as they represent:
    /// - Tangent lines (derivatives)
    /// - Linear approximations
    /// - Rates of change
    /// </remarks>
    public readonly struct LinearEquation : IEquatable<LinearEquation>
    {
        /// <summary>
        /// The slope (gradient) of the line (m in y = mx + c).
        /// </summary>
        public double Slope { get; }

        /// <summary>
        /// The y-intercept of the line (c in y = mx + c).
        /// </summary>
        public double Intercept { get; }

        /// <summary>
        /// Indicates whether the line is vertical (undefined slope).
        /// </summary>
        public bool IsVertical { get; }

        /// <summary>
        /// For vertical lines, the x-coordinate where the line exists.
        /// </summary>
        public double? VerticalX { get; }

        /// <summary>
        /// Initializes a new linear equation in slope-intercept form y = mx + c.
        /// </summary>
        /// <param name="slope">The slope (m) of the line.</param>
        /// <param name="intercept">The y-intercept (c) of the line.</param>
        public LinearEquation(double slope, double intercept)
        {
            Slope = slope;
            Intercept = intercept;
            IsVertical = false;
            VerticalX = null;
        }

        /// <summary>
        /// Initializes a vertical line at x = verticalX.
        /// </summary>
        /// <param name="verticalX">The x-coordinate of the vertical line.</param>
        private LinearEquation(double verticalX)
        {
            Slope = double.PositiveInfinity;
            Intercept = 0;
            IsVertical = true;
            VerticalX = verticalX;
        }

        /// <summary>
        /// Creates a vertical line at the specified x-coordinate.
        /// </summary>
        /// <param name="x">The x-coordinate.</param>
        /// <returns>A vertical line equation.</returns>
        public static LinearEquation CreateVertical(double x) => new LinearEquation(x);

        /// <summary>
        /// Evaluates y for a given x value.
        /// </summary>
        /// <param name="x">The x value.</param>
        /// <returns>The corresponding y value (or null for vertical lines).</returns>
        public double? Evaluate(double x)
        {
            if (IsVertical)
                return null;  // Vertical lines don't have y as a function of x
            
            return Slope * x + Intercept;
        }

        /// <summary>
        /// Returns the equation as a string.
        /// </summary>
        public override string ToString()
        {
            if (IsVertical)
                return $"x = {VerticalX}";

            if (Math.Abs(Slope) < 1e-9)
                return $"y = {Intercept}";  // Horizontal line

            string slopeStr = Math.Abs(Slope - 1) < 1e-9 ? "x" : $"{Slope}x";
            string interceptStr = Intercept >= 0 ? $" + {Intercept}" : $" - {-Intercept}";
            
            if (Math.Abs(Intercept) < 1e-9)
                return $"y = {slopeStr}";
            
            return $"y = {slopeStr}{interceptStr}";
        }

        public bool Equals(LinearEquation other)
        {
            if (IsVertical && other.IsVertical)
                return Math.Abs(VerticalX!.Value - other.VerticalX!.Value) < 1e-9;
            
            if (IsVertical || other.IsVertical)
                return false;

            return Math.Abs(Slope - other.Slope) < 1e-9 && 
                   Math.Abs(Intercept - other.Intercept) < 1e-9;
        }

        public override bool Equals(object? obj) => obj is LinearEquation other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(Slope, Intercept, IsVertical, VerticalX);

        public static bool operator ==(LinearEquation left, LinearEquation right) => left.Equals(right);
        public static bool operator !=(LinearEquation left, LinearEquation right) => !left.Equals(right);
    }

    /// <summary>
    /// Provides static methods for operations on linear equations.
    /// </summary>
    /// <remarks>
    /// Linear equations form the foundation for calculus concepts:
    /// - Tangent lines to curves (derivatives)
    /// - Linear approximations (differentials)
    /// - First-order Taylor series
    /// - Newton's method for finding roots
    /// </remarks>
    public static class LinearEquations
    {
        /// <summary>
        /// Creates a linear equation from two points.
        /// </summary>
        /// <param name="x1">X-coordinate of first point.</param>
        /// <param name="y1">Y-coordinate of first point.</param>
        /// <param name="x2">X-coordinate of second point.</param>
        /// <param name="y2">Y-coordinate of second point.</param>
        /// <returns>The linear equation passing through both points.</returns>
        /// <remarks>
        /// This uses the two-point form: (y - y1) = m(x - x1) where m = (y2 - y1) / (x2 - x1)
        /// </remarks>
        /// <example>
        /// <code>
        /// // Find line through (1, 2) and (3, 6)
        /// var line = LinearEquations.FromTwoPoints(1, 2, 3, 6);
        /// // Returns y = 2x + 0 (slope = 4/2 = 2)
        /// 
        /// // Find line through (0, 5) and (2, 5)
        /// var horizontal = LinearEquations.FromTwoPoints(0, 5, 2, 5);
        /// // Returns y = 5 (horizontal line, slope = 0)
        /// </code>
        /// </example>
        public static LinearEquation FromTwoPoints(double x1, double y1, double x2, double y2)
        {
            // Check for vertical line
            if (Math.Abs(x2 - x1) < 1e-9)
                return LinearEquation.CreateVertical(x1);

            // Calculate slope: m = (y2 - y1) / (x2 - x1)
            double slope = (y2 - y1) / (x2 - x1);

            // Calculate intercept: c = y1 - m * x1
            double intercept = y1 - slope * x1;

            return new LinearEquation(slope, intercept);
        }

        /// <summary>
        /// Creates a linear equation from a point and a slope.
        /// </summary>
        /// <param name="x">X-coordinate of the point.</param>
        /// <param name="y">Y-coordinate of the point.</param>
        /// <param name="slope">The slope of the line.</param>
        /// <returns>The linear equation with given slope through the point.</returns>
        /// <remarks>
        /// This is particularly useful for finding tangent lines in calculus,
        /// where you have a point on a curve and the derivative (slope) at that point.
        /// </remarks>
        /// <example>
        /// <code>
        /// // Create tangent line at point (2, 5) with slope 3
        /// var tangent = LinearEquations.FromPointAndSlope(2, 5, 3);
        /// // Returns y = 3x - 1
        /// // (because 5 = 3(2) + c, so c = -1)
        /// </code>
        /// </example>
        public static LinearEquation FromPointAndSlope(double x, double y, double slope)
        {
            // Use point-slope form: y - y1 = m(x - x1)
            // Rearranging to slope-intercept: y = mx + (y1 - m*x1)
            double intercept = y - slope * x;
            return new LinearEquation(slope, intercept);
        }

        /// <summary>
        /// Finds the intersection point of two lines.
        /// </summary>
        /// <param name="line1">First line.</param>
        /// <param name="line2">Second line.</param>
        /// <returns>The point of intersection (x, y).</returns>
        /// <exception cref="ParallelLinesException">Thrown when lines are parallel.</exception>
        /// <exception cref="IdenticalLinesException">Thrown when lines are identical.</exception>
        /// <remarks>
        /// For lines y = m1*x + c1 and y = m2*x + c2:
        /// At intersection: m1*x + c1 = m2*x + c2
        /// Solving: x = (c2 - c1) / (m1 - m2)
        /// Then: y = m1*x + c1
        /// </remarks>
        /// <example>
        /// <code>
        /// var line1 = new LinearEquation(2, 3);   // y = 2x + 3
        /// var line2 = new LinearEquation(-1, 9);  // y = -x + 9
        /// var intersection = LinearEquations.FindIntersection(line1, line2);
        /// // Returns (2, 7)
        /// // Verification: 2(2) + 3 = 7, -(2) + 9 = 7 ✓
        /// </code>
        /// </example>
        public static (double x, double y) FindIntersection(LinearEquation line1, LinearEquation line2)
        {
            // Handle vertical lines
            if (line1.IsVertical && line2.IsVertical)
            {
                if (Math.Abs(line1.VerticalX!.Value - line2.VerticalX!.Value) < 1e-9)
                    throw new IdenticalLinesException();
                throw new ParallelLinesException();
            }

            if (line1.IsVertical)
            {
                double x = line1.VerticalX!.Value;
                double y = line2.Slope * x + line2.Intercept;
                return (x, y);
            }

            if (line2.IsVertical)
            {
                double x = line2.VerticalX!.Value;
                double y = line1.Slope * x + line1.Intercept;
                return (x, y);
            }

            // Check if parallel (same slope)
            if (Math.Abs(line1.Slope - line2.Slope) < 1e-9)
            {
                // Check if identical (same slope and intercept)
                if (Math.Abs(line1.Intercept - line2.Intercept) < 1e-9)
                    throw new IdenticalLinesException();
                throw new ParallelLinesException();
            }

            // Find intersection: m1*x + c1 = m2*x + c2
            // x = (c2 - c1) / (m1 - m2)
            double xIntersect = (line2.Intercept - line1.Intercept) / (line1.Slope - line2.Slope);
            double yIntersect = line1.Slope * xIntersect + line1.Intercept;

            return (xIntersect, yIntersect);
        }

        /// <summary>
        /// Determines if two lines are parallel.
        /// </summary>
        /// <param name="line1">First line.</param>
        /// <param name="line2">Second line.</param>
        /// <returns>True if lines are parallel (but not identical), false otherwise.</returns>
        /// <example>
        /// <code>
        /// var line1 = new LinearEquation(2, 3);  // y = 2x + 3
        /// var line2 = new LinearEquation(2, 5);  // y = 2x + 5
        /// bool parallel = LinearEquations.AreParallel(line1, line2);
        /// // Returns true (same slope, different intercepts)
        /// </code>
        /// </example>
        public static bool AreParallel(LinearEquation line1, LinearEquation line2)
        {
            if (line1.IsVertical && line2.IsVertical)
                return Math.Abs(line1.VerticalX!.Value - line2.VerticalX!.Value) >= 1e-9;

            if (line1.IsVertical || line2.IsVertical)
                return false;

            bool sameSlope = Math.Abs(line1.Slope - line2.Slope) < 1e-9;
            bool differentIntercept = Math.Abs(line1.Intercept - line2.Intercept) >= 1e-9;

            return sameSlope && differentIntercept;
        }

        /// <summary>
        /// Determines if two lines are perpendicular.
        /// </summary>
        /// <param name="line1">First line.</param>
        /// <param name="line2">Second line.</param>
        /// <returns>True if lines are perpendicular, false otherwise.</returns>
        /// <remarks>
        /// Two lines are perpendicular if m1 * m2 = -1 (slopes are negative reciprocals).
        /// Special case: horizontal and vertical lines are always perpendicular.
        /// </remarks>
        /// <example>
        /// <code>
        /// var line1 = new LinearEquation(2, 0);   // y = 2x
        /// var line2 = new LinearEquation(-0.5, 3); // y = -0.5x + 3
        /// bool perpendicular = LinearEquations.ArePerpendicular(line1, line2);
        /// // Returns true (2 * -0.5 = -1)
        /// </code>
        /// </example>
        public static bool ArePerpendicular(LinearEquation line1, LinearEquation line2)
        {
            // One vertical, one horizontal
            if (line1.IsVertical && Math.Abs(line2.Slope) < 1e-9)
                return true;
            if (line2.IsVertical && Math.Abs(line1.Slope) < 1e-9)
                return true;

            if (line1.IsVertical || line2.IsVertical)
                return false;

            // Check if m1 * m2 = -1
            return Math.Abs(line1.Slope * line2.Slope + 1) < 1e-9;
        }

        /// <summary>
        /// Finds the perpendicular line passing through a given point.
        /// </summary>
        /// <param name="line">The original line.</param>
        /// <param name="x">X-coordinate of the point.</param>
        /// <param name="y">Y-coordinate of the point.</param>
        /// <returns>A line perpendicular to the original, passing through (x, y).</returns>
        /// <remarks>
        /// This is particularly useful in calculus for finding normal lines to curves.
        /// The normal line at a point is perpendicular to the tangent line.
        /// </remarks>
        /// <example>
        /// <code>
        /// var tangent = new LinearEquation(2, 1);  // y = 2x + 1
        /// var normal = LinearEquations.PerpendicularThrough(tangent, 1, 3);
        /// // Returns y = -0.5x + 3.5 (perpendicular slope = -1/2)
        /// </code>
        /// </example>
        public static LinearEquation PerpendicularThrough(LinearEquation line, double x, double y)
        {
            if (line.IsVertical)
            {
                // Perpendicular to vertical is horizontal
                return new LinearEquation(0, y);
            }

            if (Math.Abs(line.Slope) < 1e-9)
            {
                // Perpendicular to horizontal is vertical
                return LinearEquation.CreateVertical(x);
            }

            // Perpendicular slope is negative reciprocal
            double perpendicularSlope = -1.0 / line.Slope;
            return FromPointAndSlope(x, y, perpendicularSlope);
        }

        /// <summary>
        /// Calculates the distance from a point to a line.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="x">X-coordinate of the point.</param>
        /// <param name="y">Y-coordinate of the point.</param>
        /// <returns>The perpendicular distance from the point to the line.</returns>
        /// <remarks>
        /// For line ax + by + c = 0 and point (x0, y0):
        /// Distance = |ax0 + by0 + c| / √(a² + b²)
        /// 
        /// Converting y = mx + c to standard form: mx - y + c = 0
        /// So a = m, b = -1, c = intercept
        /// </remarks>
        /// <example>
        /// <code>
        /// var line = new LinearEquation(1, 0);  // y = x
        /// double distance = LinearEquations.DistanceFromPoint(line, 3, 0);
        /// // Returns approximately 2.12 (distance from (3, 0) to y = x)
        /// </code>
        /// </example>
        public static double DistanceFromPoint(LinearEquation line, double x, double y)
        {
            if (line.IsVertical)
            {
                return Math.Abs(x - line.VerticalX!.Value);
            }

            // Convert to standard form: mx - y + c = 0
            double a = line.Slope;
            double b = -1;
            double c = line.Intercept;

            // Distance formula: |ax0 + by0 + c| / √(a² + b²)
            return Math.Abs(a * x + b * y + c) / Math.Sqrt(a * a + b * b);
        }

        // TODO: Future enhancements for calculus integration
        // - Find tangent line to a curve at a point (requires derivative)
        // - Find normal line to a curve at a point
        // - Linear approximation / linearization of functions
        // - Newton's method for root finding
        // - Systems of linear equations (2x2, 3x3, etc.)
        // - Matrix representation of linear systems
        // - Least squares regression (best-fit line)
    }
}
