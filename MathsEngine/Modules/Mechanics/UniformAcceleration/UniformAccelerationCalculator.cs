using MathsEngine.Utils;

namespace MathsEngine.Modules.Mechanics.UniformAcceleration
{
    /// <summary>
    /// Provides methods for calculations involving uniform acceleration, commonly known as the SUVAT equations.
    /// </summary>
    public static class UniformAccelerationCalculator
    {
        /// <summary>
        /// Calculates the average velocity given an initial and final velocity.
        /// </summary>
        /// <param name="initialVelocity">The initial velocity (u).</param>
        /// <param name="finalVelocity">The final velocity (v).</param>
        /// <returns>The average velocity.</returns>
        /// <exception cref="NullInputException">Thrown when either initial or final velocity is null.</exception>
        public static double CalculateAverageVelocity(double? initialVelocity, double? finalVelocity)
        {
            if (initialVelocity is null || finalVelocity is null)
                throw new NullInputException();

            return (Convert.ToDouble(initialVelocity) + Convert.ToDouble(finalVelocity)) / 2;
        }

        /// <summary>
        /// Solves the equation of motion v = u + at for the single unknown variable.
        /// </summary>
        /// <param name="v">Final velocity. Can be null if it's the value to be calculated.</param>
        /// <param name="u">Initial velocity. Can be null if it's the value to be calculated.</param>
        /// <param name="a">Acceleration. Can be null if it's the value to be calculated.</param>
        /// <param name="t">Time. Can be null if it's the value to be calculated.</param>
        /// <returns>The calculated value of the missing variable, or null if all variables are provided.</returns>
        /// <exception cref="InvalidOperationException">Thrown if more than one input is null.</exception>
        /// <exception cref="DivideByZeroException">Thrown if a division by zero occurs during calculation.</exception>
        public static double? CalculateVUAT(double? v, double? u, double? a, double? t)
        {
            int missingCount =
                (v is null ? 1 : 0) +
                (u is null ? 1 : 0) +
                (a is null ? 1 : 0) +
                (t is null ? 1 : 0);

            if (missingCount > 1)
                throw new InvalidOperationException("Exactly one parameter must be null to be calculated.");

            if (v == null) // v = u + at 
                return Convert.ToDouble(Convert.ToDouble(u) + Convert.ToDouble(a) * Convert.ToDouble(t));

            if (u == null) // u = v - at
                return Convert.ToDouble(Convert.ToDouble(v) - Convert.ToDouble(a) * Convert.ToDouble(t));

            if (a == null) // a = v - u / t
            {
                double time = Convert.ToDouble(t);
                if (time == 0)
                    throw new DivideByZeroException("Time (t) cannot be zero when calculating acceleration.");
                return Convert.ToDouble((Convert.ToDouble(v) - Convert.ToDouble(u)) / time);
            }

            if (t == null) // t = v - u / a
            {
                double acceleration = Convert.ToDouble(a);
                if (acceleration == 0)
                    throw new DivideByZeroException("Acceleration (a) cannot be zero when calculating time.");
                return Convert.ToDouble((Convert.ToDouble(v) - Convert.ToDouble(u)) / acceleration);
            }

            return null;
        }

        /// <summary>
        /// Solves the equation of motion v^2 = u^2 + 2as for the single unknown variable.
        /// </summary>
        /// <param name="v">Final velocity. Can be null if it's the value to be calculated.</param>
        /// <param name="u">Initial velocity. Can be null if it's the value to be calculated.</param>
        /// <param name="a">Acceleration. Can be null if it's the value to be calculated.</param>
        /// <param name="s">Displacement. Can be null if it's the value to be calculated.</param>
        /// <returns>The calculated value of the missing variable, or null if all variables are provided.</returns>
        /// <exception cref="InvalidOperationException">Thrown if more than one input is null.</exception>
        /// <exception cref="DivideByZeroException">Thrown if a division by zero occurs during calculation.</exception>
        public static double? CalculateVUAS(double? v, double? u, double? a, double? s)
        {
            int missingCount =
                (v is null ? 1 : 0) +
                (u is null ? 1 : 0) +
                (a is null ? 1 : 0) +
                (s is null ? 1 : 0);

            if (missingCount > 1)
                throw new Exception();

            if (v == null) // v^2 = u^2 + 2as
                return Convert.ToDouble(Math.Sqrt(Math.Pow(Convert.ToDouble(u), 2) + 2 * (Convert.ToDouble(a) * Convert.ToDouble(s))));
            if (u == null) // u^2 = v^2 - 2as
                return Convert.ToDouble(Math.Sqrt(Math.Pow(Convert.ToDouble(v), 2) - 2 * (Convert.ToDouble(a) * Convert.ToDouble(s))));
            if (a == null) // a = (v^2 - u^2) / 2s
            {
                double displacement = Convert.ToDouble(s);
                if (displacement == 0)
                    throw new DivideByZeroException("Displacement (s) cannot be zero when calculating acceleration.");
                return Convert.ToDouble((Math.Pow(Convert.ToDouble(v), 2) - Math.Pow(Convert.ToDouble(u), 2)) / (2 * displacement));
            }
            if (s == null) // s = (v^2 - u^2) / 2a
            {
                double acceleration = Convert.ToDouble(a);
                if (acceleration == 0)
                    throw new DivideByZeroException("Acceleration (a) cannot be zero when calculating displacement.");
                return Convert.ToDouble((Math.Pow(Convert.ToDouble(v), 2) - Math.Pow(Convert.ToDouble(u), 2)) / (2 * acceleration));
            }

            return null;
        }

        /// <summary>
        /// Solves the equation of motion s = 0.5 * (u + v) * t for the single unknown variable.
        /// </summary>
        /// <param name="s">Displacement. Can be null if it's the value to be calculated.</param>
        /// <param name="u">Initial velocity. Can be null if it's the value to be calculated.</param>
        /// <param name="v">Final velocity. Can be null if it's the value to be calculated.</param>
        /// <param name="t">Time. Can be null if it's the value to be calculated.</param>
        /// <returns>The calculated value of the missing variable, or null if all variables are provided.</returns>
        /// <exception cref="InvalidOperationException">Thrown if more than one input is null.</exception>
        /// <exception cref="DivideByZeroException">Thrown if a division by zero occurs during calculation.</exception>
        public static double? CalculateSUVT(double? s, double? u, double? v, double? t)
        {
            int missingCount =
                (s is null ? 1 : 0) +
                (u is null ? 1 : 0) +
                (v is null ? 1 : 0) +
                (t is null ? 1 : 0);

            if (missingCount > 1)
                throw new Exception();

            if (s == null) // s = 0.5 * (u + v) * t
                return Convert.ToDouble((Convert.ToDouble(u) + Convert.ToDouble(v)) * Convert.ToDouble(t) / 2);
            if (u == null) // u = (2s / t) - v
            {
                double time = Convert.ToDouble(t);
                if (time == 0)
                    throw new DivideByZeroException("Time (t) cannot be zero when calculating initial velocity.");
                return Convert.ToDouble((2 * Convert.ToDouble(s) / time) - Convert.ToDouble(v));
            }
            if (v == null) // v = (2s / t) - u
            {
                double time = Convert.ToDouble(t);
                if (time == 0)
                    throw new DivideByZeroException("Time (t) cannot be zero when calculating final velocity.");
                return Convert.ToDouble((2 * Convert.ToDouble(s) / time) - Convert.ToDouble(u));
            }
            if (t == null) // t = 2s / (u + v)
            {
                double velocitySum = Convert.ToDouble(u) + Convert.ToDouble(v);
                if (velocitySum == 0)
                    throw new DivideByZeroException("Sum of initial and final velocities (u + v) cannot be zero.");
                return Convert.ToDouble((2 * Convert.ToDouble(s)) / velocitySum);
            }

            return null;
        }

        /// <summary>
        /// Solves the equation of motion s = ut + 0.5at^2 for the single unknown variable.
        /// </summary>
        /// <param name="s">Displacement. Can be null if it's the value to be calculated.</param>
        /// <param name="u">Initial velocity. Can be null if it's the value to be calculated.</param>
        /// <param name="a">Acceleration. Can be null if it's the value to be calculated.</param>
        /// <param name="t">Time. Can be null if it's the value to be calculated.</param>
        /// <returns>The calculated value of the missing variable, or null if all variables are provided. When calculating time (t), returns the positive, non-zero solution.</returns>
        /// <exception cref="InvalidOperationException">Thrown if more than one input is null, or if no real solution exists for time (t).</exception>
        /// <exception cref="DivideByZeroException">Thrown if a division by zero occurs during calculation.</exception>
        public static double? CalculateSUTAT(double? s, double? u, double? a, double? t)
        {
            int missingCount =
                (s is null ? 1 : 0) +
                (u is null ? 1 : 0) +
                (a is null ? 1 : 0) +
                (t is null ? 1 : 0);

            if (missingCount > 1)
                throw new Exception();

            if (s == null) // s = ut + 0.5at^2
            {
                return Convert.ToDouble(Convert.ToDouble(u) * Convert.ToDouble(t) + 0.5 * Convert.ToDouble(a) * Math.Pow(Convert.ToDouble(t), 2));
            }
            if (u == null) // u = (s - 0.5at^2) / t
            {
                double time = Convert.ToDouble(t);
                if (time == 0)
                    throw new DivideByZeroException("Time (t) cannot be zero.");
                return Convert.ToDouble((Convert.ToDouble(s) - 0.5 * Convert.ToDouble(a) * Math.Pow(time, 2)) / time);
            }
            if (a == null) // a = 2(s - ut) / t^2
            {
                double time = Convert.ToDouble(t);
                if (time == 0)
                    throw new DivideByZeroException("Time (t) cannot be zero.");
                return Convert.ToDouble(2 * (Convert.ToDouble(s) - Convert.ToDouble(u) * time) / Math.Pow(time, 2));
            }
            if (t == null) // 0.5at^2 + ut - s = 0
            {
                double acceleration = Convert.ToDouble(a);
                double initialVelocity = Convert.ToDouble(u);
                double displacement = Convert.ToDouble(s);

                if (acceleration == 0)
                {
                    if (initialVelocity == 0)
                        throw new InvalidOperationException("Both acceleration and initial velocity cannot be zero.");
                    return Convert.ToDouble(displacement / initialVelocity);
                }

                // Solve using the quadratic formula: t = (-b ± sqrt(b^2 - 4ac)) / 2a
                double discriminant = Math.Pow(initialVelocity, 2) - 4 * (0.5 * acceleration) * (-displacement);
                if (discriminant < 0)
                    throw new InvalidOperationException("No real solution for time (t) exists with these values.");

                double t1 = (-initialVelocity + Math.Sqrt(discriminant)) / (2 * 0.5 * acceleration);
                double t2 = (-initialVelocity - Math.Sqrt(discriminant)) / (2 * 0.5 * acceleration);

                // Return the positive, non-zero solution if one exists
                if (t1 > 0) return Convert.ToDouble(t1);
                if (t2 > 0) return Convert.ToDouble(t2);
                return null; // Or handle cases where time is zero or negative
            }

            return null;
        }
    }
}
