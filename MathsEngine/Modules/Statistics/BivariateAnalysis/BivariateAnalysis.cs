using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MathsEngine.Modules.Statistics.BivariateAnalysis.BivariateAnalysisLogic;
using static MathsEngine.Modules.Statistics.BivariateAnalysis.Variables;

namespace MathsEngine.Modules.Statistics.BivariateAnalysis
{
    internal static class BivariateAnalysis
    {
        public static void calculate()
        {
            DataPoints = getNumDataPoints();

            Score1 = getScores(Score1);
            Score2 = getScores(Score2);

            Rank1 = getRanks(Score1, Rank1);
            Rank2 = getRanks(Score2, Rank2);

            Difference = getDifference();
            DifferenceSquared = getDifferenceSquared();

            double correlationValue = getCorrelationValue();
            Console.WriteLine($"\nThe Spearman's Rank Correlation Coefficient is: {correlationValue:F3}");

            Correlation correlation = calculateCorrelation(correlationValue);
            Console.WriteLine($"Correlation: " + CorrelationExtensions.DisplayString(correlation));

            displayAllInfo();

            Console.ReadLine();
        }
    }
}