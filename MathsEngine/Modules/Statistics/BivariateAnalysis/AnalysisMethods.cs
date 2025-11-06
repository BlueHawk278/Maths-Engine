using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static MathsEngine.Modules.Statistics.BivariateAnalysis.MathsVariables;

namespace MathsEngine.Modules.Statistics.BivariateAnalysis
{
    internal class AnalysisMethods
    {
        /// <summary>
        /// Gets the number of data points and assigns them to the list
        /// </summary> 
        internal static void getNumDataPoints()
        {
            Console.WriteLine("How many data points would you like to enter");
            numDataPoints = Convert.ToInt16(Console.ReadLine());

            dataPoints.Clear();
            for (int i = 0; i < numDataPoints; i++)
            {
                dataPoints.Add(i + 1);
            }
        }

        /// <summary>
        /// Gets scores from user input to be ranked
        /// </summary>
        internal static void getScores(List<int> scores)
        {
            Console.WriteLine("Press any button to enter scores...");
            Console.ReadLine();

            scores.Clear();
            int num = 0;
            while (num < dataPoints.Count)
            {
                Console.Write($"Enter point {dataPoints[num]}: ");
                int number = Convert.ToInt16(Console.ReadLine());
                scores.Add(number);
                num++;
            }
        }

        internal static void getRanks(List<int> scores, List<double> ranks)
        {
            // Local copy of scores
            List<int> sorted = new List<int>(scores);
            // Order them in descending order
            sorted.Sort();
            sorted.Reverse();

            // Clear and initialize the ranks list for the current calculation
            ranks.Clear();
            for (int i = 0; i < scores.Count; i++) ranks.Add(0);

            int rank = 1;

            for (int i = 0; i < sorted.Count; i++)
            {
                int score = sorted[i];

                // Find all indexes with this score (handle ties)
                List<int> tiedIndexes = new List<int>();
                for (int j = 0; j < scores.Count; j++)
                {
                    if (scores[j] == score && ranks[j] == 0)
                        tiedIndexes.Add(j);
                }

                // Average rank if tie
                double averageRank = 0;
                if (tiedIndexes.Count > 0)
                {
                    for (int k = 0; k < tiedIndexes.Count; k++)
                        averageRank += rank + k;
                    averageRank /= tiedIndexes.Count;
                }

                // Assign the average rank to all tied positions
                foreach (int index in tiedIndexes)
                {
                    ranks[index] = averageRank;
                }

                rank += tiedIndexes.Count;
            }
        }

        internal static void getDifference()
        {
            Difference.Clear();
            for (int i = 0; i < numDataPoints; i++)
            {
                double difference = Math.Abs(Rank1[i] - Rank2[i]);
                Difference.Add(difference);
            }
        }

        internal static void getDifferenceSquared()
        {
            differenceSquared.Clear();
            sumDifferenceSquared = 0;
            foreach (var val in Difference)
            {
                double squared = Math.Pow(val, 2);
                differenceSquared.Add(squared);
                sumDifferenceSquared += squared;
            }
        }

        internal static double getCorrelation()
        {
            // Correlation must be between -1 and 1
            double topLine = sumDifferenceSquared * 6;
            double bottomLine = numDataPoints * (Math.Pow(numDataPoints, 2) - 1);
            
            // Avoid division by zero if there's only one data point
            if (bottomLine == 0) return 0;

            double correlation = 1 - (topLine / bottomLine);
            
            // Clamp the result to the valid range of -1 to 1
            if (correlation < -1.0) return -1.0;
            if (correlation > 1.0) return 1.0;
            
            return correlation;
        }
    }
}