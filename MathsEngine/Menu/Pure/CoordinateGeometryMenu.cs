using MathsEngine.Modules.Pure.CoordinateGeometry;
using MathsEngine.Utils;

namespace MathsEngine.Menu.Pure;

public class CoordinateGeometryMenu
{
    public static void Menu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("--- Coordinate Geometry ---");
            Console.WriteLine("1. Calculate length of a line segment");
            Console.WriteLine("2. Calculate midpoint of a line segment");
            Console.WriteLine("3. Calculate gradient of a line");
            Console.WriteLine("4. Find equation from gradient and a point");
            Console.WriteLine("5. Find equation from two points");
            Console.WriteLine("6. Back");
            var response = Parsing.GetMenuInput("Input: ", 6);

            switch (response)
            {
                case 1:
                    HandleCalculateLength();
                    break;
                case 2:
                    HandleCalculateMidpoint();
                    break;
                case 3:
                    HandleCalculateGradient();
                    break;
                case 4:
                    HandleFindEquationFromGradientAndPoint();
                    break;
                case 5:
                    HandleFindEquationFromTwoPoints();
                    break;
                case 6:
                    return;
            }

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }

    private static void HandleCalculateLength()
    {
        var coordA = Parsing.ParseCoordinate("Enter coordinate A (x,y): ");
        var coordB = Parsing.ParseCoordinate("Enter coordinate B (x,y): ");
        var length = CoordinateGeometryCalculator.CalculateLengthOfStraightLine(coordA, coordB);
        Console.WriteLine($"\nThe length of the line segment is: {length:F4}");
    }

    private static void HandleCalculateMidpoint()
    {
        var coordA = Parsing.ParseCoordinate("Enter coordinate A (x,y): ");
        var coordB = Parsing.ParseCoordinate("Enter coordinate B (x,y): ");
        var midpoint = CoordinateGeometryCalculator.CalculateMidpointOfStraightLine(coordA, coordB);
        Console.WriteLine($"\nThe midpoint is: {midpoint}");
    }

    private static void HandleCalculateGradient()
    {
        var coordA = Parsing.ParseCoordinate("Enter coordinate A (x,y): ");
        var coordB = Parsing.ParseCoordinate("Enter coordinate B (x,y): ");
        var gradient = CoordinateGeometryCalculator.CalculateGradientBetweenTwoCoordinates(coordA, coordB);

        if (double.IsPositiveInfinity(gradient))
            Console.WriteLine("\nThe line is vertical, so the gradient is undefined (infinite).");
        else
            Console.WriteLine($"\nThe gradient of the line is: {gradient}");
    }

    private static void HandleFindEquationFromGradientAndPoint()
    {
        var gradient = Parsing.GetDoubleInput("Enter the gradient (m): ");
        var point = Parsing.ParseCoordinate("Enter a coordinate on the line (x,y): ");
        var equation = CoordinateGeometryCalculator.FindEquationFromGradientAndCoordinate(gradient, point);
        Console.WriteLine($"\nThe equation of the line is: {equation}");
    }

    private static void HandleFindEquationFromTwoPoints()
    {
        var coordA = Parsing.ParseCoordinate("Enter coordinate A (x,y): ");
        var coordB = Parsing.ParseCoordinate("Enter coordinate B (x,y): ");
        var equation = CoordinateGeometryCalculator.FindEquationFromTwoCoordinates(coordA, coordB);
        Console.WriteLine($"\nThe equation of the line is: {equation}");
    }
}