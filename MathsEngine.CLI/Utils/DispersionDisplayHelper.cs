using MathsEngine.Modules.Statistics.Dispersion;

namespace MathsEngine.Utils
{
    public static class DispersionDisplayHelper
    {
        public static void DisplayArrayOfNumbersData(ArrayOfNumbersCalculator calculator)
        {
            var stats = calculator.GetStatistics();
            
            Console.Write("\nOriginal values: ");
            foreach (double value in stats.OriginalValues)
                Console.Write(value + ", ");

            Console.Write("\nSorted values: ");
            foreach (double value in stats.SortedValues)
                Console.Write(value + ", ");

            Console.WriteLine("\nMean: " + Math.Round(calculator.Mean, 3));
            Console.WriteLine("Median: " + stats.Median);

            Console.Write("Mode: ");
            foreach (double mode in stats.ModeList)
                Console.Write(mode + " ");

            Console.WriteLine("Range: " + stats.Range);

            Console.WriteLine("Q1: " + stats.Q1);
            Console.WriteLine("Q3: " + stats.Q3);
            Console.WriteLine("IQR: " + stats.IQR);

            Console.WriteLine($"\nStandard Deviation: {Math.Round(calculator.StandardDeviation, 2)}\n");
        }

        public static void DisplayFrequencyTableData(FrequencyTableCalculator calculator)
        {
            Console.WriteLine($"\nMean: {calculator.Mean:F2}");
            Console.WriteLine($"Variance: {calculator.Variance:F2}");
            Console.WriteLine($"Standard Deviation: {calculator.StandardDeviation:F2}");
        }

        public static void DisplayContinuousTableData(ContinuousTableCalculator calculator)
        {
            Console.WriteLine($"\nMean: {calculator.Mean:F2}");
            Console.WriteLine($"Variance: {calculator.Variance:F2}");
            Console.WriteLine($"Standard Deviation: {calculator.StandardDeviation:F2}");
        }

        public static void DisplayCombinedSetsData(MathsEngine.Modules.Statistics.Dispersion.CombinedSets.CombinedSetsCalculator calculator)
        {
            Console.WriteLine($"\nCombined Mean: {calculator.Mean:F2}");
            Console.WriteLine($"Combined Variance: {calculator.Variance:F2}");
            Console.WriteLine($"Combined Standard Deviation: {calculator.StandardDeviation:F2}");
        }
    }
}
