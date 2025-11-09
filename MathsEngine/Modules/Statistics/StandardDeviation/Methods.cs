using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static MathsEngine.Modules.Statistics.StandardDeviation.MathsVariables;

namespace MathsEngine.Modules.Statistics.StandardDeviation
{
    internal class Methods
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

        internal static void getMean()
        {
            double sum = 0;

            for(int i = 0; i < numValues;i++)
            {
                sum += sortedValues[i];
            }

            Mean = sum / numValues;
        }
        internal static void getMode()
        {
            mode.Clear();
            if (sortedValues == null || sortedValues.Count == 0)
            {
                Mode = double.NaN; // No values, so no mode.
                return;
            }

            int maxCount = 0;
            int currentCount = 1;
            double currentNumber = sortedValues[0];

            for (int i = 1; i < sortedValues.Count; i++)
            {
                if (sortedValues[i] == currentNumber)
                {
                    currentCount++;
                }
                else
                {
                    if (currentCount > maxCount)
                    {
                        maxCount = currentCount;
                        mode.Clear();
                        mode.Add(currentNumber);
                    }
                    else if (currentCount == maxCount)
                    {
                        mode.Add(currentNumber);
                    }
                    currentNumber = sortedValues[i];
                    currentCount = 1;
                }
            }

            // Final check for the last group of numbers
            if (currentCount > maxCount)
            {
                maxCount = currentCount;
                mode.Clear();
                mode.Add(currentNumber);
            }
            else if (currentCount == maxCount)
            {
                mode.Add(currentNumber);
            }

            // If no number appears more than once, there is no mode
            if (maxCount <= 1)
            {
                mode.Clear();
            }

            // Assign to the single Mode variable
            if (mode.Count > 0)
            {
                Mode = mode[0]; // Assigns the first found mode.
            }
            else
            {
                Mode = double.NaN; // Represents that there is no mode.
            }
        }
        internal static void getMedian()
        {
            int midIndex = numValues / 2;

            if(numValues % 2 == 0)
            {
                Median = (sortedValues[midIndex - 1] + sortedValues[midIndex]) / 2.0;
            }
            else if(numValues % 2 == 1)
            {
                Median = sortedValues[midIndex];
            }
        }
        internal static void getRange()
        {
            Range = sortedValues[numValues - 1] - sortedValues[0];
        }

        internal static void getIQR()
        {
            IQR = Q3 - Q1;
        }
        internal static void getQ1()
        {
        }
        internal static void getQ3()
        {
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