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

#### MatrixTutor

Provides step-by-step explanations for matrix operations:

- `AddMatrixWithSteps()` - Matrix addition with element-by-element breakdown
- `SubtractMatrixWithSteps()` - Matrix subtraction with element-by-element breakdown
- `ScalarMultiplicationWithSteps()` - Scalar multiplication showing each element
- `ScalarDivisionWithSteps()` - Scalar division showing each element
- `MatrixMultiplicationWithSteps()` - Matrix multiplication with detailed calculation steps
- `CalculateDeterminantWithSteps()` - Determinant calculation (2×2 matrices)

**Example:**
```csharp
using MathsEngine.Modules.Explanations.Pure;
using MathsEngine.Modules.Pure.Matrices;

var matrix1 = new MatrixBase(new double[,] { { 1, 2 }, { 3, 4 } });
var matrix2 = new MatrixBase(new double[,] { { 2, 0 }, { 1, 2 } });

var result = MatrixTutor.MatrixMultiplicationWithSteps(matrix1, matrix2);

Console.WriteLine("Result:");
Console.WriteLine(result.GetStepsAsString());
```

### Mechanics

#### NewtonsLawsTutor

Provides step-by-step explanations for Newton's Second Law (F = ma):

- `CalculateFmaWithSteps()` - Calculate Force, Mass, or Acceleration

**Example:**
```csharp
using MathsEngine.Modules.Explanations.Mechanics;

var result = NewtonsLawsTutor.CalculateFmaWithSteps(
    f: null,  // Force to calculate
    m: 10,    // Mass in kg
    a: 5      // Acceleration in m/s²
);

Console.WriteLine($"Force: {result.Value:F2} N");
Console.WriteLine("\nSteps:");
Console.WriteLine(result.GetStepsAsString());
```

#### UniformAccelerationTutor

Provides step-by-step explanations for SUVAT equations (uniform acceleration):

- `CalculateAverageVelocityWithSteps()` - Calculate average velocity
- `CalculateVUATWithSteps()` - v = u + at equation
- `CalculateVUASWithSteps()` - v² = u² + 2as equation
- `CalculateSUVTWithSteps()` - s = 0.5(u + v)t equation
- `CalculateSUTATWithSteps()` - s = ut + 0.5at² equation

**Example:**
```csharp
using MathsEngine.Modules.Explanations.Mechanics;

var result = UniformAccelerationTutor.CalculateVUATWithSteps(
    v: null,  // Final velocity to calculate
    u: 10,    // Initial velocity
    a: 2,     // Acceleration
    t: 5      // Time
);

Console.WriteLine($"Final velocity: {result.Value:F2} m/s");
Console.WriteLine("\nSteps:");
Console.WriteLine(result.GetStepsAsString());
```

### Statistics

#### StandardDeviationTutor

Provides step-by-step explanations for calculating variance and standard deviation:

- `CalculateStandardDeviationWithSteps()` - Calculate standard deviation with detailed breakdown
- `CalculateVarianceWithSteps()` - Calculate variance showing all intermediate steps

**Example:**
```csharp
using MathsEngine.Modules.Explanations.Statistics;

var values = new List<double> { 2, 4, 4, 4, 5, 5, 7, 9 };
var result = StandardDeviationTutor.CalculateStandardDeviationWithSteps(values);

Console.WriteLine($"Standard Deviation: {result.Value:F2}");
```

#### BivariateAnalysisTutor

Provides step-by-step explanations for Spearman's Rank Correlation:

- `CalculateSpearmanRankWithSteps()` - Calculate Spearman's rank correlation coefficient with detailed ranking and calculation steps

**Example:**
```csharp
using MathsEngine.Modules.Explanations.Statistics;

var scores1 = new List<int> { 10, 20, 30, 40, 50 };
var scores2 = new List<int> { 15, 25, 35, 45, 55 };

var result = BivariateAnalysisTutor.CalculateSpearmanRankWithSteps(scores1, scores2);

Console.WriteLine($"Correlation: {result.Value:F4}");
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
5. **Well-tested**: Comprehensive unit test coverage (74 tests)

## Test Coverage

- TrigonometryTutor: 17 tests
- PythagorasTheoremTutor: 17 tests
- MatrixTutor: 17 tests
- NewtonsLawsTutor: 8 tests
- UniformAccelerationTutor: 15 tests
- StandardDeviationTutor: 3 tests
- BivariateAnalysisTutor: 8 tests

**Total: 85 tests, all passing ✅**

## Future Expansion

The Explanations module can be extended to cover:
- Additional matrix operations (inverse, transpose, etc.)
- Other Pure mathematics topics (algebra, calculus)
- More statistics calculations (hypothesis testing, regression analysis)

## Note on the "Teaching" vs "Explanations" Naming

This module was originally named "Teaching" but was renamed to "Explanations" to avoid confusion with planned future Teaching modules that will provide interactive learning experiences for mathematical concepts. The Explanations module focuses specifically on showing calculation steps.
