using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsEngine.Modules.Statistics.Dispersion.FrequencyTable
{
    internal class Discrete
    {
        public static void Start()
        {
            double[,] table = getTable();

            var Calculator = new DiscreteTable(table);
            Calculator.Run();

            Calculator.DisplayData();

            Console.ReadLine();
        }

        private static double[,] getTable()
        {
            Console.WriteLine("How many rows are there");
            int NumRows = Convert.ToInt16(Console.ReadLine());

            double[,] Table = new double[NumRows, 4];


            // Getting the x value and frequency for table
            int rowNum = 1;
            for (int i = 0; i < NumRows; i++)
            {
                Console.Write($"Enter X value No.{rowNum}:  ");
                int num = Convert.ToInt16(Console.ReadLine());
                Console.Write($"Enter the frequency for this value: ");
                int frequency = Convert.ToInt16(Console.ReadLine());

                rowNum++;
                Table[i, 0] = num;
                Table[i, 1] = frequency;
            }

            return Table;
        }
    }
}
