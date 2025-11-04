using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TIDY UP CODE!!!

namespace MathsEngine.Modules.Statistics
{
    internal class BivariateAnalysis
    {
        static List<int> dataPoints = new List<int>();
        static int numDataPoints = dataPoints.Count;

        static List<int> Score1 = new List<int>();
        static List<int> Score2 = new List<int>();

        static List<double> Rank1 = new List<double>();
        static List<double> Rank2 = new List<double>();

        static List<double> d = new List<double>();
        static List<double> dSquared = new List<double>();
        static double sigma_dSquared = 0;

        public static void Calculate()
        {
            getNumDataPoints();

            getScores(Score1);
            getScores(Score2);

            // Initialize Rank1 and Rank2 with the same size as Score1 and Score2
            for(int i = 0; i < numDataPoints; i++)
            {
                Rank1.Add(0);
                Rank2.Add(0);
            }

            getRanks(Score1, Rank1);
            getRanks(Score2, Rank2);

            for(int i = 0; i < numDataPoints; i++)
            {
                d.Add(0);
            }
            getDifference();

            for(int i = 0; i < numDataPoints; i++)
            {
                dSquared.Add(0);
            }
            getDifferenceSquared();

            getCorrelation();

            Console.ReadLine();
        }

        /// <summary>
        /// Gets the number of data points and assigns them to the list
        /// </summary> 
        private static void getNumDataPoints()
        {
            Console.WriteLine("How many data points would you like to enter");
            numDataPoints = Convert.ToInt16(Console.ReadLine());

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

        private static void getRanks(List<int> scores, List<double> ranks)
        {
            // Local copy of scores
            List<int> sorted = new List<int>(scores);
            // Order them in descending order
            sorted.Sort();
            sorted.Reverse();

            int rank = 1;

            for(int i = 0; i < sorted.Count; i++)
            {
                int score = sorted[i];

                // Find all indexes with this score (handle ties)
                List<int> tiedIndexes = new List<int>();
                for(int j = 0; j < scores.Count; j++)
                {
                    if (scores[j] == score && ranks[j] == 0)
                        tiedIndexes.Add(j);
                }

                // Average rank if tie
                double averageRank = 0;
                for (int k = 0; k < tiedIndexes.Count; k++)
                    averageRank += rank + k;
                averageRank /= tiedIndexes.Count;

                // Assign the average rank to all tied positions
                foreach( int index in tiedIndexes )
                {
                    ranks[index] = averageRank;
                }

                rank += tiedIndexes.Count;
            }
        }

        private static void getDifference()
        {
            for(int i = 0; i < numDataPoints; i++)
            {
                double difference = Math.Abs(Rank1[i] - Rank2[i]);
                d[i] = difference;
            }
        }

        private static void getDifferenceSquared()
        {
            for(int i = 0; i < numDataPoints; i++)
            {
                dSquared[i] = Math.Pow(d[i], 2);
            }

            for(int j = 0; j < numDataPoints; j++)
            {
                sigma_dSquared += dSquared[j];
            }
        }

        private static void getCorrelation()
        {
            // Correlation must be between -1 and 1
            double correlation = 999;
        }
    }
}