using System;
using MathsEngine.Modules.Pure.Trigonometry;
using MathsEngine.Utils;

namespace MathsEngine.Core.Menu.Pure
{
    public class TrigonometryMenu
    {
        public static void menu()
        {
            Console.Clear();

            Console.WriteLine("1. Calculate a missing side");
            Console.WriteLine("2. Calculate a missing angle");
            Console.WriteLine("3. Back");
            int response = Parsing.GetMenuInput("Input: ", 3);

            switch (response)
            {
                case 1:
                    HandleMissingSide();
                    break;
                case 2:
                    HandleMissingAngle();
                    break;
                case 3:
                    Menu.PureMenu();
                    break;
            }

            Console.WriteLine("\nPress Enter to return...");
            Console.ReadLine();

            Menu.MainMenu();
        }

        private static void HandleMissingSide()
        {
            Console.Clear();
            Console.WriteLine("Calculating a missing Side");

            double? angle = Parsing.GetNullableDoubleInput("Enter the angle you know in degrees: ");

            SideType sideKnown =
                Parsing.GetSideType("Which side do you know? (Opposite, Adjacent, Hypotenuse): ");

            double? knownSideLength = Parsing.GetNullableDoubleInput("Enter the length of the known side: ");

            SideType sideToFindType;

            switch (sideKnown)
            {
                case SideType.Opposite:
                    sideToFindType = Parsing.GetSideType("Which side do you want to find? (Adjacent, Hypotenuse): ");
                    break;
                case SideType.Adjacent:
                    sideToFindType = Parsing.GetSideType("Which side do you want to find? (Opposite, Hypotenuse): ");
                    break;
                case SideType.Hypotenuse:
                    sideToFindType = Parsing.GetSideType("Which side do you want to find? (Adjacent, Opposite): ");
                    break;
                default:
                    menu();
                    return;
            }

            double result = Trigonometry.CalculateMissingSide(knownSideLength, angle, sideKnown, sideToFindType);
            DisplayCalculation(result, $"{sideToFindType}");
        }

        private static void HandleMissingAngle()
        {
            Console.Clear();
            Console.WriteLine("Calculating a missing Angle\n");

            SideType side1Type = Parsing.GetSideType("Enter the first side you know (Opposite, Adjacent, Hypotenuse): ");
            double? side1Length = Parsing.GetNullableDoubleInput("Enter the length of the first side: ");

            SideType side2Type = Parsing.GetSideType("Enter the second side you know (Opposite, Adjacent, Hypotenuse): ");
            double? side2Length = Parsing.GetNullableDoubleInput("Enter the length of the second side: ");

            double result = Trigonometry.CalculateMissingAngle(side1Length, side1Type, side2Length, side2Type);
            DisplayCalculation(result, "Angle");
        }

        private static void DisplayCalculation(double result, string calculatedItem) //
        {
            Console.WriteLine($"\n--- Calculation Result ---");
            Console.WriteLine($"{calculatedItem}: {result:F2}");
        }
    }
}