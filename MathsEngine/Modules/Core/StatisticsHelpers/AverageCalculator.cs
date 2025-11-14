using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathsEngine.Modules.Statistics.StandardDeviation;

namespace MathsEngine.Modules.Core.StatisticsHelpers
{
    internal class AverageCalculator // make it so that methods can be used in different classes
    {
        internal static double calculateMean(List<double> nums)
        {
            if (nums.Count == 0) return 0;

            double sum = 0;

            foreach(double num in nums)
                sum += num;

            double average = sum / nums.Count;

            return average;
        }
        internal static double calculateMedian(List<double> nums)
        {
            nums.Sort();

            int midIndex = Variables.numValues / 2;

            if (Variables.numValues % 2 == 0)
            {
                Variables.Median = (Variables.sortedValues[midIndex - 1] + Variables.sortedValues[midIndex]) / 2.0;
            }
            else if (Variables.numValues % 2 == 1)
            {
                Variables.Median = Variables.sortedValues[midIndex];
            }

            return midIndex;
        }
        internal static double calculateMode(List<double> nums)
        {
            Variables.mode.Clear();
            if (Variables.sortedValues == null || Variables.sortedValues.Count == 0)
            {
                Variables.Mode = double.NaN; // No values, so no mode.
                return 0;
            }

            int maxCount = 0;
            int currentCount = 1;
            double currentNumber = Variables.sortedValues[0];

            for (int i = 1; i < Variables.sortedValues.Count; i++)
            {
                if (Variables.sortedValues[i] == currentNumber)
                {
                    currentCount++;
                }
                else
                {
                    if (currentCount > maxCount)
                    {
                        maxCount = currentCount;
                        Variables.mode.Clear();
                        Variables.mode.Add(currentNumber);
                    }
                    else if (currentCount == maxCount)
                    {
                        Variables.mode.Add(currentNumber);
                    }
                    currentNumber = Variables.sortedValues[i];
                    currentCount = 1;
                }
            }

            // Final check for the last group of numbers
            if (currentCount > maxCount)
            {
                maxCount = currentCount;
                Variables.mode.Clear();
                Variables.mode.Add(currentNumber);
            }
            else if (currentCount == maxCount)
            {
                Variables.mode.Add(currentNumber);
            }

            // If no number appears more than once, there is no mode
            if (maxCount <= 1)
            {
                Variables.mode.Clear();
            }

            // Assign to the single Mode variable
            if (Variables.mode.Count > 0)
            {
                Variables.Mode = Variables.mode[0]; // Assigns the first found mode.
            }
            else
            {
                Variables.Mode = double.NaN; // Represents that there is no mode.
            }

            return 0; // idk
        }
        internal static double calculateRange(List<double> nums)
        {
            nums.Sort();
            
            return nums[nums.Count - 1] - nums[0];
        }
    }
}
