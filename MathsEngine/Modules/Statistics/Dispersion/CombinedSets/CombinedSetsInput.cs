using System;
using System.Collections.Generic;

namespace MathsEngine.Modules.Statistics.Dispersion.CombinedSets
{
    public class CombinedSetsInput
    {
        public static void Start()
        {
            Console.Clear();
            getDataSets();

            //var calculator = new ArrayOfNumbersCalculator(originalValues);
            //calculator.Run();

            //calculator.DisplayData();

            Console.WriteLine("\nPress Enter to return to the menu.");
            Console.ReadLine();
        }

        private static void getDataSets()
        {
            Console.Write("How many numbers in the First Data set: ");
            string numDataPoints1 = Console.ReadLine();
            Console.Write("What is the mean of the values: ");
            string mean1 = Console.ReadLine();
            Console.Write("What is the standard deviation: ");
            string standardDeviation1 = Console.ReadLine();
            List<string> dataSet1 = new List<string>();

            Console.Write("How many numbers in the Second Data set: ");
            string numDataPoints2 = Console.ReadLine();
            Console.Write("What is the mean of the values: ");
            string mean2 = Console.ReadLine();
            Console.Write("What is the standard deviation: ");
            string standardDeviation2 = Console.ReadLine();
            List<string> dataSet2 = new List<string>();
        }
    }
}