using System;
using MathsEngine.Modules.Pure.Trigonometry;

namespace MathsEngine.Modules.Core.PureHelpers
{
    public class Trigonometry
    {
        /// <summary>
        /// Calculates the length of a missing side in a right-angled triangle.
        /// </summary>
        /// <param name="knownSideLength">The length of the know side.</param>
        /// <param name="angle">The known angle in degrees.</param>
        /// <param name="knownSideType">The type of the know side (Opposite, Adjacent, Hypotenuse)</param>
        /// <param name="sideToFind">The type of the side to calculate.</param>
        /// <returns>The length of the calculated side.</returns>
        public static double calculateMissingSide(double knownSideLength, double angle, SideType knownSideType, SideType sideToFind)
        {
            if (knownSideLength <= 0)
                throw Utils.Exceptions.NegativeSideLengthException;

            if (angle <= 0.0 || angle >= 90.0)
                throw Utils.Exceptions.AcuteAngleException;

            // Convert angle to radians
            double angleInRadians = angle * (Math.PI / 180.0);
            double result = 0;



            return 0;
        }

        /// <summary>
        /// Calculates the size of a missing angle in a right-angled triangle.
        /// </summary>
        /// <param name="side1Length">The length of the first known side.</param>
        /// <param name="side1Type">The type of the first known side.</param>
        /// <param name="side2Length">The length of the second known side.</param>
        /// <param name="side2Type">The type of the second known side.</param>
        /// <returns>The size of the calculated angle.</returns>
        public static double calculateMissingAngle(double side1Length, SideType side1Type, double side2Length, SideType side2Type)
        {
            if (side1Length  <= 0 || side2Length <= 0)
                throw Utils.Exceptions.NegativeSideLengthException;

            if (side1Type == SideType.Hypotenuse && side1Length <= side2Length)
                throw Utils.Exceptions.HypotenuseNotLongestSideException;
            if (side2Type == SideType.Hypotenuse && side2Length <= side1Length)
                throw Utils.Exceptions.HypotenuseNotLongestSideException;

            double opposite = 0, adjacent = 0, hypotenuse = 0;
            double angleInRadians = 0;

            // angle = angle * (180.0/Math.PI);
            return 0;
        }
    }
}