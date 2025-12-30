using System;
using MathsEngine.Modules.Pure.PythagorasTheorem;
using MathsEngine.Utils;

namespace MathsEngine.Core.Menu.Pure
{
    internal static class PythagorasMenu
    {
        public static void menu()
        {
            Console.Clear();
            Console.WriteLine("Pythagoras Theorem Calculator");
            Console.WriteLine("1. Find the hypotenuse");
            Console.WriteLine("2. Find another side");
            Console.WriteLine("3. Check if calculation is valid");
            Console.WriteLine("4. Main Menu");
            int response = Parsing.GetMenuInput("Input: ", 4);

            switch (response)
            {
                case 1:
                    HandleFindHypotenuse();
                    break;
                case 2:
                    HandleFindOtherSide();
                    break;
                case 3:
                    HandleCheckTheorem();
                    break;
                case 4:
                    Menu.MainMenu();
                    break;
            }
            // Return to the main menu after a calculation is done.
            Menu.MainMenu();
        }

        /// <summary>
        /// Methods that retrieve the side lengths and inputs them into the Pythagoras Theorem
        /// </summary>

        private static void HandleFindHypotenuse()
        {
            try
            {
                Console.Clear();
                double? sideA = Parsing.GetDoubleInput("Enter side A (leave blank to calculate): ");
                double? sideB = Parsing.GetDoubleInput("Enter side B (leave blank to calculate): ");

                double hypotenuse = PythagorasTheorem.CalculateHypotenuse(sideA, sideB);

                Console.WriteLine("\nHypotenuse: " + hypotenuse);
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError: Invalid input. Please enter valid numbers for the side lengths.");
                Console.ResetColor();
            }
            catch (NegativeSideLengthException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nError: {ex.Message}");
                Console.ResetColor();
            }
            finally
            {
                Console.WriteLine("\nPress Enter to return to the menu.");
                Console.ReadLine();
            }
        }

        private static void HandleFindOtherSide()
        {
            try
            {
                Console.Clear();
                double? hypotenuse = Parsing.GetDoubleInput("Enter the hypotenuse");
                double? knownSide = Parsing.GetDoubleInput("Enter the known side");

                double unknownSide =
                    PythagorasTheorem.CalculateOtherSide(hypotenuse, knownSide);

                Console.WriteLine("\nUnknown side: " + unknownSide);
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError: Invalid input.Please enter valid numbers for the side lengths.");
                Console.ResetColor();
            }
            catch (Exception ex) when (ex is NegativeSideLengthException || ex is HypotenuseNotLongestSideException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nError: {ex.Message}");
                Console.ResetColor();
            }
            finally
            {
                Console.WriteLine("\nPress Enter to go back to the main menu.");
                Console.ReadLine();
            }
        }
        private static void HandleCheckTheorem()
        {
            try
            {
                Console.Clear();
                double? hypotenuse = Parsing.GetDoubleInput("Enter the hypotenuse");
                double? firstSide = Parsing.GetDoubleInput("Enter the first side.");
                double? secondSide = Parsing.GetDoubleInput("Enter the second side.");

                bool validResult =
                    PythagorasTheorem.CheckValidCalculation(hypotenuse, firstSide, secondSide);

                Console.WriteLine((validResult) ? "\nThis is a valid equation" : "\nThis is not a valid equation");
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError: Invalid input. Please enter valid numbers for the side lengths.");
                Console.ResetColor();
            }
            finally
            {
                Console.WriteLine("\nPress Enter to return to the menu.");
                Console.ReadLine();
            }
        }
    }
}
