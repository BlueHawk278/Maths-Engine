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
        internal static void getNumDataPoints()
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

        // Get median and split into 2 lists Q1 median of lower one Q3 median of upper one
        internal static void getInterQuartileRange()
        {
            if (sortedValues == null || numValues < 4)
            {
                // Quartiles are not well-defined for fewer than 4 data points.
                Q1 = double.NaN;
                Q3 = double.NaN;
                IQR = double.NaN;
                return;
            }

            if (numValues % 2 == 0) // 0 Q1 1 Q2 2 Q3 3
            {
                List<double> upperHalf = new List<double>();
                List<double> lowerHalf = new List<double>();
                int midIndex = numValues / 2;

                for(int i = 0; i < numValues; i++)
                {
                    if (originalValues[i] > Median)
                    {
                        upperHalf.Add(sortedValues[i]);
                    }
                    else if(originalValues[i] < Median)
                    {
                        lowerHalf.Add(sortedValues[i]);
                    }
                }
            }
            else if(numValues % 2 == 1)// 1 Q1 2 Q2 4 Q3 5
            {

            }
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