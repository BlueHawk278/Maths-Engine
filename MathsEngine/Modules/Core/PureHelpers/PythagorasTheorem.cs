using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsEngine.Modules.Core.PureHelpers
{
    internal class PythagorasTheorem
    {
        internal static void getValues(double hypotenuse, double a, double b)
        {
            // Check for initial valid input
            List<double> variables = new List<double> { hypotenuse, a, b };
            int numMissingValues = 0;

            foreach (double num in variables)
            {
                if (num == 0)
                    numMissingValues++;
            }

            if (numMissingValues > 1 || numMissingValues == 0) // Maybe can check if it is valid
            {
                Console.WriteLine("Invalid input. Unable to calculate");
            }
            else
            {

            }
        }

        internal static void calculateHypotenuse()
        {

        }

        internal static void calculateMissingSide()
        {

        }

        internal static bool checkValidResult(double hypotenuse, double a, double b)
        {
    
            bool validResult = false;

            if (Math.Pow(hypotenuse, 2) == (Math.Pow(a, 2) + Math.Pow(b, 2)))
                validResult = true;
            
            return validResult;
        }
    }
}
