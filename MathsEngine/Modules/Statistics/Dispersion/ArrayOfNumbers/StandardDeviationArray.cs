using System;
using System.Collections.Generic;

namespace MathsEngine.Modules.Statistics.Dispersion.ArrayOfNumbers
{
    internal static class StandardDeviationArray
    {
        public static void Start()
        {
            int numDataPoints = GetNumberOfDataPoints();
            var originalValues = GetScoresFromUser(numDataPoints);

            var calculator = new StandardDeviationLogic(originalValues);
            calculator.Run();

            calculator.DisplayData();

            Console.ReadLine();
        }
        private static int GetNumberOfDataPoints()
        {
            Console.WriteLine("How many data points would you like to enter?");
            return Convert.ToInt16(Console.ReadLine());
        }
        private static List<double> GetScoresFromUser(int numDataPoints)
        {
            var scores = new List<double>();

            for (int i = 0; i < numDataPoints; i++)
            {
                Console.Write($"Enter point {i + 1}: ");
                scores.Add(Convert.ToInt16(Console.ReadLine()));
            }

            return scores;
        } 
    }
}