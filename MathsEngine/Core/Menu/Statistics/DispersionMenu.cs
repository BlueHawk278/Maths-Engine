using System;
using MathsEngine.Modules.Statistics.Dispersion.ArrayOfNumbers;
using MathsEngine.Modules.Statistics.Dispersion.FrequencyTable;

// TODO: Support for continuous ranges e.g. 5 < x < 10

namespace MathsEngine.Core.Menu.Statistics
{
    public class DispersionMenu
    {
        public static void menu()
        {
            Console.WriteLine("Welcome to the Dispersion / Standard Deviation Menu");
            Console.WriteLine("1. Calculate standard deviation from a set of numbers");
            Console.WriteLine("2. Calculate standard deviation from a frequency table with discontinuous values");
            Console.WriteLine("3. Calculate standard deviation from a frequency table with continuous values");
            string response = Console.ReadLine();

            switch (response)
            {
                case "1":
                    StandardDeviationArray.Start();
                    break;
                case "2":
                    Discrete.Start();
                    break;
                case "3":
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    menu();
                    break;
            }
        }
    }
}