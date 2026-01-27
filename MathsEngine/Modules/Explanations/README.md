# Explanations Module

The Explanations module provides step-by-step explanations for mathematical calculations. Unlike the standard calculation modules that return only numeric results, the Explanations module returns both the answer and a detailed breakdown of the steps taken to reach that answer.

## Purpose

This module is designed to help users:
- Understand how calculations are performed
- Learn mathematical concepts through worked examples
- Verify calculation steps for educational purposes
- Debug complex calculations by seeing intermediate results

## Architecture

The Explanations module uses a wrapper pattern that:
- **Does not modify** existing calculation code
- **Maintains backward compatibility** - all existing code continues to work unchanged
- **Provides opt-in functionality** - users choose when to get step-by-step explanations
- **Organizes by topic** - mirrors the structure of the main Modules namespace

## Core Components

### CalculationResult Class

The `CalculationResult` class encapsulates both the final answer and the steps taken:

```csharp
public class CalculationResult
{
    public double Value { get; }                    // For scalar results
    public double[,]? MatrixValue { get; }          // For matrix results
    public IReadOnlyList<string> Steps { get; }     // Step-by-step explanation
    public bool IsMatrix { get; }                   // Result type indicator
    
    public string GetStepsAsString() { ... }        // Returns formatted steps
}
```

## Available Tutors

### Pure Mathematics

#### TrigonometryTutor

Provides step-by-step explanations for trigonometry calculations:

- `CalculateMissingSideWithSteps()` - Find a missing side in a right triangle
- `CalculateMissingAngleWithSteps()` - Find a missing angle in a right triangle

**Example:**
```csharp
using MathsEngine.Modules.Explanations.Pure;
using MathsEngine.Modules.Pure.Trigonometry;

var result = TrigonometryTutor.CalculateMissingSideWithSteps(
    knownSideLength: 10,
    angle: 30,
    knownSideType: SideType.Adjacent,
    sideToFind: SideType.Opposite
);

Console.WriteLine($"Answer: {result.Value:F2}");
Console.WriteLine("\nSteps:");
Console.WriteLine(result.GetStepsAsString());
```

**Output:**
```
Answer: 5.77

Steps:
Step 1: Identify known values
  Adjacent = 10
  Angle = 30°

Step 2: Choose the trigonometric ratio
  TOA → tan(θ) = opposite / adjacent

Step 3: Convert angle to radians
  30° × π / 180 = 0.5236 radians

Step 4: Set up the equation
  tan(30°) = opposite / 10  →  opposite = 10 × tan(30°)

Step 5: Calculate the missing side
  Opposite = 5.77

Final Answer:
  The Opposite is 5.77 units
```

#### PythagorasTheoremTutor

Provides step-by-step explanations for Pythagoras theorem calculations:

- `CalculateHypotenuseWithSteps()` - Calculate the hypotenuse given two sides
- `CalculateOtherSideWithSteps()` - Calculate a missing side given the hypotenuse

**Example:**
```csharp
using MathsEngine.Modules.Explanations.Pure;

var result = PythagorasTheoremTutor.CalculateHypotenuseWithSteps(
    sideA: 3,
    sideB: 4
);

Console.WriteLine($"Answer: {result.Value:F2}");
Console.WriteLine("\nSteps:");
Console.WriteLine(result.GetStepsAsString());
```

**Output:**
```
Answer: 5.00

Steps:
Step 1: Identify known values
  Side A = 3
  Side B = 4

Step 2: Apply Pythagorean Theorem
  Formula: c² = a² + b²
  c² = 3² + 4²

Step 3: Calculate squares
  3² = 9.00
  4² = 16.00

Step 4: Add the squares
  c² = 9.00 + 16.00 = 25.00

Step 5: Take the square root
  c = √25.00 = 5.00

Final Answer:
  The hypotenuse is 5.00 units
```

## Running the Demo

A complete demonstration is available in the `Examples/ExplanationsDemo.cs` file. To run it:

```csharp
using MathsEngine.Examples;

ExplanationsDemo.RunDemo();
```

## Design Principles

1. **Non-invasive**: Original calculation modules remain unchanged
2. **Consistent**: Step format is consistent across all tutors
3. **Informative**: Steps include formulas, intermediate values, and final answers
4. **Type-safe**: Reuses existing type definitions (e.g., `SideType`)
5. **Well-tested**: Comprehensive unit test coverage

## Future Expansion

The Explanations module can be extended to cover:
- Statistics calculations (mean, standard deviation, correlation)
- Mechanics calculations (Newton's laws, UVATS equations)
- Matrix operations (multiplication, inversion, determinants)
- Other Pure mathematics topics (algebra, calculus)

## Note on the "Teaching" vs "Explanations" Naming

This module was originally named "Teaching" but was renamed to "Explanations" to avoid confusion with planned future Teaching modules that will provide interactive learning experiences for mathematical concepts. The Explanations module focuses specifically on showing calculation steps.
