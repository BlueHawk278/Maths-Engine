using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsEngine.Modules.Statistics.StandardDeviation
{
    internal static class MathsVariables
    {
        internal static List<double> originalValues = new List<double>();
        internal static List<double> sortedValues = new List<double>();
        internal static int numValues;

        internal static double Mean, Mode, Median, Range, Q1, Q2, IQR;
        internal static List<double> mode = new List<double>();
    }
}