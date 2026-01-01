using MathsEngine.Modules.Statistics.Dispersion;
using MathsEngine.Utils;

namespace MathsEngine.Menu.Statistics
{
    public class DispersionMenu
    {
        public static void menu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Dispersion Menu");
            Console.WriteLine("1. Calculate from an array of numbers");
            Console.WriteLine("2. Calculate from a frequency table");
            Console.WriteLine("3. Calculate from a continuous table");
            Console.WriteLine("4. Back");
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
                case 4:
                    Menu.StatisticsMenu();
                    break;
            }
        }

        private static void HandleArrayOfNumbers()
        {
            try
            {
                Console.Clear();
                var values = GetDoubleList("Enter the values separated by a comma: ");
                var calculator = new ArrayOfNumbersCalculator(values);
                calculator.Run();
                calculator.DisplayData();
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
                Console.WriteLine("\nError: No data was entered. Please provide a set of numbers.");
                Console.ResetColor();
            }
            catch (EmptyDataSetException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError: The data set cannot be empty. Please provide a set of numbers.");
                Console.ResetColor();
            }
        }

        private static void HandleFrequencyTable()
        {
            try
            {
                Console.Clear();
                var values = GetDoubleList("Enter the values (x) separated by a comma: ");
                var frequencies = GetIntList("Enter the frequencies (f) for each value, separated by a comma: ");
                var calculator = new FrequencyTableCalculator(values, frequencies);
                calculator.Run();
                calculator.DisplayData();
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
                Console.WriteLine("\nError: Both values and frequencies must be provided.");
                Console.ResetColor();
            }
            catch (EmptyDataSetException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError: The data sets cannot be empty.");
                Console.ResetColor();
            }
            catch (ListsNotSameSizeException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError: The number of values must match the number of frequencies.");
                Console.ResetColor();
            }
            catch (InvalidFrequencyException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError: Frequencies cannot be negative.");
                Console.ResetColor();
            }
        }

        private static void HandleContinuousTable()
        {
            try
            {
                Console.Clear();
                var intervals = GetStringList("Enter the class intervals (e.g., 10-20) separated by a comma: ");
                var frequencies = GetIntList("Enter the frequencies (f) for each interval, separated by a comma: ");
                var calculator = new ContinuousTableCalculator(intervals, frequencies);
                calculator.Run();
                calculator.DisplayData();
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError: Invalid number format in frequencies. Please ensure you enter only numbers separated by commas.");
                Console.ResetColor();
            }
            catch (NullInputException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError: Both class intervals and frequencies must be provided.");
                Console.ResetColor();
            }
            catch (EmptyDataSetException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError: The data sets cannot be empty.");
                Console.ResetColor();
            }
            catch (ListsNotSameSizeException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError: The number of class intervals must match the number of frequencies.");
                Console.ResetColor();
            }
            catch (InvalidFrequencyException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError: Frequencies cannot be negative.");
                Console.ResetColor();
            }
            catch (InvalidClassIntervalFormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError: Invalid class interval format. Please use the format 'lower-upper' (e.g., '10-20').");
                Console.ResetColor();
            }
        }

        private static List<double> GetDoubleList(string prompt)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) return null;
            return input.Split(',').Select(s => double.Parse(s.Trim())).ToList();
        }

        private static List<int> GetIntList(string prompt)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) return null;
            return input.Split(',').Select(s => int.Parse(s.Trim())).ToList();
        }

        private static List<string> GetStringList(string prompt)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input)) return null;
            return input.Split(',').Select(s => s.Trim()).ToList();
        }
    }
}