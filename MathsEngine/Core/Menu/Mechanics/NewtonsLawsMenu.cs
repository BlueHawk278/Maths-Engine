using System;
using System.Collections.Generic;
using MathsEngine.Utils;

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
            try
            {
                Console.WriteLine("Enter the Force");
                string F = Console.ReadLine();
                Console.WriteLine("Enter the Mass");
                string M = Console.ReadLine();
                Console.WriteLine("Enter the Acceleration");
                string A = Console.ReadLine();

                checkCalculation(F, M, A);
            }
            catch (NullInputException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {ex.Message}");
                Console.ResetColor();
            }
            catch (NullValuesException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Error: {ex.Message}");
                Console.ResetColor();
            }
            catch (FormatException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Invalid input. Please enter valid numbers.");
                Console.ResetColor();
            }
            // A general catch for any other unexpected errors
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
                Console.ResetColor();
            }
            finally
            {
                Console.WriteLine("\nPress any key to return to the main menu...");
                Console.ReadKey();
                Menu.mainMenu();
            }
        }

        private static void checkCalculation(string F, string M, string A)
        {
            F = string.IsNullOrEmpty(F) ? null : F;
            M = string.IsNullOrEmpty(M) ? null : M;
            A = string.IsNullOrEmpty(A) ? null : A;

            int numNull = 0;
            if (F == null) numNull++;
            if (M == null) numNull++;
            if (A == null) numNull++;

            if (numNull == 3)
                throw new NullInputException("Please provide at least two values (F, M, or A).");

            if (numNull > 1)
                throw new NullValuesException("Calculation is not possible. Only one value can be unknown.");

            double value = Modules.Mechanics.Dynamics.NewtonsLawsCalculator.calculateFma(F, M, A);

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