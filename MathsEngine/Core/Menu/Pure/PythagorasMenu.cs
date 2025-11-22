using System;

namespace MathsEngine.Core.Menu.Pure
{
    internal static class PythagorasMenu
    {
        public static void menu()
        {
            Console.WriteLine("Pythagoras Theorem Calculator");
            Console.WriteLine("1. Find the hypotenuse");
            Console.WriteLine("2. Find another side");
            Console.WriteLine("3. Check if calculation is valid");
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
        }

        /// <summary>
        /// Methods that retrieve the side lengths and inputs them into the Pythagoras Theorem
        /// </summary>

        public static void HandleFindHypotenuse()
        {
            Console.WriteLine("Enter the first side");
            double sideA = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the second side");
            double sideB = Convert.ToDouble(Console.ReadLine());

            double hypotenuse = Modules.Core.PureHelpers.PythagorasTheorem.calculateHypotenuse(sideA, sideB);

            Console.WriteLine("Hypotenuse: " + hypotenuse);

            menu();
        }
        public static void HandleFindOtherSide()
        {
            Console.WriteLine("Enter the hypotenuse");
            double hypotenuse = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the known side");
            double knownSide = Convert.ToDouble(Console.ReadLine());

            double unknownSide = Modules.Core.PureHelpers.PythagorasTheorem.calculateOtherSide(hypotenuse, knownSide);

            Console.WriteLine("Unknown side: " + unknownSide);

            menu();
        }
        public static void HandleCheckTheorem()
        {
            Console.WriteLine("Enter the hypotenuse");
            double hypotenuse = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the first side");
            double firstSide = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the second side");
            double secondSide = Convert.ToDouble(Console.ReadLine());

            bool validResult = Modules.Core.PureHelpers.PythagorasTheorem.checkValidCalculation(hypotenuse, firstSide, secondSide);

            Console.WriteLine((validResult) ? "This is a valid equation" : "This is not a valid equation");

            menu();
        }
    }
}
