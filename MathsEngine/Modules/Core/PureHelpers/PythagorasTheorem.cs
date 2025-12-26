using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsEngine.Modules.Core.PureHelpers
{
    /// <summary>
    /// Provides static methods for Pythagoras theorem calculations
    /// </summary>
    internal static class PythagorasTheorem
    {
        /// <summary>
        /// Calculates the length of the hypotenuse given side A and B
        /// </summary>
        /// <param name="a">The length of side A.</param>
        /// <param name="b">The length of side B.</param>
        /// <returns></returns>
        public static double calculateHypotenuse(double a, double b)
        {
            if (a <= 0 || b <= 0)
                throw Utils.Exceptions.NegativeSideLengthException;
            

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
        public static double calculateOtherSide(double hypotenuse, double knownSide)
        {
            if (hypotenuse <= 0 || knownSide <= 0)
                throw Utils.Exceptions.NegativeSideLengthException;

            if (knownSide >= hypotenuse)
                throw Utils.Exceptions.HypotenuseNotLongestSideException;

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
        public static bool checkValidCalculation(double hypotenuse, double a, double b)
        {
            double hSquared = Math.Sqrt(Math.Pow(hypotenuse, 2));
            double otherSides = Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));

            if (hSquared == otherSides)
                return true;
            return false;
        }
    }
}