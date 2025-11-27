using MathsEngine.Modules.Statistics.Dispersion.FrequencyTable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsEngine.Modules.Statistics.Dispersion.ContinuousTable
{
    internal class ContinuousTableInput
    {
        public static void Start()
        {
            double[,] table = getTable();

            var Calculator = new ContinuousTableCalculator(table);
            Calculator.Run();

            Calculator.DisplayData();

            Console.ReadLine();
        }

        private static double[,] getTable()
        {
            Console.WriteLine("How many rows are there");
            int NumRows = Convert.ToInt16(Console.ReadLine());

            double[,] Table = new double[NumRows, 6];


            // Getting the lower and upper x value and frequency for table
            int rowNum = 1;
            for (int i = 0; i < NumRows; i++)
            {
                Console.Write($"Enter the lower limit for X value No.{rowNum}: ");
                int lowerNum = Convert.ToInt16(Console.ReadLine());
                Console.Write($"Enter the lower limit for X value No.{rowNum}: ");
                int upperNum = Convert.ToInt16(Console.ReadLine());
                Console.Write($"Enter the frequency for value No.{rowNum}: ");
                int frequency = Convert.ToInt16(Console.ReadLine());

                rowNum++;
                Table[i, 0] = lowerNum;
                Table[i, 1] = upperNum;
                Table[i, 2] = frequency;
                Table[i, 3] = (upperNum + lowerNum) / 2;
            }

            return Table;
        }
    }
}
