# Code Review and Future Development Roadmap

**Project:** Maths Engine  
**Review Date:** January 2026  
**Reviewer:** GitHub Copilot  

---

## Executive Summary

This document provides a comprehensive review of the Maths Engine codebase, focusing on the menu and calculator modules. It identifies current issues, suggests improvements, and outlines a strategic roadmap for future development targeting WPF, async/await, generics, delegates, and expanded mathematical features.

**Current State:**
- ✅ Console application with working mathematical calculators
- ✅ Covers Pure Maths, Mechanics, and Statistics
- ⚠️ 20 compiler warnings (nullable reference types, non-initialized fields)
- ⚠️ Multiple bugs and code quality issues identified
- ⚠️ Recursive menu navigation pattern (stack overflow risk)

---

## Part 1: Code Review Findings

### Critical Issues (Must Fix)

#### 🔴 **Menu Navigation - Stack Overflow Risk**
**Files Affected:** All menu files  
**Severity:** CRITICAL  

**Issue:**  
All menus use recursive calls to `MainMenu()` instead of loops, causing unlimited stack frame accumulation.

```csharp
// Current (BROKEN)
public static void PureMenu()
{
    // ... menu logic
    MainMenu(); // ← Recursive call, never returns
}

// Recommended Fix
public static void MainMenu()
{
    while (true)
    {
        // ... menu logic
        if (shouldExit) return;
    }
}
```

**Impact:** After ~1000-2000 menu navigations, the application will crash with StackOverflowException.

---

#### 🔴 **AverageCalculator - Null Check Bug**
**File:** `Modules/Statistics/AverageCalculator.cs`  
**Lines:** 17, 37, 148  
**Severity:** CRITICAL  

**Issue:**  
Null checks are performed AFTER `.Count`, which will throw NullReferenceException.

```csharp
// Current (BROKEN)
if (nums.Count == 0 || nums == null)  // ← Will crash if nums is null

// Recommended Fix
if (nums == null || nums.Count == 0)  // ← Check null FIRST
```

**Impact:** Application crashes when null collections are passed.

---

#### 🔴 **AverageCalculator - Quartile Calculation Bug**
**File:** `Modules/Statistics/AverageCalculator.cs`  
**Lines:** 155-159  
**Severity:** HIGH  

**Issue:**  
Q1 and Q3 calculations are reversed, producing incorrect statistical results.

```csharp
// Current (WRONG)
double Q1 = CalculateMedian(upperHalf);  // ← Should use lowerHalf
double Q3 = CalculateMedian(lowerHalf);  // ← Should use upperHalf

// Correct Implementation
double Q1 = CalculateMedian(lowerHalf);
double Q3 = CalculateMedian(upperHalf);
```

**Impact:** All quartile calculations return mathematically incorrect results.

---

#### 🔴 **UniformAccelerationCalculator - Exception Handling**
**File:** `Modules/Mechanics/UniformAcceleration/UniformAccelerationCalculator.cs`  
**Lines:** 90, 133, 181  
**Severity:** HIGH  

**Issue:**  
Throws generic `Exception` instead of specific exception types.

```csharp
// Current (BAD)
throw new Exception("Error message");

// Recommended
throw new InvalidOperationException("Error message");
```

**Impact:** Poor error handling, difficult debugging, violates .NET guidelines.

---

#### 🔴 **MatrixBase - Console Input in Constructor**
**File:** `Modules/Pure/Matrices/MatrixBase.cs`  
**Lines:** 28-38  
**Severity:** HIGH  

**Issue:**  
Constructor calls `PopulateMatrix()` which requires console input, making the class untestable.

```csharp
// Current (UNTESTABLE)
public MatrixBase(int rows, int cols)
{
    // ...
    PopulateMatrix();  // ← Requires user input!
}

// Recommended - Separate construction from initialization
public MatrixBase(int rows, int cols)
{
    Rows = rows;
    Cols = cols;
    Matrix = new double[rows, cols];
}

public void PopulateMatrix() { /* ... */ }
```

**Impact:** Cannot write unit tests, violates Single Responsibility Principle.

---

### High Priority Issues

#### ⚠️ **TrigonometryMenu - Commented Out Functionality**
**File:** `Menu/Pure/TrigonometryMenu.cs`  
**Lines:** 69-82, 128-143  

Large blocks of code are commented out, making menu options non-functional.

---

#### ⚠️ **MatrixCalculator - Limited Determinant Support**
**File:** `Modules/Pure/Matrices/MatrixCalculator.cs`  
**Line:** 177  

Determinant calculation hardcoded for 2×2 matrices only. Should support NxN matrices using recursive algorithm or LU decomposition.

---

#### ⚠️ **MatrixCalculator - Wrong Exception Type**
**File:** `Modules/Pure/Matrices/MatrixCalculator.cs`  
**Line:** 42  

Uses `IncompatibleMatrixAdditionException` for subtraction operation.

---

#### ⚠️ **Correlation.cs - Logic Bug**
**File:** `Modules/Statistics/BivariateAnalysis/Correlation.cs`  
**Line:** 47  

Condition ordering incorrect for perfect negative correlation (-1).

```csharp
// Current (WRONG ORDER)
if (correlation < -0.7) return "Strong Negative";
else if (correlation == -1) return "Perfect Negative";  // ← Never reached!

// Correct
if (correlation == -1) return "Perfect Negative";
else if (correlation <= -0.7) return "Strong Negative";
```

---

### Medium Priority Issues

#### Code Quality Issues

1. **Inconsistent Error Handling**
   - Some modules use custom exceptions
   - Others use generic `Exception` or `ArgumentException`
   - **Recommendation:** Standardize on specific exception types

2. **Magic Numbers Throughout Codebase**
   - Menu limits hardcoded (3, 4, 7)
   - Tolerance values scattered (`1e-9`)
   - **Recommendation:** Create constants class

3. **Inconsistent Naming Conventions**
   - `getCorrelation()` violates C# PascalCase (should be `GetCorrelation`)
   - Some methods use `Calculate*`, others `Handle*`
   - **Recommendation:** Follow C# naming guidelines consistently

4. **Mixed Console Input Patterns**
   - Some use `Console.ReadLine()`
   - Others use `Console.ReadKey()`
   - **Recommendation:** Standardize input handling

5. **Duplicate Error Messages**
   - Same error text repeated across multiple catch blocks
   - **Recommendation:** Centralize error messages

---

### Build Warnings (20 Total)

#### Nullable Reference Type Warnings

**Files:**
- `Parsing.cs` (lines 85, 93, 101) - Possible null reference return
- `ContinuousTableCalculator.cs` (line 16) - Non-nullable field not initialized
- `BivariateAnalysisCalculator.cs` (line 30) - Multiple non-nullable fields
- `NewtonsLawsCalculator.cs` (lines 33, 37) - Nullable value type may be null
- `AverageCalculator.cs` (line 178) - Possible null reference return

**Recommendation:** Enable nullable reference types project-wide and fix all warnings.

---

## Part 2: Future Development Roadmap

### Vision

Transform Maths Engine from a console application into a modern, professional-grade mathematical computation platform with:
- Rich WPF user interface with graphing capabilities
- Asynchronous operations for responsive UI
- Generic, reusable mathematical components
- Event-driven architecture using delegates
- Comprehensive feature set covering A-Level mathematics
- Optional SQL Server integration for calculation history/templates

---

### Phase 1: Code Cleanup & Refactoring (2-3 weeks)

**Goal:** Fix critical bugs and establish solid foundation

#### 1.1 Fix Critical Bugs
- [ ] Fix menu recursion → implement loop-based navigation
- [ ] Fix AverageCalculator null checks
- [ ] Fix quartile calculation (Q1/Q3 reversal)
- [ ] Fix exception handling in UniformAccelerationCalculator
- [ ] Fix MatrixBase constructor input dependency

#### 1.2 Resolve Build Warnings
- [ ] Enable nullable reference types globally
- [ ] Fix all CS8618 warnings (non-nullable field initialization)
- [ ] Fix all CS8603 warnings (null reference returns)
- [ ] Fix all CS8629 warnings (nullable value types)

#### 1.3 Code Quality Improvements
- [ ] Standardize exception handling across all modules
- [ ] Create `Constants.cs` for magic numbers
- [ ] Implement consistent naming conventions
- [ ] Uncomment and fix TrigonometryMenu functionality
- [ ] Fix MatrixCalculator determinant for NxN matrices

---

### Phase 2: Architecture Modernization (3-4 weeks)

**Goal:** Introduce modern C# patterns and prepare for WPF

#### 2.1 Introduce Generic Types

**Current:**
```csharp
public static double CalculateMean(List<double> nums)
```

**Improved with Generics:**
```csharp
public static T CalculateMean<T>(IEnumerable<T> nums) where T : INumber<T>
{
    return nums.Aggregate((a, b) => a + b) / T.CreateChecked(nums.Count());
}
```

**Benefits:**
- Works with int, double, decimal, complex numbers
- Type-safe at compile time
- More reusable code

**Implementation Areas:**
- [ ] Statistics calculators (mean, median, mode, variance)
- [ ] Matrix operations (generic numeric types)
- [ ] Vector operations (if adding linear algebra)

---

#### 2.2 Implement Async/Await Pattern

**Use Cases for Async:**

1. **Large Matrix Operations**
```csharp
public static async Task<MatrixBase> MultiplyAsync(MatrixBase a, MatrixBase b)
{
    return await Task.Run(() => Multiply(a, b));
}
```

2. **File I/O Operations**
```csharp
public static async Task<List<double>> LoadDataFromFileAsync(string path)
{
    var lines = await File.ReadAllLinesAsync(path);
    return lines.Select(double.Parse).ToList();
}
```

3. **Database Operations** (future)
```csharp
public static async Task<List<CalculationHistory>> GetHistoryAsync()
{
    return await dbContext.Calculations.ToListAsync();
}
```

**Implementation Plan:**
- [ ] Add async suffix to all async methods
- [ ] Implement async file operations
- [ ] Make heavy computations async (matrix multiplication, large datasets)
- [ ] Use `IProgress<T>` for long-running calculations

---

#### 2.3 Introduce Delegates and Events

**Use Cases:**

1. **Calculation Progress Updates**
```csharp
public delegate void CalculationProgressHandler(object sender, ProgressEventArgs e);

public class MatrixCalculator
{
    public event CalculationProgressHandler? ProgressChanged;
    
    public async Task<MatrixBase> MultiplyLargeAsync(MatrixBase a, MatrixBase b)
    {
        for (int i = 0; i < a.Rows; i++)
        {
            // computation...
            ProgressChanged?.Invoke(this, new ProgressEventArgs(i * 100 / a.Rows));
        }
    }
}
```

2. **Validation Callbacks**
```csharp
public static void ValidateInput(double value, Func<double, bool> validator)
{
    if (!validator(value))
        throw new ArgumentException("Validation failed");
}

// Usage
ValidateInput(angle, a => a > 0 && a < 90);  // Delegate for custom validation
```

3. **Custom Calculation Strategies**
```csharp
public class StatisticsEngine
{
    public double Calculate(List<double> data, Func<List<double>, double> strategy)
    {
        return strategy(data);
    }
    
    // Usage
    var mean = engine.Calculate(data, d => d.Average());
    var variance = engine.Calculate(data, d => /* variance calc */);
}
```

**Implementation Plan:**
- [ ] Create event system for calculation progress
- [ ] Use `Func<>` and `Action<>` delegates for callbacks
- [ ] Implement strategy pattern using delegates
- [ ] Add validation delegates

---

#### 2.4 Separate UI from Business Logic

**Current Structure:**
```
MathsEngine/
├── Menu/              ← UI + Logic mixed
└── Modules/           ← Logic
```

**Improved Structure (Preparation for WPF):**
```
MathsEngine.Core/      ← Pure business logic (shared library)
├── Calculators/
├── Models/
└── Interfaces/

MathsEngine.Console/   ← Console UI
└── Menu/

MathsEngine.WPF/       ← WPF UI (future)
└── ViewModels/
```

**Implementation Plan:**
- [ ] Create `MathsEngine.Core` class library
- [ ] Move all calculator logic to Core
- [ ] Define interfaces (ICalculator, IStatisticsEngine)
- [ ] Create data models (separate from UI)
- [ ] Implement dependency injection

---

### Phase 3: WPF Application (4-6 weeks)

**Goal:** Create modern desktop application

#### 3.1 WPF Project Setup
- [ ] Create `MathsEngine.WPF` project
- [ ] Reference `MathsEngine.Core` library
- [ ] Set up MVVM architecture (Model-View-ViewModel)
- [ ] Install necessary NuGet packages:
  - `CommunityToolkit.Mvvm` (MVVM helpers)
  - `LiveCharts2` or `OxyPlot` (graphing)
  - `MaterialDesignThemes` (modern UI)

#### 3.2 UI Design

**Main Window Layout:**
```
┌─────────────────────────────────────────────┐
│ Maths Engine                          [_][□][X]│
├─────────────┬───────────────────────────────┤
│             │                               │
│  Navigation │      Main Content Area        │
│             │                               │
│  □ Pure     │  ┌─────────────────────────┐ │
│    • Pythag │  │   Calculator Panel      │ │
│    • Trig   │  │                         │ │
│    • Matrix │  │   [Input Fields]        │ │
│             │  │                         │ │
│  □ Mechanics│  │   [Calculate Button]    │ │
│    • SUVAT  │  │                         │ │
│    • Newton │  │   [Results Display]     │ │
│             │  │                         │ │
│  □ Stats    │  └─────────────────────────┘ │
│    • Average│                               │
│    • StdDev │      Visualization Panel     │
│    • Bivari │  ┌─────────────────────────┐ │
│             │  │                         │ │
│  □ History  │  │    [Graph/Chart]        │ │
│             │  │                         │ │
└─────────────┴───────────────────────────────┘
```

#### 3.3 Key Features

1. **Interactive Graphing**
   - Plot trigonometric functions
   - Visualize statistical distributions
   - Show velocity-time graphs for mechanics

2. **Calculation History**
   - Save previous calculations
   - Export to CSV/JSON
   - Load saved configurations

3. **Step-by-Step Solutions**
   - Show working for each calculation
   - Educational mode with explanations

4. **Dark/Light Theme**
   - User preference persistence
   - Material Design styling

#### 3.4 MVVM Implementation

**Example: Pythagoras Calculator ViewModel**
```csharp
public class PythagorasViewModel : ObservableObject
{
    private readonly IPythagorasCalculator _calculator;
    
    [ObservableProperty]
    private double? sideA;
    
    [ObservableProperty]
    private double? sideB;
    
    [ObservableProperty]
    private double? hypotenuse;
    
    [ObservableProperty]
    private string result;
    
    [RelayCommand]
    private async Task CalculateAsync()
    {
        if (sideA.HasValue && sideB.HasValue)
        {
            Hypotenuse = await Task.Run(() => 
                _calculator.CalculateHypotenuse(sideA.Value, sideB.Value));
            Result = $"Hypotenuse = {Hypotenuse:F2}";
        }
    }
}
```

**XAML Binding:**
```xaml
<TextBox Text="{Binding SideA, UpdateSourceTrigger=PropertyChanged}" />
<TextBox Text="{Binding SideB, UpdateSourceTrigger=PropertyChanged}" />
<Button Command="{Binding CalculateCommand}" Content="Calculate" />
<TextBlock Text="{Binding Result}" />
```

---

### Phase 4: Extended Mathematical Features (6-8 weeks)

**Goal:** Comprehensive A-Level mathematics coverage

#### 4.1 Pure Mathematics

**Calculus:**
- [ ] Numerical differentiation (finite differences)
- [ ] Numerical integration (Simpson's rule, trapezoid rule)
- [ ] Function plotting with derivatives

**Algebra:**
- [ ] Polynomial root finding (Newton-Raphson)
- [ ] Simultaneous equation solver (Gaussian elimination)
- [ ] Quadratic, cubic equation solvers

**Sequences & Series:**
- [ ] Arithmetic/geometric sequences
- [ ] Convergence tests
- [ ] Summation calculators

**Complex Numbers:**
- [ ] Complex arithmetic
- [ ] Polar form conversions
- [ ] Argand diagram plotting

**Vectors:**
- [ ] Vector operations (dot product, cross product)
- [ ] Vector equations of lines
- [ ] Angle between vectors

---

#### 4.2 Mechanics

**Kinematics:**
- [ ] Projectile motion calculator
- [ ] Relative velocity
- [ ] Circular motion

**Dynamics:**
- [ ] Connected particles
- [ ] Friction problems
- [ ] Momentum and impulse

**Statics:**
- [ ] Equilibrium problems
- [ ] Moments calculator
- [ ] Center of mass

**Energy:**
- [ ] Work-energy principle
- [ ] Potential/kinetic energy
- [ ] Power calculations

---

#### 4.3 Statistics

**Probability:**
- [ ] Binomial distribution
- [ ] Normal distribution (Z-scores, probabilities)
- [ ] Poisson distribution

**Advanced Statistics:**
- [ ] Hypothesis testing (t-test, chi-squared)
- [ ] Confidence intervals
- [ ] Linear regression with visualization
- [ ] ANOVA (Analysis of Variance)

**Data Visualization:**
- [ ] Histograms
- [ ] Box plots
- [ ] Scatter plots with regression line
- [ ] Probability density functions

---

### Phase 5: Database Integration (2-3 weeks)

**Goal:** Add persistence and data management

#### 5.1 SQL Server Setup

**Use Cases:**
1. **Calculation History**
   - Store all calculations with timestamps
   - Search and filter past calculations
   - Analytics on usage patterns

2. **Saved Templates**
   - Save frequently used calculation setups
   - Share templates between users (future)

3. **User Preferences**
   - Theme settings
   - Default units
   - Saved configurations

4. **Educational Content**
   - Store formula explanations
   - Example problems
   - Solutions database

#### 5.2 Database Schema

```sql
-- Calculation History
CREATE TABLE Calculations (
    Id INT PRIMARY KEY IDENTITY,
    CalculationType NVARCHAR(50),
    InputData NVARCHAR(MAX),  -- JSON
    OutputData NVARCHAR(MAX), -- JSON
    Timestamp DATETIME2,
    UserId INT  -- For future multi-user
);

-- Saved Templates
CREATE TABLE Templates (
    Id INT PRIMARY KEY IDENTITY,
    Name NVARCHAR(100),
    Category NVARCHAR(50),
    Configuration NVARCHAR(MAX), -- JSON
    CreatedDate DATETIME2
);

-- User Preferences
CREATE TABLE UserPreferences (
    UserId INT PRIMARY KEY,
    Theme NVARCHAR(20),
    DefaultUnits NVARCHAR(50),
    Settings NVARCHAR(MAX) -- JSON
);
```

#### 5.3 Entity Framework Core

**Implementation:**
```csharp
public class MathsEngineDbContext : DbContext
{
    public DbSet<Calculation> Calculations { get; set; }
    public DbSet<Template> Templates { get; set; }
    public DbSet<UserPreference> UserPreferences { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=.;Database=MathsEngine;...");
    }
}

// Usage
public async Task SaveCalculationAsync(string type, object input, object output)
{
    using var context = new MathsEngineDbContext();
    
    var calc = new Calculation
    {
        CalculationType = type,
        InputData = JsonSerializer.Serialize(input),
        OutputData = JsonSerializer.Serialize(output),
        Timestamp = DateTime.UtcNow
    };
    
    context.Calculations.Add(calc);
    await context.SaveChangesAsync();
}
```

#### 5.4 Repository Pattern

```csharp
public interface ICalculationRepository
{
    Task<List<Calculation>> GetRecentAsync(int count);
    Task<List<Calculation>> SearchAsync(string type, DateTime from, DateTime to);
    Task SaveAsync(Calculation calculation);
}

public class CalculationRepository : ICalculationRepository
{
    private readonly MathsEngineDbContext _context;
    
    public async Task<List<Calculation>> GetRecentAsync(int count)
    {
        return await _context.Calculations
            .OrderByDescending(c => c.Timestamp)
            .Take(count)
            .ToListAsync();
    }
}
```

---

## Part 3: Implementation Timeline

### Recommended Development Sequence

| Phase | Duration | Priority | Dependencies |
|-------|----------|----------|--------------|
| **Phase 1: Bug Fixes** | 2-3 weeks | 🔴 CRITICAL | None |
| **Phase 2: Architecture** | 3-4 weeks | 🟡 HIGH | Phase 1 complete |
| **Phase 3: WPF UI** | 4-6 weeks | 🟢 MEDIUM | Phase 2 complete |
| **Phase 4: Math Features** | 6-8 weeks | 🟢 MEDIUM | Phase 3 started |
| **Phase 5: Database** | 2-3 weeks | 🔵 LOW | Phase 3 complete |

**Total Estimated Time:** 17-24 weeks (4-6 months)

---

## Part 4: Technical Recommendations

### Tools and Libraries

#### Essential NuGet Packages

**For Core Library:**
```xml
<PackageReference Include="System.Numerics" Version="4.3.0" />
<PackageReference Include="MathNet.Numerics" Version="5.0.0" />  <!-- Advanced math -->
```

**For WPF Application:**
```xml
<PackageReference Include="CommunityToolkit.Mvvm" Version="8.2.2" />
<PackageReference Include="LiveCharts2" Version="2.0.0-rc2" />
<PackageReference Include="MaterialDesignThemes" Version="4.9.0" />
<PackageReference Include="Microsoft.Extensions.DependencyInjection" Version="8.0.0" />
```

**For Database:**
```xml
<PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="8.0.0" />
<PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="8.0.0" />
```

---

### Code Quality Tools

1. **Static Analysis:**
   - Enable all nullable reference type warnings
   - Use SonarLint for code quality
   - Configure StyleCop for consistent formatting

2. **Testing:**
   - Expand unit test coverage to 80%+
   - Add integration tests for database
   - Use Moq for mocking dependencies

3. **CI/CD:**
   - Set up GitHub Actions for automated builds
   - Run tests on every PR
   - Automated code quality checks

---

### Architecture Patterns

1. **SOLID Principles:**
   - **S**ingle Responsibility - separate UI, logic, data
   - **O**pen/Closed - use interfaces for extensibility
   - **L**iskov Substitution - proper inheritance hierarchies
   - **I**nterface Segregation - focused interfaces
   - **D**ependency Inversion - depend on abstractions

2. **Design Patterns:**
   - **MVVM** - for WPF application
   - **Repository** - for database access
   - **Strategy** - for different calculation methods
   - **Factory** - for creating calculator instances
   - **Observer** - for event-driven updates

---

## Part 5: Risk Assessment

### Technical Risks

| Risk | Probability | Impact | Mitigation |
|------|-------------|--------|------------|
| WPF learning curve | High | Medium | Start with simple views, iterate |
| Performance issues with large matrices | Medium | Medium | Use async, optimize algorithms |
| Database complexity | Low | Low | Start simple, expand gradually |
| Breaking existing tests | High | Low | Fix tests incrementally |

### Recommendations

1. **Start Small:** Fix critical bugs first before adding features
2. **Incremental Changes:** Don't rewrite everything at once
3. **Maintain Tests:** Keep existing tests passing
4. **Document As You Go:** Update README with new features
5. **User Feedback:** Test WPF UI with real users early

---

## Part 6: Quick Wins (Priority Actions)

### Week 1-2 Quick Fixes

These can be done immediately for maximum impact:

1. ✅ **Fix menu recursion** → Immediate stability improvement
2. ✅ **Fix null check bugs** → Prevent crashes
3. ✅ **Fix quartile calculation** → Correct mathematical results
4. ✅ **Uncomment TrigonometryMenu** → Restore functionality
5. ✅ **Add XML documentation** → Better code understanding
6. ✅ **Create Constants.cs** → Remove magic numbers

---

## Conclusion

The Maths Engine has a solid foundation but requires addressing critical bugs before expanding functionality. The roadmap provides a clear path to transform it into a professional-grade application with modern C# features (async, generics, delegates) and a rich WPF interface.

**Immediate Next Steps:**
1. Fix critical bugs (menu recursion, null checks, quartiles)
2. Resolve all compiler warnings
3. Separate UI from business logic
4. Begin WPF prototype

**Long-term Vision:**
A comprehensive, user-friendly mathematical computation platform suitable for GCSE/A-Level students and educators, featuring interactive visualizations, step-by-step solutions, and persistent calculation history.

---

## Appendix: Code Examples

### Example 1: Fixed Menu Navigation

```csharp
public static class Menu
{
    public static void MainMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Maths Engine");
            Console.WriteLine("1. Pure");
            Console.WriteLine("2. Mechanics");
            Console.WriteLine("3. Statistics");
            Console.WriteLine("4. Exit Program");
            
            int response = Parsing.GetMenuInput("Input: ", 4);
            Console.Clear();
            
            switch (response)
            {
                case 1:
                    PureMenu();
                    break;
                case 2:
                    MechanicsMenu();
                    break;
                case 3:
                    StatisticsMenu();
                    break;
                case 4:
                    return; // Exit the loop
            }
        }
    }
}
```

### Example 2: Generic Statistics Calculator

```csharp
public static class GenericStatistics
{
    public static T Mean<T>(IEnumerable<T> values) where T : INumber<T>
    {
        if (!values.Any())
            throw new ArgumentException("Collection cannot be empty");
            
        var sum = values.Aggregate((a, b) => a + b);
        var count = T.CreateChecked(values.Count());
        return sum / count;
    }
    
    public static T Variance<T>(IEnumerable<T> values) where T : INumber<T>
    {
        var mean = Mean(values);
        var squaredDiffs = values.Select(v => (v - mean) * (v - mean));
        return Mean(squaredDiffs);
    }
}

// Usage
var intMean = GenericStatistics.Mean(new[] { 1, 2, 3, 4, 5 });
var doubleMean = GenericStatistics.Mean(new[] { 1.5, 2.5, 3.5 });
```

### Example 3: Async Matrix Multiplication

```csharp
public static async Task<MatrixBase> MultiplyAsync(
    MatrixBase a, 
    MatrixBase b, 
    IProgress<int>? progress = null)
{
    if (a.Cols != b.Rows)
        throw new IncompatibleMatrixMultiplicationException();
        
    var result = new MatrixBase(a.Rows, b.Cols);
    
    await Task.Run(() =>
    {
        for (int i = 0; i < a.Rows; i++)
        {
            for (int j = 0; j < b.Cols; j++)
            {
                double sum = 0;
                for (int k = 0; k < a.Cols; k++)
                {
                    sum += a.Matrix[i, k] * b.Matrix[k, j];
                }
                result.Matrix[i, j] = sum;
            }
            
            // Report progress
            progress?.Report((i + 1) * 100 / a.Rows);
        }
    });
    
    return result;
}
```

### Example 4: Delegate-Based Validation

```csharp
public class InputValidator
{
    public static void Validate<T>(
        T value, 
        Func<T, bool> validator, 
        string errorMessage)
    {
        if (!validator(value))
            throw new ArgumentException(errorMessage);
    }
}

// Usage examples
InputValidator.Validate(angle, a => a > 0 && a < 90, "Angle must be between 0 and 90 degrees");
InputValidator.Validate(mass, m => m > 0, "Mass must be positive");
InputValidator.Validate(matrix, m => m.IsSquare, "Matrix must be square");
```

---

**Document Version:** 1.0  
**Last Updated:** January 2026
