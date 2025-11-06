using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MathsEngine.Modules.Statistics.BivariateAnalysis.AnalysisMethods;
using static MathsEngine.Modules.Statistics.BivariateAnalysis.MathsVariables;

namespace MathsEngine.Modules.Statistics.BivariateAnalysis
{
    internal class BivariateAnalysisController
    {
        public static void Calculate()
        {
            getNumDataPoints();

            getScores(Score1);
            getScores(Score2);

            getRanks(Score1, Rank1);
            getRanks(Score2, Rank2);

            getDifference();
            getDifferenceSquared();

            double correlation = getCorrelation();
            Console.WriteLine($"\nThe Spearman's Rank Correlation Coefficient is: {correlation:F3}");

            displayAllInfo();

            Console.ReadLine();
        }
    }
}