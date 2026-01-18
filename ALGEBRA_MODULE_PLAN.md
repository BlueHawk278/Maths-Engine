# Basic Algebra Module - Implementation Plan

## Overview
This document outlines the design and implementation plan for adding a Basic Algebra module to the Maths Engine.

---

## Module Scope

### Core Features to Implement

#### 1. Linear Equations (Single Variable)
**Functionality:**
- Solve equations of form: `ax + b = c`
- Solve equations of form: `ax + b = cx + d`
- Validate and simplify equations
- Show step-by-step solution

**Examples:**
- `2x + 5 = 13` → `x = 4`
- `3x - 7 = 2x + 5` → `x = 12`
- `5x = 20` → `x = 4`

#### 2. Quadratic Equations
**Functionality:**
- Solve using quadratic formula: `ax² + bx + c = 0`
- Calculate discriminant
- Find real and complex roots
- Identify number of solutions

**Examples:**
- `x² - 5x + 6 = 0` → `x = 2` or `x = 3`
- `x² + 2x + 1 = 0` → `x = -1` (repeated root)
- `x² + x + 1 = 0` → Complex roots

#### 3. Expression Simplification
**Functionality:**
- Expand brackets: `2(x + 3)` → `2x + 6`
- Collect like terms: `3x + 2x + 5` → `5x + 5`
- Factorize simple expressions: `2x + 6` → `2(x + 3)`

#### 4. Simultaneous Equations (2 variables)
**Functionality:**
- Solve 2x2 systems using substitution
- Solve 2x2 systems using elimination
- Validate solution

**Examples:**
- `x + y = 10` and `x - y = 2` → `x = 6, y = 4`

---

## File Structure

```
MathsEngine/
├── Modules/
│   └── Pure/
│       └── Algebra/
│           ├── LinearEquationSolver.cs
│           ├── QuadraticEquationSolver.cs
│           ├── SimultaneousEquationsSolver.cs
│           ├── ExpressionSimplifier.cs
│           └── AlgebraModels.cs
├── Menu/
│   └── Pure/
│       └── AlgebraMenu.cs
└── Tests/
    └── PureTests/
        └── AlgebraTests/
            ├── LinearEquationTests.cs
            ├── QuadraticEquationTests.cs
            ├── SimultaneousEquationsTests.cs
            └── ExpressionSimplifierTests.cs
```

---

## Implementation Details

### 1. LinearEquationSolver.cs

```csharp
namespace MathsEngine.Modules.Pure.Algebra
{
    public static class LinearEquationSolver
    {
        /// <summary>
        /// Solves linear equation of form ax + b = c
        /// </summary>
        /// <param name="a">Coefficient of x</param>
        /// <param name="b">Constant on left side</param>
        /// <param name="c">Constant on right side</param>
        /// <returns>Value of x</returns>
        public static double SolveSimple(double a, double b, double c);
        
        /// <summary>
        /// Solves linear equation of form ax + b = cx + d
        /// </summary>
        public static double SolveGeneral(double a, double b, double c, double d);
        
        /// <summary>
        /// Shows step-by-step solution
        /// </summary>
        public static List<string> GetSolutionSteps(double a, double b, double c);
    }
}
```

### 2. QuadraticEquationSolver.cs

```csharp
namespace MathsEngine.Modules.Pure.Algebra
{
    public class QuadraticSolution
    {
        public double? RealRoot1 { get; set; }
        public double? RealRoot2 { get; set; }
        public Complex? ComplexRoot1 { get; set; }
        public Complex? ComplexRoot2 { get; set; }
        public double Discriminant { get; set; }
        public SolutionType Type { get; set; }
    }
    
    public enum SolutionType
    {
        TwoRealRoots,
        OneRepeatedRoot,
        TwoComplexRoots,
        NoSolution
    }
    
    public static class QuadraticEquationSolver
    {
        /// <summary>
        /// Solves quadratic equation ax² + bx + c = 0
        /// </summary>
        public static QuadraticSolution Solve(double a, double b, double c);
        
        /// <summary>
        /// Calculates discriminant (b² - 4ac)
        /// </summary>
        public static double CalculateDiscriminant(double a, double b, double c);
        
        /// <summary>
        /// Shows step-by-step solution
        /// </summary>
        public static List<string> GetSolutionSteps(double a, double b, double c);
    }
}
```

### 3. SimultaneousEquationsSolver.cs

```csharp
namespace MathsEngine.Modules.Pure.Algebra
{
    public class SimultaneousEquationsSolution
    {
        public double X { get; set; }
        public double Y { get; set; }
        public bool HasSolution { get; set; }
        public string Message { get; set; }
    }
    
    public static class SimultaneousEquationsSolver
    {
        /// <summary>
        /// Solves 2x2 system using elimination method
        /// Equation 1: a1*x + b1*y = c1
        /// Equation 2: a2*x + b2*y = c2
        /// </summary>
        public static SimultaneousEquationsSolution SolveByElimination(
            double a1, double b1, double c1,
            double a2, double b2, double c2);
        
        /// <summary>
        /// Shows step-by-step solution
        /// </summary>
        public static List<string> GetSolutionSteps(
            double a1, double b1, double c1,
            double a2, double b2, double c2);
    }
}
```

### 4. AlgebraMenu.cs

```csharp
namespace MathsEngine.Menu.Pure
{
    internal static class AlgebraMenu
    {
        public static void Menu()
        {
            // Main algebra menu
            // 1. Linear Equations
            // 2. Quadratic Equations
            // 3. Simultaneous Equations
            // 4. Expression Simplification
            // 5. Back to Pure Menu
        }
        
        private static void LinearEquationsMenu();
        private static void QuadraticEquationsMenu();
        private static void SimultaneousEquationsMenu();
        private static void ExpressionSimplificationMenu();
    }
}
```

---

## Test Cases

### Linear Equation Tests
```csharp
[Theory]
[InlineData(2, 5, 13, 4)]           // 2x + 5 = 13 → x = 4
[InlineData(3, -7, 8, 5)]           // 3x - 7 = 8 → x = 5
[InlineData(5, 0, 20, 4)]           // 5x = 20 → x = 4
[InlineData(-2, 10, 4, 3)]          // -2x + 10 = 4 → x = 3
public void SolveSimple_ValidInputs_ReturnsCorrectSolution(
    double a, double b, double c, double expected)

[Theory]
[InlineData(3, 7, 2, 5, 12)]        // 3x + 7 = 2x + 5 → x = -2
[InlineData(5, 3, 2, 10, 7/3)]      // 5x + 3 = 2x + 10 → x = 7/3
public void SolveGeneral_ValidInputs_ReturnsCorrectSolution(...)

[Fact]
public void SolveSimple_ZeroCoefficient_ThrowsException()
// 0x + 5 = 10 → Invalid
```

### Quadratic Equation Tests
```csharp
[Theory]
[InlineData(1, -5, 6, 2, 3)]        // x² - 5x + 6 = 0 → x = 2, 3
[InlineData(1, -3, 2, 1, 2)]        // x² - 3x + 2 = 0 → x = 1, 2
public void Solve_TwoRealRoots_ReturnsCorrectSolutions(...)

[Theory]
[InlineData(1, -2, 1, -1)]          // x² - 2x + 1 = 0 → x = 1 (repeated)
public void Solve_RepeatedRoot_ReturnsSingleRoot(...)

[Theory]
[InlineData(1, 0, 1)]               // x² + 1 = 0 → Complex roots
public void Solve_NegativeDiscriminant_ReturnsComplexRoots(...)

[Fact]
public void Solve_ZeroLeadingCoefficient_ThrowsException()
// 0x² + 2x + 1 = 0 → Not quadratic
```

### Simultaneous Equations Tests
```csharp
[Theory]
[InlineData(1, 1, 10, 1, -1, 2, 6, 4)]  // x+y=10, x-y=2 → x=6, y=4
[InlineData(2, 3, 13, 1, -1, 1, 4, 3)]  // 2x+3y=13, x-y=1 → x=4, y=3
public void SolveByElimination_ValidSystem_ReturnsCorrectSolution(...)

[Fact]
public void SolveByElimination_ParallelLines_ReturnsNoSolution()
// x + y = 1, x + y = 2 → No solution

[Fact]
public void SolveByElimination_SameLines_ReturnsInfiniteSolutions()
// 2x + 4y = 6, x + 2y = 3 → Infinite solutions
```

---

## Integration Steps

### Step 1: Create Core Functionality (2-3 hours)
1. Create `Modules/Pure/Algebra/` directory
2. Implement `LinearEquationSolver.cs`
3. Implement `QuadraticEquationSolver.cs`
4. Implement `SimultaneousEquationsSolver.cs`
5. Create exception classes for algebra-specific errors

### Step 2: Create Menu System (1-2 hours)
1. Create `Menu/Pure/AlgebraMenu.cs`
2. Add sub-menus for each algebra type
3. Implement error handling using `ErrorDisplay` utility
4. Add to main Pure menu

### Step 3: Add Tests (2-3 hours)
1. Create test directory structure
2. Implement comprehensive test suite
3. Test edge cases (zero coefficients, parallel lines, etc.)
4. Verify all tests pass

### Step 4: Update Main Menu (15 minutes)
1. Add "Algebra" option to Pure menu in `Menu.cs`
2. Update menu constants
3. Test navigation flow

### Step 5: Documentation (30 minutes)
1. Add XML documentation to all public methods
2. Update README.md with new module
3. Create examples document

---

## Example User Flow

```
Welcome to the Maths Engine
1. Pure
2. Mechanics
3. Statistics
4. Exit Program
Input: 1

Welcome to the Pure Maths Menu
1. Pythagoras Theorem
2. Trigonometry
3. Matrices
4. Algebra          ← NEW
5. Main Menu
Input: 4

Welcome to the Algebra Menu
1. Linear Equations (Single Variable)
2. Quadratic Equations
3. Simultaneous Equations (2 Variables)
4. Expression Simplification
5. Back
Input: 1

Linear Equation Solver
Solve equation of form: ax + b = c

Enter coefficient a: 2
Enter constant b: 5
Enter result c: 13

Solving: 2x + 5 = 13

Step 1: Subtract 5 from both sides
        2x = 8

Step 2: Divide both sides by 2
        x = 4

Solution: x = 4

Press Enter to return...
```

---

## Exception Handling

### New Exception Classes
```csharp
/// <summary>
/// Thrown when equation has zero coefficient for variable
/// </summary>
public class ZeroCoefficientException : Exception

/// <summary>
/// Thrown when quadratic equation has zero leading coefficient
/// </summary>
public class NotQuadraticException : Exception

/// <summary>
/// Thrown when simultaneous equations have no unique solution
/// </summary>
public class NoUniqueSolutionException : Exception

/// <summary>
/// Thrown when equation is malformed
/// </summary>
public class InvalidEquationException : Exception
```

---

## Advanced Features (Future Enhancement)

### Phase 2 - Additional Features
1. **Cubic Equations** - Solve ax³ + bx² + cx + d = 0
2. **Polynomial Division** - Divide polynomials
3. **Partial Fractions** - Decompose rational expressions
4. **Inequalities** - Solve linear/quadratic inequalities
5. **Graphing** - Visual representation of equations

### Phase 3 - Interactive Features
1. **Equation Parser** - Input equations as strings (e.g., "2x + 5 = 13")
2. **Variable Substitution** - Evaluate expressions with given values
3. **Equation Builder** - Interactive equation construction
4. **Practice Mode** - Generate random problems for practice

---

## Estimated Time

**Total Implementation Time: 6-9 hours**

- Core functionality: 3-4 hours
- Menu system: 1-2 hours
- Testing: 2-3 hours
- Documentation: 30 minutes
- Integration & testing: 30 minutes

---

## Priority Order

**High Priority (Implement First):**
1. ✅ Linear Equations (most common, relatively simple)
2. ✅ Quadratic Equations (GCSE core topic)

**Medium Priority:**
3. ⏳ Simultaneous Equations (2x2 systems)

**Lower Priority (Future):**
4. ⏳ Expression Simplification (more complex, parser needed)
5. ⏳ Advanced topics (cubics, inequalities)

---

## Benefits

1. **Educational Value** - Core GCSE/A-Level topic
2. **Practical Use** - Commonly needed calculations
3. **Foundation** - Basis for more advanced algebra
4. **Complements Existing Modules** - Fits well with Pure Maths section
5. **Extensible** - Easy to add more features later

---

## Next Steps

After reviewing this plan:
1. Confirm scope and priorities
2. Implement core Linear Equation solver
3. Add tests
4. Implement Quadratic solver
5. Create menu system
6. Integrate with main application
7. Test end-to-end user flow

Let me know if you'd like me to start implementing any of these components!
