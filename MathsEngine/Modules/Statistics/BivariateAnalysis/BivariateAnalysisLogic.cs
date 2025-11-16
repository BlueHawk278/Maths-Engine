using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static MathsEngine.Modules.Statistics.BivariateAnalysis.Variables;

/*
 * TODO: Format displayAllInfo() to make it look better,
 *       Draw a scatter graph for the values,
 *       Draw a line of best fit,
 *       Determine the equation of the line of best fit
 */

namespace MathsEngine.Modules.Statistics.BivariateAnalysis
{
    /// <summary>
    /// Provides static methods for performing bivariate analysis calculations.
    /// </summary>
    /// <remarks>
    /// This class relies on static variables defined in <see cref="Variables"/> to store state,
    /// such as data points, scores, and intermediate calculations.
    /// </remarks>
    internal static class BivariateAnalysisLogic
    {
        /// <summary>
        /// Prompts the user for the number of data points and initializes the data points list.
        /// </summary> 
        internal static List<int> getNumDataPoints()
        {
            Console.WriteLine("How many data points would you like to enter");
            NumDataPoints = Convert.ToInt16(Console.ReadLine());

            DataPoints.Clear();
            for (int i = 0; i < NumDataPoints; i++)
            {
                DataPoints.Add(i + 1);
            }

            return DataPoints;
        }

        /// <summary>
        /// Prompts the user to enter a set of scores.
        /// </summary>
        /// <param name="scores">The list to populate with the entered scores.</param>
        internal static List<int> getScores(List<int> scores)
        {
            Console.WriteLine("Press any button to enter scores...");
            Console.ReadLine();

            scores.Clear();
            for(int i = 0; i < DataPoints.Count; i++)
            {
                Console.Write($"Enter points {DataPoints[i]}: ");
                int num = Convert.ToInt16(Console.ReadLine());
                scores.Add(num);
            }

            return scores;
        }

        /// <summary>
        /// Calculates the ranks for a given list of scores, handling ties by averaging ranks.
        /// </summary>
        /// <param name="scores">The list of scores to rank.</param>
        /// <param name="ranks">The list to populate with the calculated ranks.</param>
        internal static List<double> getRanks(List<int> scores, List<double> ranks)
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

            return ranks;
        }

        /// <summary>
        /// Calculates the absolute difference between corresponding ranks in <see cref="Rank1"/> and <see cref="Rank2"/>.
        /// </summary>
        internal static List<double> getDifference()
        {
            Difference.Clear();
            for (int i = 0; i < NumDataPoints; i++)
            {
                double difference = Math.Abs(Rank1[i] - Rank2[i]);
                Difference.Add(difference);
            }
            return Difference;
        }

        /// <summary>
        /// Calculates the square of each difference and the sum of these squared differences.
        /// </summary>
        internal static List<double> getDifferenceSquared()
        {
            DifferenceSquared.Clear();
            SumDifferenceSquared = 0;
            foreach (var val in Difference)
            {
                double squared = Math.Pow(val, 2);
                DifferenceSquared.Add(squared);
                SumDifferenceSquared += squared;
            }
            return DifferenceSquared;
        }

        /// <summary>
        /// Calculates the Spearman's rank correlation coefficient.
        /// </summary>
        /// <returns>The correlation coefficient, a value between -1.0 and 1.0.</returns>
        /// <remarks>
        /// The formula used is: 1 - (6 * sum of squared differences) / (n * (n^2 - 1)).
        /// The result is clamped to the range [-1.0, 1.0] to handle potential floating-point inaccuracies.
        /// </remarks>
        internal static double getCorrelationValue()
        {
            // Correlation must be between -1 and 1
            double topLine = SumDifferenceSquared * 6;
            double bottomLine = NumDataPoints * (Math.Pow(NumDataPoints, 2) - 1);
            
            // Avoid division by zero if there's only one data point
            if (bottomLine == 0) return 0;

            double correlation = 1 - (topLine / bottomLine);
            
            // Clamp the result to the valid range of -1 to 1
            if (correlation < -1.0) return -1.0;
            if (correlation > 1.0) return 1.0;
            
            return Math.Round(correlation, 2);
        }

        /// <summary>
        /// Calculate the enum value for correlation based on the numeric value
        /// </summary>
        /// <param name="correlation"></param>
        /// <returns></returns>
        internal static Correlation calculateCorrelation(double correlation)
        {
            if (correlation == 0.00)
                return Correlation.NoCorrelation;
            if (correlation == 1.0)
                return Correlation.PerfectPositive;
            if (correlation == -1.0)
                return Correlation.PerfectNegative;
            if (correlation > 0.5 && correlation < 1.0)
                return Correlation.StrongPositive;
            if (correlation > 0 && correlation <= 0.5)
                return Correlation.WeakPositive;
            if (correlation < -0.5 && correlation > -1.0)
                return Correlation.StrongNegative;
            if (correlation < 0 && correlation >= -0.5)
                return Correlation.WeakNegative;

            return Correlation.Invalid;
        }

        /// <summary>
        /// Displays all collected and calculated data to the console.
        /// </summary>      
        internal static void displayAllInfo() // sort it out
        {
            Console.Write("n: ");
            for(int i = 0; i < NumDataPoints; ++i)
                Console.Write(i + 1 + " ");
            Console.WriteLine();

            Console.Write("Score 1: ");
            for (int i = 0; i < NumDataPoints; ++i)
                Console.Write(Score1[i] + " ");
            Console.WriteLine();

            Console.Write("Score 2: ");
            for (int i = 0; i < NumDataPoints; ++i)
                Console.Write(Score2[i] + " ");
            Console.WriteLine();

            Console.Write("Rank 1: ");
            for (int i = 0; i < NumDataPoints; ++i)
                Console.Write(Rank1[i] + " ");
            Console.WriteLine();

            Console.Write("Rank 2: ");
            for (int i = 0; i < NumDataPoints; ++i)
                Console.Write(Rank2[i] + " ");
            Console.WriteLine();

            Console.Write("d: ");
            for (int i = 0; i < NumDataPoints; ++i)
                Console.Write(Difference[i] + " ");
            Console.WriteLine();

            Console.Write("d^2: ");
            for (int i = 0; i < NumDataPoints; ++i)
                Console.Write(DifferenceSquared[i] + " ");
            Console.WriteLine();

            Console.Write("∑d^2: " + SumDifferenceSquared);
        }
    }
}