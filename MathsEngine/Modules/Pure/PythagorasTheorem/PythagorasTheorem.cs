using System;
using MathsEngine.Utils;

namespace MathsEngine.Modules.Pure.PythagorasTheorem
{
    /// <summary>
    /// Provides static methods for Pythagoras theorem calculations
    /// </summary>
    public static class PythagorasTheorem
    {
        /// <summary>
        /// Calculates the length of the hypotenuse given side A and B
        /// </summary>
        /// <param name="a">The length of side A.</param>
        /// <param name="b">The length of side B.</param>
        /// <returns></returns>
        public static double CalculateHypotenuse(double a, double b)
        {
            if (a <= 0 || b <= 0)
                throw new NegativeSideLengthException("Side lengths must not be negative or 0");
            

            double aSquared = Math.Pow(a, 2);
            double bSquared = Math.Pow(b, 2);

            return Math.Sqrt(aSquared + bSquared);
        }

        /// <summary>
        /// Calculates the length of a missing side given the hypotenuse and a known side
        /// </summary>
        /// <param name="hypotenuse">The length of the hypotenuse.</param>
        /// <param name="knownSide">The length of the known side.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static double CalculateOtherSide(double hypotenuse, double knownSide)
        {
            if (hypotenuse <= 0 || knownSide <= 0)
                throw new NegativeSideLengthException("Side lengths must not be negative or 0");

            if (knownSide >= hypotenuse)
                throw new HypotenuseNotLongestSideException("Hypotenuse must be the longest side");

            double hSquared = Math.Pow(hypotenuse, 2);
            double aSquared = Math.Pow(knownSide, 2);

            return Math.Sqrt(hSquared - aSquared);
        }

        /// <summary>
        /// Checks if the values entered are valid in the Pythagoras Theorem
        /// </summary>
        /// <param name="hypotenuse">The length of the hypotenuse.</param>
        /// <param name="a">The length of one of the shorter sides.</param>
        /// <param name="b">The length of the other shorter side.</param>
        /// <returns></returns>
        public static bool CheckValidCalculation(double hypotenuse, double a, double b)
        {
            if (hypotenuse <= 0 || a <= 0 || b <= 0)
                throw new NegativeSideLengthException("Side lengths must not be negative or 0");

            if (hypotenuse <= a || hypotenuse <= b)
                throw new HypotenuseNotLongestSideException("Hypotenuse must be the longest side");

            return Math.Abs((a * a + b * b) - (hypotenuse * hypotenuse)) < 1e-9;
        }
    }
}