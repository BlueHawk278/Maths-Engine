using System;
using System.Collections.Generic;

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
            Console.Write("How many numbers in the Data set: ");
            string numDataPoints = Console.ReadLine();
            Console.Write("What is the mean of the values: ");
            string mean = Console.ReadLine();
            Console.Write("What is the standard deviation: ");
            string standardDeviation = Console.ReadLine();
            return new List<string>() { numDataPoints, mean, standardDeviation };
        }
    }
}