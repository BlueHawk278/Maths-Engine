using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsEngine.Modules.Statistics.Dispersion.ContinuousTable
{
    internal class ContinuousTable : IStandardDeviation // MEAN is incorrect and therefore stnadard deviation
    {
        private double _mean;
        public double _sigmaF, _sigmaFX, _sigmaFXSquared;
        private double[,] Table { get; }
        private int NumRows { get; }

        public double StandardDeviation { get; private set; }
        public double Mean => _mean;
        public double Variance { get; private set; }

        public ContinuousTable(double[,] table)
        {
            if(table == null)
                throw new ArgumentNullException("table must not be null");
            NumRows = table.GetLength(0);
            Table = table;
        }

        public void Run()
        {
            GetTableValues(Table);
            GetTotals(Table);
            CalculateStandardDeviation();
        }

        private void GetTableValues(double[,] table)
        {
            
            for (int i = 0; i < NumRows; i++)
            {
                // Calculating fx from table
                Table[i, 4] = table[i, 3] * table[i, 2];
                // Calculating fx^2 from table
                Table[i, 5] = table[i, 4] * table[i, 3];
            }
        }

        private void GetTotals(double[,] table)
        {
            double total = 0;

            // Calculating 𝛴f
            for (int i = 0; i < NumRows; i++)
            {
                total += table[i, 2];
            }
            _sigmaF = total;
            total = 0;

            // Calculating 𝛴fx
            for (int i = 0; i < NumRows; i++)
            {
                total += table[i, 4];
            }
            _sigmaFX = total;
            total = 0;

            // Calculating 𝛴fx^2
            for (int i = 0; i < NumRows; i++)
            {
                total += table[i, 5];
            }
            _sigmaFXSquared = total;
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
