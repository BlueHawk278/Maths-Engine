using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static MathsEngine.Modules.Statistics.BivariateAnalysis.Variables;

namespace MathsEngine.Modules.Statistics.BivariateAnalysis
{
    /// <summary>
    /// Provides static methods for performing bivariate analysis calculations.
    /// </summary>
    /// <remarks>
    /// This class relies on static variables defined in <see cref="Variables"/> to store state,
    /// such as data points, scores, and intermediate calculations.
    /// </remarks>
    internal class BivariateAnalysisLogic
    {
        /// <summary>
        /// Prompts the user for the number of data points and initializes the data points list.
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
        /// Prompts the user to enter a set of scores.
        /// </summary>
        /// <param name="scores">The list to populate with the entered scores.</param>
        internal static void getScores(List<int> scores)
        {
            Console.WriteLine("Press any button to enter scores...");
            Console.ReadLine();

            scores.Clear();
            for(int i = 0; i < dataPoints.Count; i++)
            {
                Console.Write($"Enter points {dataPoints[i]}: ");
                int num = Convert.ToInt16(Console.ReadLine());
                scores.Add(num);
            }
        }

        /// <summary>
        /// Calculates the ranks for a given list of scores, handling ties by averaging ranks.
        /// </summary>
        /// <param name="scores">The list of scores to rank.</param>
        /// <param name="ranks">The list to populate with the calculated ranks.</param>
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

        /// <summary>
        /// Calculates the absolute difference between corresponding ranks in <see cref="Rank1"/> and <see cref="Rank2"/>.
        /// </summary>
        internal static void getDifference()
        {
            Difference.Clear();
            for (int i = 0; i < numDataPoints; i++)
            {
                double difference = Math.Abs(Rank1[i] - Rank2[i]);
                Difference.Add(difference);
            }
        }

        /// <summary>
        /// Calculates the square of each difference and the sum of these squared differences.
        /// </summary>
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

        /// <summary>
        /// Calculates the Spearman's rank correlation coefficient.
        /// </summary>
        /// <returns>The correlation coefficient, a value between -1.0 and 1.0.</returns>
        /// <remarks>
        /// The formula used is: 1 - (6 * sum of squared differences) / (n * (n^2 - 1)).
        /// The result is clamped to the range [-1.0, 1.0] to handle potential floating-point inaccuracies.
        /// </remarks>
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

        /// <summary>
        /// Displays all collected and calculated data to the console.
        /// </summary>      
        internal static void displayAllInfo() // sort it out
        {
            Console.Write("n: ");
            for(int i = 0; i < numDataPoints; ++i)
                Console.Write(i + 1 + " ");
            Console.WriteLine();

            Console.Write("Score 1: ");
            for (int i = 0; i < numDataPoints; ++i)
                Console.Write(Score1[i] + " ");
            Console.WriteLine();

            Console.Write("Score 2: ");
            for (int i = 0; i < numDataPoints; ++i)
                Console.Write(Score2[i] + " ");
            Console.WriteLine();

            Console.Write("Rank 1: ");
            for (int i = 0; i < numDataPoints; ++i)
                Console.Write(Rank1[i] + " ");
            Console.WriteLine();

            Console.Write("Rank 2: ");
            for (int i = 0; i < numDataPoints; ++i)
                Console.Write(Rank2[i] + " ");
            Console.WriteLine();

            Console.Write("d: ");
            for (int i = 0; i < numDataPoints; ++i)
                Console.Write(Difference[i] + " ");
            Console.WriteLine();

            Console.Write("d^2: ");
            for (int i = 0; i < numDataPoints; ++i)
                Console.Write(differenceSquared[i] + " ");
            Console.WriteLine();
        }
    }
}