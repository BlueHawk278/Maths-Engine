# Statistics Module

## Overview

The Statistics module provides computational tools for statistical analysis taught at GCSE and A-level Mathematics. This module implements algorithms for measures of central tendency, dispersion, and correlation analysis.

**Key Features**:
- **Averages** - Calculate mean, median, mode, and range for raw data and frequency tables
- **Dispersion** - Calculate standard deviation, variance, and interquartile range (IQR)
- **Bivariate Analysis** - Perform Spearman's Rank correlation analysis with ranked data processing

**Design Principle**: All calculation classes are designed to be reusable and testable, with clear separation between data processing logic and user interface concerns.

---

## Module Structure

```
Modules/Statistics/
├── AverageCalculator.cs           # Generic calculator for mean, median, mode, range
├── Dispersion/
│   ├── IStandardDeviation.cs      # Interface for dispersion calculators
│   ├── ArrayOfNumbersCalculator.cs    # Raw data dispersion
│   ├── FrequencyTableCalculator.cs    # Discrete frequency table
│   ├── ContinuousTableCalculator.cs   # Grouped/continuous data
���   └── CombinedSets/
│       └── CombinedSetsCalculator.cs  # Combine two data sets
└── BivariateAnalysis/
    ├── BivariateAnalysis.cs           # Entry point for correlation analysis
    ├── BivariateAnalysisCalculator.cs # Spearman's Rank calculation
    └── Correlation.cs                 # Correlation enum and helpers
```

---

## 📊 Average Calculator

### Purpose
Calculate measures of central tendency (location) and spread for numerical datasets. Uses C# generics to work with any numeric type.

### Classes

#### `AverageCalculator<T>` (Generic Class)

**Namespace**: `MathsEngine.Modules.Statistics`

**Type Constraint**: `where T : INumber<T>` (requires .NET 7+)

**Key Responsibilities**:
- Calculate mean (average)
- Calculate median (middle value)
- Calculate mode (most frequent value)
- Calculate range (max - min)
- Calculate interquartile range (IQR)

---

### Methods

#### 1. `CalculateMean(List<T> numbers)`
Calculates the arithmetic mean (average) of a list of numbers.

**Parameters**:
- `numbers` (`List<T>`) - List of numeric values

**Returns**: `T` - The mean value

**Throws**:
- `NullInputException` - If the list is null or empty

**Example**:
```csharp
using MathsEngine.Modules.Statistics;

var calculator = new AverageCalculator<double>();
var data = new List<double> { 10, 20, 30, 40, 50 };
double mean = calculator.CalculateMean(data);
Console.WriteLine($"Mean: {mean}");  // Output: 30
```

**Mathematical Background**:
```
Mean = (Sum of all values) / (Number of values)
Mean = (10 + 20 + 30 + 40 + 50) / 5 = 150 / 5 = 30
```

---

#### 2. `CalculateMedian(List<T> numbers)`
Calculates the median (middle value) of a list of numbers.

**Parameters**:
- `numbers` (`List<T>`) - List of numeric values

**Returns**: `T` - The median value

**Throws**:
- `NullInputException` - If the list is null or empty

**Example**:
```csharp
var data = new List<double> { 10, 20, 30, 40, 50 };
double median = calculator.CalculateMedian(data);
Console.WriteLine($"Median: {median}");  // Output: 30

// Even number of values
var data2 = new List<double> { 10, 20, 30, 40 };
double median2 = calculator.CalculateMedian(data2);
Console.WriteLine($"Median: {median2}");  // Output: 25
```

**Mathematical Background**:
- **Odd count**: Median is the middle value when sorted
- **Even count**: Median is the average of the two middle values

---

#### 3. `CalculateMode(List<T> numbers)`
Calculates the mode(s) - the most frequently occurring value(s).

**Parameters**:
- `numbers` (`List<T>`) - List of numeric values

**Returns**: `List<T>` - List containing the mode(s), or empty list if no mode exists

**Throws**:
- `NullInputException` - If the list is null or has only one value

**Example**:
```csharp
var data = new List<int> { 1, 2, 2, 3, 3, 3, 4 };
var modes = calculator.CalculateMode(data);
Console.WriteLine($"Mode: {modes[0]}");  // Output: 3

// Bimodal dataset
var data2 = new List<int> { 1, 2, 2, 3, 3 };
var modes2 = calculator.CalculateMode(data2);
// Output: [2, 3] (both appear twice)
```

**Mathematical Background**:
- Mode is the value(s) that appear most frequently
- A dataset can have no mode (all values unique), one mode, or multiple modes (bimodal/multimodal)

---

#### 4. `CalculateRange(List<T> numbers)`
Calculates the range (difference between maximum and minimum values).

**Parameters**:
- `numbers` (`List<T>`) - List of numeric values

**Returns**: `T` - The range

**Example**:
```csharp
var data = new List<double> { 10, 25, 15, 40, 5 };
double range = calculator.CalculateRange(data);
Console.WriteLine($"Range: {range}");  // Output: 35 (40 - 5)
```

---

#### 5. `GetInterQuartileRange(List<T> numbers)`
Calculates Q1, Q3, and the interquartile range (IQR).

**Parameters**:
- `numbers` (`List<T>`) - List of numeric values

**Returns**: `List<T>` - List containing [Q1, Q3, IQR]

**Example**:
```csharp
var data = new List<double> { 5, 7, 9, 11, 13, 15, 17, 19, 21 };
var quartiles = calculator.GetInterQuartileRange(data);
Console.WriteLine($"Q1: {quartiles[0]}");    // Lower quartile
Console.WriteLine($"Q3: {quartiles[1]}");    // Upper quartile
Console.WriteLine($"IQR: {quartiles[2]}");   // Q3 - Q1
```

**Mathematical Background**:
- **Q1 (Lower Quartile)**: 25th percentile - 25% of data falls below this
- **Q3 (Upper Quartile)**: 75th percentile - 75% of data falls below this
- **IQR**: Q3 - Q1, measures the spread of the middle 50% of data

---

## 📈 Dispersion (Standard Deviation)

### Purpose
Calculate measures of dispersion (spread) for different data representations: raw data, frequency tables, and grouped/continuous data.

### Interface

#### `IStandardDeviation`

**Namespace**: `MathsEngine.Modules.Statistics.Dispersion`

Defines the contract for all dispersion calculators.

**Properties**:
- `Mean` (`double`) - The mean of the dataset
- `Variance` (`double`) - The variance (σ²)
- `StandardDeviation` (`double`) - The standard deviation (σ)

**Methods**:
- `Run()` - Performs all calculations
- `DisplayData()` - Outputs results to console

---

### Classes

#### 1. `ArrayOfNumbersCalculator` (Raw Data)

**Namespace**: `MathsEngine.Modules.Statistics.Dispersion`

Calculates dispersion for a simple list of numbers.

**Constructor**:
```csharp
public ArrayOfNumbersCalculator(List<double> originalValues)
```

**Parameters**:
- `originalValues` - List of raw data values

**Throws**:
- `NullInputException` - If list is null
- `EmptyDataSetException` - If list is empty

**Example**:
```csharp
using MathsEngine.Modules.Statistics.Dispersion;

var data = new List<double> { 2, 4, 4, 4, 5, 5, 7, 9 };
var calculator = new ArrayOfNumbersCalculator(data);
calculator.Run();

Console.WriteLine($"Mean: {calculator.Mean}");
Console.WriteLine($"Variance: {calculator.Variance}");
Console.WriteLine($"Standard Deviation: {calculator.StandardDeviation}");

// Or display all results at once
calculator.DisplayData();
```

**Calculations Performed**:
- Mean, median, mode, range
- Q1, Q3, IQR
- Variance and standard deviation

**Mathematical Background**:
```
Variance (σ²) = Σ(x - μ)² / n
Standard Deviation (σ) = √Variance

Where:
- x = each value
- μ = mean
- n = number of values
```

---

#### 2. `FrequencyTableCalculator` (Discrete Frequency Data)

**Namespace**: `MathsEngine.Modules.Statistics.Dispersion`

Calculates dispersion for frequency table data (discrete values with frequencies).

**Constructor**:
```csharp
public FrequencyTableCalculator(List<double> values, List<int> frequencies)
```

**Parameters**:
- `values` - List of distinct x values
- `frequencies` - List of frequencies (f) corresponding to each value

**Throws**:
- `NullInputException` - If either list is null
- `EmptyDataSetException` - If lists are empty
- `ListsNotSameSizeException` - If lists have different lengths
- `InvalidFrequencyException` - If any frequency is negative

**Example**:
```csharp
// Data: Value 10 appears 3 times, 20 appears 5 times, 30 appears 2 times
var values = new List<double> { 10, 20, 30 };
var frequencies = new List<int> { 3, 5, 2 };

var calculator = new FrequencyTableCalculator(values, frequencies);
calculator.Run();
calculator.DisplayData();
```

**Mathematical Background**:
```
Mean = Σ(f × x) / Σf

Variance = [Σ(f × x²) / Σf] - μ²

Where:
- f = frequency
- x = value
- μ = mean
- Σf = total frequency
```

---

#### 3. `ContinuousTableCalculator` (Grouped/Continuous Data)

**Namespace**: `MathsEngine.Modules.Statistics.Dispersion`

Calculates dispersion for grouped data with class intervals.

**Constructor**:
```csharp
public ContinuousTableCalculator(List<string> classIntervals, List<int> frequencies)
```

**Parameters**:
- `classIntervals` - List of class intervals as strings (e.g., "10-20", "20-30")
- `frequencies` - List of frequencies for each class

**Throws**:
- `NullInputException` - If either list is null
- `EmptyDataSetException` - If lists are empty
- `ListsNotSameSizeException` - If lists have different lengths
- `InvalidFrequencyException` - If any frequency is negative
- `InvalidClassIntervalFormatException` - If interval format is incorrect

**Example**:
```csharp
// Class intervals with frequencies
var intervals = new List<string> { "0-10", "10-20", "20-30", "30-40" };
var frequencies = new List<int> { 5, 12, 8, 3 };

var calculator = new ContinuousTableCalculator(intervals, frequencies);
calculator.Run();
calculator.DisplayData();
```

**Mathematical Background**:
```
For grouped data, use class midpoints:
Midpoint = (Lower bound + Upper bound) / 2

Then calculate mean and variance using midpoints as x values
```

---

#### 4. `CombinedSetsCalculator` (Combining Two Data Sets)

**Namespace**: `MathsEngine.Modules.Statistics.Dispersion.CombinedSets`

Combines statistics from two separate datasets without access to the raw data.

**Constructor**:
```csharp
public CombinedSetsCalculator(
    int n1, double mean1, double stdDev1,
    int n2, double mean2, double stdDev2
)
```

**Parameters**:
- `n1` - Size of first dataset
- `mean1` - Mean of first dataset
- `stdDev1` - Standard deviation of first dataset
- `n2` - Size of second dataset
- `mean2` - Mean of second dataset
- `stdDev2` - Standard deviation of second dataset

**Throws**:
- `InsufficientDataException` - If n1 or n2 ≤ 0
- `ArgumentException` - If any standard deviation is negative

**Example**:
```csharp
using MathsEngine.Modules.Statistics.Dispersion.CombinedSets;

// Dataset 1: n=30, mean=50, σ=5
// Dataset 2: n=20, mean=60, σ=8
var calculator = new CombinedSetsCalculator(
    n1: 30, mean1: 50, stdDev1: 5,
    n2: 20, mean2: 60, stdDev2: 8
);
calculator.Run();
calculator.DisplayData();
```

**Mathematical Background**:
```
Combined Mean = (n₁μ₁ + n₂μ₂) / (n₁ + n₂)

Combined Variance = [Σx² / n_total] - μ_combined²

Where Σx² = n₁(σ₁² + μ₁²) + n₂(σ₂² + μ₂²)
```

---

## 📉 Bivariate Analysis

### Purpose
Analyze the relationship between two variables using Spearman's Rank correlation coefficient.

### Classes

#### `Correlation` (Enum)

**Namespace**: `MathsEngine.Modules.Statistics.BivariateAnalysis`

Represents the strength and direction of correlation.

**Values**:
- `PerfectPositive` - ρ = 1
- `StrongPositive` - ρ ≥ 0.7
- `WeakPositive` - 0 < ρ < 0.7
- `NoCorrelation` - ρ = 0
- `WeakNegative` - -0.7 < ρ < 0
- `StrongNegative` - ρ ≤ -0.7
- `PerfectNegative` - ρ = -1
- `Invalid` - Outside -1 to 1 range

---

#### `BivariateAnalysisCalculator` (Instance Class)

**Namespace**: `MathsEngine.Modules.Statistics.BivariateAnalysis`

Performs Spearman's Rank correlation analysis on two datasets.

**Constructor**:
```csharp
public BivariateAnalysisCalculator(List<int> scores1, List<int> scores2)
```

**Parameters**:
- `scores1` - First dataset
- `scores2` - Second dataset (must be same length as scores1)

**Throws**:
- `NullInputException` - If either list is null
- `ListsNotSameSizeException` - If lists have different lengths
- `InsufficientDataException` - If fewer than 2 data pairs

**Properties**:
- `Ranks1` (`List<double>`) - Ranked values from dataset 1
- `Ranks2` (`List<double>`) - Ranked values from dataset 2
- `Difference` (`List<double>`) - Rank differences (d)
- `DifferenceSquared` (`List<double>`) - Squared rank differences (d²)
- `SumDifferenceSquared` (`double`) - Σd²
- `CorrelationCoefficient` (`double`) - Spearman's ρ
- `Correlation` (`Correlation`) - Correlation category
- `CorrelationString` (`string`) - Human-readable correlation description

**Methods**:

##### `Run()`
Executes the full Spearman's Rank calculation sequence.

**Example**:
```csharp
using MathsEngine.Modules.Statistics.BivariateAnalysis;

var maths = new List<int> { 85, 92, 78, 88, 95 };
var physics = new List<int> { 80, 90, 75, 85, 93 };

var calculator = new BivariateAnalysisCalculator(maths, physics);
calculator.Run();

Console.WriteLine($"Spearman's ρ: {calculator.CorrelationCoefficient:F3}");
Console.WriteLine($"Correlation: {calculator.CorrelationString}");
Console.WriteLine($"Σd²: {calculator.SumDifferenceSquared}");
```

**Mathematical Background**:
```
Spearman's Rank Correlation Coefficient:

ρ = 1 - (6 × Σd²) / [n(n² - 1)]

Where:
- d = difference between ranks for each pair
- n = number of data pairs
- Σd² = sum of squared differences

Steps:
1. Rank both datasets (highest = 1)
2. Calculate difference (d) for each pair
3. Square the differences (d²)
4. Sum the squared differences (Σd²)
5. Apply formula to get ρ

Handling Tied Ranks:
- If multiple values are equal, assign average rank
- E.g., values at positions 3, 4, 5 all equal → each gets rank 4
```

---

#### `BivariateAnalysis` (Static Class)

**Namespace**: `MathsEngine.Modules.Statistics.BivariateAnalysis`

Provides a console-based entry point for bivariate analysis.

**Methods**:

##### `Start()`
Interactive console session for Spearman's Rank analysis.

**Example**:
```csharp
BivariateAnalysis.Start();
// Prompts user for two datasets
// Performs analysis
// Displays results
```

---

## Common Exceptions

| Exception | Meaning | When It's Thrown |
|-----------|---------|------------------|
| `NullInputException` | Required input is missing | When a parameter or dataset is null |
| `EmptyDataSetException` | Dataset is empty | When attempting calculations on empty data |
| `ListsNotSameSizeException` | Lists have different lengths | When paired data have different counts |
| `InsufficientDataException` | Not enough data points | When dataset is too small for calculation |
| `InvalidFrequencyException` | Frequency value is invalid | When a frequency is negative |
| `InvalidClassIntervalFormatException` | Class interval format wrong | When interval string isn't "lower-upper" format |

---

## Usage Examples

### Example 1: Complete Statistical Analysis (Raw Data)
```csharp
using MathsEngine.Modules.Statistics;
using MathsEngine.Modules.Statistics.Dispersion;

// Raw exam scores
var scores = new List<double> { 45, 52, 58, 62, 65, 68, 70, 72, 75, 85 };

// Calculate averages
var avgCalc = new AverageCalculator<double>();
double mean = avgCalc.CalculateMean(scores);
double median = avgCalc.CalculateMedian(scores);

Console.WriteLine($"Mean: {mean:F1}");
Console.WriteLine($"Median: {median:F1}");

// Calculate dispersion
var dispCalc = new ArrayOfNumbersCalculator(scores);
dispCalc.Run();

Console.WriteLine($"Standard Deviation: {dispCalc.StandardDeviation:F2}");
Console.WriteLine($"Variance: {dispCalc.Variance:F2}");
```

### Example 2: Frequency Table Analysis
```csharp
using MathsEngine.Modules.Statistics.Dispersion;

// Survey results: How many hours studied?
var hours = new List<double> { 0, 1, 2, 3, 4, 5 };
var students = new List<int> { 2, 5, 12, 18, 8, 3 };

var calculator = new FrequencyTableCalculator(hours, students);
calculator.Run();

Console.WriteLine($"Average study hours: {calculator.Mean:F2}");
Console.WriteLine($"Standard deviation: {calculator.StandardDeviation:F2}");
```

### Example 3: Spearman's Rank Correlation
```csharp
using MathsEngine.Modules.Statistics.BivariateAnalysis;

// Student rankings in two subjects
var mathRank = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8 };
var scienceRank = new List<int> { 2, 1, 4, 3, 6, 5, 7, 8 };

var calculator = new BivariateAnalysisCalculator(mathRank, scienceRank);
calculator.Run();

Console.WriteLine($"Correlation coefficient: {calculator.CorrelationCoefficient:F3}");
Console.WriteLine($"Interpretation: {calculator.CorrelationString}");

if (calculator.CorrelationCoefficient > 0.7)
{
    Console.WriteLine("Strong positive correlation detected!");
}
```

### Example 4: Combining Two Datasets
```csharp
using MathsEngine.Modules.Statistics.Dispersion.CombinedSets;

// Class A: 25 students, mean=72, σ=8
// Class B: 30 students, mean=68, σ=10
// What are the combined statistics?

var calculator = new CombinedSetsCalculator(
    n1: 25, mean1: 72, stdDev1: 8,
    n2: 30, mean2: 68, stdDev2: 10
);
calculator.Run();

Console.WriteLine($"Combined mean: {calculator.Mean:F2}");
Console.WriteLine($"Combined std dev: {calculator.StandardDeviation:F2}");
```

### Example 5: Error Handling
```csharp
using MathsEngine.Modules.Statistics.Dispersion;
using MathsEngine.Utils;

try
{
    var values = new List<double> { 10, 20, 30 };
    var frequencies = new List<int> { 5, 8 };  // Wrong size!
    
    var calculator = new FrequencyTableCalculator(values, frequencies);
}
catch (ListsNotSameSizeException ex)
{
    Console.WriteLine($"Error: {ex.Message}");
    Console.WriteLine("Ensure each value has a corresponding frequency.");
}
```

---

## Design Notes

### Why Generic AverageCalculator<T>?
Using generics with `INumber<T>` allows the same code to work with `int`, `double`, `decimal`, and other numeric types without code duplication. This demonstrates advanced C# knowledge appropriate for A-level coursework.

### Why Separate Calculator Classes for Different Data Types?
Different data representations (raw data, frequency tables, grouped data) require different calculation approaches. Separate classes follow the Single Responsibility Principle and make the code easier to understand and test.

### Why Interface for Dispersion Calculators?
The `IStandardDeviation` interface ensures all dispersion calculators provide consistent properties (`Mean`, `Variance`, `StandardDeviation`) and methods (`Run()`, `DisplayData()`), making them interchangeable.

### How Does Spearman's Rank Handle Tied Values?
When multiple values are equal, they're assigned the average of the ranks they would occupy. For example, if three values tie for ranks 4, 5, and 6, each receives rank 5 (the average of 4, 5, and 6).

---

## Related Modules

- **Explanations/Statistics/** - Educational wrappers providing step-by-step explanations
  - `StandardDeviationTutor` - Shows variance and standard deviation calculations
  - `BivariateAnalysisTutor` - Shows Spearman's Rank working step-by-step
- **Menu/Statistics/** - Console UI for accessing these calculations
- **Utils/** - Shared parsing and exception handling

---

## Testing

Tests for this module can be found in:
- `MathsEngine.Tests/StatisticsTests/DispersionTests/`
- `MathsEngine.Tests/StatisticsTests/BivariateAnalysisTests/`

**Test Coverage**: High  
**Number of Tests**: 19+ unit tests

**Key Test Scenarios**:
- Accuracy of mean, median, mode calculations
- Correct handling of even/odd dataset sizes for median
- Variance and standard deviation calculations
- Spearman's Rank with tied values
- Combined sets calculations
- Error conditions (null data, mismatched sizes, negative frequencies)

---