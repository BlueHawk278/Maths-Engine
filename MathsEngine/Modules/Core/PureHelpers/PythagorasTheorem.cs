using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsEngine.Modules.Core.PureHelpers
{
    internal static class PythagorasTheorem // need to check execution of methods
    {
        internal static void calculate(Dictionary<string, double> values)
        {
            int numMissingValues = 0;

            foreach (KeyValuePair<string, double> kvp in values)
            {
                if (kvp.Value == 0)
                    numMissingValues++;
            }

            if (numMissingValues > 1)
            {
                Console.WriteLine("Invalid input. Unable to calculate");
            }
            else if (numMissingValues == 0)
            {
                checkValidResult(values);
            }
            else if (values["Hypotenuse"] == 0)
            {
                calculateHypotenuse(values);
            }
            else if (values["a"] == 0)
            {
                calculateMissingSide(values);
            }
            else if (values["b"] == 0)
            {
                calculateMissingSide(values);
            }
        }

        internal static double calculateHypotenuse(Dictionary<string, double> values)
        {
            return Math.Sqrt(Math.Pow(values["A"], 2) + Math.Pow(values["B"], 2));
        }

        internal static double calculateMissingSide(Dictionary<string, double> values)
        {
            return Math.Sqrt(Math.Sqrt(values["Hypotenuse"]) - Math.Sqrt(values["side"]));
        }

        internal static bool checkValidResult(Dictionary<string, double> values)
        {
    
            bool validResult = false;

            if (Math.Pow(values["Hypotenuse"], 2) == (Math.Pow(values["A"], 2) + Math.Pow(values["B"], 2)))
                validResult = true;
            
            return validResult;
        }
    }
}