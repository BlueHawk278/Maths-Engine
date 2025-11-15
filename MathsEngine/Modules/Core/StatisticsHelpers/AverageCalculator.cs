using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathsEngine.Modules.Statistics.StandardDeviation;

namespace MathsEngine.Modules.Core.StatisticsHelpers
{
    internal class AverageCalculator
    {
        /// <summary>
        /// Calculates the mean (average) of a list of double values.
        /// </summary>
        /// <param name="nums">A list of double values for which the mean is to be calculated. The list must not be null.</param>
        /// <returns>The mean of the values in the list. Returns 0 if the list is empty.</returns>
        internal static double calculateMean(List<double> nums)
        {
            if (nums.Count == 0) return 0;

            double sum = 0;

            foreach (double num in nums)
                sum += num;

            double average = sum / nums.Count;

            return average;
        }

        /// <summary>
        /// Calculates the median (average) of a list of double values
        /// </summary>
        /// <param name="nums"> A list of double values for which the median is to be calculated. The list must not be null.</param>
        /// <returns>The median of the values of the list. Returns 0 if the list is empty.</returns>
        internal static double calculateMedian(List<double> nums)
        {
            nums.Sort();

            int midIndex = nums.Count / 2;

            if (nums.Count % 2 == 0)
            {
                Variables.Median = (Variables.sortedValues[midIndex - 1] + Variables.sortedValues[midIndex]) / 2.0;
            }
            else if (nums.Count % 2 == 1)
            {
                Variables.Median = Variables.sortedValues[midIndex];
            }

            return midIndex;
        }

        /// <summary>
        /// Calculates the mode(s) of a list of numbers.
        /// </summary>
        /// <param name="numbers">The list of numbers to analyze.</param>
        /// <returns>A List containing the mode(s). Returns an empty list if there is no mode.</returns>
        internal static List<double> calculateMode(List<double> numbers)
        {
            // If the list is empty or has only one value, there can be no mode.
            if (numbers == null || numbers.Count <= 1)
            {
                return new List<double>();
            }

            // Use a Dictionary to count the frequency of each number.
            // Key: the number, Value: its frequency.
            var counts = new Dictionary<double, int>();
            foreach (var number in numbers)
            {
                if (counts.ContainsKey(number))
                {
                    counts[number]++;
                }
                else
                {
                    counts[number] = 1;
                }
            }

            // Find the highest frequency count.
            int maxCount = 0;
            foreach (var count in counts.Values)
            {
                if (count > maxCount)
                {
                    maxCount = count;
                }
            }

            // If no number appears more than once, there is no mode.
            if (maxCount <= 1)
            {
                return new List<double>();
            }

            // Find all numbers that have the highest frequency.
            var modes = new List<double>();
            foreach (var pair in counts)
            {
                if (pair.Value == maxCount)
                {
                    modes.Add(pair.Key);
                }
            }

            return modes;
        }

        /// <summary>
        /// Calculates the range of a list of doubles. It sorts the list then gets the difference from the index at each end.
        /// </summary>
        /// <param name="nums"></param>
        /// <returns>The difference between the min and max value.</returns>
        internal static double calculateRange(List<double> nums)
        {
            nums.Sort();

            return nums[nums.Count - 1] - nums[0];
        }

        // Get median and split into 2 lists Q1 median of lower one Q3 median of upper one
        /*
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

                for (int i = 0; i < numValues; i++)
                {
                    if (originalValues[i] > Median)
                    {
                        upperHalf.Add(sortedValues[i]);
                    }
                    else if (originalValues[i] < Median)
                    {
                        lowerHalf.Add(sortedValues[i]);
                    }
                }
            }
            else if (numValues % 2 == 1)// 1 Q1 2 Q2 4 Q3 5
            {

            }
        } // not finished
        */
    }
}
