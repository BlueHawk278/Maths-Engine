# Utilities Module

## Overview

The Utilities (Utils) module provides foundational support services used throughout the Maths Engine application. This module contains input parsing, validation, error display, and custom exception definitions.

**Key Components**:
- **Parsing** - Input validation and conversion utilities
- **Exceptions** - Custom exception hierarchy for domain-specific errors
- **Display** - Result and error formatting utilities

**Design Principle**: These utilities are application-wide services that promote code reuse and consistency across all modules.

---

## Module Structure

```
Utils/
├── Parsing.cs          # Input parsing and validation
├── Exceptions.cs       # Custom exception definitions
├── Display.cs          # Result formatting
└── ErrorDisplay.cs     # Error message formatting
```

---

## 🔍 Parsing

### Purpose
Provide robust input parsing and validation for console applications, with graceful error handling and user-friendly prompts.

### Classes

#### `Parsing` (Static Class)

**Namespace**: `MathsEngine.Utils`

**Key Responsibilities**:
- Parse user input from console
- Validate input types (int, double, enum)
- Handle nullable types for optional inputs
- Provide retry loops for invalid input

---

### Methods

#### 1. `GetNullableDoubleInput(string prompt)`
Prompts for a double value that can be null (representing "skip" or "unknown").

**Parameters**:
- `prompt` (`string`) - Message to display to user

**Returns**: `double?` - The parsed value, or `null` if user presses Enter without typing

**Throws**:
- `ArgumentException` - If input cannot be parsed as a double

**Example**:
```csharp
using MathsEngine.Utils;

double? value = Parsing.GetNullableDoubleInput("Enter a value (or press Enter to skip): ");

if (value.HasValue)
    Console.WriteLine($"You entered: {value.Value}");
else
    Console.WriteLine("No value entered");
```

**Use Case**: Perfect for calculations where certain values are unknown:
```csharp
double? force = Parsing.GetNullableDoubleInput("Enter force (or leave blank): ");
double? mass = Parsing.GetNullableDoubleInput("Enter mass: ");
double? acceleration = Parsing.GetNullableDoubleInput("Enter acceleration (or leave blank): ");

// Calculate whichever value is null
```

---

#### 2. `GetDoubleInput(string prompt)`
Prompts for a required double value with retry loop on invalid input.

**Parameters**:
- `prompt` (`string`) - Message to display to user

**Returns**: `double` - The parsed value (guaranteed to be valid)

**Example**:
```csharp
double sideLength = Parsing.GetDoubleInput("Enter side length: ");
// Keeps prompting until valid double is entered
```

**Behavior**:
- If user enters invalid input (e.g., "abc"), displays error and re-prompts
- Continues until valid double is provided
- Cannot return null - always returns a valid value

---

#### 3. `GetIntInput(string prompt)`
Prompts for a required integer value with retry loop on invalid input.

**Parameters**:
- `prompt` (`string`) - Message to display to user

**Returns**: `int` - The parsed value (guaranteed to be valid)

**Example**:
```csharp
int rows = Parsing.GetIntInput("Enter number of rows: ");
int cols = Parsing.GetIntInput("Enter number of columns: ");

var matrix = new MatrixBase(rows, cols);
```

---

#### 4. `GetMenuInput(string prompt, int maxNum)`
Prompts for a menu selection, validating the input is within range [1, maxNum].

**Parameters**:
- `prompt` (`string`) - Message to display to user
- `maxNum` (`int`) - Maximum valid option number

**Returns**: `int` - The selected menu option (guaranteed to be 1 ≤ value ≤ maxNum)

**Example**:
```csharp
Console.WriteLine("1. Option A");
Console.WriteLine("2. Option B");
Console.WriteLine("3. Option C");

int choice = Parsing.GetMenuInput("Select an option: ", 3);

switch (choice)
{
    case 1: // Option A
        break;
    case 2: // Option B
        break;
    case 3: // Option C
        break;
}
```

**Behavior**:
- Rejects input < 1 or > maxNum
- Rejects non-integer input
- Keeps prompting until valid selection

---

#### 5. `GetSideType(string prompt)`
Prompts for a trigonometry side type (Opposite, Adjacent, Hypotenuse).

**Parameters**:
- `prompt` (`string`) - Message to display to user

**Returns**: `SideType` - The selected side type enum value

**Example**:
```csharp
SideType knownSide = Parsing.GetSideType("Which side do you know? ");
SideType sideToFind = Parsing.GetSideType("Which side do you want to find? ");

double result = Trigonometry.CalculateMissingSide(
    knownSideLength: 10,
    angle: 30,
    knownSideType: knownSide,
    sideToFind: sideToFind
);
```

**Accepted Inputs** (case-insensitive):
- "Opposite" or "opposite" → `SideType.Opposite`
- "Adjacent" or "adjacent" → `SideType.Adjacent`
- "Hypotenuse" or "hypotenuse" → `SideType.Hypotenuse`

---

## ⚠️ Custom Exceptions

### Purpose
Provide domain-specific exception types with meaningful names and messages, making error handling clearer and more precise.

### Exception Hierarchy

All custom exceptions inherit from `System.Exception` and are defined in `MathsEngine.Utils`.

---

### General Exceptions

#### `NullInputException`
Thrown when required input is null or empty.

**Constructors**:
```csharp
public NullInputException()
public NullInputException(string message)
```

**Default Message**: "Values entered must not be null"

**Example**:
```csharp
public static double Calculate(double? value)
{
    if (value is null)
        throw new NullInputException();
    
    return value.Value * 2;
}
```

---

#### `NullValuesException`
Thrown when too many values are null for a calculation to proceed.

**Default Message**: "Too many null values"

**Example**:
```csharp
if (missingCount > 1)
    throw new NullValuesException("Must provide at least 2 out of 3 values");
```

---

### Pure Mathematics Exceptions

#### `NegativeSideLengthException`
Thrown when a side length is negative or zero.

**Default Message**: "Side lengths must be positive."

**Example**:
```csharp
if (sideLength <= 0)
    throw new NegativeSideLengthException();
```

---

#### `HypotenuseNotLongestSideException`
Thrown when the hypotenuse is not the longest side in a right triangle.

**Default Message**: "Hypotenuse must be the longest side"

**Example**:
```csharp
if (knownSide >= hypotenuse)
    throw new HypotenuseNotLongestSideException();
```

---

#### `AcuteAngleException`
Thrown when an angle is not in the valid range (0°, 90°).

**Default Message**: "Angle must be between 0 and 90 degrees"

**Example**:
```csharp
if (angle <= 0 || angle >= 90)
    throw new AcuteAngleException();
```

---

#### `DuplicateSideException`
Thrown when the same side is specified twice in a trigonometry calculation.

**Default Message**: "Known side and the side to find cannot be the same"

**Example**:
```csharp
if (knownSideType == sideToFind)
    throw new DuplicateSideException();
```

---

#### `IncompatibleMatrixAdditionException`
Thrown when attempting to add matrices with different dimensions.

**Default Message**: "Matrices can't be added, they are not the same size"

**Example**:
```csharp
if (matrix1.NumRows != matrix2.NumRows || matrix1.NumCols != matrix2.NumCols)
    throw new IncompatibleMatrixAdditionException();
```

---

#### `IncompatibleMatrixSubtractionException`
Thrown when attempting to subtract matrices with different dimensions.

**Default Message**: "Matrices can't be subtracted, they are not the same size"

---

#### `IncompatibleMatrixMultiplicationException`
Thrown when matrix dimensions are incompatible for multiplication.

**Default Message**: "Cannot multiply these matrices"

**Example**:
```csharp
if (matrix1.NumCols != matrix2.NumRows)
    throw new IncompatibleMatrixMultiplicationException();
```

---

#### `NotSquareMatrixException`
Thrown when a square matrix is required but a non-square matrix is provided.

**Example**:
```csharp
if (matrix.NumRows != matrix.NumCols)
    throw new NotSquareMatrixException("Determinant requires square matrix");
```

---

### Statistics Exceptions

#### `ListsNotSameSizeException`
Thrown when two related lists have different lengths.

**Default Message**: "Inputs must have the same amount of data points"

**Example**:
```csharp
if (values.Count != frequencies.Count)
    throw new ListsNotSameSizeException();
```

---

#### `InsufficientDataException`
Thrown when there aren't enough data points for a calculation.

**Default Message**: "There is insufficient input to perform a calculation"

**Example**:
```csharp
if (dataPoints.Count < 2)
    throw new InsufficientDataException("Need at least 2 data points for correlation");
```

---

#### `EmptyDataSetException`
Thrown when a dataset is empty.

**Example**:
```csharp
if (data.Count == 0)
    throw new EmptyDataSetException();
```

---

#### `InvalidFrequencyException`
Thrown when a frequency value is negative.

**Example**:
```csharp
if (frequency < 0)
    throw new InvalidFrequencyException();
```

---

#### `InvalidClassIntervalFormatException`
Thrown when a class interval string is in incorrect format.

**Expected Format**: "lower-upper" (e.g., "10-20")

**Example**:
```csharp
if (!interval.Contains("-"))
    throw new InvalidClassIntervalFormatException();
```

---

### Mechanics Exceptions

#### `NullMassException`
Thrown when mass is zero or negative.

**Default Message**: "Mass must be a positive number"

**Example**:
```csharp
if (mass <= 0)
    throw new NullMassException();
```

---

## 🖥️ Display Utilities

### Purpose
Provide consistent formatting for results and error messages throughout the application.

---

### `Display` (Static Class)

**Namespace**: `MathsEngine.Utils`

#### Methods

##### `DisplayResult(Dictionary<string, double?> resultDict)`
Displays calculation results in a formatted table.

**Parameters**:
- `resultDict` - Dictionary mapping variable names to values

**Example**:
```csharp
using MathsEngine.Utils;

var results = new Dictionary<string, double?>
{
    { "Force", 100.5 },
    { "Mass", 25.0 },
    { "Acceleration", null }  // Not calculated
};

Display.DisplayResult(results);
```

**Output**:
```
#----- Calculation Result -----#
Force: 100.50
Mass: 25.00
Acceleration: Not Calculated
```

---

### `ErrorDisplay` (Static Class)

**Namespace**: `MathsEngine.Utils`

#### Methods

##### `ShowError(string message)`
Displays an error message in red text, then resets console color.

**Parameters**:
- `message` (`string`) - The error message to display

**Example**:
```csharp
using MathsEngine.Utils;

try
{
    double result = PythagorasTheorem.CalculateHypotenuse(-3, 4);
}
catch (NegativeSideLengthException ex)
{
    ErrorDisplay.ShowError(ex.Message);
}
```

**Output** (in red):
```
Error: Side lengths must be positive.
```

---

##### `ShowValidationError()`
Displays a generic validation error message.

**Example**:
```csharp
catch (FormatException)
{
    ErrorDisplay.ShowValidationError();
}
```

**Output** (in red):
```
Error: Invalid input. Please enter valid numbers.
```

---

## Usage Examples

### Example 1: Comprehensive Input Validation
```csharp
using MathsEngine.Utils;
using MathsEngine.Modules.Pure.PythagorasTheorem;

try
{
    // Get inputs with validation
    double? sideA = Parsing.GetNullableDoubleInput("Enter side A: ");
    double? sideB = Parsing.GetNullableDoubleInput("Enter side B: ");
    
    // Perform calculation
    double hypotenuse = PythagorasTheorem.CalculateHypotenuse(sideA, sideB);
    
    // Display result
    Console.WriteLine($"\nHypotenuse: {hypotenuse:F2}");
}
catch (NullInputException)
{
    ErrorDisplay.ShowError("Both sides must be provided");
}
catch (NegativeSideLengthException)
{
    ErrorDisplay.ShowError("Side lengths cannot be negative");
}
```

### Example 2: Menu-Driven Application
```csharp
using MathsEngine.Utils;

while (true)
{
    Console.Clear();
    Console.WriteLine("=== Main Menu ===");
    Console.WriteLine("1. Pure Maths");
    Console.WriteLine("2. Statistics");
    Console.WriteLine("3. Mechanics");
    Console.WriteLine("4. Exit");
    
    int choice = Parsing.GetMenuInput("Select option: ", 4);
    
    switch (choice)
    {
        case 1:
            PureMenu();
            break;
        case 2:
            StatisticsMenu();
            break;
        case 3:
            MechanicsMenu();
            break;
        case 4:
            return;  // Exit
    }
}
```

### Example 3: Exception Handling Hierarchy
```csharp
using MathsEngine.Utils;
using MathsEngine.Modules.Pure.Matrices;

try
{
    int rows1 = Parsing.GetIntInput("Matrix 1 - Rows: ");
    int cols1 = Parsing.GetIntInput("Matrix 1 - Columns: ");
    var matrix1 = new MatrixBase(rows1, cols1);
    matrix1.PopulateMatrix();
    
    int rows2 = Parsing.GetIntInput("Matrix 2 - Rows: ");
    int cols2 = Parsing.GetIntInput("Matrix 2 - Columns: ");
    var matrix2 = new MatrixBase(rows2, cols2);
    matrix2.PopulateMatrix();
    
    var result = MatrixCalculator.AddMatrix(matrix1, matrix2);
    
    Console.WriteLine("Result:");
    for (int i = 0; i < result.GetLength(0); i++)
    {
        for (int j = 0; j < result.GetLength(1); j++)
        {
            Console.Write($"{result[i, j]:F2} ");
        }
        Console.WriteLine();
    }
}
catch (NullInputException)
{
    ErrorDisplay.ShowError("Please provide values for all matrix elements");
}
catch (IncompatibleMatrixAdditionException)
{
    ErrorDisplay.ShowError("Matrices must be the same size to add them");
}
catch (FormatException)
{
    ErrorDisplay.ShowError("Invalid input format. Please enter numbers only");
}
catch (Exception ex)
{
    ErrorDisplay.ShowError($"An unexpected error occurred: {ex.Message}");
}
```

### Example 4: Type-Safe Enum Input
```csharp
using MathsEngine.Utils;
using MathsEngine.Modules.Pure.Trigonometry;

Console.WriteLine("Trigonometry Calculator");
Console.WriteLine("Available sides: Opposite, Adjacent, Hypotenuse");
Console.WriteLine();

SideType knownSide = Parsing.GetSideType("Which side do you know? ");
double length = Parsing.GetDoubleInput($"Enter {knownSide} length: ");
double angle = Parsing.GetDoubleInput("Enter the angle in degrees: ");

Console.WriteLine();
SideType sideToFind = Parsing.GetSideType("Which side do you want to find? ");

try
{
    double result = Trigonometry.CalculateMissingSide(
        knownSideLength: length,
        angle: angle,
        knownSideType: knownSide,
        sideToFind: sideToFind
    );
    
    Console.WriteLine($"\n{sideToFind} = {result:F2} units");
}
catch (DuplicateSideException)
{
    ErrorDisplay.ShowError("You cannot find the side you already know!");
}
catch (AcuteAngleException)
{
    ErrorDisplay.ShowError("Angle must be between 0 and 90 degrees");
}
```

### Example 5: Graceful Degradation with Nullable Inputs
```csharp
using MathsEngine.Utils;
using MathsEngine.Modules.Mechanics.UniformAcceleration;

Console.WriteLine("SUVAT Equation Solver");
Console.WriteLine("Leave unknowns blank by pressing Enter\n");

double? s = Parsing.GetNullableDoubleInput("Displacement (s) in m: ");
double? u = Parsing.GetNullableDoubleInput("Initial velocity (u) in m/s: ");
double? v = Parsing.GetNullableDoubleInput("Final velocity (v) in m/s: ");
double? a = Parsing.GetNullableDoubleInput("Acceleration (a) in m/s²: ");
double? t = Parsing.GetNullableDoubleInput("Time (t) in s: ");

// Count how many values are missing
int missingCount = 
    (s is null ? 1 : 0) +
    (u is null ? 1 : 0) +
    (v is null ? 1 : 0) +
    (a is null ? 1 : 0) +
    (t is null ? 1 : 0);

if (missingCount > 2)
{
    ErrorDisplay.ShowError("Too many unknowns. Provide at least 3 values.");
    return;
}

try
{
    // Try different equations based on what's missing
    if (s is null && u.HasValue && v.HasValue && t.HasValue)
    {
        s = UniformAccelerationCalculator.CalculateSUVT(s, u, v, t);
        Console.WriteLine($"\nDisplacement: {s:F2} m");
    }
    else if (v is null && u.HasValue && a.HasValue && t.HasValue)
    {
        v = UniformAccelerationCalculator.CalculateVUAT(v, u, a, t);
        Console.WriteLine($"\nFinal velocity: {v:F2} m/s");
    }
    // ... other equation combinations
}
catch (InvalidOperationException ex)
{
    ErrorDisplay.ShowError(ex.Message);
}
```

---

## Common Patterns

### Pattern 1: Input-Validation-Calculation-Display
```csharp
// 1. Input (with validation)
double? value1 = Parsing.GetNullableDoubleInput("Enter value 1: ");
double? value2 = Parsing.GetNullableDoubleInput("Enter value 2: ");

try
{
    // 2. Validation (happens in calculation method)
    // 3. Calculation
    double result = SomeCalculator.Calculate(value1, value2);
    
    // 4. Display
    Console.WriteLine($"Result: {result:F2}");
}
catch (CustomException ex)
{
    // 5. Error Display
    ErrorDisplay.ShowError(ex.Message);
}
```

### Pattern 2: Menu Loop with Validation
```csharp
while (true)
{
    Console.Clear();
    Console.WriteLine("Menu Title");
    Console.WriteLine("1. Option 1");
    Console.WriteLine("2. Option 2");
    Console.WriteLine("3. Back");
    
    int choice = Parsing.GetMenuInput("Input: ", 3);
    
    switch (choice)
    {
        case 1:
            HandleOption1();
            break;
        case 2:
            HandleOption2();
            break;
        case 3:
            return;  // Exit menu
    }
    
    Console.WriteLine("\nPress any key to continue...");
    Console.ReadKey();
}
```

### Pattern 3: Try-Multiple-Catches for Specific Errors
```csharp
try
{
    // Attempt calculation
    var result = PerformCalculation(inputs);
    DisplaySuccess(result);
}
catch (NullInputException)
{
    ErrorDisplay.ShowError("Please provide all required values");
}
catch (NegativeSideLengthException)
{
    ErrorDisplay.ShowError("Lengths must be positive numbers");
}
catch (IncompatibleMatrixAdditionException)
{
    ErrorDisplay.ShowError("Matrices must have matching dimensions");
}
catch (FormatException)
{
    ErrorDisplay.ShowError("Invalid number format");
}
catch (Exception ex)
{
    // Catch-all for unexpected errors
    ErrorDisplay.ShowError($"Unexpected error: {ex.Message}");
}
finally
{
    // Always executed - good for cleanup
    Console.WriteLine("\nPress Enter to return to menu...");
    Console.ReadLine();
}
```

---

## Design Notes

### Why Static Classes for Utilities?
Utility methods are **stateless helper functions** that don't require object state. Making them static:
- Avoids unnecessary object instantiation
- Makes them easily accessible from anywhere
- Clearly signals they are pure utility functions

### Why Custom Exceptions Instead of Standard Ones?
Custom exceptions provide:
- **Self-documenting code**: `HypotenuseNotLongestSideException` is clearer than `ArgumentException("Hypotenuse must be longest side")`
- **Precise error handling**: Can catch specific mathematical errors separately
- **Better stack traces**: Exception name immediately shows what went wrong
- **Domain vocabulary**: Uses mathematical terms students understand

### Why Nullable Input Methods?
Nullable inputs (`double?`) elegantly represent "optional" or "unknown" values:
- `null` means "this is what I want to calculate" or "skip this input"
- Type-safe (compiler enforces null-checking)
- Natural mapping to mathematical problem-solving (find the unknown)

### Why Retry Loops in Input Methods?
Retry loops provide better user experience:
- **Forgiving**: Users can correct mistakes without restarting
- **Educational**: Shows what valid input looks like
- **Robust**: Prevents crashes from bad input
- **Appropriate for console apps**: GUI would use different validation approach

### Error Message Guidelines
All error messages should:
1. **Be user-friendly**: Avoid technical jargon where possible
2. **Explain what's wrong**: Not just "error" but why it failed
3. **Suggest a fix**: Where appropriate, hint at the solution
4. **Use consistent formatting**: All start with "Error:" in red text

---

## Exception Quick Reference Table

| Exception | Module | Thrown When... | Default Message |
|-----------|--------|----------------|-----------------|
| `NullInputException` | General | Required value is null | "Values entered must not be null" |
| `NullValuesException` | General | Too many nulls to calculate | "Too many null values" |
| `NegativeSideLengthException` | Pure | Side length ≤ 0 | "Side lengths must be positive." |
| `HypotenuseNotLongestSideException` | Pure | Hypotenuse not longest | "Hypotenuse must be the longest side" |
| `AcuteAngleException` | Pure | Angle not in (0°, 90°) | "Angle must be between 0 and 90 degrees" |
| `DuplicateSideException` | Pure | Same side twice | "Known side and the side to find cannot be the same" |
| `IncompatibleMatrixAdditionException` | Pure | Matrix size mismatch | "Matrices can't be added, they are not the same size" |
| `IncompatibleMatrixSubtractionException` | Pure | Matrix size mismatch | "Matrices can't be subtracted, they are not the same size" |
| `IncompatibleMatrixMultiplicationException` | Pure | Invalid dimensions | "Cannot multiply these matrices" |
| `NotSquareMatrixException` | Pure | Need square matrix | Custom message |
| `ListsNotSameSizeException` | Statistics | Lists different lengths | "Inputs must have the same amount of data points" |
| `InsufficientDataException` | Statistics | Too few data points | "There is insufficient input to perform a calculation" |
| `EmptyDataSetException` | Statistics | Empty dataset | No message |
| `InvalidFrequencyException` | Statistics | Negative frequency | No message |
| `InvalidClassIntervalFormatException` | Statistics | Bad interval format | No message |
| `NullMassException` | Mechanics | Mass ≤ 0 | "Mass must be a positive number" |

---

## Testing Utilities

### How to Test Exception Throwing
```csharp
using Xunit;
using MathsEngine.Utils;

public class ExceptionTests
{
    [Fact]
    public void NegativeSideLength_ThrowsCorrectException()
    {
        // Arrange
        double? negative = -5;
        double? positive = 10;
        
        // Act & Assert
        var exception = Assert.Throws<NegativeSideLengthException>(() =>
            PythagorasTheorem.CalculateHypotenuse(negative, positive)
        );
        
        Assert.Equal("Side lengths must be positive.", exception.Message);
    }
}
```

### How to Test Parsing (Manually)
Since `Parsing` methods read from console, automated testing is difficult. Manual testing approach:

**Test Script**:
1. Valid input: Enter "42" → Should return 42.0
2. Invalid input: Enter "abc" → Should re-prompt
3. Empty input (for nullable): Press Enter → Should return null
4. Decimal input: Enter "3.14159" → Should return 3.14159
5. Negative input: Enter "-5" → Should accept (validation happens later)

---

## Extension Points

### Adding a New Exception Type
```csharp
// In Utils/Exceptions.cs

/// <summary>
/// Exception thrown when [describe condition].
/// </summary>
public class YourNewException : Exception
{
    public YourNewException() : base("Default message") { }
    public YourNewException(string message) : base(message) { }
}
```

### Adding a New Parsing Method
```csharp
// In Utils/Parsing.cs

public static YourType GetYourTypeInput(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine()?.Trim();
        
        if (YourType.TryParse(input, out YourType result))
            return result;
        
        Console.WriteLine("Invalid input. Try again.");
    }
}
```

---

## Best Practices

### ✅ DO:
- Use `GetNullableDoubleInput()` when a value is optional or unknown
- Use `GetDoubleInput()` when a value is required and must be provided
- Use `GetMenuInput()` for menu selections to ensure valid range
- Catch specific exceptions before general `Exception`
- Use `ErrorDisplay.ShowError()` for consistent error formatting
- Provide helpful error messages that guide the user

### ❌ DON'T:
- Use `Console.ReadLine()` directly without validation
- Use generic exceptions when custom ones exist
- Display errors with `Console.WriteLine()` - use `ErrorDisplay`
- Catch exceptions and silently ignore them
- Parse input without try-catch or retry logic

---

## Integration with Other Modules

### Menu Layer
Menus use `Parsing` for all user input:
```csharp
// Menu/Pure/PythagorasMenu.cs
double? sideA = Parsing.GetNullableDoubleInput("Enter side A: ");
```

### Calculation Modules
Calculations throw custom exceptions:
```csharp
// Modules/Pure/PythagorasTheorem.cs
if (a <= 0 || b <= 0)
    throw new NegativeSideLengthException();
```

### Menu Error Handling
Menus catch exceptions and use `ErrorDisplay`:
```csharp
// Menu/Pure/PythagorasMenu.cs
catch (NegativeSideLengthException)
{
    ErrorDisplay.ShowError("Error: Cannot have negative sides.");
}
```

**Complete Flow**:
```
User Input → Parsing.GetDoubleInput()
          → Calculation Method (throws exception if invalid)
          → Menu catches exception
          → ErrorDisplay.ShowError()
          → User sees red error message
          → Menu continues/retries
```

---

## Related Modules

- **Menu/** - Primary consumer of parsing utilities
- **Modules/** - Throws custom exceptions during calculations
- **Explanations/** - May use exceptions for validation

---

## Testing

While `Parsing` methods are difficult to unit test (they read from console), the exception types are fully testable.

Tests for exceptions can be found in:
- `MathsEngine.Tests/PureTests/` - Tests that exceptions are thrown correctly
- `MathsEngine.Tests/StatisticsTests/` - Validates exception conditions
- `MathsEngine.Tests/MechanicsTests/` - Confirms error handling

**Exception Test Coverage**: Complete  
**All custom exceptions are tested**: Yes

---

## Summary

The Utils module provides the foundation for:
- **Input Handling**: Robust, user-friendly console input with validation
- **Error Communication**: Clear, consistent error messages using custom exceptions
- **Code Reuse**: Shared utilities used across all modules

**Key Principle**: Utilities should be simple, reliable, and widely reusable.

---