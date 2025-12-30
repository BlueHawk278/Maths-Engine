using System;
using System.Collections.Generic;
using MathsEngine.Utils;

namespace MathsEngine.Modules.Statistics.Dispersion.ArrayOfNumbers
{
    internal static class ArrayOfNumbersInput
    {
        public static void Start()
        {
            Console.Clear();
            int numDataPoints = GetNumberOfDataPoints();
            var originalValues = GetScoresFromUser(numDataPoints);

            var calculator = new ArrayOfNumbersCalculator(originalValues);
            calculator.Run();

            calculator.DisplayData();

            Console.WriteLine("\nPress Enter to return to the menu.");
            Console.ReadLine();
        }
        private static int GetNumberOfDataPoints()
        {
            return Parsing.GetIntInput("How many data points would you like to enter?");
        }
        private static List<double> GetScoresFromUser(int numDataPoints)
        {
            var scores = new List<double>();

            for (int i = 0; i < numDataPoints; i++)
            {
                scores.Add(Parsing.GetDoubleInput($"Enter point {i + 1}: "));
            }

            return scores;
        } 
    }
}