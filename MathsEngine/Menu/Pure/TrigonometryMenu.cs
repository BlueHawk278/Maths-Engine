using MathsEngine.Modules.Pure.Trigonometry;
using MathsEngine.Utils;

namespace MathsEngine.Menu.Pure
{
    public class TrigonometryMenu // Implement a check method to check for a valid triangle
    {
        public static void Menu()
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
                    MathsEngine.Menu.Menu.PureMenu();
                    break;
            }

            Console.WriteLine("\nPress Enter to return...");
            Console.ReadLine();

            MathsEngine.Menu.Menu.MainMenu();
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
                    Menu();
                    return;
            }

            var teachingResult =
                TrigonometryTutor.CalculateMissingSideWithSteps(knownSideLength, angle, sideKnown, sideToFindType);

            Console.Clear();
            Console.WriteLine("--- Worked Solution ---\n");

            foreach(var step in teachingResult.Steps)
                Console.WriteLine(step);

            Console.WriteLine($"\nFinal Answer: {teachingResult.Value:F2}");
            Console.WriteLine("\nPress Enter to return to the Menu.");
            Console.ReadLine();
        }

        private static void HandleMissingAngle()
        {
            Console.Clear();
            Console.WriteLine("Calculating a missing Angle\n");

            SideType side1Type = Parsing.GetSideType("Enter the first side you know (Opposite, Adjacent, Hypotenuse): ");
            double? side1Length = Parsing.GetNullableDoubleInput("Enter the length of the first side: ");

            SideType side2Type = Parsing.GetSideType("Enter the second side you know (Opposite, Adjacent, Hypotenuse): ");
            double? side2Length = Parsing.GetNullableDoubleInput("Enter the length of the second side: ");

            var teachingResult =
                TrigonometryTutor.CalculateMissingAngleWithSteps(
                        side1Length, side1Type, side2Length, side2Type);

            Console.Clear();
            Console.WriteLine("--- Worked Solution ---\n");

            foreach (var step in teachingResult.Steps)
            {
                Console.WriteLine(step);
            }

            Console.WriteLine($"\nFinal Answer: {teachingResult.Value:F2}");
            Console.ReadLine();
        }
    }
}