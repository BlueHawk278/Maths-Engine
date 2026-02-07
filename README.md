# Maths Engine

A C# application providing computational tools for GCSE and Further Mathematics topics. The engine supports Pure Mathematics, Statistics, and Mechanics calculations with optional step-by-step explanations for educational purposes.

**Now supporting both CLI and WinForms interfaces!**

## Purpose

This project provides:
- Reliable implementations of common mathematical algorithms for students and educators
- A modular architecture suitable for extension with additional mathematical topics
- Step-by-step calculation breakdowns for learning and verification
- Multiple user interfaces (Console and WinForms) sharing the same core logic

## Intended Users

- Students studying GCSE Maths/Further Maths or A-level Mathematics
- Educators requiring worked examples of mathematical procedures
- Developers seeking reference implementations of mathematical algorithms in C#

## Features

### Pure Mathematics
- **Pythagoras Theorem**: Calculate hypotenuse or missing sides in right triangles
- **Trigonometry**: Solve for missing sides and angles using SOH-CAH-TOA ratios
- **Matrices**: Addition, subtraction, scalar operations, multiplication, and determinant calculation (2×2)
- **Coordinate Geometry**: Distance, midpoint, gradient, and straight line calculations

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

The solution is now organized into multiple projects:

```
MathsEngine/
├── MathsEngine.Core/        # Core business logic (calculator classes)
│   ├── Modules/             # Calculation implementations
│   │   ├── Pure/            # Pure maths (Pythagoras, Trig, Matrices, etc.)
│   │   ├── Statistics/      # Statistical calculations
│   │   ├── Mechanics/       # Physics calculations
│   │   └── Explanations/    # Step-by-step calculation explanations
│   └── Utils/               # Core exceptions
├── MathsEngine.CLI/         # Console user interface
│   ├── Menu/                # Console menus organized by topic
│   ├── Utils/               # Console-specific helpers (Parsing, Display)
│   └── Program.cs           # CLI entry point
├── MathsEngine.WinForms/    # Windows Forms user interface (stub)
│   └── README.md            # WinForms development guide
├── MathsEngine.Tests/       # Unit tests for core logic
└── MathsEngine/             # Legacy project (deprecated)
```

### Architectural Principles

**Multi-Interface Architecture**: The core calculation logic in `MathsEngine.Core` is completely UI-agnostic, allowing it to be used by multiple interfaces (CLI, WinForms, or any future interface) without modification.

**Separation of Concerns**: User interface code is isolated from calculation logic. The CLI and WinForms projects contain only UI code, while all mathematical operations are in the Core library.

**Wrapper Pattern for Explanations**: The `Explanations` module provides step-by-step breakdowns without modifying existing calculation classes. This maintains backward compatibility and keeps educational features optional.

**Custom Exception Hierarchy**: Domain-specific exceptions (e.g., `IncompatibleMatrixMultiplicationException`, `HypotenuseNotLongestSideException`) provide clearer error messages than generic .NET exceptions.

## Running the Application

### Prerequisites
- .NET 8.0 SDK or later
- For WinForms: Windows OS (or cross-platform development with EnableWindowsTargeting)

### Running the CLI Application

From the command line:
```bash
dotnet run --project MathsEngine.CLI
```

Or build and run from Visual Studio:
1. Open `MathsEngine.sln` in Visual Studio
2. Set `MathsEngine.CLI` as the startup project
3. Run the project (F5 or Start)

The CLI presents a hierarchical menu system:
1. Select a category (Pure, Mechanics, Statistics)
2. Select a specific topic (e.g., Trigonometry, Matrices)
3. Select a calculation type
4. Enter required values
5. View result and return to menu

### Running the WinForms Application

**Note**: The WinForms project is currently a stub/placeholder. See `MathsEngine.WinForms/README.md` for details on future development.

### Programmatic Usage

To use calculation classes directly in your own projects, reference `MathsEngine.Core`:

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

1. **Create calculation class** in `MathsEngine.Core/Modules/[Category]/`:
   ```csharp
   public static class NewTopicCalculator
   {
       public static double Calculate(double input) { /* ... */ }
   }
   ```

2. **Create menu class** in `MathsEngine.CLI/Menu/[Category]/`:
   ```csharp
   internal class NewTopicMenu
   {
       public static void Menu() { /* ... */ }
   }
   ```

3. **Add custom exceptions** to `MathsEngine.Core/Utils/Exceptions.cs` if needed

4. **(Optional) Create explanation wrapper** in `MathsEngine.Core/Modules/Explanations/[Category]/`:
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

### Adding WinForms UI

The WinForms project is set up and references `MathsEngine.Core`. To add UI:

1. Create forms for each mathematical topic
2. Reference calculation classes from `MathsEngine.Core`
3. Handle user input and display results using WinForms controls
4. All calculation logic is already available in the Core library

### Testing

Tests are organized in the `MathsEngine.Tests` project. To add tests for new functionality:

1. Create a test class matching the module structure
2. Reference `MathsEngine.Core` (tests only test core logic, not UI)
3. Test calculation accuracy against known mathematical results
4. Test edge cases (zero values, invalid inputs, boundary conditions)
5. Verify custom exceptions are thrown correctly

Run tests with:
```bash
dotnet test
```

## Design Rationale

### Why Multiple Projects?
The solution is split into:
- **Core**: Pure calculation logic, no UI dependencies
- **CLI**: Console-specific UI implementation
- **WinForms**: Windows Forms UI (future development)
- **Tests**: Unit tests for core logic

This allows the same calculation logic to be used by different interfaces without duplication.

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

## Project Status

### Current State
- ✅ **MathsEngine.Core**: Complete - all calculation logic extracted and UI-independent
- ✅ **MathsEngine.CLI**: Complete - fully functional console interface
- ⚠️ **MathsEngine.WinForms**: Stub/placeholder - ready for development
- ⚠️ **MathsEngine** (legacy): Deprecated - kept for reference, use MathsEngine.CLI instead

### Limitations

- WinForms interface not yet implemented (structure in place)
- No graphical plotting or interactive visualization
- No persistent storage of calculation history
- Limited to numeric computation (no symbolic algebra or equation solving)
- Matrix operations currently support 2×2 determinants only

## Migration Guide

If you were using the original `MathsEngine` project:

1. **For CLI usage**: Use `MathsEngine.CLI` instead - it provides the exact same console interface
2. **For library usage**: Reference `MathsEngine.Core` - all calculation classes are in the same namespaces
3. **For testing**: Tests now reference `MathsEngine.Core` only

## License

MIT License (see LICENSE file)

## Repository

https://github.com/BlueHawk278/Maths-Engine