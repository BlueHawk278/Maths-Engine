using System;

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
                    HandleFindHypotenuse();
                    break;
                case "2":
                    HandleFindOtherSide();
                    break;
                case "3":
                    HandleCheckTheorem();
                    break;
            }
            // Return to the main menu after a calculation is done.
            Menu.mainMenu();
        }

        /// <summary>
        /// Methods that retrieve the side lengths and inputs them into the Pythagoras Theorem
        /// </summary>

        public static void HandleFindHypotenuse()
        {
            Console.Clear();
            Console.WriteLine("Enter the first side");
            double sideA = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the second side");
            double sideB = Convert.ToDouble(Console.ReadLine());

            double hypotenuse = Modules.Core.PureHelpers.PythagorasTheorem.calculateHypotenuse(sideA, sideB);

            Console.WriteLine("\nHypotenuse: " + hypotenuse);
            Console.WriteLine("\nPress Enter to return to the menu.");
            Console.ReadLine();
        }
        public static void HandleFindOtherSide()
        {
            Console.Clear();
            Console.WriteLine("Enter the hypotenuse");
            double hypotenuse = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the known side");
            double knownSide = Convert.ToDouble(Console.ReadLine());

            double unknownSide = Modules.Core.PureHelpers.PythagorasTheorem.calculateOtherSide(hypotenuse, knownSide);

            Console.WriteLine("\nUnknown side: " + unknownSide);
            Console.WriteLine("\nPress Enter to return to the menu.");
            Console.ReadLine();
        }
        public static void HandleCheckTheorem()
        {
            Console.Clear();
            Console.WriteLine("Enter the hypotenuse");
            double hypotenuse = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the first side");
            double firstSide = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the second side");
            double secondSide = Convert.ToDouble(Console.ReadLine());

            bool validResult = Modules.Core.PureHelpers.PythagorasTheorem.checkValidCalculation(hypotenuse, firstSide, secondSide);

            Console.WriteLine((validResult) ? "\nThis is a valid equation" : "\nThis is not a valid equation");
            Console.WriteLine("\nPress Enter to return to the menu.");
            Console.ReadLine();
        }
    }
}
