using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static MathsEngine.Modules.Statistics.Dispersion.Variables;

namespace MathsEngine.Modules.Statistics.Dispersion
{
    internal static class StandardDeviationLogic
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
        } // make a global function as it is used more than once, for DRY
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
        } //
        internal static void sortValues()
        {
            sortedValues = new List<double>(originalValues);
            sortedValues.Sort();
        }
        internal static void getAverages()
        {
            Mean = Core.StatisticsHelpers.AverageCalculator.calculateMean(originalValues);
            Median = Core.StatisticsHelpers.AverageCalculator.calculateMedian(originalValues);
            modeList = Core.StatisticsHelpers.AverageCalculator.calculateMode(originalValues);
            Range = Core.StatisticsHelpers.AverageCalculator.calculateRange(originalValues);

            var quartiles = Core.StatisticsHelpers.AverageCalculator.getInterQuartileRange(originalValues);
            Q1 = quartiles[0];
            Q3 = quartiles[1];
            IQR = quartiles[2];
        }
        internal static void displayData()
        {
            Console.WriteLine("Mean: " + Mean);
            Console.WriteLine("Median: " + Median);

            Console.Write("Mode: ");
            foreach(double mode in modeList)
                Console.Write(mode + " ");

            Console.WriteLine("Range: " + Range);

            Console.WriteLine("Q1: " + Q1);
            Console.WriteLine("Q3: " + Q3);
            Console.WriteLine("IQR: " + IQR);
        }
    }
}