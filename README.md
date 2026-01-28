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
├── Menu/              # Console interface organized by mathematical topic
│   ├── Pure/          # Menus for Pure Mathematics topics
│   ├── Statistics/    # Menus for Statistics topics
│   └── Mechanics/     # Menus for Mechanics topics
├── Modules/           # Core calculation logic
│   ├── Pure/          # Trigonometry, Matrices, Pythagoras implementations
│   ├── Statistics/    # Statistical calculation classes
│   ├── Mechanics/     # Dynamics and kinematics solvers
│   └── Explanations/  # Step-by-step wrappers for educational use
├── Utils/             # Input parsing, validation, and custom exceptions
├── Examples/          # Demonstration code for Explanations module
└── Program.cs         # Application entry point
```

### Architectural Principles

**Separation of Concerns**: User interface code (`Menu/`) is isolated from calculation logic (`Modules/`). This allows the calculation classes to be reused in different contexts (GUI, web service, unit tests) without modification.

**Wrapper Pattern for Explanations**: The `Explanations` module provides step-by-step breakdowns without modifying existing calculation classes. This maintains backward compatibility and keeps educational features optional.

**Custom Exception Hierarchy**: Domain-specific exceptions (e.g., `IncompatibleMatrixMultiplicationException`, `HypotenuseNotLongestSideException`) provide clearer error messages than generic .NET exceptions.

## Running the Application

### Prerequisites
- .NET Framework 4.x or .NET 6+ SDK
- Visual Studio or compatible C# IDE

### Execution
1. Open `MathsEngine.sln` in Visual Studio
2. Build the solution (Build → Build Solution)
3. Run the project (F5 or Start)
4. Navigate using numeric menu inputs

The application presents a hierarchical menu system:
1. Select a category (Pure, Mechanics, Statistics)
2. Select a specific topic (e.g., Trigonometry, Matrices)
3. Select a calculation type
4. Enter required values
5. View result and return to menu

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

## Extending the Project

### Adding a New Calculation Topic

1. **Create calculation class** in `Modules/[Category]/`:
   ```csharp
   public static class NewTopicCalculator
   {
       public static double Calculate(double input) { /* ... */ }
   }
   ```

2. **Create menu class** in `Menu/[Category]/`:
   ```csharp
   internal class NewTopicMenu
   {
       public static void Menu() { /* ... */ }
   }
   ```

3. **Add custom exceptions** to `Utils/Exceptions.cs` if needed

4. **(Optional) Create explanation wrapper** in `Modules/Explanations/[Category]/`:
   ```csharp
   public static class NewTopicTutor
   {
       public static CalculationResult CalculateWithSteps(double input)
       {
           var steps = new List<string>();
           // Add step descriptions
           double value = NewTopicCalculator.Calculate(input);
           return new CalculationResult(value, steps);
       }
   }
   ```

5. **Register in parent menu** by adding a menu option

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

## Limitations

- Console-only interface (no graphical plotting or interactive visualization)
- No persistent storage of calculation history
- Limited to numeric computation (no symbolic algebra or equation solving)
- Matrix operations currently support 2×2 determinants only

## License

MIT License (see LICENSE file)

## Repository

https://github.com/BlueHawk278/Maths-Engine