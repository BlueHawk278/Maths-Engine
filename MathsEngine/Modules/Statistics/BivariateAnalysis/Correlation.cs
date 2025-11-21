using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsEngine.Modules.Statistics.BivariateAnalysis
{
    internal enum Correlation
    {
        PerfectPositive,
        StrongPositive,
        WeakPositive,
        NoCorrelation,
        WeakNegative,
        StrongNegative,
        PerfectNegative,
    }
    /// <summary>
    /// Provides an extensions method to display the correlations in a user-friendly manner.
    /// </summary>
    internal static class CorrelationExtensions
    {
        public static string displayString(Correlation correlation)
        {
            switch (correlation)
            {
                case Correlation.PerfectPositive:
                    return "Perfect Positive correlation";
                case Correlation.StrongPositive:
                    return "Strong Positive Correlation";
                case Correlation.WeakPositive:
                    return "Weak Positive Correlation";
                case Correlation.NoCorrelation:
                    return "No Correlation";
                case Correlation.WeakNegative:
                    return "Weak Negative Correlation";
                case Correlation.StrongNegative:
                    return "Strong Negative Correlation";
                case Correlation.PerfectNegative:
                    return "Perfect Negative Correlation";
                default:
                    return "Invalid Correlation";
            }
        }
    }
}
