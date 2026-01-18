        using MathsEngine.Utils;

namespace MathsEngine.Modules.Statistics.BivariateAnalysis
{
    public static class BivariateAnalysis
    {
        public static void Start()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Bivariate Analysis - Spearman's Rank");
                var scores1 = GetScores("Enter the first set of scores, separated by commas:");
                var scores2 = GetScores("Enter the second set of scores, separated by commas:");

                var calculator = new BivariateAnalysisCalculator(scores1, scores2);
                calculator.Run();

                DisplayResults(calculator);
            }
            catch (FormatException)
            {
                ErrorDisplay.ShowError("Error: Invalid input. Please ensure you enter only numbers separated by commas.");
            }
            catch (NullInputException)
            {
                ErrorDisplay.ShowError("Error: One or both of the score sets were empty. Please provide data.");
            }
            catch (ListsNotSameSizeException)
            {
                ErrorDisplay.ShowError("Error: The two sets of scores must contain the same number of values.");
            }
            catch (InsufficientDataException)
            {
                ErrorDisplay.ShowError("Error: At least two pairs of scores are required to perform the analysis.");
            }
        }

        private static List<int> GetScores(string prompt)
        {
            Console.WriteLine(prompt);
            string? input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
                throw new NullInputException();

            return input.Split(',')
                        .Select(s => int.Parse(s.Trim()))
                        .ToList();
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