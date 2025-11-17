# Dispersion Module

## Purpose

A brief, one-sentence description of what this module is responsible for.
*Example for `Dispersion`*: "This module provides tools to calculate statistical measures of dispersion, such as standard deviation and interquartile range."

## Key Components

List the main classes or files in the module and their roles.

*   **`StandardDeviation.cs`**: The main entry point for the standard deviation feature.
*   **`StandardDeviationLogic.cs`**: Contains the core calculation logic, keeping it separate from the user interaction.
*   **`Variables.cs`**: A static class that holds the data and results for the calculations.

## How to Use

Provide a simple code snippet showing how to use the module. This is incredibly helpful for future reference.

```csharp
// Example of how to calculate standard deviation
StandardDeviation.Calculate();
```

## Dependencies

This module depends on `MathsEngine.Modules.Core.StatisticsHelpers` for basic calculations like mean and median.