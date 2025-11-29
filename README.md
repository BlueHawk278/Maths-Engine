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

Planned Features
Coming as I develop the project further:
-	More statistical measures
-	Algebra tools
-	Differentiation and integration
-	Mechanics topics
-	Graphing support in a GUI
-	Step-by-step explanations
-	Unit testing

Folder Structure
The project is organized into two main folders: `Core` for the user interface and menu system, and `Modules` for the calculation logic.

```text
MathsEngine/
├─ Properties/
├─ References/
├─ bin/
├─ Core/
│  ├─ Menu/
│  │  ├─ Pure/
│  │  │  ├─ MatrixMenu.cs
│  │  │  └─ PythagorasMenu.cs
│  │  ├─ Statistics/
│  │  │  └─ DispersionMenu.cs
│  │  └─ Menu.cs
├─ Modules/
│  ├─ Core/
│  │  ├─ PureHelpers/
│  │  │  └─ PythagorasTheorem.cs
│  │  ├─ StatisticsHelpers/
│  │  │  └─ AverageCalculator.cs
│  ├─ Mechanics/
│  │  └─ UniformAcceleration/
│  ├─ Pure/
│  │  ├─ Matrices/
│  │  │  ├─ MatrixBase.cs
│  │  │  └─ MatrixCalculator.cs
│  │  ├─ PythagorasTheorem/
│  │  │  └─ PythagorasTheorem.cs
│  │  └─ Statistics/
├─ obj/
├─ App.config
└─ Program.cs
```

