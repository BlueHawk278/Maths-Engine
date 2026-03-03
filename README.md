# Maths Engine

A C# console application providing computational tools for GCSE and Further Mathematics topics. The engine supports Pure Mathematics, Statistics, and Mechanics calculations with optional step-by-step explanations for educational purposes.

## Purpose

This project provides:
- Reliable implementations of common mathematical algorithms for students and educators
- A modular architecture suitable for extension with additional mathematical topics
- Step-by-step calculation breakdowns for learning and verification

## Intended Users

- Students studying GCSE Maths/Further Maths or A-level Mathematics
- Educators requiring worked examples of mathematical procedures
- Developers seeking reference implementations of mathematical algorithms in C#

## Features

### Pure Mathematics
- **Pythagoras Theorem**: Calculate hypotenuse or missing sides in right triangles
- **Trigonometry**: Solve for missing sides and angles using SOH-CAH-TOA ratios
- **Matrices**: Addition, subtraction, scalar operations, multiplication, and determinant calculation (2×2)
- **Coordinate Geometry**: Finding the length, midpoint and equation of a straight line

### Statistics
- **Averages**: Mean, median, mode, and range for raw data and frequency tables
- **Dispersion**: Standard deviation, variance, and interquartile range
- **Bivariate Analysis**: Spearman's Rank correlation with ranked data processing

### Mechanics
- **Newton's Laws**: F = ma calculations solving for force, mass, or acceleration
- **Uniform Acceleration**: SUVAT equation solvers for kinematics problems

### Explanations Module
All core calculations have optional step-by-step explanations available through dedicated "Tutor" classes. These return `CalculationResult` objects containing both the numeric answer and a formatted list of calculation steps.

## System Structure

```
MathsEngine/
├── MathsEngine.Console/        # Console UI — menus and user input
│   ├── Menu/
│   │   ├── Pure/               # Pure maths topic menus
│   │   ├── Statistics/         # Statistics topic menus
│   │   └── Mechanics/          # Mechanics topic menus
│   └── Utils/                  # Input parsing and error display
├── MathsEngine.Models/         # Core calculation library (no UI)
│   ├── Modules/
│   │   ├── Pure/               # Pythagoras, Trigonometry, Matrices, Coordinate Geometry
│   │   ├── Statistics/         # Averages, Dispersion, Bivariate Analysis
│   │   ├── Mechanics/          # Newton's Laws, SUVAT
│   │   └── Explanations/       # Step-by-step tutor wrappers
│   └── Utils/                  # Custom exceptions
├── MathsEngine.Tests/          # xUnit test project
└── WinForms/                   # Windows Forms GUI (in development)
```

### Architectural Principles

**Separation of Concerns**: User interface code (`Forms`) are isolated from calculation logic (`Modules/`). This allows the calculation classes to be reused in different contexts (GUI, Console, Unit tests) without modification.

**Wrapper Pattern for Explanations**: The `Explanations` module provides step-by-step breakdowns without modifying existing calculation classes. This maintains backward compatibility and keeps educational features optional.

**Custom Exception Hierarchy**: Domain-specific exceptions (e.g., `IncompatibleMatrixMultiplicationException`, `HypotenuseNotLongestSideException`) provide clearer error messages than generic .NET exceptions.

### Programmatic Usage

To use calculation classes directly:

```csharp
using MathsEngine.Modules.Pure.Trigonometry;

// Basic calculation
double result = Trigonometry.CalculateMissingSide(
    knownSideLength: 10,
    angle: 30,
    knownSideType: SideType.Adjacent,
    sideToFind: SideType.Opposite
);

// With step-by-step explanation
using MathsEngine.Modules.Explanations.Pure;

var calculation = TrigonometryTutor.CalculateMissingSideWithSteps(
    knownSideLength: 10,
    angle: 30,
    knownSideType: SideType.Adjacent,
    sideToFind: SideType.Opposite
);

Console.WriteLine($"Answer: {calculation.Value}");
Console.WriteLine(calculation.GetStepsAsString());
```

### Testing

Tests are organized in the `MathsEngine.Tests` project. To add tests for new functionality:

1. Create a test class matching the module structure
2. Test calculation accuracy against known mathematical results
3. Test edge cases (zero values, invalid inputs, boundary conditions)
4. Verify custom exceptions are thrown correctly

## Design Rationale

### Why Static Methods for Calculations?
Most calculation methods are stateless transformations (input → output). Static methods make this explicit and avoid unnecessary object instantiation.

### Why Instance Classes for Data Structures?
`MatrixBase` uses instance methods because matrices are data objects with properties (dimensions, values). Operations on matrices are implemented in the static `MatrixCalculator` class.

### Why Separate Explanations Module?
Integrating step-by-step explanations into calculation classes would:
- Increase complexity for users who only need numeric results
- Mix presentation concerns with business logic
- Break backward compatibility

The wrapper pattern keeps explanations opt-in while reusing existing calculation code.