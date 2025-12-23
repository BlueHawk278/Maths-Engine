using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsEngine.Modules.Statistics.Dispersion.ContinuousTable
{
    internal class ContinuousTableCalculator : IStandardDeviation
    {
        private double _mean;
        public double _sigmaF, _sigmaFX, _sigmaFXSquared;
        private double[,] Table { get; }
        private int NumRows { get; }

        public double StandardDeviation { get; private set; }
        public double Mean => _mean;
        public double Variance { get; private set; }

        public ContinuousTableCalculator(double[,] table)
        {
            if (table == null)
                throw Utils.Exceptions.NullInputException;
            NumRows = table.GetLength(0);
            Table = table;
        }

        public void Run()
        {
            CalculateTotals();
            CalculateStandardDeviation();
        }

        private void CalculateTotals()
        {
            for (int i = 0; i < NumRows; i++)
            {
                double f = Table[i, 2];
                double x = Table[i, 3]; // Midpoint
                double fx = x * f;
                double fxSquared = fx * x;

                Table[i, 4] = fx;
                Table[i, 5] = fxSquared;

                _sigmaF += f;
                _sigmaFX += fx;
                _sigmaFXSquared += fxSquared;
            }
        }

        private void CalculateStandardDeviation()
        {
            _mean = _sigmaFX / _sigmaF;
            Variance = (_sigmaFXSquared / _sigmaF) - (Mean * Mean);
            StandardDeviation = Math.Sqrt(Variance);
        }

        public void DisplayData()
        {
            Console.WriteLine($"Mean: {_mean}");
            Console.WriteLine($"Standard Deviation: {StandardDeviation}");
        }
    }
}
