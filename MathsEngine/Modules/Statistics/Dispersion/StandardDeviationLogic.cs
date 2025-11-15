using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static MathsEngine.Modules.Statistics.StandardDeviation.Variables;

namespace MathsEngine.Modules.Statistics.Dispersion
{
    internal class StandardDeviationLogic
    {
        internal static void getNumValues()
        {
            Console.WriteLine("How many values would you like?");
            numValues = Convert.ToInt32(Console.ReadLine());

            originalValues.Clear();
            for(int i = 0; i < numValues; i++)
            {
                originalValues.Add(i + 1);
            }
        }

        internal static void getValues()
        {
            Console.WriteLine("Press any button to enter the values");
            Console.ReadLine();

            for(int i = 0; i < numValues;i++)
            {
                Console.Write($"Enter number {i + 1}: ");
                int num = Convert.ToInt16(Console.ReadLine());
                originalValues[i] = num;
            }
        }
        internal static void sortValues()
        {
            sortedValues = new List<double>(originalValues);
            sortedValues.Sort();
        }

        internal static void displayData()
        {
            Console.WriteLine("Mean: " + Mean);
            Console.WriteLine("Median: " + Median);
            Console.WriteLine("Mode: " + Mode);
            Console.WriteLine("Range: " + Range);
        }
    }
}