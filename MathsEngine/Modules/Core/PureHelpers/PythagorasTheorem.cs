using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsEngine.Modules.Core.PureHelpers
{
    internal class PythagorasTheorem // need to check execution of methods
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

            if (numMissingValues > 1) // Maybe can check if it is valid
            {
                Console.WriteLine("Invalid input. Unable to calculate");
            }
            else if (numMissingValues == 0)
            {
                checkValidResult(hypotenuse, a, b); // placeholder
            }
            else if (hypotenuse == 0)
            {
                calculateHypotenuse(a, b);
            }
            else if (a == 0)
            {
                calculateMissingSide(hypotenuse, b);
            }
            else if (b == 0)
            {
                calculateMissingSide(hypotenuse, a);
            }
        }

        internal static double calculateHypotenuse(double a, double b)
        {
            return Math.Sqrt(Math.Pow(a, 2) + Math.Pow(b, 2));
        }

        internal static double calculateMissingSide(double hypotenuse, double side)
        {
            return Math.Sqrt(Math.Sqrt(hypotenuse) - Math.Sqrt(side));
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