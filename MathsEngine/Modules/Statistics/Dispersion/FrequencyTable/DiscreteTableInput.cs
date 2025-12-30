using MathsEngine.Utils;

namespace MathsEngine.Modules.Statistics.Dispersion.FrequencyTable
{
    internal class DiscreteTableInput
    {
        public static void Start()
        {
            double[,] table = getTable();

            var calculator = new DiscreteTableCalculator(table);
            calculator.Run();

            calculator.DisplayData();

            Console.ReadLine();
        }

        private static double[,] getTable()
        {
            int numRows = Parsing.GetIntInput("How many rows are there?");

            double[,] table = new double[numRows, 4];


            // Getting the x value and frequency for table
            int rowNum = 1;
            for (int i = 0; i < numRows; i++)
            {
                int num = Parsing.GetIntInput($"Enter X value No.{rowNum}:  ");
                int frequency = Parsing.GetIntInput("Enter the frequency for this value: ");

                rowNum++;
                table[i, 0] = num;
                table[i, 1] = frequency;
            }

            return table;
        }
    }
}
