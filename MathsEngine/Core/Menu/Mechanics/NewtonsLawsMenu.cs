using System;
using System.Collections.Generic;

// Newton's 1st Law: A body will remain stationary or moving at a constant velocity unless acted upon by an external force.
// Newton's 2nd Law: The resultant force is proportional to the acceleration - F = m*a
// Newton's 3rd Law: Every action has an equal but opposite reaction.

namespace MathsEngine.Core.Menu.Mechanics
{
    public class NewtonsLawsMenu
    {
        public static void menu()
        {
            Console.WriteLine("1. Basic F=ma equations");
            Console.WriteLine("Input: ");
            string response = Console.ReadLine();

            switch (response)
            {
                case "1":
                    handleFMA_Equations();
                    break;
                default:
                    Menu.mainMenu();
                    break;
            }
        }

        private static void handleFMA_Equations()
        {
            Console.WriteLine("Enter the Force");
            string F = Console.ReadLine();
            Console.WriteLine("Enter the Mass");
            string M = Console.ReadLine();
            Console.WriteLine("Enter the Acceleration");
            string A= Console.ReadLine();

            checkCalculation(F, M, A);
        }

        private static void checkCalculation(string F, string M, string A)
        {
            F = string.IsNullOrEmpty(F) ? null : F;
            M = string.IsNullOrEmpty(M) ? null : M;
            A = string.IsNullOrEmpty(A) ? null : A;

            int numNull = 0;
            var values = new List<string> { F, M, A };
            
            foreach(string num in values)
                if (num == null)
                    numNull++;

            if (numNull > 1)
                throw Utils.Exceptions.NullValuesException;

            double value = Modules.Mechanics.Dynamics.NewtonsLawsCalculator.calculateFma(F, M, A);

            if (value == 0) // ERROR
                throw new Exception("Something went wrong");

            if (F == null) F = Convert.ToString(value);
            if (M == null) M = Convert.ToString(value);
            if (A == null) A = Convert.ToString(value);

            displayCalculation(F, M, A);
        }

        private static void displayCalculation(string F, string M, string A)
        {
            Console.WriteLine("--- Calculation Results ---");
            Console.WriteLine($"Resultant Force (F): {FormatValue(F)}");
            Console.WriteLine($"Mass (M): {FormatValue(M)}");
            Console.WriteLine($"Acceleration (A): {FormatValue(A)}");
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