using MathsEngine.Modules.Pure.Algebra;
using MathsEngine.Utils;
using static MathsEngine.Utils.MenuConstants;

namespace MathsEngine.Menu.Pure
{
    internal static class AlgebraMenu
    {
        private const int ALGEBRA_MENU_OPTIONS = 4;

        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Algebra Menu");
            Console.WriteLine("1. Linear Equations (Single Variable)");
            Console.WriteLine("2. Quadratic Equations");
            Console.WriteLine("3. Simultaneous Equations (2 Variables)");
            Console.WriteLine("4. Back to Pure Menu");
            int response = Parsing.GetMenuInput("Input: ", ALGEBRA_MENU_OPTIONS);
            Console.Clear();

            switch (response)
            {
                case 1:
                    LinearEquationsMenu();
                    break;
                case 2:
                    QuadraticEquationsMenu();
                    break;
                case 3:
                    SimultaneousEquationsMenu();
                    break;
                case 4:
                    MathsEngine.Menu.Menu.PureMenu();
                    break;
            }
        }

        private static void LinearEquationsMenu()
        {
            Console.Clear();
            Console.WriteLine("Linear Equation Solver");
            Console.WriteLine("1. Solve ax + b = c");
            Console.WriteLine("2. Solve ax + b = cx + d");
            Console.WriteLine("3. Back");
            int response = Parsing.GetMenuInput("Input: ", 3);
            Console.Clear();

            switch (response)
            {
                case 1:
                    HandleSolveSimpleLinear();
                    break;
                case 2:
                    HandleSolveGeneralLinear();
                    break;
                case 3:
                    Menu();
                    return;
            }

            Console.WriteLine("\nPress Enter to return...");
            Console.ReadLine();
            Menu();
        }

        private static void HandleSolveSimpleLinear()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Solve equation of form: ax + b = c\n");

                double a = Parsing.GetDoubleInput("Enter coefficient a: ");
                double b = Parsing.GetDoubleInput("Enter constant b: ");
                double c = Parsing.GetDoubleInput("Enter result c: ");

                Console.WriteLine($"\nSolving: {FormatSimpleLinear(a, b, c)}");

                var steps = LinearEquationSolver.GetSolutionSteps(a, b, c);
                Console.WriteLine();
                foreach (var step in steps)
                {
                    Console.WriteLine(step);
                }
            }
            catch (ZeroCoefficientException ex)
            {
                ErrorDisplay.ShowError(ex.Message);
            }
            catch (Exception ex)
            {
                ErrorDisplay.ShowError($"An error occurred: {ex.Message}");
            }
        }

        private static void HandleSolveGeneralLinear()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Solve equation of form: ax + b = cx + d\n");

                double a = Parsing.GetDoubleInput("Enter coefficient a (left side): ");
                double b = Parsing.GetDoubleInput("Enter constant b (left side): ");
                double c = Parsing.GetDoubleInput("Enter coefficient c (right side): ");
                double d = Parsing.GetDoubleInput("Enter constant d (right side): ");

                Console.WriteLine($"\nSolving: {a}x + {(b >= 0 ? "+" : "")}{b} = {c}x + {(d >= 0 ? "+" : "")}{d}");

                double result = LinearEquationSolver.SolveGeneral(a, b, c, d);
                Console.WriteLine($"\nSolution: x = {result:F2}");
            }
            catch (ZeroCoefficientException ex)
            {
                ErrorDisplay.ShowError(ex.Message);
            }
            catch (NoSolutionException ex)
            {
                ErrorDisplay.ShowError(ex.Message);
            }
            catch (InfiniteSolutionsException ex)
            {
                ErrorDisplay.ShowError(ex.Message);
            }
            catch (Exception ex)
            {
                ErrorDisplay.ShowError($"An error occurred: {ex.Message}");
            }
        }

        private static void QuadraticEquationsMenu()
        {
            try
            {
                Console.Clear();
                Console.WriteLine("Quadratic Equation Solver");
                Console.WriteLine("Solve equation of form: ax² + bx + c = 0\n");

                double a = Parsing.GetDoubleInput("Enter coefficient a (x²): ");
                double b = Parsing.GetDoubleInput("Enter coefficient b (x): ");
                double c = Parsing.GetDoubleInput("Enter constant c: ");

                Console.WriteLine($"\nSolving: {FormatQuadratic(a, b, c)} = 0");

                var solution = QuadraticEquationSolver.Solve(a, b, c);
                
                Console.WriteLine($"\nDiscriminant: {solution.Discriminant:F2}");

                switch (solution.SolutionType)
                {
                    case QuadraticSolutionType.TwoRealRoots:
                        Console.WriteLine("\nTwo distinct real roots:");
                        Console.WriteLine($"x₁ = {solution.Root1:F2}");
                        Console.WriteLine($"x₂ = {solution.Root2:F2}");
                        break;

                    case QuadraticSolutionType.OneRepeatedRoot:
                        Console.WriteLine("\nOne repeated root:");
                        Console.WriteLine($"x = {solution.Root1:F2}");
                        break;

                    case QuadraticSolutionType.TwoComplexRoots:
                        Console.WriteLine("\nTwo complex roots:");
                        Console.WriteLine($"x₁ = {solution.ComplexRealPart:F2} + {solution.ComplexImaginaryPart:F2}i");
                        Console.WriteLine($"x₂ = {solution.ComplexRealPart:F2} - {solution.ComplexImaginaryPart:F2}i");
                        break;
                }

                // Ask if user wants step-by-step solution
                Console.Write("\nShow step-by-step solution? (y/n): ");
                string? response = Console.ReadLine()?.Trim().ToLower();
                if (response == "y" || response == "yes")
                {
                    var steps = QuadraticEquationSolver.GetSolutionSteps(a, b, c);
                    Console.WriteLine("\n--- Step-by-Step Solution ---");
                    foreach (var step in steps)
                    {
                        Console.WriteLine(step);
                    }
                }
            }
            catch (NotQuadraticException ex)
            {
                ErrorDisplay.ShowError(ex.Message);
            }
            catch (Exception ex)
            {
                ErrorDisplay.ShowError($"An error occurred: {ex.Message}");
            }

            Console.WriteLine("\nPress Enter to return...");
            Console.ReadLine();
            Menu();
        }

        private static void SimultaneousEquationsMenu()
        {
            Console.Clear();
            Console.WriteLine("Simultaneous Equations Solver");
            Console.WriteLine("\nThis feature will be available in a future update!");
            Console.WriteLine("Coming soon: Solve 2x2 systems using elimination method");

            Console.WriteLine("\nPress Enter to return...");
            Console.ReadLine();
            Menu();
        }

        // Helper methods for formatting equations

        private static string FormatSimpleLinear(double a, double b, double c)
        {
            string result = "";

            // Format ax term
            if (a == 1)
                result = "x";
            else if (a == -1)
                result = "-x";
            else
                result = $"{a}x";

            // Format + b term
            if (b > 0)
                result += $" + {b}";
            else if (b < 0)
                result += $" - {Math.Abs(b)}";

            // Format = c
            result += $" = {c}";
            return result;
        }

        private static string FormatQuadratic(double a, double b, double c)
        {
            string result = "";

            // x² term
            if (a == 1)
                result = "x²";
            else if (a == -1)
                result = "-x²";
            else
                result = $"{a}x²";

            // x term
            if (b > 0)
                result += $" + {b}x";
            else if (b < 0)
                result += $" - {Math.Abs(b)}x";

            // constant
            if (c > 0)
                result += $" + {c}";
            else if (c < 0)
                result += $" - {Math.Abs(c)}";

            return result;
        }
    }
}
