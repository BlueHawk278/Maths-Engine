# Mechanics Module

## Overview

The Mechanics module provides computational tools for physics calculations taught at GCSE and A-level Physics/Further Mathematics. This module implements algorithms for dynamics (forces) and kinematics (motion).

**Key Features**:
- **Newton's Laws** - F = ma calculations for force, mass, and acceleration
- **Uniform Acceleration** - SUVAT equation solvers for motion with constant acceleration
- **Multiple Unknown Solver** - Automatically selects appropriate equation based on known values

**Design Principle**: All calculation methods use nullable parameters to represent "unknown" values, allowing a single method to solve for different variables depending on what the user provides.

---

## Module Structure

```
Modules/Mechanics/
├── Dynamics/
│   └── NewtonsLawsCalculator.cs       # F = ma calculations
└── UniformAcceleration/
    └── UniformAccelerationCalculator.cs   # SUVAT equations
```

---

## ⚙️ Dynamics (Newton's Laws)

### Purpose
Solve problems involving Newton's Second Law: **F = ma** (Force = mass × acceleration)

**Units**:
- Force (F): Newtons (N)
- Mass (m): Kilograms (kg)
- Acceleration (a): Metres per second squared (m/s²)

### Classes

#### `NewtonsLawsCalculator` (Static Class)

**Namespace**: `MathsEngine.Modules.Mechanics.Dynamics`

**Key Responsibilities**:
- Calculate force given mass and acceleration
- Calculate mass given force and acceleration
- Calculate acceleration given force and mass
- Validate F = ma equations

---

### Methods

#### 1. `CalculateFma(double? f, double? m, double? a)`
Solves F = ma for the single unknown variable.

**Parameters**:
- `f` (`double?`) - Force in Newtons (null if this is the unknown)
- `m` (`double?`) - Mass in kilograms (null if this is the unknown, must be > 0)
- `a` (`double?`) - Acceleration in m/s² (null if this is the unknown)

**Returns**: `double?` - The calculated value

**Throws**:
- `NullInputException` - If more than one parameter is null or all parameters are provided
- `NullMassException` - If mass is 0 or negative
- `DivideByZeroException` - If attempting to divide by zero during calculation
- `InvalidOperationException` - If calculation is not possible with provided values

**Example - Finding Force**:
```csharp
using MathsEngine.Modules.Mechanics.Dynamics;

// A car with mass 1500kg accelerates at 2 m/s². Find the force.
double? force = NewtonsLawsCalculator.CalculateFma(
    f: null,    // Unknown - to be calculated
    m: 1500,    // Mass in kg
    a: 2        // Acceleration in m/s²
);
Console.WriteLine($"Force: {force} N");  // Output: 3000 N
```

**Example - Finding Mass**:
```csharp
// A 500N force causes 2.5 m/s² acceleration. Find the mass.
double? mass = NewtonsLawsCalculator.CalculateFma(
    f: 500,     // Force in N
    m: null,    // Unknown - to be calculated
    a: 2.5      // Acceleration in m/s²
);
Console.WriteLine($"Mass: {mass} kg");  // Output: 200 kg
```

**Example - Finding Acceleration**:
```csharp
// A 200N force acts on a 50kg object. Find the acceleration.
double? acceleration = NewtonsLawsCalculator.CalculateFma(
    f: 200,     // Force in N
    m: 50,      // Mass in kg
    a: null     // Unknown - to be calculated
);
Console.WriteLine($"Acceleration: {acceleration} m/s²");  // Output: 4 m/s²
```

**Mathematical Background**:
```
Newton's Second Law: F = ma

Rearranging:
- To find Force:        F = m × a
- To find Mass:         m = F / a
- To find Acceleration: a = F / m
```

---

#### 2. `CheckValidCalculation(double? f, double? m, double? a)`
Verifies if three given values satisfy F = ma (accounting for floating-point precision).

**Parameters**:
- `f` (`double?`) - Force in Newtons
- `m` (`double?`) - Mass in kilograms
- `a` (`double?`) - Acceleration in m/s²

**Returns**: `bool` - `true` if the equation is satisfied, `false` otherwise

**Throws**:
- `ArgumentException` - If any parameter is null
- `NullMassException` - If mass is 0 or negative

**Example**:
```csharp
bool isValid = NewtonsLawsCalculator.CheckValidCalculation(
    f: 100,
    m: 25,
    a: 4
);
Console.WriteLine($"Valid: {isValid}");  // Output: True (100 = 25 × 4)

bool isInvalid = NewtonsLawsCalculator.CheckValidCalculation(
    f: 100,
    m: 25,
    a: 5
);
Console.WriteLine($"Valid: {isInvalid}");  // Output: False (100 ≠ 25 × 5)
```

**Mathematical Background**:
```
Checks if: |F - (m × a)| < 1e-9

Uses tolerance for floating-point comparison
```

---

## 🚀 Uniform Acceleration (SUVAT Equations)

### Purpose
Solve motion problems with constant acceleration using the SUVAT equations.

**Variables**:
- **s**: Displacement (m)
- **u**: Initial velocity (m/s)
- **v**: Final velocity (m/s)
- **a**: Acceleration (m/s²)
- **t**: Time (s)

**The Five SUVAT Equations**:
1. `v = u + at`
2. `v² = u² + 2as`
3. `s = ut + ½at²`
4. `s = ½(u + v)t`
5. `s = vt - ½at²`

### Classes

#### `UniformAccelerationCalculator` (Static Class)

**Namespace**: `MathsEngine.Modules.Mechanics.UniformAcceleration`

**Key Responsibilities**:
- Calculate average velocity
- Solve SUVAT equations for unknown variables
- Automatically select appropriate equation based on known values

---

### Methods

#### 1. `CalculateAverageVelocity(double? initialVelocity, double? finalVelocity)`
Calculates the average velocity given initial and final velocities.

**Parameters**:
- `initialVelocity` (`double?`) - Initial velocity (u) in m/s
- `finalVelocity` (`double?`) - Final velocity (v) in m/s

**Returns**: `double` - Average velocity in m/s

**Throws**:
- `InvalidOperationException` - If either parameter is null

**Example**:
```csharp
using MathsEngine.Modules.Mechanics.UniformAcceleration;

// Object accelerates from 10 m/s to 30 m/s
double avgVelocity = UniformAccelerationCalculator.CalculateAverageVelocity(
    initialVelocity: 10,
    finalVelocity: 30
);
Console.WriteLine($"Average velocity: {avgVelocity} m/s");  // Output: 20 m/s
```

**Mathematical Background**:
```
Average velocity = (u + v) / 2
```

---

#### 2. `CalculateVUAT(double? v, double? u, double? a, double? t)`
Solves the equation **v = u + at** for the single unknown variable.

**Parameters**:
- `v` (`double?`) - Final velocity (m/s)
- `u` (`double?`) - Initial velocity (m/s)
- `a` (`double?`) - Acceleration (m/s²)
- `t` (`double?`) - Time (s)

**Returns**: `double?` - The calculated value, or null if all values are provided

**Throws**:
- `InvalidOperationException` - If more than one parameter is null
- `DivideByZeroException` - If attempting to divide by zero

**Example - Finding Final Velocity**:
```csharp
// Initial velocity 5 m/s, acceleration 2 m/s², time 10s
double? v = UniformAccelerationCalculator.CalculateVUAT(
    v: null,    // Unknown
    u: 5,
    a: 2,
    t: 10
);
Console.WriteLine($"Final velocity: {v} m/s");  // Output: 25 m/s
```

**Example - Finding Time**:
```csharp
// From 0 to 20 m/s with 4 m/s² acceleration
double? t = UniformAccelerationCalculator.CalculateVUAT(
    v: 20,
    u: 0,
    a: 4,
    t: null     // Unknown
);
Console.WriteLine($"Time: {t} s");  // Output: 5 s
```

**Mathematical Background**:
```
v = u + at

Rearranging:
- To find v: v = u + at
- To find u: u = v - at
- To find a: a = (v - u) / t
- To find t: t = (v - u) / a
```

---

#### 3. `CalculateVUAS(double? v, double? u, double? a, double? s)`
Solves the equation **v² = u² + 2as** for the single unknown variable.

**Parameters**:
- `v` (`double?`) - Final velocity (m/s)
- `u` (`double?`) - Initial velocity (m/s)
- `a` (`double?`) - Acceleration (m/s²)
- `s` (`double?`) - Displacement (m)

**Returns**: `double?` - The calculated value

**Throws**:
- `InvalidOperationException` - If more than one parameter is null or calculation not possible
- `DivideByZeroException` - If attempting to divide by zero

**Example**:
```csharp
// Object accelerates from rest at 3 m/s² over 50m. Find final velocity.
double? v = UniformAccelerationCalculator.CalculateVUAS(
    v: null,    // Unknown
    u: 0,       // Starts from rest
    a: 3,
    s: 50
);
Console.WriteLine($"Final velocity: {v:F2} m/s");  // Output: 17.32 m/s
```

**Mathematical Background**:
```
v² = u² + 2as

Rearranging:
- To find v: v = √(u² + 2as)
- To find u: u = √(v² - 2as)
- To find a: a = (v² - u²) / (2s)
- To find s: s = (v² - u²) / (2a)
```

---

#### 4. `CalculateSUVT(double? s, double? u, double? v, double? t)`
Solves the equation **s = ½(u + v)t** for the single unknown variable.

**Parameters**:
- `s` (`double?`) - Displacement (m)
- `u` (`double?`) - Initial velocity (m/s)
- `v` (`double?`) - Final velocity (m/s)
- `t` (`double?`) - Time (s)

**Returns**: `double?` - The calculated value

**Throws**:
- `InvalidOperationException` - If more than one parameter is null
- `DivideByZeroException` - If attempting to divide by zero

**Example**:
```csharp
// Accelerates from 10 m/s to 30 m/s in 4s. Find displacement.
double? s = UniformAccelerationCalculator.CalculateSUVT(
    s: null,    // Unknown
    u: 10,
    v: 30,
    t: 4
);
Console.WriteLine($"Displacement: {s} m");  // Output: 80 m
```

**Mathematical Background**:
```
s = ½(u + v)t = (average velocity) × time

Rearranging:
- To find s: s = 0.5 × (u + v) × t
- To find u: u = (2s / t) - v
- To find v: v = (2s / t) - u
- To find t: t = 2s / (u + v)
```

---

#### 5. `CalculateSUTAT(double? s, double? u, double? t, double? a)`
Solves the equation **s = ut + ½at²** for the single unknown variable.

**Parameters**:
- `s` (`double?`) - Displacement (m)
- `u` (`double?`) - Initial velocity (m/s)
- `t` (`double?`) - Time (s)
- `a` (`double?`) - Acceleration (m/s²)

**Returns**: `double?` - The calculated value

**Throws**:
- `InvalidOperationException` - If more than one parameter is null or involves quadratic with no solution
- `DivideByZeroException` - If attempting to divide by zero

**Example**:
```csharp
// Object starts at 5 m/s, accelerates at 2 m/s² for 10s. Find displacement.
double? s = UniformAccelerationCalculator.CalculateSUTAT(
    s: null,    // Unknown
    u: 5,
    t: 10,
    a: 2
);
Console.WriteLine($"Displacement: {s} m");  // Output: 150 m
```

**Mathematical Background**:
```
s = ut + ½at²

Rearranging:
- To find s: s = u×t + 0.5×a×t²
- To find u: u = (s - 0.5×a×t²) / t
- To find a: a = 2(s - u×t) / t²
- To find t: Requires solving quadratic equation
  ½at² + ut - s = 0
```

---

## Common Exceptions

| Exception | Meaning | When It's Thrown |
|-----------|---------|------------------|
| `NullInputException` | Wrong number of unknowns | When more than 1 or 0 values are null in F=ma |
| `NullMassException` | Mass is invalid | When mass ≤ 0 |
| `InvalidOperationException` | Cannot perform calculation | When more than 1 unknown in SUVAT or calculation impossible |
| `DivideByZeroException` | Division by zero attempted | When dividing by a parameter that is 0 |
| `ArgumentException` | Invalid arguments | When all parameters should be provided but one is null |

---

## Usage Examples

### Example 1: Complete F = ma Problem
```csharp
using MathsEngine.Modules.Mechanics.Dynamics;

// A rocket with mass 50,000 kg produces 2,000,000 N of thrust.
// What is its acceleration?

double? acceleration = NewtonsLawsCalculator.CalculateFma(
    f: 2_000_000,   // 2 million Newtons
    m: 50_000,      // 50,000 kg
    a: null         // Unknown
);

Console.WriteLine($"Rocket acceleration: {acceleration} m/s²");
// Output: 40 m/s²
```

### Example 2: Multi-Step SUVAT Problem
```csharp
using MathsEngine.Modules.Mechanics.UniformAcceleration;

// A car accelerates from rest at 3 m/s² for 5 seconds.
// Find: (a) final velocity, (b) distance travelled

// Part (a): Find final velocity using v = u + at
double? finalVelocity = UniformAccelerationCalculator.CalculateVUAT(
    v: null,
    u: 0,       // From rest
    a: 3,
    t: 5
);
Console.WriteLine($"Final velocity: {finalVelocity} m/s");  // 15 m/s

// Part (b): Find distance using s = ut + ½at²
double? distance = UniformAccelerationCalculator.CalculateSUTAT(
    s: null,
    u: 0,
    t: 5,
    a: 3
);
Console.WriteLine($"Distance: {distance} m");  // 37.5 m

// Alternative: Use s = ½(u+v)t
double? distanceAlt = UniformAccelerationCalculator.CalculateSUVT(
    s: null,
    u: 0,
    v: finalVelocity,
    t: 5
);
Console.WriteLine($"Distance (check): {distanceAlt} m");  // 37.5 m
```

### Example 3: Braking Distance Problem
```csharp
using MathsEngine.Modules.Mechanics.UniformAcceleration;

// A car travelling at 25 m/s brakes with deceleration 6 m/s².
// How far does it travel before stopping?

double? distance = UniformAccelerationCalculator.CalculateVUAS(
    v: 0,           // Comes to rest
    u: 25,          // Initial speed
    a: -6,          // Deceleration (negative acceleration)
    s: null         // Unknown
);

Console.WriteLine($"Braking distance: {distance:F2} m");  // 52.08 m
```

### Example 4: Combined Dynamics and Kinematics
```csharp
using MathsEngine.Modules.Mechanics.Dynamics;
using MathsEngine.Modules.Mechanics.UniformAcceleration;

// A 1200kg car experiences 3600N driving force.
// Step 1: Find acceleration
double? acceleration = NewtonsLawsCalculator.CalculateFma(
    f: 3600,
    m: 1200,
    a: null
);
Console.WriteLine($"Acceleration: {acceleration} m/s²");  // 3 m/s²

// Step 2: If it accelerates from 5 m/s for 8 seconds, find final speed
double? finalSpeed = UniformAccelerationCalculator.CalculateVUAT(
    v: null,
    u: 5,
    a: acceleration,
    t: 8
);
Console.WriteLine($"Final speed: {finalSpeed} m/s");  // 29 m/s
```

### Example 5: Error Handling
```csharp
using MathsEngine.Modules.Mechanics.Dynamics;
using MathsEngine.Utils;

try
{
    // Trying to calculate with mass = 0 (invalid)
    double? result = NewtonsLawsCalculator.CalculateFma(
        f: 100,
        m: 0,       // Invalid!
        a: null
    );
}
catch (NullMassException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
    Console.WriteLine("Mass must be a positive value.");
}

try
{
    // Trying to calculate with two unknowns (impossible)
    double? result = UniformAccelerationCalculator.CalculateVUAT(
        v: null,    // Unknown
        u: null,    // Also unknown!
        a: 2,
        t: 5
    );
}
catch (InvalidOperationException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
    Console.WriteLine("Can only solve for one unknown at a time.");
}
```

---

## Design Notes

### Why Nullable Parameters?
Using `double?` to represent unknown values is natural and type-safe. `null` explicitly means "this is what I want to calculate", making the API self-documenting.

### Why Single Methods Instead of Multiple Overloads?
Having one method that can solve for any unknown (based on which parameter is `null`) is more flexible than having separate methods like `CalculateForce(m, a)`, `CalculateMass(f, a)`, etc. It reduces code duplication and makes the API simpler.

### How Does the SUVAT Solver Choose Which Equation?
The calculator examines which parameters are `null` and selects the appropriate equation. For example:
- If `s`, `u`, `v`, `t` are provided → no calculation needed
- If only `s` is null and you have `u`, `v`, `t` → use s = ½(u+v)t
- The user doesn't need to know which equation to use - the calculator figures it out

### Why Separate Methods for Each SUVAT Equation?
Each equation involves different variables. Separate methods make it clear which variables are needed for each calculation type and improve error messages when invalid combinations are provided.

---

## Related Modules

- **Explanations/Mechanics/** - Educational wrappers providing step-by-step explanations
  - `NewtonsLawsTutor` - Shows F = ma calculations with working
  - `UniformAccelerationTutor` - Shows SUVAT equation solutions step-by-step
- **Menu/Mechanics/** - Console UI for accessing these calculations
- **Utils/** - Shared parsing and exception handling

---

## Testing

Tests for this module can be found in:
- `MathsEngine.Tests/MechanicsTests/DynamicsTests/`
- `MathsEngine.Tests/MechanicsTests/UniformAccelerationTests/`

**Test Coverage**: High  
**Number of Tests**: 23+ unit tests

**Key Test Scenarios**:
- Accuracy of F = ma calculations for each variable
- Accuracy of each SUVAT equation
- Handling of negative values (deceleration, negative displacement)
- Error conditions (mass = 0, division by zero, too many unknowns)
- Edge cases (acceleration = 0, time = 0)
- Floating-point precision in validation

---