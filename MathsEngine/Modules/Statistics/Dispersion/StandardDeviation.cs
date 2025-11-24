using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsEngine.Modules.Statistics.Dispersion
{
    internal static class StandardDeviation
    {
        public static void Start() // Initial logic as far as we can right now
        {
            int numDataPoints = GetNumberOfDataPoints();
            var originalValues = GetScoresFromUser(numDataPoints);

            var calculator = new StandardDeviationLogic(originalValues);
            calculator.Run();

            calculator.displayData();

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
