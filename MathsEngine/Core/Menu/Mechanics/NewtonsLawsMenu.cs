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
            Console.WriteLine("1. Calculate a missing value (F=ma)");
            Console.WriteLine("2. Check a calculation");
            Console.WriteLine("3. Main Menu");
            int response = Parsing.GetMenuInput("Input: ", 3);

            switch (response)
            {
                case 1:
                    handleFMA_Equations();
                    break;
                case 2:
                    handleCheckCalculation();
                    break;
                case 3:
                    Menu.MainMenu();
                    break;
            }
        }

        private static void handleFMA_Equations()
        {
            try
            {
                double? force = Parsing.GetNullableDoubleInput("Enter the force");
                double? mass = Parsing.GetNullableDoubleInput("Enter the mass");
                double? acceleration = Parsing.GetNullableDoubleInput("Enter the acceleration");

                PerformCalculation(force, mass, acceleration);
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
                Menu.MainMenu();
            }
        }

        private static void handleCheckCalculation()
        {
            try
            {
                double? force = Parsing.GetNullableDoubleInput("Enter the force");
                double? mass = Parsing.GetNullableDoubleInput("Enter the mass");
                double? acceleration = Parsing.GetNullableDoubleInput("Enter the acceleration");

                bool isValid = Modules.Mechanics.Dynamics.NewtonsLawsCalculator.CheckValidCalculation(force, mass, acceleration);

                if (isValid)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nThis is a valid calculation.");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\nThis is not a valid calculation.");
                }
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
            finally
            {
                Console.WriteLine("\nPress any key to return to the main menu...");
                Console.ReadKey();
                Menu.MainMenu();
            }
        }

        private static void PerformCalculation(double? F, double? M, double? A)
        {
            int missingCount =
                (F is null ? 1 : 0) +
                (M is null ? 1 : 0) +
                (A is null ? 1 : 0);

            if (missingCount > 1)
                throw new ArgumentException("Calculation is not possible. Only one value can be unknown.");

            if (missingCount == 0)
            {
                Console.WriteLine("\nAll values provided. Use 'Check a calculation' to verify them.");
                return;
            }

            double? calculatedValue = Modules.Mechanics.Dynamics.NewtonsLawsCalculator.CalculateFma(F, M, A);

            if (F is null) F = calculatedValue;
            else if(M is null) M = calculatedValue;
            else if(A is null) A = calculatedValue;

            displayCalculation(F, M, A);
        }

        private static void displayCalculation(double? F, double? M, double? A)
        {
            Console.WriteLine("--- Calculation Results ---");
            Console.WriteLine($"Resultant Force (F): {FormatValue(F)}");
            Console.WriteLine($"Mass (M): {FormatValue(M)}");
            Console.WriteLine($"Acceleration (A): {FormatValue(A)}");
        }

        private static string FormatValue(double? value)
        {
            if (value is null)
                return "Not Calculated";

            // Convert to double to format it to 2 decimal places.
            return Convert.ToDouble(value).ToString("F2");
        }
    }
}