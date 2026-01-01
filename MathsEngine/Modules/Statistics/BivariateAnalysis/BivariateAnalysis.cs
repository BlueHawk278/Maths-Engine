        using MathsEngine.Utils;

namespace MathsEngine.Modules.Statistics.BivariateAnalysis
{
    public class BivariateAnalysis
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
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError: Invalid input. Please ensure you enter only numbers separated by commas.");
                Console.ResetColor();
            }
            catch (NullInputException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError: One or both of the score sets were empty. Please provide data.");
                Console.ResetColor();
            }
            catch (ListsNotSameSizeException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError: The two sets of scores must contain the same number of values.");
                Console.ResetColor();
            }
            catch (InsufficientDataException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError: At least two pairs of scores are required to perform the analysis.");
                Console.ResetColor();
            }
        }

        private static List<int> GetScores(string prompt)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine();

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