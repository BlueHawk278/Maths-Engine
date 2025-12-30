using MathsEngine.Utils;

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
            int numRows = Parsing.GetIntInput("How many rows are there");

            double[,] Table = new double[numRows, 6];


            // Getting the lower and upper x value and frequency for table
            int rowNum = 1;
            for (int i = 0; i < numRows; i++)
            {
                int lowerNum = Parsing.GetIntInput($"Enter the lower limit for X value No.{rowNum}: ");
                int upperNum = Parsing.GetIntInput($"Enter the upper limit for X value No.{rowNum}: ");
                int frequency = Parsing.GetIntInput($"Enter the frequency for value No.{rowNum}: ");

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
