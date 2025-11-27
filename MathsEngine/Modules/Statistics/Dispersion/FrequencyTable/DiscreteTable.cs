using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsEngine.Modules.Statistics.Dispersion.FrequencyTable
{
    internal class DiscreteTable : IStandardDeviation
    {
        private double _mean;
        public double _sigmaF, _sigmaFX, _sigmaFXSquared;
        public double[,] Table { get; private set; }
        private int NumRows { get;}
        public double Variance { get; private set; }
        public double StandardDeviation { get; private set; }
        public double Mean => _mean;

        public DiscreteTable(double[,] table)
        {
            if(table == null)
                throw new ArgumentNullException("Table must not be empty");

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
            // Calculating fx from frequency * x
            for (int i = 0; i < NumRows; i++)
            {
                Table[i, 2] = Table[i, 0] * Table[i, 1];
            }

            // Calculating fx^2 from fx * x
            for (int i = 0; i < NumRows; i++)
            {
                Table[i, 3] = Table[i, 0] * Table[i, 2];
            }
        }

        private void GetTotals(double[,] table)
        {
            double total = 0;

            // 𝛴F
            for (int i = 0; i < NumRows; i++)
            {
                total += Table[i, 1];
            }
            _sigmaF = total;
            total = 0;

            // 𝛴FX
            for (int i = 0; i < NumRows; i++)
            {
                total += Table[i, 2];
            }
            _sigmaFX = total;
            total = 0;

            // 𝛴FX^2
            for (int i = 0; i < NumRows; i++)
            {
                total += Table[i, 3];
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
            Console.WriteLine($"Mean: {Mean}");
            Console.WriteLine($"Standard Deviation: {StandardDeviation}");
        }
    }
}
