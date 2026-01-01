using System;
using MathsEngine.Utils;

namespace MathsEngine.Modules.Pure.Trigonometry
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
        public static double CalculateMissingSide(double? knownSideLength, double? angle, SideType knownSideType, SideType sideToFind)
        {
            int missingCount =
                (knownSideLength is null ? 1 : 0) +
                (angle is null ? 1 : 0);

            if (missingCount != 0)
                throw new NullInputException();

            if (knownSideLength <= 0)
                throw new NegativeSideLengthException();

            if (angle <= 0.0 || angle >= 90.0)
                throw new AcuteAngleException();

            if (sideToFind == knownSideType)
                throw new DuplicateSideException();

            // Convert angle to radians
            double angleInRadians = Convert.ToDouble(angle) * (Math.PI / 180.0);
            double result = 0;

            if ((knownSideType == SideType.Opposite && sideToFind == SideType.Hypotenuse) ||
                (knownSideType == SideType.Hypotenuse && sideToFind == SideType.Opposite))
            {
                if (sideToFind == SideType.Hypotenuse) 
                    result = Convert.ToDouble(knownSideLength) / Math.Sin(angleInRadians);
                else // Find O, know H: O = H * sin(angle)
                    result = Convert.ToDouble(knownSideLength) * Math.Sin(angleInRadians);
            }

            // CAH (Cosine)
            if ((knownSideType == SideType.Adjacent && sideToFind == SideType.Hypotenuse) ||
                (knownSideType == SideType.Hypotenuse && sideToFind == SideType.Adjacent))
            {
                if (sideToFind == SideType.Hypotenuse)
                    result = Convert.ToDouble(knownSideLength) / Math.Cos(angleInRadians);
                else
                    result = Convert.ToDouble(knownSideLength) * Math.Cos(angleInRadians);
            }

            // TOA (Tangent)
            if ((knownSideType == SideType.Opposite && sideToFind == SideType.Adjacent) ||
                (knownSideType == SideType.Adjacent && sideToFind == SideType.Opposite))
            {
                if (sideToFind == SideType.Adjacent)
                    result = Convert.ToDouble(knownSideLength) / Math.Tan(angleInRadians);
                else
                    result = Convert.ToDouble(knownSideLength) * Math.Tan(angleInRadians);
            }

            return result;
        }

        /// <summary>
        /// Calculates the size of a missing angle in a right-angled triangle.
        /// </summary>
        /// <param name="side1Length">The length of the first known side.</param>
        /// <param name="side1Type">The type of the first known side.</param>
        /// <param name="side2Length">The length of the second known side.</param>
        /// <param name="side2Type">The type of the second known side.</param>
        /// <returns>The size of the calculated angle.</returns>
        public static double CalculateMissingAngle(double? side1Length, SideType side1Type, double? side2Length, SideType side2Type)
        {
            int missingCount =
                (side1Length is null ? 1 : 0) +
                (side2Length is null ? 1 : 0);

            if (missingCount != 0)
                throw new NullInputException();

            if (side1Length  <= 0 || side2Length <= 0)
                throw new NegativeSideLengthException();

            if (side1Type == side2Type)
                throw new DuplicateSideException();

            if (side1Type == SideType.Hypotenuse && side1Length <= side2Length)
                throw new HypotenuseNotLongestSideException();
            if (side2Type == SideType.Hypotenuse && side2Length <= side1Length)
                throw new HypotenuseNotLongestSideException();

            double opposite = 0, adjacent = 0, hypotenuse = 0;
            double angleInRadians = 0;

            // SOH (Sine)
            if ((side1Type == SideType.Opposite && side2Type == SideType.Hypotenuse) ||
                (side1Type == SideType.Hypotenuse && side2Type == SideType.Opposite))
            {
                opposite = (side1Type == SideType.Opposite) ? Convert.ToDouble(side1Length) : Convert.ToDouble(side2Length);
                hypotenuse = (side1Type == SideType.Hypotenuse) ? Convert.ToDouble(side1Length) : Convert.ToDouble(side2Length);
                angleInRadians = Math.Asin(opposite / hypotenuse);
            }

            // CAH (Cosine)
            if ((side1Type == SideType.Adjacent && side2Type == SideType.Hypotenuse) ||
                (side1Type == SideType.Hypotenuse && side2Type == SideType.Adjacent))
            {
                adjacent = (side1Type == SideType.Adjacent) ? Convert.ToDouble(side1Length) : Convert.ToDouble(side2Length);
                hypotenuse = (side1Type == SideType.Hypotenuse) ? Convert.ToDouble(side1Length) : Convert.ToDouble(side2Length);
                angleInRadians = Math.Acos(adjacent / hypotenuse);
            }

            // TOA (Tangent)
            if ((side1Type == SideType.Opposite && side2Type == SideType.Adjacent) ||
                (side1Type == SideType.Adjacent && side2Type == SideType.Opposite))
            {
                opposite = (side1Type == SideType.Opposite) ? Convert.ToDouble(side1Length) : Convert.ToDouble(side2Length);
                adjacent = (side1Type == SideType.Adjacent) ? Convert.ToDouble(side1Length) : Convert.ToDouble(side2Length);
                angleInRadians = Math.Atan(opposite / adjacent);
            }

            return angleInRadians * (180.0 / Math.PI);
        }
    }
}