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

        static List<double> Rank1 = new List<double>();
        static List<double> Rank2 = new List<double>();

        static List<double> d = new List<double>();
        static List<double> dSquared = new List<double>();

        public static void Calculate()
        {
            getNumDataPoints();

            getScores(Score1);
            getScores(Score2);

            getRanks(Score1);
            getRanks(Score2);

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
        /// Gets scores from user input to be ranked
        /// </summary>
        private static void getScores(List<int> scores)
        {
            Console.WriteLine("Press any button to enter scores...");
            Console.ReadLine();

            int num = 0;
            while(num < dataPoints.Count)
            {
                Console.Write($"Enter point {dataPoints[num]}: ");
                int number = Convert.ToInt16(Console.ReadLine());
                scores.Add(number);
                num++;
            }
        }

        private static void getRanks(List<int> scores)
        {
            // Local copy of scores
            List<int> localScores = scores;
            // Order them in descending order
            localScores.Sort();
            localScores.Reverse();

            int maxNum = 0;
            int numDuplicates = 0;

            for(int i = 0; i < localScores.Count; i++)
            {

            }

        }
    }
}