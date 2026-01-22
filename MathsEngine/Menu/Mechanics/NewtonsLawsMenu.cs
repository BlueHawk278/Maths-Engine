using MathsEngine.Utils;

// Newton's 1st Law: A body will remain stationary or moving at a constant velocity unless acted upon by an external force.
// Newton's 2nd Law: The resultant force is proportional to the acceleration - F = m*a
// Newton's 3rd Law: Every action has an equal but opposite reaction.

namespace MathsEngine.Menu.Mechanics
{
    public class NewtonsLawsMenu : IMenu
    {
        public static void Menu()
        {
            while (true)
            {
                Console.WriteLine("1. Calculate a missing value (F=ma)");
                Console.WriteLine("2. Check a calculation");
                Console.WriteLine("3. Back");
                int response = Parsing.GetMenuInput("Input: ", 3);

                switch (response)
                {
                    case 1:
                        HandleFMA_Equations();
                        break;
                    case 2:
                        HandleCheckCalculation();
                        break;
                    case 3: return;
                }
            }
        }

        private static void HandleFMA_Equations()
        {
            try
            {
                double? force = Parsing.GetNullableDoubleInput("Enter the force");
                double? mass = Parsing.GetNullableDoubleInput("Enter the mass");
                double? acceleration = Parsing.GetNullableDoubleInput("Enter the acceleration");

                PerformCalculation(force, mass, acceleration);

                Console.WriteLine("\nCalculation complete. Press any key to return to the menu...");
                Console.ReadKey();
            }
            catch (NullInputException ex)
            {
                ErrorDisplay.ShowError(ex.Message);
            }
            catch (NullMassException ex)
            {
                ErrorDisplay.ShowError(ex.Message);
            }
            catch (FormatException)
            {
                ErrorDisplay.ShowError("Error: Invalid input. Please enter valid numbers.");
            }
            catch (Exception ex)
            {
                ErrorDisplay.ShowError($"An unexpected error occurred: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("\nPress any key to return to the main Menu...");
                Console.ReadKey();

                MathsEngine.Menu.Menu.MainMenu();
            }
        }

        private static void HandleCheckCalculation()
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

                Console.WriteLine("\nCalculation complete. Press any key to return to the menu...");
                Console.ReadKey();
            }
            catch (NullValuesException ex)
            {
                ErrorDisplay.ShowError(ex.Message);
            }
            catch (NullMassException ex)
            {
                ErrorDisplay.ShowError(ex.Message);
            }
            catch (FormatException)
            {
                ErrorDisplay.ShowError("Error: Invalid input. Please enter valid numbers.");
            }
            finally
            {
                Console.WriteLine("\nPress any key to return to the main Menu...");
                Console.ReadKey();

                MathsEngine.Menu.Menu.MainMenu();
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
            else if (M is null) M = calculatedValue;
            else if (A is null) A = calculatedValue;

            var resultDictionary = new Dictionary<string, double?>()
            {
                {"Resultant Force (F)", F},
                {"Mass (M)", M},
                {"Acceleration (A)", A}
            };

            Display.DisplayResult(resultDictionary);
        }
    }
}