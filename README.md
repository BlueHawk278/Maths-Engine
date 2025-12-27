Maths Engine

Welcome! Maths Engine is a C# project where I’m building a collection of tools to handle GCSE and Further Maths topics. 
It’s still an early prototype, but it already performs some useful calculations and is growing fast.

Features:
-	Easy-to-use maths functions
-	Organised into clear topic areas
-	Built with clean OOP design
-	Designed to expand over time

Current Modules:
- Statistics:
  -	Spearman’s Rank / Bivariate analysis
  -	Standard Deviation
  -	Mean, Median, Mode etc.
- Pure Maths:
  -	Pythagoras Theorem
  -	Matrices
- Mechanics:
  - UVATS Equations
  - Newton's Laws Calculations 

Planned Features
Coming as I develop the project further:
-	More statistical measures
-	Mechanics topics
-	Graphing support in a GUI
-	Step-by-step explanations
-	Unit testing

Folder Structure
The project is organized into two main folders: `Core` for the user interface and menu system, and `Modules` for the calculation logic.

```text
bin/

Core/
├─ Menu/
│  ├─ Mechanics/
│  │  ├─ NewtonsLawsMenu.cs
│  │  └─ UniformAccelerationMenu.cs
│  ├─ Pure/
│  │  ├─ MatrixMenu.cs
│  │  └─ PythagorasMenu.cs
|  |  └─ TrigonometryMenu.cs
│  ├─ Statistics/
│  │  └─ DispersionMenu.cs
│  └─ Menu.cs

Modules/
├─ Mechanics/
│  ├─ Dynamics/
│  │  └─ NewtonsLawsCalculator.cs
│  └─ UniformAcceleration/
│     └─ UniformAccelerationCalculator.cs
├─ Pure/
│  ├─ Matrices/
│  │  ├─ MatrixBase.cs
│  │  └─ MatrixCalculator.cs
│  ├─ PythagorasTheorem/
│  │  └─ PythagorasTheorem.cs
|  |─ Trigonometry/
|  |  ├─ SideType.cs
|  |  └─ TrigonometryCalculator.cs
├─ Statistics/
│  ├─ BivariateAnalysis/
│  │  ├─ BivariateAnalysis.cs
│  │  ├─ BivariateAnalysis.md
│  │  ├─ BivariateAnalysisCalculator.cs
│  │  └─ Correlation.cs
│  ├─ Dispersion/
│  │  ├─ ArrayOfNumbers/
│  │  │  ├─ ArrayOfNumbersCalculator.cs
│  │  │  └─ ArrayOfNumbersInput.cs
│  │  ├─ ContinuousTable/
│  │  │  ├─ ContinuousTableCalculator.cs
│  │  │  └─ ContinuousTableInput.cs
│  │  ├─ FrequencyTable/
│  │  │  ├─ DiscreteTableCalculator.cs
│  │  │  └─ DiscreteTableInput.cs
│  │  ├─ Dispersion.md
│  │  └─ StandardDeviation.cs

obj/

App.config
Program.cs

```
