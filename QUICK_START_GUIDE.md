# Quick-Start Implementation Guide

This guide provides step-by-step instructions for implementing the highest-impact improvements to your Maths Engine project. Each section can be completed independently.

## Table of Contents
1. [Fix Nullable Warnings (30 minutes)](#1-fix-nullable-warnings)
2. [Standardize Method Naming (15 minutes)](#2-standardize-method-naming)
3. [Fix Failing Tests (1 hour)](#3-fix-failing-tests)
4. [Create Error Display Utility (30 minutes)](#4-create-error-display-utility)
5. [Add Input Validation Improvements (45 minutes)](#5-add-input-validation-improvements)
6. [Add Constants File (20 minutes)](#6-add-constants-file)

---

## 1. Fix Nullable Warnings
**Time Required**: 30 minutes  
**Impact**: High - Improves code safety and removes compiler warnings

### Step 1: Update Parsing.cs

**File**: `MathsEngine/Utils/Parsing.cs`

```csharp
// Line 7: Add nullable annotation to GetNullableDoubleInput
public static double? GetNullableDoubleInput(string prompt)
{
    Console.Write(prompt);
    string? input = Console.ReadLine()?.Trim();  // Add ? here

    if (string.IsNullOrEmpty(input))
        return null;

    if (double.TryParse(input, out double value))
        return value;

    throw new ArgumentException("Invalid number entered.");
}

// Lines 21-32: Update GetDoubleInput
public static double GetDoubleInput(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine()?.Trim();  // Add ? here

        if (!string.IsNullOrEmpty(input) && double.TryParse(input, out double value))
            return value;
            
        Console.WriteLine("Invalid input. Try again");
    }
}

// Lines 34-45: Update GetIntInput
public static int GetIntInput(string prompt)
{
    while (true)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine()?.Trim();  // Add ? here

        if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int result))
            return result;
            
        Console.WriteLine("Invalid input. Try again");
    }
}

// Lines 62-77: Update GetSideType
public static SideType GetSideType(string prompt)
{
    while (true)
    {
        Console.WriteLine(prompt);
        string? input = Console.ReadLine()?.Trim();  // Add ? here

        if (input == "Hypotenuse" || input == "hypotenuse")
            return SideType.Hypotenuse;
        if (input == "Opposite" || input == "opposite")
            return SideType.Opposite;
        if (input == "Adjacent" || input == "adjacent")
            return SideType.Adjacent;
            
        Console.WriteLine("You have not entered a valid side. Try Again");
    }
}
```

### Step 2: Update ContinuousTableCalculator.cs

**File**: `MathsEngine/Modules/Statistics/Dispersion/ContinuousTableCalculator.cs`

```csharp
// Line 16: Initialize the field
private List<double> _midpoints = new List<double>();  // Add = new List<double>()
```

### Step 3: Update BivariateAnalysisCalculator.cs

**File**: `MathsEngine/Modules/Statistics/BivariateAnalysis/BivariateAnalysisCalculator.cs`

```csharp
// Add nullable annotations to properties (around line 30)
public string CorrelationString { get; set; } = string.Empty;
public List<double> Ranks1 { get; set; } = new List<double>();
public List<double> Ranks2 { get; set; } = new List<double>();
public List<double> Difference { get; set; } = new List<double>();
public List<double> DifferenceSquared { get; set; } = new List<double>();
```

### Step 4: Test the changes
```bash
dotnet build
# Should see fewer nullable warnings
```

---

## 2. Standardize Method Naming
**Time Required**: 15 minutes  
**Impact**: Medium - Improves code consistency

### Files to Update:

1. **MathsEngine/Menu/Pure/PythagorasMenu.cs**
   - Change `public static void menu()` → `public static void Menu()`
   - Line 8

2. **MathsEngine/Menu/Pure/MatrixMenu.cs**
   - Change `public static void menu()` → `public static void Menu()`

3. **MathsEngine/Menu/Pure/TrigonometryMenu.cs**
   - Change method name to `Menu()`

4. **MathsEngine/Menu/Mechanics/UniformAccelerationMenu.cs**
   - Change `public static void menu()` → `public static void Menu()`

5. **MathsEngine/Menu/Mechanics/NewtonsLawsMenu.cs**
   - Change `public static void menu()` → `public static void Menu()`

6. **MathsEngine/Menu/Statistics/DispersionMenu.cs**
   - Change `public static void menu()` → `public static void Menu()`

### Update Menu.cs to call renamed methods:

**File**: `MathsEngine/Menu/Menu.cs`

```csharp
// Line 51
PythagorasMenu.Menu();  // Change from .menu()

// Line 54
TrigonometryMenu.Menu();  // Change from .Menu() if needed

// Line 57
MatrixMenu.Menu();  // Change from .menu()

// Line 77
UniformAccelerationMenu.Menu();  // Change from .menu()

// Line 80
NewtonsLawsMenu.Menu();  // Change from .menu()

// Line 103
DispersionMenu.Menu();  // Change from .menu()
```

### Test:
```bash
dotnet build
dotnet run --project MathsEngine/MathsEngine.csproj
# Navigate through menus to ensure they still work
```

---

## 3. Fix Failing Tests
**Time Required**: 1 hour  
**Impact**: High - Ensures code reliability

### Fix 1: NewtonsLawsCalculator Exception Types

**File**: `MathsEngine/Modules/Mechanics/Dynamics/NewtonsLawsCalculator.cs`

The tests expect `NullValuesException` but the code throws `NullInputException`. Update the code:

```csharp
// Line 19-27: Update CalculateFma method
public static double? CalculateFma(double? f, double? m, double? a)
{
    int missingCount =
        (f is null ? 1 : 0) +
        (m is null ? 1 : 0) +
        (a is null ? 1 : 0);

    if (missingCount == 0)
        throw new NullValuesException("Must be ONE missing value to perform the calculation");
        
    if (missingCount > 1)
        throw new NullValuesException("Too many missing values to perform the calculation");

    if (m <= 0)
        throw new NullMassException("Mass must be a positive number.");

    if (f is null) // F = m * a
        return m.Value * a.Value;

    if (m is null) // m = F / a
    {
        if (a.Value == 0)
            throw new DivideByZeroException("Acceleration cannot be zero when calculating mass.");
        return f.Value / a.Value;
    }

    if (a is null) // a = F / m
    {
        if (m.Value == 0)
            throw new DivideByZeroException("Mass cannot be zero when calculating acceleration.");
        return f.Value / m.Value;
    }

    throw new InvalidOperationException("Could not perform calculation with the provided values.");
}
```

### Fix 2: CheckValidCalculation Method

**File**: `MathsEngine/Modules/Mechanics/Dynamics/NewtonsLawsCalculator.cs`

```csharp
// Line 53-62: Update CheckValidCalculation
public static bool CheckValidCalculation(double? f, double? m, double? a)
{
    int missingCount =
        (f is null ? 1 : 0) +
        (m is null ? 1 : 0) +
        (a is null ? 1 : 0);

    if (missingCount > 0)
        throw new NullValuesException("All values must be provided to check a calculation.");

    if (m <= 0)
        throw new NullMassException("Mass must be a positive number.");

    return Math.Abs(f.Value - (m.Value * a.Value)) < 1e-9;
}
```

### Fix 3: Update Exception Tests

**File**: `MathsEngine.Tests/StatisticsTest/DispersionTests/ArrayOfNumbersDispersionTests.cs`

```csharp
// Line 12-13: Update test to expect correct exception
[Fact]
public void Constructor_EmptyList_ThrowsEmptyDataSetException()  // Rename test
{
    Assert.Throws<EmptyDataSetException>(() =>  // Change from NullInputException
        new ArrayOfNumbersCalculator(new List<double>()));
}
```

Apply similar changes to:
- `ContinuousTableDispersionTests.cs`
- `DiscreteTableDispersionTests.cs`

### Run Tests:
```bash
dotnet test
# Should now pass all tests
```

---

## 4. Create Error Display Utility
**Time Required**: 30 minutes  
**Impact**: High - Reduces code duplication significantly

### Step 1: Create New File

**File**: `MathsEngine/Utils/ErrorDisplay.cs`

```csharp
namespace MathsEngine.Utils
{
    /// <summary>
    /// Utility class for displaying error messages to the console with consistent formatting.
    /// </summary>
    public static class ErrorDisplay
    {
        /// <summary>
        /// Displays an error message in red text.
        /// </summary>
        /// <param name="message">The error message to display.</param>
        public static void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nError: {message}");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays a standard validation error message.
        /// </summary>
        public static void ShowValidationError()
        {
            ShowError("Invalid input. Please enter valid numbers.");
        }

        /// <summary>
        /// Displays an error message for invalid numeric input.
        /// </summary>
        public static void ShowInvalidNumberError()
        {
            ShowError("Invalid input. Please enter valid numbers for the side lengths.");
        }

        /// <summary>
        /// Displays a success message in green text.
        /// </summary>
        /// <param name="message">The success message to display.</param>
        public static void ShowSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{message}");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays an information message in cyan text.
        /// </summary>
        /// <param name="message">The information message to display.</param>
        public static void ShowInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n{message}");
            Console.ResetColor();
        }
    }
}
```

### Step 2: Update PythagorasMenu.cs to Use ErrorDisplay

**File**: `MathsEngine/Menu/Pure/PythagorasMenu.cs`

```csharp
// Add using statement at top
using MathsEngine.Utils;

// Update HandleFindHypotenuse method (lines 44-74)
private static void HandleFindHypotenuse()
{
    try
    {
        Console.Clear();
        double? sideA = Parsing.GetNullableDoubleInput("Enter side A: ");
        double? sideB = Parsing.GetNullableDoubleInput("Enter side B: ");

        double hypotenuse = PythagorasTheorem.CalculateHypotenuse(sideA, sideB);

        Console.WriteLine("\nHypotenuse: " + hypotenuse);
    }
    catch (FormatException)
    {
        ErrorDisplay.ShowInvalidNumberError();  // Use utility
    }
    catch (NullInputException)
    {
        ErrorDisplay.ShowInvalidNumberError();  // Use utility
    }
    catch (NegativeSideLengthException ex)
    {
        ErrorDisplay.ShowError(ex.Message);  // Use utility
    }
}

// Apply same pattern to HandleFindOtherSide and HandleCheckTheorem
```

### Step 3: Apply to Other Menus

Repeat the pattern above for:
- `MatrixMenu.cs`
- `TrigonometryMenu.cs`
- `NewtonsLawsMenu.cs`
- `UniformAccelerationMenu.cs`
- `DispersionMenu.cs`

### Test:
```bash
dotnet build
dotnet run --project MathsEngine/MathsEngine.csproj
# Test various error scenarios
```

---

## 5. Add Input Validation Improvements
**Time Required**: 45 minutes  
**Impact**: Medium - Improves user experience

### Update Parsing.cs with Better Error Handling

**File**: `MathsEngine/Utils/Parsing.cs`

```csharp
public static class Parsing
{
    private const int MAX_INPUT_LENGTH = 100;  // Prevent memory issues

    public static double? GetNullableDoubleInput(string prompt)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine()?.Trim();

        if (string.IsNullOrEmpty(input))
            return null;

        if (input.Length > MAX_INPUT_LENGTH)
            throw new ArgumentException($"Input too long. Maximum {MAX_INPUT_LENGTH} characters.");

        if (double.TryParse(input, out double value))
            return value;

        throw new ArgumentException("Invalid number entered. Please enter a valid decimal number.");
    }

    public static double GetDoubleInput(string prompt)
    {
        while (true)
        {
            try
            {
                Console.Write(prompt);
                string? input = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Input cannot be empty. Please try again.");
                    continue;
                }

                if (input.Length > MAX_INPUT_LENGTH)
                {
                    Console.WriteLine($"Input too long. Maximum {MAX_INPUT_LENGTH} characters. Please try again.");
                    continue;
                }

                if (double.TryParse(input, out double value))
                    return value;

                Console.WriteLine("Invalid number format. Please enter a valid decimal number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}. Please try again.");
            }
        }
    }

    public static int GetIntInput(string prompt)
    {
        while (true)
        {
            try
            {
                Console.Write(prompt);
                string? input = Console.ReadLine()?.Trim();

                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Input cannot be empty. Please try again.");
                    continue;
                }

                if (input.Length > MAX_INPUT_LENGTH)
                {
                    Console.WriteLine($"Input too long. Maximum {MAX_INPUT_LENGTH} characters. Please try again.");
                    continue;
                }

                if (int.TryParse(input, out int value))
                    return value;

                Console.WriteLine("Invalid integer format. Please enter a whole number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}. Please try again.");
            }
        }
    }

    public static int GetMenuInput(string prompt, int maxNum)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine()?.Trim();

            if (int.TryParse(input, out int value) && value >= 1 && value <= maxNum)
                return value;

            Console.WriteLine($"Invalid input. Please enter a number between 1 and {maxNum}.");
        }
    }

    public static SideType GetSideType(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string? input = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Input cannot be empty. Please try again.");
                continue;
            }

            // Case-insensitive comparison
            switch (input.ToLower())
            {
                case "hypotenuse":
                    return SideType.Hypotenuse;
                case "opposite":
                    return SideType.Opposite;
                case "adjacent":
                    return SideType.Adjacent;
                default:
                    Console.WriteLine("Invalid side type. Please enter 'Hypotenuse', 'Opposite', or 'Adjacent'.");
                    break;
            }
        }
    }
}
```

---

## 6. Add Constants File
**Time Required**: 20 minutes  
**Impact**: Medium - Improves maintainability

### Create Constants File

**File**: `MathsEngine/Utils/Constants.cs`

```csharp
namespace MathsEngine.Utils
{
    /// <summary>
    /// Mathematical constants used throughout the application.
    /// </summary>
    public static class MathConstants
    {
        /// <summary>
        /// Tolerance for floating-point equality comparisons.
        /// </summary>
        public const double EQUALITY_TOLERANCE = 1e-9;

        /// <summary>
        /// Default number of decimal places for display.
        /// </summary>
        public const int DEFAULT_DECIMAL_PLACES = 2;

        /// <summary>
        /// Maximum decimal places for precise calculations.
        /// </summary>
        public const int MAX_DECIMAL_PLACES = 6;
    }

    /// <summary>
    /// Menu configuration constants.
    /// </summary>
    public static class MenuConstants
    {
        public const int MAIN_MENU_OPTIONS = 4;
        public const int PURE_MENU_OPTIONS = 4;
        public const int MECHANICS_MENU_OPTIONS = 3;
        public const int STATISTICS_MENU_OPTIONS = 3;
        public const int PYTHAGORAS_MENU_OPTIONS = 4;
    }

    /// <summary>
    /// Input validation constants.
    /// </summary>
    public static class ValidationConstants
    {
        /// <summary>
        /// Maximum length for user input strings.
        /// </summary>
        public const int MAX_INPUT_LENGTH = 100;

        /// <summary>
        /// Maximum size for arrays/matrices to prevent memory issues.
        /// </summary>
        public const int MAX_ARRAY_SIZE = 10000;
    }

    /// <summary>
    /// Display formatting constants.
    /// </summary>
    public static class DisplayConstants
    {
        public const string MENU_SEPARATOR = "====================";
        public const string RESULT_HEADER = "#----- Calculation Result -----#";
    }
}
```

### Update Code to Use Constants

**Example 1**: `MathsEngine/Menu/Menu.cs`

```csharp
// Add using
using static MathsEngine.Utils.MenuConstants;

// Update method calls
int response = Parsing.GetMenuInput("Input: ", MAIN_MENU_OPTIONS);
```

**Example 2**: `MathsEngine/Modules/Pure/PythagorasTheorem/PythagorasTheorem.cs`

```csharp
// Add using
using static MathsEngine.Utils.MathConstants;

// Line 90: Update tolerance check
return Math.Abs((A * A + B * B) - (Hypotenuse * Hypotenuse)) < EQUALITY_TOLERANCE;
```

**Example 3**: `MathsEngine/Utils/Display.cs`

```csharp
// Add using
using static MathsEngine.Utils.MathConstants;
using static MathsEngine.Utils.DisplayConstants;

// Update methods
private static string FormatValue(double? value)
{
    if (value == null)
        return "Not Calculated";

    return value.Value.ToString($"F{DEFAULT_DECIMAL_PLACES}");
}

public static void DisplayResult(Dictionary<string, double?> ResultDict)
{
    Console.WriteLine(RESULT_HEADER);
    foreach (KeyValuePair<string, double?> kvp in ResultDict)
        Console.WriteLine($"{kvp.Key}: {FormatValue(kvp.Value)}");
}
```

---

## Testing Checklist

After implementing each improvement, test:

- [ ] Project builds without errors: `dotnet build`
- [ ] No nullable warnings (or significantly reduced)
- [ ] All tests pass: `dotnet test`
- [ ] Console app runs: `dotnet run --project MathsEngine/MathsEngine.csproj`
- [ ] Navigate through all menus
- [ ] Test valid calculations
- [ ] Test invalid inputs (error messages should be clear)
- [ ] Test edge cases (zero, negative numbers, empty inputs)

## Git Workflow

After completing each section:

```bash
# Stage changes
git add .

# Commit with descriptive message
git commit -m "Fix nullable warnings in Parsing.cs"

# Push to your branch
git push
```

## Summary

By following this guide, you will:

1. ✅ Eliminate nullable warnings
2. ✅ Standardize code style
3. ✅ Fix all failing tests
4. ✅ Reduce code duplication
5. ✅ Improve input validation
6. ✅ Make code more maintainable

**Total Time**: ~3-4 hours  
**Impact**: Significant improvement in code quality and maintainability

## Next Steps

After completing this guide, review:
- `CODE_IMPROVEMENTS.md` for more advanced refactoring
- `NEXT_STEPS.md` for feature additions and GUI development

Happy coding! 🚀
