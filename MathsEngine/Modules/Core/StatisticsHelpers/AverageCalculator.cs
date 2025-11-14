using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsEngine.Modules.Core.StatisticsHelpers
{
    internal class AverageCalculator
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

        internal static double calculateRange(List<double> nums)
        {
            nums.Sort();
            
            return nums[nums.Count - 1] - nums[0];
        }
    }
}
