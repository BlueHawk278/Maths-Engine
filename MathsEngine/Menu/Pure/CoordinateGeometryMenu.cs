using MathsEngine.Modules.Explanations;
using MathsEngine.Modules.Explanations.Pure;
using MathsEngine.Modules.Pure.CoordinateGeometry;
using MathsEngine.Utils;

namespace MathsEngine.Menu.Pure;

public static class CoordinateGeometryMenu
{
    public static void Menu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("--- Coordinate Geometry ---");
            Console.WriteLine("1. Calculate length of a line segment");
            Console.WriteLine("2. Calculate midpoint of a line segment");
            Console.WriteLine("3. Find equation from gradient and a point");
            Console.WriteLine("4. Find equation from two points");
            Console.WriteLine("5. Back");
            var response = Parsing.GetMenuInput("Input: ", 5);

            switch (response)
            {
                case 1:
                    HandleCalculateLength();
                    break;
                case 2:
                    HandleCalculateMidpoint();
                    break;
                case 3:
                    HandleFindEquationFromGradientAndPoint();
                    break;
                case 4:
                    HandleFindEquationFromTwoPoints();
                    break;
                case 5:
                    return;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    private static void HandleCalculateLength()
    {
        try
        {
            var coordA = Parsing.ParseCoordinate("Enter coordinate A: ");
            var coordB = Parsing.ParseCoordinate("Enter coordinate B: ");

            var result = CoordinateGeometryTutor.CalculateLengthOfStraightLineWithSteps(coordA, coordB);

            Console.WriteLine($"\nResult: The length of the line is {result.Value:F2} units.");
            DisplaySteps(result);
        }
        catch (FormatException e)
        {
            ErrorDisplay.ShowError(e.Message);
        }
    }

    private static void HandleCalculateMidpoint()
    {
        try
        {
            var coordA = Parsing.ParseCoordinate("Enter coordinate A: ");
            var coordB = Parsing.ParseCoordinate("Enter coordinate B: ");

            var result = CoordinateGeometryTutor.CalculateMidpointOfStraightLineWithSteps(coordA, coordB);

            Console.WriteLine($"\nResult: The midpoint is {result.CoordinateValue}.");
            DisplaySteps(result);
        }
        catch (FormatException e)
        {
            ErrorDisplay.ShowError(e.Message);
        }
    }

    private static void HandleFindEquationFromGradientAndPoint()
    {
        try
        {
            var gradient = Parsing.GetDoubleInput("Enter the gradient (m): ");
            var point = Parsing.ParseCoordinate("Enter the coordinate on the line: ");

            var result = CoordinateGeometryTutor.FindEquationFromGradientAndCoordinateWithSteps(gradient, point);

            Console.WriteLine($"\nResult: The equation of the line is {result.StraightLineValue}.");
            DisplaySteps(result);
        }
        catch (FormatException e)
        {
            ErrorDisplay.ShowError(e.Message);
        }
    }

    private static void HandleFindEquationFromTwoPoints()
    {
        try
        {
            var coordA = Parsing.ParseCoordinate("Enter coordinate A: ");
            var coordB = Parsing.ParseCoordinate("Enter coordinate B: ");

            var result = CoordinateGeometryTutor.FindEquationFromTwoCoordinatesWithSteps(coordA, coordB);

            Console.WriteLine($"\nResult: The equation of the line is {result.StraightLineValue}.");
            DisplaySteps(result);
        }
        catch (FormatException e)
        {
            ErrorDisplay.ShowError(e.Message);
        }
    }

    /// <summary>
    /// Asks the user if they want to see the steps and displays them if requested.
    /// </summary>
    private static void DisplaySteps(CalculationResult result)
    {
        Console.Write("\nDo you want to see the steps? (y/n): ");
        var response = Console.ReadLine()?.Trim().ToLower();
        if (response == "y")
        {
            Console.WriteLine("\n--- Steps ---");
            Console.WriteLine(result.GetStepsAsString());
        }
    }
}