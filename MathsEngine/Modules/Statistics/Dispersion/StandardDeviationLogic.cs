using System;
using System.Collections.Generic;
using System.Linq;

namespace MathsEngine.Modules.Statistics.Dispersion
{
    internal class StandardDeviationLogic : IStandardDeviation
    {
        private readonly List<double> _originalValues = new List<double>();
        private readonly List<double> _sortedValues = new List<double>();
        private readonly int _numValues;

        private double _mean, _median, _range, _q1, _q3, _iqr;
        private List<double> _modeList = new List<double>();

        private List<double> _distanceFromMean = new List<double>();

        public double Variance { get; private set; }
        public double StandardDeviation { get; private set; }
        public double Mean => _mean;

        public StandardDeviationLogic(List<double> originalValues)
        {
            if (originalValues == null || originalValues.Count() == 0)
                throw new ArgumentException("Score lists must be non-null and have the same number of elements.");
            _originalValues = originalValues;
            _sortedValues = new List<double>(originalValues);
            _sortedValues.Sort();
            _numValues = _sortedValues.Count();
        }
        public void Run()
        {
            getAverages(_originalValues);
            _distanceFromMean = getDistanceFromMean();
            Variance = getVariance(_distanceFromMean);
            StandardDeviation = getStandardDeviation(Variance);
        }
        private void getAverages(List<double> values)
        {
            _mean = Core.StatisticsHelpers.AverageCalculator.calculateMean(values);
            _median = Core.StatisticsHelpers.AverageCalculator.calculateMedian(values);
            _modeList = Core.StatisticsHelpers.AverageCalculator.calculateMode(values);
            _range = Core.StatisticsHelpers.AverageCalculator.calculateRange(values);

            var quartiles = Core.StatisticsHelpers.AverageCalculator.getInterQuartileRange(values);
            _q1 = quartiles[0];
            _q3 = quartiles[1];
            _iqr = quartiles[2];
        }
        private List<double> getDistanceFromMean()
        {
            var distanceFromMean = new List<double>();

            const double epsilon = 1e-9; // IDK, but it's needed for this to work

            for (int i = 0; i < _numValues; i++)
            {
                distanceFromMean.Add(_sortedValues[i] - Mean);
            }

            // Check it total deviation from mean is 0
            if (Math.Abs(distanceFromMean.Sum()) < epsilon)
                return distanceFromMean;

            return null;
        }
        private double getVariance(List<double> distanceFromMean)
        {
            if (distanceFromMean == null || distanceFromMean.Count() == 0)
                throw new ArgumentException("Score list must be non-null and have the same number of elements");

            double variance = 0;

            for (int i = 0; i < _numValues; i++)
            {
                variance += Math.Pow(distanceFromMean[i], 2);
            }

            return variance / _numValues;
        }
        private double getStandardDeviation(double variance)
        {
            return Math.Sqrt(variance);
        }
        public void DisplayData()
        {
            Console.WriteLine();

            Console.WriteLine("Original values: ");
            foreach(double value in _originalValues)
                Console.Write(value + ", ");
            Console.WriteLine();

            Console.WriteLine("Sorted values: ");
            foreach(double value in _sortedValues)
                Console.Write(value + ", ");
            Console.WriteLine();

            Console.WriteLine("Distance from mean: ");
            foreach(double value in _distanceFromMean)
                Console.Write(Math.Round(value, 3) + ", ");
            Console.WriteLine();

            Console.WriteLine();

            Console.WriteLine("Mean: " + Math.Round(Mean, 3));
            Console.WriteLine("Median: " + _median);

            Console.Write("Mode: ");
            foreach(double mode in _modeList)
                Console.Write(mode + " ");

            Console.WriteLine("Range: " + _range);

            Console.WriteLine("Q1: " + _q1);
            Console.WriteLine("Q3: " + _q3);
            Console.WriteLine("IQR: " + _iqr);
            
            Console.WriteLine($"\nStandard Deviation: {Math.Round(StandardDeviation, 2)}");
        }
    }
}