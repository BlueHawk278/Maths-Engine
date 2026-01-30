# Pure Mathematics Module

## Overview

The Pure Mathematics module provides computational tools for fundamental mathematical concepts taught at GCSE and A-level. This module implements algorithms for trigonometry, matrices and number theory.

**Key Features**:
- **Pythagoras Theorem** - Calculate hypotenuse and missing sides in right-angled triangles
- **Trigonometry** - Solve for missing sides and angles using SOH-CAH-TOA ratios
- **Matrices** - Perform matrix operations (addition, subtraction, scalar operations, multiplication, determinants)
- **Number Theory** - Calculate Highest Common Factor (HCF) and Lowest Common Multiple (LCM)

**Design Principle**: All calculation classes in this module contain no UI dependencies, making them reusable in any context (CLI, GUI and unit tests).

---

## Module Structure

```
Modules/Pure/
├── PythagorasTheorem/
│   └── PythagorasTheorem.cs       # Right-angled triangle calculations
├── Trigonometry/
│   ├── Trigonometry.cs            # SOH-CAH-TOA calculations
│   └── SideType.cs                # Enum: Opposite, Adjacent, Hypotenuse
├── Matrices/
│   ├── MatrixBase.cs              # Matrix data structure
│   └── MatrixCalculator.cs        # Matrix operations (static methods)
└── NumberTheory.cs                # HCF and LCM calculations
```

---

## 📐 Pythagoras Theorem

### Purpose
Calculate missing sides in right-angled triangles using the Pythagorean theorem: **h² = a² + b²**

In a right-angled triangle:
- The **hypotenuse** (h) is the longest side opposite the right angle
- The two **shorter sides** (a and b) form the right angle

### Classes

#### `PythagorasTheorem` (Static Class)

**Namespace**: `MathsEngine.Modules.Pure.PythagorasTheorem`

**Key Responsibilities**:
- Calculate hypotenuse given two shorter sides
- Calculate a missing side given the hypotenuse and one other side
- Validate triangle calculations

---

### Methods

#### 1. `CalculateHypotenuse(double? a, double? b)`
Calculates the length of the hypotenuse given the two shorter sides.

**Parameters**:
- `a` (`double?`) - Length of the first side (must be > 0)
- `b` (`double?`) - Length of the second side (must be > 0)

**Returns**: `double` - Length of the hypotenuse

**Throws**:
- `NullInputException` - If either parameter is null
- `NegativeSideLengthException` - If either side ≤ 0

**Example**:
```csharp
using MathsEngine.Modules.Pure.PythagorasTheorem;

// Calculate hypotenuse of a 3-4-5 triangle
double hypotenuse = PythagorasTheorem.CalculateHypotenuse(3, 4);
Console.WriteLine($"Hypotenuse: {hypotenuse}");  // Output: 5
```

**Mathematical Background**:
```
h² = a² + b²
h = √(a² + b²)
h = √(9 + 16) = √25 = 5
```

---

#### 2. `CalculateOtherSide(double? hypotenuse, double? knownSide)`
Calculates a missing side given the hypotenuse and one other side.

**Parameters**:
- `hypotenuse` (`double?`) - Length of the hypotenuse (must be the longest side)
- `knownSide` (`double?`) - Length of the known side

**Returns**: `double` - Length of the unknown side

**Throws**:
- `NullInputException` - If either parameter is null
- `NegativeSideLengthException` - If either value ≤ 0
- `HypotenuseNotLongestSideException` - If knownSide ≥ hypotenuse

**Example**:
```csharp
// Find the missing side of a 5-12-13 triangle
double unknownSide = PythagorasTheorem.CalculateOtherSide(13, 5);
Console.WriteLine($"Unknown side: {unknownSide}");  // Output: 12
```

**Mathematical Background**:
```
h² = a² + b²
b² = h² - a²
b = √(h² - a²)
b = √(169 - 25) = √144 = 12
```

---

#### 3. `CheckValidCalculation(double? hypotenuse, double? a, double? b)`
Verifies whether three given side lengths form a valid right-angled triangle.

**Parameters**:
- `hypotenuse` (`double?`) - Length of the hypotenuse
- `a` (`double?`) - Length of first side
- `b` (`double?`) - Length of second side

**Returns**: `bool` - `true` if valid, `false` otherwise

**Throws**:
- `NullInputException` - If any parameter is null
- `NegativeSideLengthException` - If any value ≤ 0
- `HypotenuseNotLongestSideException` - If hypotenuse is not the longest side

**Example**:
```csharp
bool isValid = PythagorasTheorem.CheckValidCalculation(5, 3, 4);
Console.WriteLine($"Valid triangle: {isValid}");  // Output: True
```

---

## 📏 Trigonometry

### Purpose
Solve for missing sides and angles in right-angled triangles using trigonometric ratios (SOH-CAH-TOA).

**Trigonometric Ratios**:
- **SOH**: sin(θ) = Opposite / Hypotenuse
- **CAH**: cos(θ) = Adjacent / Hypotenuse
- **TOA**: tan(θ) = Opposite / Adjacent

### Classes

#### `SideType` (Enum)

**Namespace**: `MathsEngine.Modules.Pure.Trigonometry`

Represents the sides of a right-angled triangle relative to an angle.

**Values**:
- `Opposite` - The side opposite to the angle
- `Adjacent` - The side adjacent to the angle (not the hypotenuse)
- `Hypotenuse` - The longest side opposite the right angle

---

#### `Trigonometry` (Static Class)

**Namespace**: `MathsEngine.Modules.Pure.Trigonometry`

**Key Responsibilities**:
- Calculate missing sides using trigonometric ratios
- Calculate missing angles using inverse trigonometric functions

---

### Methods

#### 1. `CalculateMissingSide(double? knownSideLength, double? angle, SideType knownSideType, SideType sideToFind)`
Calculates the length of a missing side in a right-angled triangle.

**Parameters**:
- `knownSideLength` (`double?`) - Length of the known side (must be > 0)
- `angle` (`double?`) - Known angle in degrees (must be 0 < angle < 90)
- `knownSideType` (`SideType`) - Type of the known side
- `sideToFind` (`SideType`) - Type of the side to calculate

**Returns**: `double` - Length of the calculated side

**Throws**:
- `NullInputException` - If knownSideLength or angle is null
- `NegativeSideLengthException` - If knownSideLength ≤ 0
- `AcuteAngleException` - If angle ≤ 0 or angle ≥ 90
- `DuplicateSideException` - If knownSideType == sideToFind

**Example**:
```csharp
using MathsEngine.Modules.Pure.Trigonometry;

// Find the opposite side when adjacent = 10 and angle = 30°
double opposite = Trigonometry.CalculateMissingSide(
    knownSideLength: 10,
    angle: 30,
    knownSideType: SideType.Adjacent,
    sideToFind: SideType.Opposite
);
Console.WriteLine($"Opposite: {opposite:F2}");  // Output: 5.77
```

**Mathematical Background**:
```
tan(θ) = opposite / adjacent
opposite = adjacent × tan(θ)
opposite = 10 × tan(30°) ≈ 5.77
```

---

#### 2. `CalculateMissingAngle(double? side1Length, SideType side1Type, double? side2Length, SideType side2Type)`
Calculates the size of a missing angle in a right-angled triangle.

**Parameters**:
- `side1Length` (`double?`) - Length of the first known side
- `side1Type` (`SideType`) - Type of the first known side
- `side2Length` (`double?`) - Length of the second known side
- `side2Type` (`SideType`) - Type of the second known side

**Returns**: `double` - The calculated angle in degrees

**Throws**:
- `NullInputException` - If any length is null
- `NegativeSideLengthException` - If any length ≤ 0
- `DuplicateSideException` - If both sides are the same type

**Example**:
```csharp
// Find the angle when opposite = 5 and hypotenuse = 10
double angle = Trigonometry.CalculateMissingAngle(
    side1Length: 5,
    side1Type: SideType.Opposite,
    side2Length: 10,
    side2Type: SideType.Hypotenuse
);
Console.WriteLine($"Angle: {angle:F2}°");  // Output: 30.00°
```

**Mathematical Background**:
```
sin(θ) = opposite / hypotenuse
θ = arcsin(opposite / hypotenuse)
θ = arcsin(5 / 10) = arcsin(0.5) = 30°
```

---

## 🔢 Matrices

### Purpose
Perform standard matrix operations used in linear algebra, including addition, subtraction, scalar operations, multiplication, and determinant calculation.

### Classes

#### `MatrixBase` (Instance Class)

**Namespace**: `MathsEngine.Modules.Pure.Matrices`

Represents a matrix as a 2D array with associated properties and helper methods.

**Properties**:
- `NumRows` (`int`) - Number of rows in the matrix
- `NumCols` (`int`) - Number of columns in the matrix
- `Matrix` (`double[,]`) - The 2D array containing matrix values

**Constructors**:

##### `MatrixBase(int rows, int cols)`
Creates an empty matrix with specified dimensions.

**Example**:
```csharp
using MathsEngine.Modules.Pure.Matrices;

var matrix = new MatrixBase(3, 3);
matrix.PopulateMatrix();  // Prompts user for values
```

##### `MatrixBase(double[,] array)`
Creates a matrix from an existing 2D array.

**Example**:
```csharp
double[,] data = { { 1, 2 }, { 3, 4 } };
var matrix = new MatrixBase(data);
```

**Methods**:

##### `PopulateMatrix()`
Prompts the user to input values for each element in the matrix via console.

##### `GetIdentityMatrix(int size)` (Static)
Returns an identity matrix of the specified size.

**Example**:
```csharp
var identity = MatrixBase.GetIdentityMatrix(3);
// Result: [[1,0,0], [0,1,0], [0,0,1]]
```

---

#### `MatrixCalculator` (Static Class)

**Namespace**: `MathsEngine.Modules.Pure.Matrices`

Provides static methods for matrix operations.

**Methods**:

##### `AddMatrix(MatrixBase matrix1, MatrixBase matrix2)`
Adds two matrices element-wise.

**Parameters**:
- `matrix1` - First matrix
- `matrix2` - Second matrix (must have same dimensions as matrix1)

**Returns**: `double[,]` - Resulting matrix

**Throws**:
- `NullInputException` - If either matrix is null or empty
- `IncompatibleMatrixAdditionException` - If dimensions don't match

**Example**:
```csharp
var m1 = new MatrixBase(new double[,] { { 1, 2 }, { 3, 4 } });
var m2 = new MatrixBase(new double[,] { { 5, 6 }, { 7, 8 } });
var result = MatrixCalculator.AddMatrix(m1, m2);
// Result: [[6, 8], [10, 12]]
```

---

##### `SubtractMatrix(MatrixBase matrix1, MatrixBase matrix2)`
Subtracts matrix2 from matrix1 element-wise.

**Throws**:
- `NullInputException` - If either matrix is null or empty
- `IncompatibleMatrixSubtractionException` - If dimensions don't match

---

##### `ScalarMultiplication(MatrixBase matrix, double number)`
Multiplies every element in the matrix by a scalar value.

**Example**:
```csharp
var m = new MatrixBase(new double[,] { { 1, 2 }, { 3, 4 } });
var result = MatrixCalculator.ScalarMultiplication(m, 2);
// Result: [[2, 4], [6, 8]]
```

---

##### `ScalarDivision(MatrixBase matrix, double number)`
Divides every element in the matrix by a scalar value.

**Throws**:
- `DivideByZeroException` - If number is 0

---

##### `MatrixMultiplication(MatrixBase matrix1, MatrixBase matrix2)`
Multiplies two matrices using the standard matrix multiplication algorithm.

**Requirements**: 
- matrix1.NumCols must equal matrix2.NumRows

**Throws**:
- `IncompatibleMatrixMultiplicationException` - If dimensions are incompatible

**Example**:
```csharp
var m1 = new MatrixBase(new double[,] { { 1, 2 }, { 3, 4 } });
var m2 = new MatrixBase(new double[,] { { 2, 0 }, { 1, 2 } });
var result = MatrixCalculator.MatrixMultiplication(m1, m2);
// Result: [[4, 4], [10, 8]]
```

**Mathematical Background**:
```
For C = A × B:
C[i,j] = Σ(A[i,k] × B[k,j]) for all k
```

---

##### `CalculateDeterminant(MatrixBase matrix)`
Calculates the determinant of a 2×2 matrix.

**Parameters**:
- `matrix` - Must be a 2×2 matrix

**Returns**: `double` - The determinant value

**Example**:
```csharp
var m = new MatrixBase(new double[,] { { 4, 3 }, { 2, 1 } });
double det = MatrixCalculator.CalculateDeterminant(m);
Console.WriteLine($"Determinant: {det}");  // Output: -2
```

**Mathematical Background**:
```
For a 2×2 matrix:
| a  b |
| c  d |

det = (a × d) - (b × c)
```

---

## 🔢 Number Theory

### Purpose
Calculate the Highest Common Factor (HCF) and Lowest Common Multiple (LCM) of two integers.

### Classes

#### `NumberTheory` (Static Class)

**Namespace**: `MathsEngine.Modules.Pure`

**Methods**:

##### `GetLcmAndHcf(int a, int b)`
Calculates both HCF and LCM for two integers.

**Parameters**:
- `a` (`int`) - First integer
- `b` (`int`) - Second integer

**Returns**: `(int Hcf, int Lcm)` - Tuple containing both values

**Example**:
```csharp
using MathsEngine.Modules.Pure;

var (hcf, lcm) = NumberTheory.GetLcmAndHcf(12, 18);
Console.WriteLine($"HCF: {hcf}, LCM: {lcm}");  // Output: HCF: 6, LCM: 36
```

**Mathematical Background**:
- **HCF**: Largest number that divides both a and b
- **LCM**: Smallest number that is divisible by both a and b
- Formula: `LCM(a, b) = (a × b) / HCF(a, b)`

---

## Common Exceptions

| Exception | Meaning | When It's Thrown |
|-----------|---------|------------------|
| `NullInputException` | Required input is missing | When a required parameter is null |
| `NegativeSideLengthException` | Side length is invalid | When a length is ≤ 0 |
| `HypotenuseNotLongestSideException` | Triangle constraint violated | When hypotenuse is not the longest side |
| `AcuteAngleException` | Angle out of valid range | When angle ≤ 0° or ≥ 90° |
| `DuplicateSideException` | Same side specified twice | When known side and side to find are the same |
| `IncompatibleMatrixAdditionException` | Matrix dimensions don't match | When adding/subtracting matrices of different sizes |
| `IncompatibleMatrixMultiplicationException` | Cannot multiply matrices | When matrix1.cols ≠ matrix2.rows |
| `NotSquareMatrixException` | Operation requires square matrix | When attempting determinant on non-square matrix |

---

## Usage Examples

### Example 1: Complete Trigonometry Workflow
```csharp
using MathsEngine.Modules.Pure.Trigonometry;

// Given: A right triangle with adjacent side = 8, angle = 40°
// Find: The opposite side and hypotenuse

// Step 1: Find opposite side
double opposite = Trigonometry.CalculateMissingSide(
    knownSideLength: 8,
    angle: 40,
    knownSideType: SideType.Adjacent,
    sideToFind: SideType.Opposite
);
Console.WriteLine($"Opposite: {opposite:F2}");  // ~6.71

// Step 2: Find hypotenuse
double hypotenuse = Trigonometry.CalculateMissingSide(
    knownSideLength: 8,
    angle: 40,
    knownSideType: SideType.Adjacent,
    sideToFind: SideType.Hypotenuse
);
Console.WriteLine($"Hypotenuse: {hypotenuse:F2}");  // ~10.44
```

### Example 2: Matrix Operations Chain
```csharp
using MathsEngine.Modules.Pure.Matrices;

// Create two matrices
var A = new MatrixBase(new double[,] { { 1, 2 }, { 3, 4 } });
var B = new MatrixBase(new double[,] { { 5, 6 }, { 7, 8 } });

// Add them
var sum = MatrixCalculator.AddMatrix(A, B);

// Multiply result by scalar
var scaled = MatrixCalculator.ScalarMultiplication(new MatrixBase(sum), 0.5);

// Calculate determinant
double det = MatrixCalculator.CalculateDeterminant(new MatrixBase(scaled));
Console.WriteLine($"Final determinant: {det}");
```

### Example 3: Error Handling
```csharp
using MathsEngine.Modules.Pure.PythagorasTheorem;
using MathsEngine.Utils;

try
{
    double result = PythagorasTheorem.CalculateHypotenuse(-3, 4);
}
catch (NegativeSideLengthException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
    // Handle gracefully - prompt user for valid input
}
catch (NullInputException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
    // Handle missing values
}
```

---

## Design Notes

### Why Static Methods for Calculations?
Pure mathematical operations are **stateless transformations** - the same inputs always produce the same outputs. Static methods make this explicit and avoid unnecessary object instantiation.

### Why Instance Class for MatrixBase?
A matrix **is** data with properties (dimensions, values), so it should be represented as an object. Operations **on** matrices are implemented in the static `MatrixCalculator` class.

### Why SideType Enum?
Using an enum instead of strings prevents typos and provides compile-time checking. `SideType.Opposite` is safer than `"opposite"`.

---

## Related Modules

- **Explanations/Pure/** - Educational wrappers providing step-by-step explanations
  - `TrigonometryTutor` - Shows trigonometry working
  - `PythagorasTheoremTutor` - Shows Pythagoras calculations step-by-step
  - `MatrixTutor` - Shows matrix operation breakdowns
- **Menu/Pure/** - Console UI for accessing these calculations
- **Utils/** - Shared parsing and exception handling

---

## Testing

Tests for this module can be found in:
- `MathsEngine.Tests/PureTests/PythagorasTests/`
- `MathsEngine.Tests/PureTests/TrigonometryTests/`
- `MathsEngine.Tests/PureTests/MatrixTests/`

**Test Coverage**: High  
**Number of Tests**: 51+ unit tests

---