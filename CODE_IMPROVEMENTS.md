# Code Improvement Recommendations

## Overview
This document provides comprehensive recommendations to improve code quality, maintainability, and consistency in the Maths Engine project. The recommendations are categorized by priority and focus area.

## 1. High Priority Improvements

### 1.1 Fix Nullable Reference Type Warnings
**Issue**: The project has `<Nullable>enable</Nullable>` in the .csproj but has numerous nullable warnings.

**Recommendations**:
- Add proper null checks or use nullable annotations (`?`) where appropriate
- In `Parsing.cs`: Handle nullable string returns from `Console.ReadLine()` properly
- In calculator classes: Ensure fields are initialized or marked as nullable

**Example Fix**:
```csharp
// Current (Parsing.cs line 10)
string input = Console.ReadLine()?.Trim();

// Improved
string? input = Console.ReadLine()?.Trim();
```

### 1.2 Standardize Naming Conventions
**Issue**: Inconsistent method naming (e.g., `menu()` vs `Menu()`)

**Recommendations**:
- Rename all `menu()` methods to `Menu()` to follow C# PascalCase convention
- Files affected:
  - `PythagorasMenu.cs`
  - `MatrixMenu.cs`
  - `UniformAccelerationMenu.cs`
  - `NewtonsLawsMenu.cs`
  - `DispersionMenu.cs`

### 1.3 Fix Failing Tests
**Issue**: 12 tests are currently failing, mainly due to:
- Wrong exception types being thrown
- Tests expecting `NullValuesException` but code throws `NullInputException`

**Recommendations**:
- Review and align exception types between implementation and tests
- Fix the `NewtonsLawsCalculator.CheckValidCalculation` method to return correct boolean values
- Update tests to match actual behavior or fix implementation to match test expectations

## 2. Code Quality Improvements

### 2.1 Reduce Code Duplication in Error Handling
**Issue**: Menu classes have repetitive try-catch blocks with identical error handling logic.

**Current Pattern** (repeated in multiple menus):
```csharp
catch (FormatException)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("\nError: Invalid input. Please enter valid numbers for the side lengths.");
    Console.ResetColor();
}
```

**Recommendation**: Create a utility class for error display:
```csharp
public static class ErrorDisplay
{
    public static void ShowError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\nError: {message}");
        Console.ResetColor();
    }

    public static void ShowValidationError()
    {
        ShowError("Invalid input. Please enter valid numbers.");
    }
}
```

### 2.2 Extract Common Menu Patterns
**Issue**: All menu classes follow similar patterns but duplicate code.

**Recommendation**: Create a base menu class or helper:
```csharp
public abstract class BaseMenu
{
    protected static void DisplayMenuHeader(string title)
    {
        Console.Clear();
        Console.WriteLine(title);
    }

    protected static void WaitForReturn()
    {
        Console.WriteLine("\nPress Enter to return...");
        Console.ReadLine();
    }

    protected static void ExecuteWithErrorHandling(Action action)
    {
        try
        {
            action();
        }
        catch (FormatException)
        {
            ErrorDisplay.ShowValidationError();
        }
        catch (Exception ex) when (ex is NullInputException || ex is NegativeSideLengthException)
        {
            ErrorDisplay.ShowError(ex.Message);
        }
    }
}
```

### 2.3 Improve Input Validation
**Issue**: Input parsing has inconsistent error handling.

**Recommendations**:
- `GetDoubleInput` and `GetIntInput` use infinite loops without proper error messages for invalid formats
- Add try-catch blocks to handle `Convert.ToDouble`/`Convert.ToInt32` exceptions
- Consider using `TryParse` consistently

**Improved Example**:
```csharp
public static double GetDoubleInput(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine()?.Trim();

        if (!string.IsNullOrEmpty(input) && double.TryParse(input, out double value))
            return value;
            
        Console.WriteLine("Invalid input. Please enter a valid number.");
    }
}
```

### 2.4 Add Missing XML Documentation
**Issue**: Some public methods lack XML documentation.

**Recommendation**: Add comprehensive XML comments to:
- All public calculator methods
- Menu entry points
- Exception classes without descriptions

**Example**:
```csharp
/// <summary>
/// Calculates the mean (average) of a list of numbers.
/// </summary>
/// <param name="values">The list of numbers to calculate the mean for.</param>
/// <returns>The arithmetic mean of the input values.</returns>
/// <exception cref="EmptyDataSetException">Thrown when the input list is empty.</exception>
public static double CalculateMean(List<double> values)
```

## 3. Architecture Improvements

### 3.1 Separate Concerns
**Issue**: Calculator classes mix business logic with display logic (e.g., `DisplayData()` methods).

**Recommendation**:
- Move all display logic to dedicated formatter or presenter classes
- Keep calculator classes focused on pure computation
- Consider introducing a Service layer between UI and calculation logic

**Example Structure**:
```
Modules/
  Statistics/
    Dispersion/
      Calculators/          # Pure calculation logic
      Presenters/           # Display/formatting logic
      Models/              # Data models
```

### 3.2 Use Dependency Injection
**Issue**: Static classes make testing difficult and reduce flexibility.

**Recommendation**:
- Convert static calculator classes to instance-based with interfaces
- Use constructor injection for dependencies
- This enables better unit testing and mocking

### 3.3 Introduce Constants
**Issue**: Magic numbers scattered throughout code (e.g., tolerance values, menu limits).

**Recommendation**: Create a constants file:
```csharp
public static class MathConstants
{
    public const double EQUALITY_TOLERANCE = 1e-9;
    public const int DEFAULT_DECIMAL_PLACES = 2;
}

public static class MenuConstants
{
    public const int PURE_MENU_OPTIONS = 4;
    public const int MECHANICS_MENU_OPTIONS = 3;
    public const int STATISTICS_MENU_OPTIONS = 3;
}
```

### 3.4 Exception Strategy
**Issue**: Inconsistent exception usage across modules.

**Recommendation**:
- Create a clear exception hierarchy
- Use more specific exceptions instead of generic `ArgumentException`
- Document when each exception type should be used

**Example**:
```csharp
// Base exceptions
public abstract class MathsEngineException : Exception { }

// Category-specific exceptions
public abstract class ValidationException : MathsEngineException { }
public abstract class CalculationException : MathsEngineException { }

// Specific exceptions
public class InvalidInputException : ValidationException { }
public class InsufficientDataException : CalculationException { }
```

## 4. Testing Improvements

### 4.1 Increase Test Coverage
**Current**: Good test coverage for core calculations
**Recommendation**: Add tests for:
- Edge cases in menu navigation
- Error handling paths
- Boundary conditions (very large/small numbers, zero, negative values)

### 4.2 Add Integration Tests
**Recommendation**: Create integration tests that:
- Test complete menu flows
- Verify end-to-end calculations through the UI layer
- Use a test framework like SpecFlow for BDD-style tests

### 4.3 Parameterized Tests
**Current**: Good use of `[Theory]` and `[InlineData]`
**Recommendation**: Expand parameterized tests to cover more edge cases

## 5. Code Style and Consistency

### 5.1 Formatting Consistency
**Recommendations**:
- Use consistent spacing in method declarations
- Align curly braces consistently
- Consider adding an `.editorconfig` file to enforce style rules

### 5.2 Use Modern C# Features
**Recommendations**:
- Use pattern matching where appropriate
- Consider using records for immutable data models
- Use null-coalescing operators (`??`, `??=`)
- Use expression-bodied members for simple properties/methods

**Examples**:
```csharp
// Instead of
if (value is null)
    throw new ArgumentNullException();

// Use
ArgumentNullException.ThrowIfNull(value); // .NET 6+

// Instead of multiple null checks
if (a is null || b is null || c is null)

// Use
if (a is null or b is null or c is null)
```

### 5.3 Method Length
**Issue**: Some methods are quite long (e.g., menu methods).

**Recommendation**:
- Break down methods longer than 30-40 lines
- Extract helper methods for better readability
- Each method should do one thing well

## 6. Performance Considerations

### 6.1 Avoid Unnecessary Conversions
**Issue**: Repeated use of `Convert.ToDouble()` on already-verified values.

**Recommendation**:
```csharp
// Instead of
double aSquared = Math.Pow(Convert.ToDouble(a), 2);

// Since a is already validated as double?, use:
double aSquared = Math.Pow(a.Value, 2);
```

### 6.2 Use Appropriate Data Structures
**Current**: Good use of `List<T>` for most collections
**Recommendation**: Consider `IReadOnlyList<T>` for collections that shouldn't be modified after creation

## 7. Security Considerations

### 7.1 Input Validation
**Current**: Good validation for numeric inputs
**Recommendation**: 
- Add maximum input length checks to prevent memory issues
- Validate array/matrix sizes before allocation
- Add timeouts for long-running calculations

### 7.2 Exception Messages
**Current**: Some exceptions expose internal details
**Recommendation**: Ensure exception messages don't leak sensitive information

## 8. Documentation

### 8.1 Inline Comments
**Current**: Minimal inline comments
**Recommendation**: Add comments for:
- Complex mathematical formulas
- Non-obvious business rules
- Performance-critical sections

### 8.2 README Updates
**Recommendation**: Update README.md to include:
- How to run tests
- How to build the project
- Contributing guidelines
- Code style guidelines

## Priority Implementation Order

1. **Quick Wins** (1-2 days):
   - Fix nullable warnings
   - Standardize naming conventions
   - Fix failing tests
   - Add missing XML documentation

2. **Medium Term** (3-5 days):
   - Extract error handling utility
   - Reduce code duplication in menus
   - Add constants for magic numbers
   - Improve input validation

3. **Long Term** (1-2 weeks):
   - Refactor menu system with base classes
   - Separate display logic from business logic
   - Introduce dependency injection
   - Add integration tests
   - Improve exception hierarchy

## Benefits of Implementation

- **Maintainability**: Easier to understand and modify code
- **Reliability**: Fewer bugs through better testing and validation
- **Scalability**: Easier to add new modules and features
- **Collaboration**: Consistent code style makes team development easier
- **Performance**: Small optimizations add up
- **User Experience**: Better error messages and input handling
