using MathsEngine.Utils;

namespace MathsEngine.Modules.Statistics.BivariateAnalysis
{
    /// <summary>
    /// Handles the user interface for the Bivariate Analysis feature.
    /// </summary>
    internal static class BivariateAnalysis
    {
        public static void Start()
        {
            Console.Clear();
            // --- 1. Handle all user input here ---
            int numDataPoints = GetNumberOfDataPoints();
            var scores1 = GetScoresFromUser(numDataPoints, "Score Set 1");
            var scores2 = GetScoresFromUser(numDataPoints, "Score Set 2");

            // --- 2. Create an INSTANCE of the calculator and run it ---
            var calculator = new BivariateAnalysisCalculator(scores1, scores2);
            calculator.Run();

            // --- 3. Display the results from the calculator object ---
            DisplayResults(calculator);

            Console.WriteLine("\nPress Enter to return to the menu.");
            Console.ReadLine();
        }

        private static int GetNumberOfDataPoints()
        {
            return Parsing.GetIntInput("How many data points would you like to enter?");
        }

        private static List<int> GetScoresFromUser(int count, string scoreName)
        {
            var scores = new List<int>();
            Console.WriteLine($"\n--- Entering scores for {scoreName} ---");
            for (int i = 0; i < count; i++)
            {
                scores.Add(Parsing.GetIntInput($"Enter point {i + 1}: "));
            }
            return scores;
        }

        private static void DisplayResults(BivariateAnalysisCalculator calc)
        {
            Console.WriteLine("\n--- Results ---");
            Console.WriteLine($"Rank 1: {string.Join(", ", calc.Ranks1)}");
            Console.WriteLine($"Rank 2: {string.Join(", ", calc.Ranks2)}");
            Console.WriteLine($"Difference: {string.Join(", ", calc.Difference)}");
            Console.WriteLine($"Difference Squared: {string.Join(", ", calc.DifferenceSquared)}");
            Console.WriteLine($"Sum of Difference Squared: {calc.SumDifferenceSquared:F2}");
            Console.WriteLine($"\nSpearman's Rank Correlation Coefficient is: {calc.CorrelationCoefficient:F3}");
            Console.WriteLine($"Correlation: {calc.CorrelationString}");
        }
    }
}