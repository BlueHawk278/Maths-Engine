using MathsEngine.Modules.Statistics.Dispersion;
using MathsEngine.Utils;

namespace MathsEngine.Console.Menu.Statistics
{
    public class DispersionMenu
    {
        public static void Menu()
        {
            while (true)
            {
                System.Console.Clear();
                System.Console.WriteLine("Welcome to the Dispersion Menu");
                System.Console.WriteLine("1. Calculate from an array of numbers");
                System.Console.WriteLine("2. Calculate from a frequency table");
                System.Console.WriteLine("3. Calculate from a continuous table");
                System.Console.WriteLine("4. Back");
                int response = Parsing.GetMenuInput("Input: ", 4);

                switch (response)
                {
                    case 1:
                        HandleArrayOfNumbers();
                        break;
                    case 2:
                        HandleFrequencyTable();
                        break;
                    case 3:
                        HandleContinuousTable();
                        break;
                    case 4: return;
                }
            }
        }

        private static void HandleArrayOfNumbers()
        {
            try
            {
                System.Console.Clear();
                var values = GetDoubleList("Enter the values separated by a comma: ");
                var calculator = new ArrayOfNumbersCalculator(values);
                calculator.Run();

                System.Console.WriteLine("\n--- Results ---");
                System.Console.WriteLine($"Original values: {string.Join(", ", calculator.OriginalValues)}");
                System.Console.WriteLine($"Sorted values: {string.Join(", ", calculator.SortedValues)}");
                System.Console.WriteLine($"Mean: {calculator.Mean:F3}");
                System.Console.WriteLine($"Median: {calculator.Median}");
                System.Console.WriteLine($"Mode: {string.Join(", ", calculator.Mode)}");
                System.Console.WriteLine($"Range: {calculator.Range}");
                System.Console.WriteLine($"Q1: {calculator.Q1}");
                System.Console.WriteLine($"Q3: {calculator.Q3}");
                System.Console.WriteLine($"IQR: {calculator.Iqr}");
                System.Console.WriteLine($"Standard Deviation: {calculator.StandardDeviation:F2}");
                System.Console.WriteLine($"Variance: {calculator.Variance:F2}");

                System.Console.WriteLine("\nCalculation complete. Press any key to return to the menu...");
                System.Console.ReadKey();
            }
            catch (FormatException)
            {
                ErrorDisplay.ShowError(
                    "Error: Invalid input.Please ensure you enter only numbers separated by commas.");
            }
            catch (NullInputException)
            {
                ErrorDisplay.ShowError("Error: No data was entered. Please ensure you enter a set of numbers.");
            }
            catch (EmptyDataSetException)
            {
                ErrorDisplay.ShowError("Error: The data set cannot be empty.Please provide a set of numbers.");
            }
        }

        private static void HandleFrequencyTable()
        {
            try
            {
                System.Console.Clear();
                var values = GetDoubleList("Enter the values (x) separated by a comma: ");
                var frequencies = GetIntList("Enter the frequencies (f) for each value, separated by a comma: ");
                var calculator = new FrequencyTableCalculator(values, frequencies);
                calculator.Run();

                System.Console.WriteLine("\n--- Results ---");
                System.Console.WriteLine($"Mean: {calculator.Mean:F3}");
                System.Console.WriteLine($"Standard Deviation: {calculator.StandardDeviation:F2}");
                System.Console.WriteLine($"Variance: {calculator.Variance:F2}");

                System.Console.WriteLine("\nCalculation complete. Press any key to return to the menu...");
                System.Console.ReadKey();
            }
            catch (FormatException)
            {
                ErrorDisplay.ShowError(
                    "\nError: Invalid input. Please ensure you enter only numbers separated by commas.");
            }
            catch (NullInputException)
            {
                ErrorDisplay.ShowError("Error: Both values and frequencies must be provided.");
            }
            catch (EmptyDataSetException)
            {
                ErrorDisplay.ShowError("Error: The data sets cannot be empty.");
            }
            catch (ListsNotSameSizeException)
            {
                ErrorDisplay.ShowError("Error: The number of values must match the number of frequencies.");
            }
            catch (InvalidFrequencyException)
            {
                ErrorDisplay.ShowError("Error: Frequencies cannot be negative.");
            }
        }

        private static void HandleContinuousTable()
        {
            try
            {
                System.Console.Clear();
                var intervals = GetStringList("Enter the class intervals (e.g., 10-20) separated by a comma: ");
                var frequencies = GetIntList("Enter the frequencies (f) for each interval, separated by a comma: ");
                var calculator = new ContinuousTableCalculator(intervals, frequencies);
                calculator.Run();

                System.Console.WriteLine("\n--- Results ---");
                System.Console.WriteLine($"Mean: {calculator.Mean:F3}");
                System.Console.WriteLine($"Standard Deviation: {calculator.StandardDeviation:F2}");
                System.Console.WriteLine($"Variance: {calculator.Variance:F2}");

                System.Console.WriteLine("\nCalculation complete. Press any key to return to the menu...");
                System.Console.ReadKey();
            }
            catch (FormatException)
            {
                ErrorDisplay.ShowError(
                    "Error: Invalid number format in frequencies. Please ensure you enter only numbers separated by commas.");
            }
            catch (NullInputException)
            {
                ErrorDisplay.ShowError("Error: Both class intervals and frequencies must be provided.");
            }
            catch (EmptyDataSetException)
            {
                ErrorDisplay.ShowError("Error: The data sets cannot be empty.");
            }
            catch (ListsNotSameSizeException)
            {
                ErrorDisplay.ShowError("Error: The number of class intervals must match the number of frequencies.");
            }
            catch (InvalidFrequencyException)
            {
                ErrorDisplay.ShowError("Error: Frequencies cannot be negative.");
            }
            catch (InvalidClassIntervalFormatException)
            {
                ErrorDisplay.ShowError(
                    "Error: Invalid class interval format. Please use the format 'lower-upper' (e.g., '10-20').");
            }
        }

        private static List<double> GetDoubleList(string prompt)
        {
            System.Console.WriteLine(prompt);
            string? input = System.Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) return new List<double>();
            return input.Split(',').Select(s => double.Parse(s.Trim())).ToList();
        }

        private static List<int> GetIntList(string prompt)
        {
            System.Console.WriteLine(prompt);
            string? input = System.Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) return new List<int>();
            return input.Split(',').Select(s => int.Parse(s.Trim())).ToList();
        }

        private static List<string> GetStringList(string prompt)
        {
            System.Console.WriteLine(prompt);
            string? input = System.Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) return new List<string>();
            return input.Split(',').Select(s => s.Trim()).ToList();
        }
    }
}