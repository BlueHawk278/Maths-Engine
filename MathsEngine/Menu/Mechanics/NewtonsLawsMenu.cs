using MathsEngine.Utils;

// Newton's 1st Law: A body will remain stationary or moving at a constant velocity unless acted upon by an external force.
// Newton's 2nd Law: The resultant force is proportional to the acceleration - F = m*a
// Newton's 3rd Law: Every action has an equal but opposite reaction.

namespace MathsEngine.Menu.Mechanics
{
    public class NewtonsLawsMenu
    {
        public static void Menu()
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
                case 3:
                    Menu.MechanicsMenu();
                    break;
            }
        }

        

        private static void HandleFMA_Equations()
        

        private static void HandleCheckCalculation()
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

        private static void

        private static void PerformCalculation(double? F, double? M, double? A)
        
    }
}