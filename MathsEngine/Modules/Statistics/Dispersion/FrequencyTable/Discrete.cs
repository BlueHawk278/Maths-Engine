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
            Console.WriteLine("How many columns are there");
            int NumRows = Convert.ToInt16(Console.ReadLine());

            double[,] Table = new double[NumRows, 4];


            // Getting the x value and frequency for table
            for (int i = 0; i < NumRows; i++)
            {
                Console.Write($"Enter X value No.{NumRows++}:  ");
                int num = Convert.ToInt16(Console.ReadLine());
                Console.Write($"Enter the frequency for this value: ");
                int frequency = Convert.ToInt16(Console.ReadLine());

                Table[NumRows, 0] = num;
                Table[NumRows, 1] = frequency; // out of range error
            }

            return Table;
        }
    }
}
