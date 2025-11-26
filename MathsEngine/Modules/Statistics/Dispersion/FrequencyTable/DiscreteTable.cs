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
        private int NumRows { get; set; }
        public double Variance { get; private set; }
        public double StandardDeviation { get; private set; }
        public double Mean => _mean;

        public void Run()
        {

        }

        private void GetTable(double[] table)
        {
            Console.WriteLine("How many columns are there");
            NumRows = Convert.ToInt16(Console.ReadLine());

            Table = new double[NumRows, 4];


            // Getting the x value and frequency for table
            for (int i = 0; i < NumRows; i++)
            {
                Console.Write($"Enter X value No.{NumRows++}:  ");
                int num = Convert.ToInt16(Console.ReadLine());
                Console.Write($"Enter the frequency for this value: ");
                int frequency = Convert.ToInt16(Console.ReadLine());

                Table[NumRows, 0] = num;
                Table[NumRows, 1] = frequency;
            }

            // Calculating fx from frequency * x
            for (int i = 0; i < NumRows; i++)
            {
                Table[NumRows, 2] = Table[NumRows, 0] * Table[NumRows, 1];
            }

            // Calculating fx^2 from fx * x
            for (int i = 0; i < NumRows; i++)
            {
                Table[NumRows, 3] = Table[NumRows, 0] * Table[NumRows, 2];
            }
        }

        private void GetTotals(double[] table)
        {
            double total = 0;

            // 𝛴F
            for (int i = 0; i < NumRows; i++)
            {
                total += Table[NumRows, 1];
            }
            _sigmaF = total;
            total = 0;

            // 𝛴FX
            for (int i = 0; i < NumRows; i++)
            {
                total += Table[NumRows, 2];
            }
            _sigmaFX = total;
            total = 0;

            // 𝛴FX^2
            for (int i = 0; i < NumRows; i++)
            {
                total += Table[NumRows, 3];
            }
            _sigmaFXSquared = total;
            total = 0;
        }

        private void GetMeanX()
        {
            _mean = _sigmaFX / _sigmaF;
        }

        private void CalculateStandardDeviation()
        {
            Variance = (_sigmaFXSquared / _sigmaF) - (Mean * Mean);
            StandardDeviation = Math.Sqrt(Variance);
        }

        public void DisplayData()
        {

        }
    }
}
