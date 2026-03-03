# MathsEngine.Models — Core Calculation Library

This project contains all mathematical logic for the Maths Engine. It is a class library with no UI code, referenced by both `MathsEngine.Console` and `MathsEngine.Tests`.

## Structure

```
MathsEngine.Models/
├── Modules/
│   ├── Pure/               # Pythagoras, Trigonometry, Matrices, Coordinate Geometry, Number Theory
│   ├── Statistics/         # Averages, Dispersion, Bivariate Analysis
│   ├── Mechanics/          # Newton's Laws, SUVAT
│   └── Explanations/       # Step-by-step tutor wrappers
└── Utils/
    └── Exceptions.cs       # All custom exceptions
```

## Design Principles

- **Static methods** for all stateless calculations (input → output)
- **Instance classes** only for data structures (e.g. `MatrixBase`, `Coordinate`, `BivariateAnalysisCalculator`)
- **No UI code** — this library is purely for mathematical computation
- **Custom exceptions** for all domain-specific error conditions

## Custom Exceptions (`Utils/Exceptions.cs`)

| Exception | Domain | Thrown When |
|---|---|---|
| `NullInputException` | General | A required input is null or empty |
| `NullValuesException` | General | Too many null values for a calculation |
| `NegativeSideLengthException` | Pythagoras / Trig | A side length is zero or negative |
| `HypotenuseNotLongestSideException` | Pythagoras / Trig | Hypotenuse is shorter than another side |
| `AcuteAngleException` | Trigonometry | Angle is not strictly between 0° and 90° |
| `DuplicateSideException` | Trigonometry | Known side and target side are the same |
| `IncompatibleMatrixAdditionException` | Matrices | Matrices are not the same size |
| `IncompatibleMatrixSubtractionException` | Matrices | Matrices are not the same size |
| `IncompatibleMatrixMultiplicationException` | Matrices | Inner dimensions do not match |
| `NotSquareMatrixException` | Matrices | Determinant attempted on non-square matrix |
| `EmptyDataSetException` | Statistics | An empty list is passed to a calculator |
| `ListsNotSameSizeException` | Statistics | Two lists of different lengths are passed |
| `InvalidFrequencyException` | Statistics | A negative frequency value is provided |
| `InvalidClassIntervalFormatException` | Statistics | A class interval string cannot be parsed |
| `InsufficientDataException` | Statistics | Fewer than the minimum required data points |
| `NullMassException` | Mechanics | Mass is zero or negative in F = ma |