using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsEngine.Modules.Mechanics.UniformAcceleration
{
    internal class UniformAccelerationCalculator
    {
        private double _u, _v, _a, _t, _s;
        private double _averageVelocity;

        private double CalculateAverageVelocity(double initialVelocity, double finalVelocity)
        {
            return initialVelocity + finalVelocity / 2;
        }

        private double CalculateVUAT(string v, string u, string a, string t)
        {
            // Check the values entered
            List<string> values = new List<string> { v, u, a, t };
            int invalidNums = 0;
            for (int i = 0; i < 4; i++)
                if (values[i] == null)
                    invalidNums++;
            if (invalidNums > 1)
                throw new ArgumentException("Must be only one missing value");

            if (v == null) // v = u + at 
                return Convert.ToDouble(u) + Convert.ToDouble(a) * Convert.ToDouble(t);

            if (u == null) // u = v - at
                return Convert.ToDouble(v) - Convert.ToDouble(a) * Convert.ToDouble(t);

            if (a == null) // a = v - u / t
                return (Convert.ToDouble(v) - Convert.ToDouble(u)) / Convert.ToDouble(t);

            if (t == null) // t = v - u / a
                return (Convert.ToDouble(v) - Convert.ToDouble(u)) / Convert.ToDouble(a);

            return 0;
        }
        private double CalculateVUAS(string v, string u, string a, string s)
        {
            // Check the values entered
            List<string> values = new List<string> { v, u, a, s };
            int invalidNums = 0;
            for (int i = 0; i < 4; i++)
                if (values[i] == null)
                    invalidNums++;
            if (invalidNums > 1)
                throw new ArgumentException("Must be only one missing value");

            if (v == null) // v^2 = u^2 + 2as
                return Math.Sqrt(Math.Pow(Convert.ToDouble(u), 2) + 2 * (Convert.ToDouble(a) * Convert.ToDouble(s)));
            if (u == null) // u^2 = v^2 - 2as
                return Math.Sqrt(Math.Pow(Convert.ToDouble(v), 2) - 2 * (Convert.ToDouble(a) * Convert.ToDouble(s)));
            if (a == null) // a = (v^2 - u^2) / 2s
            {
                double displacement = Convert.ToDouble(s);
                if (displacement == 0)
                    throw new DivideByZeroException("Displacement (s) cannot be zero when calculating acceleration.");
                return (Math.Pow(Convert.ToDouble(v), 2) - Math.Pow(Convert.ToDouble(u), 2)) / (2 * displacement);
            }
            if (s == null) // s = (v^2 - u^2) / 2a
            {
                double acceleration = Convert.ToDouble(a);
                if (acceleration == 0)
                    throw new DivideByZeroException("Acceleration (a) cannot be zero when calculating displacement.");
                return (Math.Pow(Convert.ToDouble(v), 2) - Math.Pow(Convert.ToDouble(u), 2)) / (2 * acceleration);
            }

            return 0;
        }
        private double CalculateSUVT(string s, string u, string v, string t)
        {
            // Check the values entered
            List<string> values = new List<string> { s, u, v, t };
            int invalidNums = 0;
            for (int i = 0; i < 4; i++)
                if (values[i] == null)
                    invalidNums++;
            if (invalidNums > 1)
                throw new ArgumentException("Must be only one missing value");

            if (s == null) // s = 0.5 * (u + v) * t
                return (Convert.ToDouble(u) + Convert.ToDouble(v)) * Convert.ToDouble(t) / 2;
            if (u == null) // u = (2s / t) - v
            {
                double time = Convert.ToDouble(t);
                if (time == 0)
                    throw new DivideByZeroException("Time (t) cannot be zero when calculating initial velocity.");
                return (2 * Convert.ToDouble(s) / time) - Convert.ToDouble(v);
            }
            if (v == null) // v = (2s / t) - u
            {
                double time = Convert.ToDouble(t);
                if (time == 0)
                    throw new DivideByZeroException("Time (t) cannot be zero when calculating final velocity.");
                return (2 * Convert.ToDouble(s) / time) - Convert.ToDouble(u);
            }
            if (t == null) // t = 2s / (u + v)
            {
                double velocitySum = Convert.ToDouble(u) + Convert.ToDouble(v);
                if (velocitySum == 0)
                    throw new DivideByZeroException("Sum of initial and final velocities (u + v) cannot be zero.");
                return (2 * Convert.ToDouble(s)) / velocitySum;
            }

            return 0;
        }
        private double CalculateSUTAT(string s, string u, string a, string t)
        {
            return 0;
        }
    }
}
