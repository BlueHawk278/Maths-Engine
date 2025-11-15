using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsEngine.Modules.Statistics.BivariateAnalysis
{
    /// <summary>
    /// Contains variables for bivariate analysis calculations.
    /// </summary>
    internal static class Variables
    {
        /// <summary>
        /// Gets or sets the list of data points.
        /// </summary>
        internal static List<int> DataPoints { get; set; } = new List<int>();

        /// <summary>
        /// Gets or sets the number of data points.
        /// </summary>
        internal static int _numDataPoints;

        internal static int NumDataPoints
        {
            get { return _numDataPoints; }
            set
            {
                if (value > 0)
                    _numDataPoints = value;
            }
        }

        /// <summary>
        /// Gets or sets the scores for the first variable.
        /// </summary>
        internal static List<int> Score1 { get; set; } = new List<int>();

        /// <summary>
        /// Gets or sets the scores for the second variable.
        /// </summary>
        internal static List<int> Score2 { get; set; } = new List<int>();

        /// <summary>
        /// Gets or sets the ranks for the first variable.
        /// </summary>
        internal static List<double> Rank1 { get; set; } = new List<double>();

        /// <summary>
        /// Gets or sets the ranks for the second variable.
        /// </summary>
        internal static List<double> Rank2 { get; set; } = new List<double>();

        /// <summary>
        /// Gets or sets the difference between ranks.
        /// </summary>
        internal static List<double> Difference { get; set; } = new List<double>();

        /// <summary>
        /// Gets or sets the squared difference between ranks.
        /// </summary>
        internal static List<double> DifferenceSquared { get; set; } = new List<double>();

        /// <summary>
        /// Gets or sets the sum of the squared differences.
        /// </summary>
        internal static double SumDifferenceSquared { get; set; }
    }
}