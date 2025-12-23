using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsEngine.Modules.Statistics.Dispersion.FrequencyTable
{
    internal class DiscreteTableCalculator : IStandardDeviation
    {
        private double _mean;
        public double _sigmaF, _sigmaFX, _sigmaFXSquared;
        private double[,] Table { get; set; }
        private int NumRows { get;}
        public double Variance { get; private set; }
        public double StandardDeviation { get; private set; }
        public double Mean => _mean;

        public DiscreteTableCalculator(double[,] table)
        {
            if(table == null)
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
                double x = Table[i, 0];
                double f = Table[i, 1];
                double fx = x * f;
                double fxSquared = fx * x;

                Table[i, 2] = fx;
                Table[i, 3] = fxSquared;

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
            Console.WriteLine($"Mean: {Mean}");
            Console.WriteLine($"Standard Deviation: {StandardDeviation}");
        }
    }
}