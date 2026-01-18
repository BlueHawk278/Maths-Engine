using System;
using MathsEngine.Utils;
using static MathsEngine.Utils.MathConstants;

namespace MathsEngine.Modules.Mechanics.Dynamics
{
    public class NewtonsLawsCalculator
    {
        /// <summary>
        /// Solves the equation of F = ma for inputted values.
        /// </summary>
        /// <param name="f"> Force. Can be null if it's the value to calculate.</param>
        /// <param name="m"> Mass. Can be null if it's the value to calculate.</param>
        /// <param name="a"> Acceleration. Can be null if it's the value to calculate.</param>
        /// <returns></returns>
        /// <exception cref="NullInputException"> Can be thrown if the input is missing more than one values. </exception>
        /// <exception cref="NullMassException"> Can be thrown if mass entered is 0. </exception>
        /// <exception cref="DivideByZeroException"> Can be thrown if a value is entered that would lead to a divide by 0 error.</exception>
        /// <exception cref="InvalidOperationException"> Can be thrown if a calculation is not possible with the provided values.</exception>
        public static double? CalculateFma(double? f, double? m, double? a)
        {
            int missingCount =
                (f is null ? 1 : 0) +
                (m is null ? 1 : 0) +
                (a is null ? 1 : 0);

            if (missingCount == 0)
                throw new NullValuesException("Cannot calculate - no missing values. Expected exactly one missing value to solve for.");
                
            if (missingCount > 1)
                throw new NullValuesException("Cannot calculate - too many missing values. Expected exactly one missing value to solve for.");

            if (f is null) // F = m * a
            {
                // Validate mass when we're using it in multiplication
                if (m is not null && m <= 0)
                    throw new NullMassException("Mass must be a positive number.");
                return m!.Value * a!.Value;
            }

            if (m is null) // m = F / a
            {
                if (a!.Value == 0)
                    throw new DivideByZeroException("Acceleration cannot be zero when calculating mass.");
                return f.Value / a.Value;
            }

            if (a is null) // a = F / m
            {
                // Check for division by zero BEFORE validating mass range
                if (m!.Value == 0)
                    throw new DivideByZeroException("Mass cannot be zero when calculating acceleration.");
                if (m.Value < 0)
                    throw new NullMassException("Mass must be a positive number.");
                return f.Value / m.Value;
            }

            throw new InvalidOperationException("Could not perform calculation with the provided values.");
        }

        public static bool CheckValidCalculation(double? f, double? m, double? a)
        {
            int missingCount =
                (f is null ? 1 : 0) +
                (m is null ? 1 : 0) +
                (a is null ? 1 : 0);

            if (missingCount > 0)
                throw new NullValuesException("All values must be provided to check a calculation.");

            if (m <= 0)
                throw new NullMassException("Mass must be a positive number.");

            return Math.Abs(f.Value - (m.Value * a.Value)) < EQUALITY_TOLERANCE;
        }
    }
}