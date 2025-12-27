using System;
using System.Collections.Generic;
using MathsEngine.Utils;

namespace MathsEngine.Modules.Mechanics.UniformAcceleration
{
    internal class UniformAccelerationCalculator
    {

        public static double CalculateAverageVelocity(string initialVelocity, string finalVelocity)
        {
            if (string.IsNullOrEmpty(initialVelocity) || string.IsNullOrEmpty(finalVelocity))
                throw new NullInputException("Side lengths must not be negative");

            return (Convert.ToDouble(initialVelocity) + Convert.ToDouble(finalVelocity)) / 2;
        }

        public static string CalculateVUAT(string v, string u, string a, string t)
        {
            // Check the values entered
            List<string> values = new List<string> { v, u, a, t };
            int invalidNums = 0;
            for (int i = 0; i < 4; i++)
                if (values[i] == null)
                    invalidNums++;
            if (invalidNums > 1)
                throw new NullValuesException("Side lengths must not be negative");

            if (v == null) // v = u + at 
                return Convert.ToString(Convert.ToDouble(u) + Convert.ToDouble(a) * Convert.ToDouble(t));

            if (u == null) // u = v - at
                return Convert.ToString(Convert.ToDouble(v) - Convert.ToDouble(a) * Convert.ToDouble(t));

            if (a == null) // a = v - u / t
                return Convert.ToString((Convert.ToDouble(v) - Convert.ToDouble(u)) / Convert.ToDouble(t));

            if (t == null) // t = v - u / a
                return Convert.ToString((Convert.ToDouble(v) - Convert.ToDouble(u)) / Convert.ToDouble(a));

            return "";
        }
        public static string CalculateVUAS(string v, string u, string a, string s)
        {
            // Check the values entered
            List<string> values = new List<string> { v, u, a, s };
            int invalidNums = 0;
            for (int i = 0; i < 4; i++)
                if (values[i] == null)
                    invalidNums++;
            if (invalidNums > 1)
                throw new NullValuesException("Side lengths must not be negative");

            if (v == null) // v^2 = u^2 + 2as
                return Convert.ToString(Math.Sqrt(Math.Pow(Convert.ToDouble(u), 2) + 2 * (Convert.ToDouble(a) * Convert.ToDouble(s))));
            if (u == null) // u^2 = v^2 - 2as
                return Convert.ToString(Math.Sqrt(Math.Pow(Convert.ToDouble(v), 2) - 2 * (Convert.ToDouble(a) * Convert.ToDouble(s))));
            if (a == null) // a = (v^2 - u^2) / 2s
            {
                double displacement = Convert.ToDouble(s);
                if (displacement == 0)
                    throw new DivideByZeroException("Displacement (s) cannot be zero when calculating acceleration.");
                return Convert.ToString((Math.Pow(Convert.ToDouble(v), 2) - Math.Pow(Convert.ToDouble(u), 2)) / (2 * displacement));
            }
            if (s == null) // s = (v^2 - u^2) / 2a
            {
                double acceleration = Convert.ToDouble(a);
                if (acceleration == 0)
                    throw new DivideByZeroException("Acceleration (a) cannot be zero when calculating displacement.");
                return Convert.ToString((Math.Pow(Convert.ToDouble(v), 2) - Math.Pow(Convert.ToDouble(u), 2)) / (2 * acceleration));
            }

            return "";
        }
        public static string CalculateSUVT(string s, string u, string v, string t)
        {
            // Check the values entered
            List<string> values = new List<string> { s, u, v, t };
            int invalidNums = 0;
            for (int i = 0; i < 4; i++)
                if (values[i] == null)
                    invalidNums++;
            if (invalidNums > 1)
                throw new NullValuesException("Side lengths must not be negative");

            if (s == null) // s = 0.5 * (u + v) * t
                return Convert.ToString((Convert.ToDouble(u) + Convert.ToDouble(v)) * Convert.ToDouble(t) / 2);
            if (u == null) // u = (2s / t) - v
            {
                double time = Convert.ToDouble(t);
                if (time == 0)
                    throw new DivideByZeroException("Time (t) cannot be zero when calculating initial velocity.");
                return Convert.ToString((2 * Convert.ToDouble(s) / time) - Convert.ToDouble(v));
            }
            if (v == null) // v = (2s / t) - u
            {
                double time = Convert.ToDouble(t);
                if (time == 0)
                    throw new DivideByZeroException("Time (t) cannot be zero when calculating final velocity.");
                return Convert.ToString((2 * Convert.ToDouble(s) / time) - Convert.ToDouble(u));
            }
            if (t == null) // t = 2s / (u + v)
            {
                double velocitySum = Convert.ToDouble(u) + Convert.ToDouble(v);
                if (velocitySum == 0)
                    throw new DivideByZeroException("Sum of initial and final velocities (u + v) cannot be zero.");
                return Convert.ToString((2 * Convert.ToDouble(s)) / velocitySum);
            }

            return "";
        }
        public static string CalculateSUTAT(string s, string u, string a, string t)
        {
            // Check the values entered
            List<string> values = new List<string> { s, u, a, t };
            int invalidNums = 0;
            for (int i = 0; i < 4; i++)
                if (values[i] == null)
                    invalidNums++;
            if (invalidNums > 1)
                throw new NullValuesException("Side lengths must not be negative");

            if (s == null) // s = ut + 0.5at^2
            {
                return Convert.ToString(Convert.ToDouble(u) * Convert.ToDouble(t) + 0.5 * Convert.ToDouble(a) * Math.Pow(Convert.ToDouble(t), 2));
            }
            if (u == null) // u = (s - 0.5at^2) / t
            {
                double time = Convert.ToDouble(t);
                if (time == 0)
                    throw new DivideByZeroException("Time (t) cannot be zero.");
                return Convert.ToString((Convert.ToDouble(s) - 0.5 * Convert.ToDouble(a) * Math.Pow(time, 2)) / time);
            }
            if (a == null) // a = 2(s - ut) / t^2
            {
                double time = Convert.ToDouble(t);
                if (time == 0)
                    throw new DivideByZeroException("Time (t) cannot be zero.");
                return Convert.ToString(2 * (Convert.ToDouble(s) - Convert.ToDouble(u) * time) / Math.Pow(time, 2));
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
                    return Convert.ToString(displacement / initialVelocity);
                }

                // Solve using the quadratic formula: t = (-b ± sqrt(b^2 - 4ac)) / 2a
                double discriminant = Math.Pow(initialVelocity, 2) - 4 * (0.5 * acceleration) * (-displacement);
                if (discriminant < 0)
                    throw new InvalidOperationException("No real solution for time (t) exists with these values.");

                double t1 = (-initialVelocity + Math.Sqrt(discriminant)) / (2 * 0.5 * acceleration);
                double t2 = (-initialVelocity - Math.Sqrt(discriminant)) / (2 * 0.5 * acceleration);

                // Return the positive, non-zero solution if one exists
                if (t1 > 0) return Convert.ToString(t1);
                if (t2 > 0) return Convert.ToString(t2);
                return ""; // Or handle cases where time is zero or negative
            }

            return "";
        }
    }
}
