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
            {
                return Convert.ToDouble(u) + Convert.ToDouble(a) * Convert.ToDouble(t);
            }

            if (u == null) // u = v - at
            {
                return Convert.ToDouble(v) - Convert.ToDouble(a) * Convert.ToDouble(t);
            }

            if (a == null) // a = v - u / t
            {
                return (Convert.ToDouble(v) - Convert.ToDouble(u)) / Convert.ToDouble(t);
            }

            if (t == null) // t = v - u / a
            {
                return (Convert.ToDouble(v) - Convert.ToDouble(u)) / Convert.ToDouble(a);
            }

            return 0;
        }
    }
}
