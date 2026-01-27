using System;
using MathsEngine.Modules.Explanations.Pure;
using MathsEngine.Modules.Pure.Trigonometry;

namespace MathsEngine.Examples;

/// <summary>
/// Demonstrates the Explanations module with step-by-step calculations
/// </summary>
public static class ExplanationsDemo
{
    public static void RunDemo()
    {
        Console.WriteLine("=== MathsEngine Explanations Module Demo ===\n");

        // Example 1: Trigonometry - Calculate missing side
        Console.WriteLine("Example 1: Calculate missing side in a right triangle");
        Console.WriteLine("-------------------------------------------------------");
        var trigResult = TrigonometryTutor.CalculateMissingSideWithSteps(
            knownSideLength: 10,
            angle: 30,
            knownSideType: SideType.Adjacent,
            sideToFind: SideType.Opposite
        );

        Console.WriteLine($"Answer: {trigResult.Value:F2}");
        Console.WriteLine("\nSteps:");
        Console.WriteLine(trigResult.GetStepsAsString());
        Console.WriteLine("\n");

        // Example 2: Pythagoras - Calculate hypotenuse
        Console.WriteLine("Example 2: Calculate hypotenuse using Pythagoras theorem");
        Console.WriteLine("--------------------------------------------------------");
        var pythagResult = PythagorasTheoremTutor.CalculateHypotenuseWithSteps(
            sideA: 3,
            sideB: 4
        );

        Console.WriteLine($"Answer: {pythagResult.Value:F2}");
        Console.WriteLine("\nSteps:");
        Console.WriteLine(pythagResult.GetStepsAsString());
        Console.WriteLine("\n");

        // Example 3: Trigonometry - Calculate missing angle
        Console.WriteLine("Example 3: Calculate missing angle in a right triangle");
        Console.WriteLine("-------------------------------------------------------");
        var angleResult = TrigonometryTutor.CalculateMissingAngleWithSteps(
            side1Length: 3,
            side1Type: SideType.Opposite,
            side2Length: 4,
            side2Type: SideType.Adjacent
        );

        Console.WriteLine($"Answer: {angleResult.Value:F2}°");
        Console.WriteLine("\nSteps:");
        Console.WriteLine(angleResult.GetStepsAsString());
    }
}
