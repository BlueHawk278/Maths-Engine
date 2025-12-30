using System;
using System.Collections.Generic;
using MathsEngine.Utils;

namespace MathsEngine.Modules.Statistics.Dispersion.CombinedSets
{
    public class CombinedSetsInput
    {
        public static void Start()
        {
            Console.Clear();
            var dataSet1 = getDataSet();
            var dataSet2 = getDataSet();

            var calculator = new CombinedSetsCalculator(dataSet1, dataSet2);
            calculator.Run();

            calculator.DisplayData();

            Console.WriteLine("\nPress Enter to return to the menu.");
            Console.ReadLine();
        }

        private static List<string> getDataSet()
        {
            int numDataPoints = Parsing.GetIntInput("How many numbers in the Data set: ");
            double mean = Parsing.GetDoubleInput("What is the mean of the values: ");
            double standardDeviation = Parsing.GetDoubleInput("What is the standard deviation: ");

            //return new List<int> { numDataPoints, mean, standardDeviation };
        }
    }
}