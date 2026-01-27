using System;
using MathsEngine.Modules.Explanations.Pure;
using MathsEngine.Modules.Explanations.Mechanics;
using MathsEngine.Modules.Pure.Trigonometry;
using MathsEngine.Modules.Pure.Matrices;

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
        Console.WriteLine("\n");

        // Example 4: Newton's Laws - Calculate Force
        Console.WriteLine("Example 4: Calculate force using Newton's Second Law (F = ma)");
        Console.WriteLine("-----------------------------------------------------------");
        var forceResult = NewtonsLawsTutor.CalculateFmaWithSteps(
            f: null,  // Force to calculate
            m: 10,    // Mass in kg
            a: 5      // Acceleration in m/s²
        );

        Console.WriteLine($"Answer: {forceResult.Value:F2} N");
        Console.WriteLine("\nSteps:");
        Console.WriteLine(forceResult.GetStepsAsString());
        Console.WriteLine("\n");

        // Example 5: Uniform Acceleration - SUVAT equation
        Console.WriteLine("Example 5: Calculate final velocity using SUVAT (v = u + at)");
        Console.WriteLine("-----------------------------------------------------------");
        var velocityResult = UniformAccelerationTutor.CalculateVUATWithSteps(
            v: null,  // Final velocity to calculate
            u: 10,    // Initial velocity
            a: 2,     // Acceleration
            t: 5      // Time
        );

        Console.WriteLine($"Answer: {velocityResult.Value:F2} m/s");
        Console.WriteLine("\nSteps:");
        Console.WriteLine(velocityResult.GetStepsAsString());
        Console.WriteLine("\n");

        // Example 6: Matrix Multiplication
        Console.WriteLine("Example 6: Multiply two 2×2 matrices");
        Console.WriteLine("------------------------------------");
        var matrix1 = new MatrixBase(new double[,] { { 1, 2 }, { 3, 4 } });
        var matrix2 = new MatrixBase(new double[,] { { 2, 0 }, { 1, 2 } });

        var matrixResult = MatrixTutor.MatrixMultiplicationWithSteps(matrix1, matrix2);

        Console.WriteLine("Steps:");
        Console.WriteLine(matrixResult.GetStepsAsString());
    }
}
