using System;
using System.Collections.Generic;
using System.Linq;

namespace MathsEngine.Modules.Statistics.BivariateAnalysis
{
    /// <summary>
    /// Performs a complete bivariate analysis for a given set of paired scores.
    /// This class is instantiated for a single calculation and holds its own state.
    /// </summary>
    public class BivariateAnalysisCalculator
    {
        // --- 1. Data is stored as private instance fields ---

        private readonly List<int> _scores1;
        private readonly List<int> _scores2;

        private readonly Correlation _correlationValue;

        // --- 2. Results are exposed as public properties with private setters ---
        public List<double> Ranks1 { get; private set; }
        public List<double> Ranks2 { get; private set; }
        public List<double> Difference { get; private set; }
        public List<double> DifferenceSquared { get; private set; }
        public double SumDifferenceSquared { get; private set; }
        public double CorrelationCoefficient { get; private set; }

        /// <summary>
        /// Initializes a new instance of the calculator with two sets of scores.
        /// </summary>
        public BivariateAnalysisCalculator(List<int> scores1, List<int> scores2)
        {
            if (scores1 == null || scores2 == null || scores1.Count != scores2.Count)
            {
                throw new ArgumentException("Score lists must be non-null and have the same number of elements.");
            }
            _scores1 = scores1;
            _scores2 = scores2;
        }

        /// <summary>
        /// Runs the full sequence of calculations.
        /// </summary>
        public void Run()
        {
            Ranks1 = CalculateRanksFor(_scores1);
            Ranks2 = CalculateRanksFor(_scores2);
            Difference = CalculateDifference();
            DifferenceSquared = CalculateDifferenceSquared();
            CorrelationCoefficient = CalculateCorrelation();
        }

        // --- 3. All calculation logic is now private to this class ---

        private List<double> CalculateRanksFor(List<int> scores)
        {
            var sorted = new List<int>(scores);
            sorted.Sort();
            sorted.Reverse();

            var ranks = new double[scores.Count];
            int rank = 1;

            for (int i = 0; i < sorted.Count; i++)
            {
                int score = sorted[i];
                var tiedIndexes = new List<int>();
                for (int j = 0; j < scores.Count; j++)
                {
                    if (scores[j] == score && ranks[j] == 0)
                        tiedIndexes.Add(j);
                }

                if (tiedIndexes.Count > 0)
                {
                    double averageRank = 0;
                    for (int k = 0; k < tiedIndexes.Count; k++)
                        averageRank += rank + k;
                    averageRank /= tiedIndexes.Count;

                    foreach (int index in tiedIndexes)
                        ranks[index] = averageRank;
                }
                rank += tiedIndexes.Count;
            }
            return ranks.ToList();
        }

        private List<double> CalculateDifference()
        {
            var differences = new List<double>();
            for (int i = 0; i < Ranks1.Count; i++)
            {
                differences.Add(Ranks1[i] - Ranks2[i]);
            }
            return differences;
        }

        private List<double> CalculateDifferenceSquared()
        {
            var diffsSquared = new List<double>();
            double sum = 0;
            foreach (var val in Difference)
            {
                double squared = Math.Pow(val, 2);
                diffsSquared.Add(squared);
                sum += squared;
            }
            SumDifferenceSquared = sum;
            return diffsSquared;
        }

        private double CalculateCorrelation()
        {
            double topLine = SumDifferenceSquared * 6;
            double bottomLine = _scores1.Count * (Math.Pow(_scores1.Count, 2) - 1);

            if (bottomLine == 0) return 0;

            return 1 - (topLine / bottomLine);
        }
    }
}