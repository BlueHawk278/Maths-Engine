using System;
using MathsEngine.Modules.Core.PureHelpers;
using MathsEngine.Modules.Pure.Trigonometry;

namespace MathsEngine.Core.Menu.Pure
{
    public class TrigonometryMenu
    {
        public static void menu()
        {
            Console.Clear();

            Console.WriteLine("1. Calculate a missing side");
            Console.WriteLine("2. Calculate a missing angle");
            string response = Console.ReadLine();

            switch (response)
            {
                case "1":
                    handleMissingSide();
                    break;
                case "2":
                    handleMissingAngle();
                    break;
                default:
                    menu();
                    break;
            }
        }

        private static void handleMissingSide()
        {
            Console.WriteLine("Enter the angle you know in degrees:");
            double angle = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Which side do you know? (1. Opposite, 2. Adjacent, 3. Hypotenuse)");
            string sideKnownChoice = Console.ReadLine();

            Console.Write("Enter the length of the known side: ");
            double knownSideLength = Convert.ToDouble(Console.ReadLine());

            SideType knownSideType;
            SideType sideToFindType;
            string sideToFindChoice;
            double result = 0;

            switch (sideKnownChoice)
            {
                case "1":
                    knownSideType = SideType.Opposite;
                    Console.WriteLine("Which side do you want to find? (1. Adjacent, 2. Hypotenuse)");
                    sideToFindChoice = Console.ReadLine();
                    sideToFindType = sideToFindChoice == "1" ? SideType.Adjacent : SideType.Hypotenuse;
                    break;
                case "2":
                    knownSideType = SideType.Adjacent;
                    Console.WriteLine("Which side do you want to find? (1. Opposite, 2. Hypotenuse)");
                    sideToFindChoice = Console.ReadLine();
                    sideToFindType = sideToFindChoice == "1" ? SideType.Opposite : SideType.Hypotenuse;
                    break;
                case "3":
                    knownSideType = SideType.Hypotenuse;
                    Console.WriteLine("Which side do you want to find? (1. Opposite, 2. Adjacent)");
                    sideToFindChoice = Console.ReadLine();
                    sideToFindType = sideToFindChoice == "1" ? SideType.Opposite : SideType.Adjacent;
                    break;
                default:
                    menu();
                    return;
            }

            result = Trigonometry.calculateMissingSide(knownSideLength, angle, knownSideType, sideToFindType);
            displayCalculation(result, $"{sideToFindType}");
        }

        private static void handleMissingAngle()
        {
            Console.WriteLine("Enter the first side you know (1. Opposite, 2. Adjacent, 3. Hypotenuse):");
            string side1Choice = Console.ReadLine();
            Console.Write("Enter the length of this side: ");
            double side1Length = Convert.ToDouble(Console.ReadLine());
            SideType side1Type = (SideType)Convert.ToInt32(side1Choice) - 1;


            Console.WriteLine("Enter the second side you know (1. Opposite, 2. Adjacent, 3. Hypotenuse):");
            string side2Choice = Console.ReadLine();
            Console.Write("Enter the length of this side: ");
            double side2Length = Convert.ToDouble(Console.ReadLine());
            SideType side2Type = (SideType)Convert.ToInt32(side2Choice) - 1;

            double result = Trigonometry.calculateMissingAngle(side1Length, side1Type, side2Length, side2Type);
            displayCalculation(result, "Angle");
        }

        private static void displayCalculation(double result, string calculatedItem) //
        {
            Console.WriteLine($"\n--- Calculation Result ---");
            Console.WriteLine($"{calculatedItem}: {result:F2}");
            Console.WriteLine("\nPress Enter to return to the menu.");
            Console.ReadLine();
            menu();
        }

        private static string formatValue(string value)
        {
            if (value == null)
                return "Not Calculated";

            // Convert to double to format it to 2 decimal places.
            return Convert.ToDouble(value).ToString("F2");
        }
    }
}