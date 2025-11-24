using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsEngine.Modules.Statistics.Dispersion
{
    internal class StandardDeviationLogic
    {
        private readonly List<double> _originalValues = new List<double>();
        private readonly List<double> _sortedValues = new List<double>();
        private readonly int _numValues;

        private double Mean, Median, Range, Q1, Q3, IQR;
        private List<double> modeList = new List<double>();

        public StandardDeviationLogic(List<double> originalValues)
        {
            if (_originalValues == null || _originalValues.Count() == 0)
                throw new ArgumentException("Score lists must be non-null and have the same number of elements.");
            _originalValues = originalValues;
            _sortedValues = new List<double>(originalValues);
            _sortedValues.Sort();
            _numValues = _sortedValues.Count();
        }

        public void Run()
        {
            getAverages(_originalValues);
        }

        private void getAverages(List<double> values)
        {
            Mean = Core.StatisticsHelpers.AverageCalculator.calculateMean(values);
            Median = Core.StatisticsHelpers.AverageCalculator.calculateMedian(values);
            modeList = Core.StatisticsHelpers.AverageCalculator.calculateMode(values);
            Range = Core.StatisticsHelpers.AverageCalculator.calculateRange(values);

            var quartiles = Core.StatisticsHelpers.AverageCalculator.getInterQuartileRange(values);
            Q1 = quartiles[0];
            Q3 = quartiles[1];
            IQR = quartiles[2];
        }
        public void displayData()
        {
            Console.WriteLine("Mean: " + Mean);
            Console.WriteLine("Median: " + Median);

            Console.Write("Mode: ");
            foreach(double mode in modeList)
                Console.Write(mode + " ");

            Console.WriteLine("Range: " + Range);

            Console.WriteLine("Q1: " + Q1);
            Console.WriteLine("Q3: " + Q3);
            Console.WriteLine("IQR: " + IQR);
        }
    }
}