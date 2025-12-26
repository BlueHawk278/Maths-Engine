using System;

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
            Console.WriteLine("Enter the angle you know in degrees");
            double angle = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Which side do you know? (1. Opposite, 2. Adjacent, 3. Hypotenuse");
            string response = Console.ReadLine();

            switch (response)
            {
                case "1":
                    // Opp
                    break;
                case "2":
                    // Adj
                    break;
                case "3":
                    // Hyp
                    break;
                default:
                    menu();
                    break;
            }
        }

        private static void handleMissingAngle()
        {

        }

        private static void displayCalculation()
        {

        }

        private static string FormatValue(string value)
        {
            if (value == null)
                return "Not Calculated";

            // Convert to double to format it to 2 decimal places.
            return Convert.ToDouble(value).ToString("F2");
        }
    }
}