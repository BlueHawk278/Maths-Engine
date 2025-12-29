using System;
using System.Collections.Generic;
using MathsEngine.Utils;

namespace MathsEngine.Modules.Mechanics.Dynamics
{
    public class NewtonsLawsCalculator // Integrate uniform acceleration equations
    {
        public static double CalculateFma(string F, string m, string a)
        {
            bool fUnknown = string.IsNullOrEmpty(F);
            bool mUnknown = string.IsNullOrEmpty(m);
            bool aUnknown = string.IsNullOrEmpty(a);

            var unknownCount = 0;
            if (fUnknown) unknownCount++;
            if (mUnknown) unknownCount++;
            if (aUnknown) unknownCount++;

            if (unknownCount != 1)
                throw new NullValuesException("Must provide exactly two values to calculate the third.");

            double force = fUnknown ? 0 : Convert.ToDouble(F);
            double mass = mUnknown ? 0 : Convert.ToDouble(m);
            double acceleration = aUnknown ? 0 : Convert.ToDouble(a);

            if (fUnknown)
                return mass * acceleration;
            if (mUnknown)
            {
                if (acceleration == 0) throw new DivideByZeroException("Acceleration cannot be zero when calculating mass.");
                return force / acceleration;
            }
            if (aUnknown)
            {
                if (mass == 0) throw new DivideByZeroException("Mass cannot be zero when calculating acceleration.");
                return force / mass;
            }
            // This line is unreachable due to the unknownCount check, but is required for compilation
            throw new InvalidOperationException("An unexpected error occurred during calculation.");
        }

        public static bool CheckValidCalculation(string F, string m, string a)
        {
            bool fUnknown = string.IsNullOrEmpty(F);
            bool mUnknown = string.IsNullOrEmpty(m);
            bool aUnknown = string.IsNullOrEmpty(a);

            if (fUnknown || mUnknown || aUnknown)
                throw new NullValuesException("Must provide all three values to check a calculation.");

            double force = Convert.ToDouble(F);
            double mass = Convert.ToDouble(m);
            double acceleration = Convert.ToDouble(a);

            // Use a small tolerance for floating-point comparison
            return Math.Abs(force - (mass * acceleration)) < 1e-9;
        }
    }
}