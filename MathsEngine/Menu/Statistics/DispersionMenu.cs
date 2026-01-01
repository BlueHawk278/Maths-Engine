using MathsEngine.Modules.Statistics.Dispersion.ArrayOfNumbers;
using MathsEngine.Modules.Statistics.Dispersion.ContinuousTable;
using MathsEngine.Modules.Statistics.Dispersion.FrequencyTable;
using MathsEngine.Utils;

// TODO: Support for continuous ranges e.g. 4-6 7-9
//       Working backwards from the mean to find a missing frequency
//       Combining sets of data to find new means and standard deviations

namespace MathsEngine.Menu.Statistics
{
    public class DispersionMenu
    {
        public static void menu()
        {
            Console.WriteLine("Welcome to the Dispersion / Standard Deviation Menu");
            Console.WriteLine("1. Calculate standard deviation from a set of numbers");
            Console.WriteLine("2. Calculate standard deviation from a frequency table with discontinuous values");
            Console.WriteLine("3. Calculate standard deviation from a frequency table with continuous values");
            Console.WriteLine("4. Back");
            int response = Parsing.GetMenuInput("Input: ", 4);
            Console.Clear();

            switch (response)
            {
                case 1:
                    ArrayOfNumbersInput.Start();
                    Menu.MainMenu();
                    break;
                case 2:
                    DiscreteTableInput.Start();
                    Menu.MainMenu();
                    break;
                case 3:
                    ContinuousTableInput.Start();
                    Menu.MainMenu();
                    break;
                case 4:
                    Menu.StatisticsMenu();
                    break;
            }

            Console.WriteLine("\nPress Enter to return...");
            Console.ReadLine();

            Menu.MainMenu();
        }
    }
}