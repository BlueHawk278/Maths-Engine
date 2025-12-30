using System;
using MathsEngine.Utils;

namespace MathsEngine.Modules.Mechanics.Dynamics
{
    public class NewtonsLawsCalculator
    {
        public static double? CalculateFma(double? f, double? m, double? a)
        {
            int missingCount =
                (f is null ? 1 : 0) +
                (m is null ? 1 : 0) +
                (a is null ? 1 : 0);

            if (missingCount != 1)
                throw new ArgumentException("Exactly one value must be null to perform a calculation.");

            if (m <= 0)
                throw new ArgumentException("Mass must be a positive number.");

            if (f is null) // F = m * a
                return m.Value * a.Value;

            if (m is null) // m = F / a
            {
                if (a.Value == 0)
                    throw new DivideByZeroException("Acceleration cannot be zero when calculating mass.");
                return f.Value / a.Value;
            }

            if (a is null) // a = F / m
            {
                // This check is technically redundant due to the check at the start, but good for safety.
                if (m.Value == 0)
                    throw new DivideByZeroException("Mass cannot be zero when calculating acceleration.");
                return f.Value / m.Value;
            }

            throw new InvalidOperationException("Could not perform calculation with the provided values.");
        }

        public static bool CheckValidCalculation(double? f, double? m, double? a)
        {
            if (f is null || m is null || a is null)
                throw new ArgumentException("All values must be provided to check a calculation.");

            if (m <= 0)
                throw new ArgumentException("Mass must be a positive number.");

            return Math.Abs(f.Value - (m.Value * a.Value)) < 1e-9;
        }
    }
}