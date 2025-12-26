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


            return 0;
        }

        /// <summary>
        /// Calculates the size of a missing angle in a right-angled triangle.
        /// </summary>
        /// <param name="side1Length">The length of the first known side.</param>
        /// <param name="side1Type">The type of the first known side.</param>
        /// <param name="side2Length">The length of the second known side.</param>
        /// <param name="side2Type">The type of the second known side.</param>
        /// <returns></returns>
        public static double calculateMissingAngle(double side1Length, SideType side1Type, double side2Length, SideType side2Type)
        {


            return 0;
        }
    }
}