using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Completed: number of data points
 *            getting the scores for each judge
 */

/* TODO: Comply with C# naming conventions
 *       Use DRY principle to get all data points in one method and ranks
 *       Calculate the ranks etc.
 *       CHECKLIST
 */

namespace MathsEngine.Modules.Statistics
{
    internal class BivariateAnalysis
    {
        static List<int> dataPoints = new List<int>();

        static List<int> Score1 = new List<int>();
        static List<int> Score2 = new List<int>();

        static List<int> Rank1 = new List<int>();
        static List<int> Rank2 = new List<int>();

        static List<int> d = new List<int>();
        static List<int> dSquared = new List<int>();

        public static void Calculate()
        {
            getNumDataPoints();
            getScores();

            Console.ReadLine();
        }

        /// <summary>
        /// Gets the number of data points and assigns them to the list
        /// </summary> 
        private static void getNumDataPoints()
        {
            Console.WriteLine("How many data points would you like to enter");
            int numDataPoints = Convert.ToInt16(Console.ReadLine());

            for(int i = 0; i < numDataPoints; i++)
            {
                dataPoints.Add(i + 1);
            }
        }

        /// <summary>
        /// Gets the scores for each judge
        /// </summary>
        private static void getScores()
        {
            getScore1();
            getScore2();
        }
        private static void getScore1()
        {
            Console.WriteLine("Press any button to enter scores...");
            Console.ReadLine();

            int num = 0;
            while(num < dataPoints.Count)
            {
                Console.Write($"Enter point {dataPoints[num]}: ");
                int number = Convert.ToInt16(Console.ReadLine());
                Score1.Add(number);
                num++;
            }
        }
        private static void getScore2()
        {
            Console.WriteLine("Press any button to enter scores...");
            Console.ReadLine();

            int num = 0;
            while (num < dataPoints.Count)
            {
                Console.Write($"Enter point {dataPoints[num]}: ");
                int number = Convert.ToInt16(Console.ReadLine());
                Score2.Add(number);
                num++;
            }
        }
    }
}