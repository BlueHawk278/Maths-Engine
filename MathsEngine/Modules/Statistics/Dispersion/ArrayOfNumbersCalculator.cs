using MathsEngine.Utils;

namespace MathsEngine.Modules.Statistics.Dispersion
{
    public class ArrayOfNumbersCalculator : IStandardDeviation
    {
        private readonly List<double> _originalValues = [];
        private readonly List<double> _sortedValues = [];
        private readonly int _numValues;

        private double _mean, _median, _range, _q1, _q3, _iqr;
        private List<double> _modeList = [];

        public double Variance { get; private set; }
        public double StandardDeviation { get; private set; }
        public double Mean => _mean;

        public ArrayOfNumbersCalculator(List<double> originalValues)
        {
            if (originalValues == null)
                throw new NullInputException();

            if (originalValues.Count == 0)
                throw new EmptyDataSetException();

            _originalValues = originalValues;
            _sortedValues = new List<double>(originalValues);
            _sortedValues.Sort();
            _numValues = _sortedValues.Count();
        }
        public void Run()
        {
            CalculateAverages();
            CalculateVarianceAndStdDeviation();
        }
        private void CalculateAverages()
        {
            AverageCalculator<double> averageCalculator = new AverageCalculator<double>();

            _mean = averageCalculator.CalculateMean(_originalValues);
            _median = averageCalculator.CalculateMedian(_originalValues);
            _modeList = averageCalculator.CalculateMode(_originalValues);
            _range = averageCalculator.CalculateRange(_originalValues);

            var quartiles = averageCalculator.GetInterQuartileRange(_originalValues);
            _q1 = quartiles[0];
            _q3 = quartiles[1];
            _iqr = quartiles[2];
        }
        private void CalculateVarianceAndStdDeviation()
        {
            double sumOfSquaredDistances = 0;
            for (int i = 0; i < _numValues; i++)
            {
                double distance = _originalValues[i] - Mean;
                sumOfSquaredDistances += distance * distance;
            }

            Variance = sumOfSquaredDistances / _numValues;
            StandardDeviation = Math.Sqrt(Variance);
        }
        public void DisplayData()
        {
            Console.Write("\nOriginal values: ");
            foreach (double value in _originalValues)
                Console.Write(value + ", ");

            Console.Write("\nSorted values: ");
            foreach (double value in _sortedValues)
                Console.Write(value + ", ");

            Console.WriteLine("\nMean: " + Math.Round(Mean, 3));
            Console.WriteLine("Median: " + _median);

            Console.Write("Mode: ");
            foreach (double mode in _modeList)
                Console.Write(mode + " ");

            Console.WriteLine("Range: " + _range);

            Console.WriteLine("Q1: " + _q1);
            Console.WriteLine("Q3: " + _q3);
            Console.WriteLine("IQR: " + _iqr);

            Console.WriteLine($"\nStandard Deviation: {Math.Round(StandardDeviation, 2)}\n");
        }
    }
}