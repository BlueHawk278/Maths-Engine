# Dispersion — Sub-module

Provides four calculator classes for standard deviation, variance, and related measures. All implement the `IStandardDeviation` interface.

## `IStandardDeviation` Interface

```csharp
public interface IStandardDeviation
{
    double Mean { get; }
    double Variance { get; }
    double StandardDeviation { get; }
    void Run();
}
```

All calculators follow the same pattern: construct with data → call `Run()` → read properties.

## Calculator Comparison

| Class | Input | Extra Outputs |
|---|---|---|
| `ArrayOfNumbersCalculator` | `List<double>` | Median, Mode, Range, Q1, Q3, IQR |
| `FrequencyTableCalculator` | `List<double>` values + `List<int>` frequencies | — |
| `ContinuousTableCalculator` | `List<string>` intervals (e.g. `"10-20"`) + `List<int>` frequencies | — |
| `CombinedSetsCalculator` | `n`, `mean`, `stdDev` for two sets | — |

## Exceptions

| Exception | Thrown By | Condition |
|---|---|---|
| `NullInputException` | All | Null list passed |
| `EmptyDataSetException` | Array, Freq, Continuous | Empty list passed |
| `ListsNotSameSizeException` | Freq, Continuous | Values and frequencies lists differ in length |
| `InvalidFrequencyException` | Freq, Continuous | Any frequency is negative |
| `InvalidClassIntervalFormatException` | Continuous | An interval string cannot be parsed (must be `"lower-upper"`) |
| `InsufficientDataException` | Combined | `n1` or `n2` is zero or negative |