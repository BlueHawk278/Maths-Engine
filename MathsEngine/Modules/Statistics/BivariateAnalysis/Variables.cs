using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsEngine.Modules.Statistics.BivariateAnalysis
{
    internal class Variables
    {
        internal static List<int> dataPoints = new List<int>();
        internal static int numDataPoints = 0;

        internal static List<int> Score1 = new List<int>();
        internal static List<int> Score2 = new List<int>();

        internal static List<double> Rank1 = new List<double>();
        internal static List<double> Rank2 = new List<double>();

        internal static List<double> Difference = new List<double>();
        internal static List<double> differenceSquared = new List<double>();
        internal static double sumDifferenceSquared = 0;
    }
}