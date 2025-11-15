using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MathsEngine.Modules.Statistics.BivariateAnalysis.BivariateAnalysisLogic;
using static MathsEngine.Modules.Statistics.BivariateAnalysis.Variables;

namespace MathsEngine.Modules.Statistics.BivariateAnalysis
{
    internal class BivariateAnalysis
    {
        public static void calculate()
        {
            getNumDataPoints();

            getScores(Score1);
            getScores(Score2);

            getRanks(Score1, Rank1);
            getRanks(Score2, Rank2);

            getDifference();
            getDifferenceSquared();

            Console.WriteLine($"\nThe Spearman's Rank Correlation Coefficient is: {getCorrelation():F3}");

            displayAllInfo();

            Console.ReadLine();
        }
    }
}