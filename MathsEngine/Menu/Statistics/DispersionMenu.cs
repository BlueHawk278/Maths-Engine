using MathsEngine.Modules.Statistics.Dispersion;
using MathsEngine.Utils;

namespace MathsEngine.Menu.Statistics
{
    public class DispersionMenu
    {
        public static void Menu()
        {
            while (true)
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
                    case 4: return;
                }
            }
        }

        private static void HandleArrayOfNumbers()
        {
            try
            {
                Console.Clear();
                var values = Parsing.GetDoubleList("Enter the values separated by a comma: ");
                var calculator = new ArrayOfNumbersCalculator(values);
                calculator.Run();
                calculator.DisplayData();

                Console.WriteLine("\nCalculation complete. Press any key to return to the menu...");
                Console.ReadKey();
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
                Console.Clear();
                var values = Parsing.GetDoubleList("Enter the values (x) separated by a comma: ");
                var frequencies = Parsing.GetIntList("Enter the frequencies (f) for each value, separated by a comma: ");
                var calculator = new FrequencyTableCalculator(values, frequencies);
                calculator.Run();
                calculator.DisplayData();

                Console.WriteLine("\nCalculation complete. Press any key to return to the menu...");
                Console.ReadKey();
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
                Console.Clear();
                var intervals = Parsing.GetStringList("Enter the class intervals (e.g., 10-20) separated by a comma: ");
                var frequencies = Parsing.GetIntList("Enter the frequencies (f) for each interval, separated by a comma: ");
                var calculator = new ContinuousTableCalculator(intervals, frequencies);
                calculator.Run();
                calculator.DisplayData();

                Console.WriteLine("\nCalculation complete. Press any key to return to the menu...");
                Console.ReadKey();
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
    }
}