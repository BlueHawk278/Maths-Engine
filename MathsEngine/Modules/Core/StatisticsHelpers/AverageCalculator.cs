using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathsEngine.Utils;

namespace MathsEngine.Modules.Core.StatisticsHelpers
{
    internal static class AverageCalculator
    {
        // MEASURES OF LOCATION

        /// <summary>
        /// Calculates the mean (average) of a list of double values.
        /// </summary>
        /// <param name="nums">A list of double values for which the mean is to be calculated. The list must not be null.</param>
        /// <returns>The mean of the values in the list. Returns 0 if the list is empty.</returns>
        internal static double calculateMean(List<double> nums)
        {
            if (nums.Count == 0 || nums == null) throw new NullInputException("Side lengths must not be negative");

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
            if (nums.Count == 0 || nums == null)
                throw new NullInputException("Side lengths must not be negative");

            var sortedNums = new List<double>(nums);
            sortedNums.Sort();

            int midIndex = nums.Count / 2;
            double median;

            if (sortedNums.Count % 2 == 0)
            {
                // Even number of elements: average of the two middle elements
                median = (sortedNums[midIndex - 1] + sortedNums[midIndex]) / 2.0;
            }
            else
            {
                // Odd number of elements: the middle element
                median = sortedNums[midIndex];
            }

            return median;
        }

        /// <summary>
        /// Calculates the mode(s) of a list of numbers.
        /// </summary>
        /// <param name="numbers">The list of numbers to analyze.</param>
        /// <returns>A List containing the mode(s). Returns an empty list if there is no mode.</returns>
        internal static List<double> calculateMode(List<double> nums)
        {
            // If the list is empty or has only one value, there can be no mode.
            if (nums == null || nums.Count <= 1) throw new NullInputException("Side lengths must not be negative");

            // Use a Dictionary to count the frequency of each number.
            // Key: the number, Value: its frequency.
            var counts = new Dictionary<double, int>();
            foreach (var number in nums)
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
            var sortedNums = new List<double>(nums);

            return sortedNums[sortedNums.Count - 1] - sortedNums[0];
        }

        // MEASURES OF DISPERSION

        /// <summary>
        /// Calculates the interquartile range (IQR) of a given list of numeric values.
        /// </summary>
        /// <remarks>The interquartile range is calculated as the difference between the third quartile (Q3)
        /// and the first quartile (Q1). The input list is sorted internally, and the calculation  accounts for
        /// both even and odd numbers of elements in the list.</remarks>
        /// <param name="originalValues">A list of numeric values for which the interquartile range is to be calculated.  The list must contain at
        /// least four elements.</param>
        /// <returns>A list containing three values: the first quartile (Q1), the third quartile (Q3),  and the interquartile
        /// range (IQR), in that order. Returns <see langword="null"/>  if the input list contains fewer than four
        /// elements.</returns>
        internal static List<double> getInterQuartileRange(List<double> originalValues)
        {
            double Q1, Q3, IQR;
            int numValues = originalValues.Count;

            var sortedValues = new List<double>(originalValues);
            sortedValues.Sort();

            if (sortedValues == null || numValues < 4)
                throw new NullInputException("Side lengths must not be negative");

            if (numValues % 2 == 0) // 0 | Q1 | 1 | Q2 | 2 | Q3 |3
            {
                int midIndex = numValues / 2;

                List<double> upperHalf = sortedValues.GetRange(0, midIndex);
                List<double> lowerHalf = sortedValues.GetRange(midIndex, midIndex);

                Q1 = calculateMedian(lowerHalf);
                Q3 = calculateMedian(upperHalf);
                IQR = Q3 - Q1;

                return new List<double> { Q1, Q3, IQR };
            }
            else if (numValues % 2 == 1)// 1 Q1 2 Q2 4 Q3 5
            {
                int midIndex = numValues / 2;

                List<double> lowerHalf = sortedValues.GetRange(0, midIndex);
                List<double> upperHalf = sortedValues.GetRange(midIndex + 1, midIndex);

                Q1 = calculateMedian(lowerHalf);
                Q3 = calculateMedian(upperHalf);
                IQR = Q3 - Q1;

                return new List<double> {Q1, Q3, IQR};
            }

            return null;
        }
    }
}