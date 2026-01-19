using System;
using MathsEngine.Utils;

namespace MathsEngine.Modules.Mechanics.Dynamics
{
    public static class NewtonsLawsCalculator
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

            if (missingCount != 1)
                throw new NullInputException("Must be ONE missing value to perform the calculation");

            if (f is null) // F = m * a
                return m.Value * a.Value;

            if (m is null) // m = F / a
            {
                if (a.Value == 0)
                    throw new DivideByZeroException("Acceleration cannot be zero when calculating mass.");
                return f.Value / a.Value;
            }

            if (m <= 0)
                throw new NullMassException("Mass must be a positive number.");

            if (a is null) // a = F / m
            {
                if (m.Value == 0)
                    throw new DivideByZeroException("Mass cannot be zero when calculating acceleration.");
                return f.Value / m.Value;
            }

            throw new InvalidOperationException("Could not perform calculation with the provided values.");
        }

        /// <summary>
        /// Takes in all the parameters for an 'F=ma' equation accounting for floating point inaccuracy.
        /// </summary>
        /// <param name="f"> Value for force (Calculate this value if null)</param>
        /// <param name="m"> Value for mass (Calculate this value if null)</param>
        /// <param name="a"> Value for acceleration (Calculate this value if null) </param>
        /// <returns> True if the equation is valid.</returns>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="NullMassException"></exception>
        public static bool CheckValidCalculation(double? f, double? m, double? a)
        {
            if (f is null || m is null || a is null)
                throw new ArgumentException("All values must be provided to check a calculation.");

            if (m <= 0)
                throw new NullMassException("Mass must be a positive number.");

            return Math.Abs(f.Value - (m.Value * a.Value)) < 1e-9;
        }
    }
}