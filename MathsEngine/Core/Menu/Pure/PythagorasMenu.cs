using System;
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
            Console.Write("Input: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    handleFindHypotenuse();
                    break;
                case "2":
                    handleFindOtherSide();
                    break;
                case "3":
                    handleCheckTheorem();
                    break;
            }
            // Return to the main menu after a calculation is done.
            Menu.mainMenu();
        }

        /// <summary>
        /// Methods that retrieve the side lengths and inputs them into the Pythagoras Theorem
        /// </summary>

        private static void handleFindHypotenuse()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Enter the first side");
                double sideA = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter the second side");
                double sideB = Convert.ToDouble(Console.ReadLine());

                double hypotenuse = Modules.Core.PureHelpers.PythagorasTheorem.calculateHypotenuse(sideA, sideB);

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

        private static void handleFindOtherSide()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Enter the hypotenuse");
                double hypotenuse = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter the known side");
                double knownSide = Convert.ToDouble(Console.ReadLine());

                double unknownSide =
                    Modules.Core.PureHelpers.PythagorasTheorem.calculateOtherSide(hypotenuse, knownSide);

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
        private static void handleCheckTheorem()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Enter the hypotenuse");
                double hypotenuse = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter the first side");
                double firstSide = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter the second side");
                double secondSide = Convert.ToDouble(Console.ReadLine());

                bool validResult =
                    Modules.Core.PureHelpers.PythagorasTheorem.checkValidCalculation(hypotenuse, firstSide, secondSide);

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
