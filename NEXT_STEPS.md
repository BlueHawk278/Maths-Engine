# Next Steps and Project Roadmap

## Overview
This document outlines the recommended next steps for the Maths Engine project, including feature additions, architectural decisions, and technology choices for future development.

## Short-Term Goals (1-3 Months)

### 1. Complete Current Module Coverage

#### 1.1 Pure Maths Expansion
**Priority: High**

Add these fundamental topics to the Pure Maths section:

- **Quadratic Equations**
  - Solve using quadratic formula
  - Complete the square
  - Factorization
  - Discriminant analysis
  
- **Linear Equations**
  - Solve single-variable equations
  - Simultaneous equations (2-3 variables)
  - Graphing linear functions
  
- **Circle Theorems**
  - Angle calculations
  - Chord properties
  - Tangent calculations
  
- **Vectors**
  - 2D and 3D vector operations
  - Dot product and cross product
  - Vector magnitude and direction
  
- **Surds and Indices**
  - Simplifying surds
  - Rationalizing denominators
  - Index laws and calculations

#### 1.2 Statistics Expansion
**Priority: High**

Enhance the statistics module:

- **Probability**
  - Basic probability calculations
  - Conditional probability
  - Probability trees
  - Combinations and permutations
  
- **Data Representation**
  - Histogram calculations
  - Cumulative frequency
  - Box plots (already have quartile data)
  
- **Hypothesis Testing**
  - Chi-squared test
  - T-tests
  - Correlation significance

#### 1.3 Mechanics Expansion
**Priority: Medium**

Add more mechanics topics:

- **Projectile Motion**
  - Range calculations
  - Maximum height
  - Time of flight
  - Trajectory equations
  
- **Momentum and Collisions**
  - Elastic collisions
  - Inelastic collisions
  - Conservation of momentum
  
- **Energy**
  - Kinetic energy
  - Potential energy
  - Work done
  - Power calculations
  
- **Moments and Equilibrium**
  - Moment calculations
  - Center of mass
  - Equilibrium conditions

### 2. User Interface Development

#### 2.1 Console UI Enhancements
**Priority: High - Quick Win**

Improve the current console interface:

- **Visual Improvements**
  - Add colored headers and sections
  - Create box-drawing characters for menus
  - Add ASCII art logo
  - Implement progress bars for long calculations
  
- **User Experience**
  - Add calculation history
  - Implement "Previous result" feature
  - Add ability to save results to file
  - Create a help system with examples

**Implementation Example**:
```csharp
public static class ConsoleUI
{
    public static void DrawHeader(string title)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("╔" + new string('═', title.Length + 2) + "╗");
        Console.WriteLine("║ " + title + " ║");
        Console.WriteLine("╚" + new string('═', title.Length + 2) + "╝");
        Console.ResetColor();
    }
    
    public static void ShowCalculationHistory()
    {
        // Display recent calculations
    }
}
```

#### 2.2 Desktop GUI Application
**Priority: Medium - Major Enhancement**

**Technology Recommendations**:

**Option 1: WPF (Windows Presentation Foundation)**
- **Pros**: Native Windows feel, mature, great for complex UIs
- **Cons**: Windows-only
- **Best for**: Windows-focused deployment

**Option 2: Avalonia UI**
- **Pros**: Cross-platform (Windows, macOS, Linux), XAML-based, modern
- **Cons**: Smaller community than WPF
- **Best for**: Cross-platform desktop application
- **Recommended**: ⭐ This is the best choice for your project

**Option 3: MAUI (Multi-platform App UI)**
- **Pros**: Cross-platform including mobile, Microsoft-backed
- **Cons**: Still maturing, more complex
- **Best for**: If you want mobile apps in the future

**Recommended Architecture for GUI**:
```
MathsEngine.Core         # Existing calculation logic (refactored)
MathsEngine.Console      # Console UI (existing)
MathsEngine.Desktop      # Avalonia/WPF GUI
MathsEngine.Shared       # Shared view models and services
```

**GUI Features to Implement**:
1. **Calculator-Style Interface**
   - Category tabs (Pure, Mechanics, Statistics)
   - Input forms for each calculation type
   - Visual result display
   
2. **Graphing Capabilities**
   - Plot functions (using OxyPlot or LiveCharts)
   - Interactive graphs
   - Export graphs as images
   
3. **Step-by-Step Solutions**
   - Show calculation steps
   - Explain formulas used
   - Educational mode for learning
   
4. **Settings and Preferences**
   - Decimal places
   - Unit preferences (SI, Imperial)
   - Theme selection (dark/light mode)

#### 2.3 Web Application
**Priority: Low - Future Consideration**

**Technology Stack Recommendation**:
- **Backend**: ASP.NET Core Web API
- **Frontend**: Blazor WebAssembly (C# on frontend!)
- **Alternative**: React/Vue with .NET API

**Advantages**:
- Accessible from any device
- No installation required
- Easy to share calculations via URL
- Cloud deployment (Azure, AWS)

**Considerations**:
- Requires server infrastructure
- More complex deployment
- Security considerations for public access

### 3. Additional Features

#### 3.1 Step-by-Step Solutions
**Priority: High - Key Educational Feature**

Implement a solution tracker that shows work:

```csharp
public interface ISolutionStep
{
    string Description { get; }
    string Formula { get; }
    string Calculation { get; }
    double Result { get; }
}

public class SolutionBuilder
{
    private List<ISolutionStep> _steps = new();
    
    public void AddStep(string description, string formula, string calculation, double result)
    {
        _steps.Add(new SolutionStep(description, formula, calculation, result));
    }
    
    public void Display()
    {
        for (int i = 0; i < _steps.Count; i++)
        {
            Console.WriteLine($"Step {i + 1}: {_steps[i].Description}");
            Console.WriteLine($"  Formula: {_steps[i].Formula}");
            Console.WriteLine($"  Calculation: {_steps[i].Calculation}");
            Console.WriteLine($"  Result: {_steps[i].Result}");
        }
    }
}
```

**Example Usage**:
```csharp
public static double CalculateHypotenuseWithSteps(double a, double b)
{
    var solution = new SolutionBuilder();
    
    solution.AddStep(
        "Square side a",
        "a² = a × a",
        $"{a}² = {a} × {a}",
        a * a
    );
    
    solution.AddStep(
        "Square side b",
        "b² = b × b",
        $"{b}² = {b} × {b}",
        b * b
    );
    
    double result = Math.Sqrt(a * a + b * b);
    solution.AddStep(
        "Apply Pythagoras theorem",
        "c = √(a² + b²)",
        $"c = √({a * a} + {b * b}) = √{a * a + b * b}",
        result
    );
    
    solution.Display();
    return result;
}
```

#### 3.2 Formula Library
**Priority: Medium**

Create a searchable formula reference:

```csharp
public class Formula
{
    public string Name { get; set; }
    public string Category { get; set; }
    public string LaTeX { get; set; }  // For rendering
    public string Description { get; set; }
    public List<string> Variables { get; set; }
    public List<string> Examples { get; set; }
}

public class FormulaLibrary
{
    private List<Formula> _formulas;
    
    public List<Formula> Search(string keyword) { }
    public Formula GetFormula(string name) { }
    public void DisplayFormula(Formula formula) { }
}
```

#### 3.3 Unit Conversion System
**Priority: Medium**

Add automatic unit conversions:

```csharp
public interface IUnit
{
    string Name { get; }
    string Symbol { get; }
    double ConversionFactor { get; }
}

public class UnitConverter
{
    public double Convert(double value, IUnit from, IUnit to)
    {
        return value * (from.ConversionFactor / to.ConversionFactor);
    }
}

// Units for mechanics
public class LengthUnits
{
    public static readonly IUnit Meters = new Unit("Meters", "m", 1.0);
    public static readonly IUnit Kilometers = new Unit("Kilometers", "km", 1000.0);
    public static readonly IUnit Feet = new Unit("Feet", "ft", 0.3048);
}
```

#### 3.4 Calculation History & Export
**Priority: Low**

Features to add:
- Save calculation history to JSON/SQLite
- Export results to PDF/CSV
- Load previous sessions
- Share calculations with others

## Medium-Term Goals (3-6 Months)

### 1. Advanced Mathematics Modules

#### 1.1 Calculus (A-Level Further Maths)
- Differentiation (chain rule, product rule, quotient rule)
- Integration (substitution, by parts, partial fractions)
- Differential equations
- Area under curves
- Volumes of revolution

#### 1.2 Complex Numbers
- Basic operations
- Argand diagrams
- De Moivre's theorem
- Roots of complex numbers

#### 1.3 Sequences and Series
- Arithmetic and geometric sequences
- Sum of series
- Binomial expansion
- Maclaurin series

### 2. Scientific Features

#### 2.1 Graphing Engine
**Library Recommendations**:
- **OxyPlot**: Excellent for desktop apps
- **LiveCharts**: Modern, animated charts
- **ScottPlot**: High-performance scientific plotting

**Features**:
- 2D function plotting
- 3D surface plots
- Parametric equations
- Multiple graphs on same axes
- Zoom, pan, export functionality

#### 2.2 Symbolic Math
**Library Recommendation**: AngouriMath (C# symbolic math library)

**Capabilities**:
- Algebraic simplification
- Symbolic differentiation and integration
- Equation solving
- Matrix operations

**Example**:
```csharp
using AngouriMath;

Entity expr = "x^2 + 2x + 1";
var simplified = expr.Simplify();
var derivative = expr.Differentiate("x");
```

### 3. Mobile Application
**Priority: Medium - If Going Cross-Platform**

**Technology**: .NET MAUI
- Share code with desktop app
- Native iOS and Android apps
- Touch-optimized interface
- Camera integration for scanning problems (future AI feature)

## Long-Term Vision (6-12 Months)

### 1. AI-Powered Features

#### 1.1 Problem Recognition
- Scan handwritten equations with OCR
- Natural language problem input
- Automatic problem categorization

**Technology**: ML.NET or Azure Computer Vision

#### 1.2 Intelligent Tutoring
- Identify common mistakes
- Suggest similar problems
- Adaptive difficulty
- Learning path recommendations

### 2. Community Features

#### 2.1 User Accounts & Cloud Sync
- Save calculations across devices
- Share solutions with others
- Collaborative problem solving

#### 2.2 Problem Database
- Community-contributed problems
- Rating and difficulty system
- Practice mode with random problems

### 3. Educational Integration

#### 3.1 Curriculum Alignment
- GCSE specification mapping
- A-Level topic coverage
- Exam board specific content (AQA, Edexcel, OCR)

#### 3.2 Teacher Tools
- Generate worksheets
- Track student progress
- Classroom mode for demonstrations

## Technology Stack Summary

### Current
- **.NET 8.0**: Modern, performant
- **C#**: Great choice for math applications
- **xUnit**: Good testing framework

### Recommended Additions

#### For Desktop GUI
```
✅ Avalonia UI          - Cross-platform desktop UI
✅ ReactiveUI           - MVVM framework
✅ OxyPlot              - Graphing
✅ Material.Avalonia    - Material Design components
```

#### For Enhanced Features
```
✅ AngouriMath          - Symbolic mathematics
✅ MathNet.Numerics     - Advanced numerical methods
✅ Plotly.NET           - Interactive graphs
✅ ClosedXML            - Excel export
✅ QuestPDF             - PDF generation
```

#### For Web/Mobile (Future)
```
✅ ASP.NET Core         - Web API
✅ Blazor WebAssembly   - Web frontend
✅ .NET MAUI            - Mobile apps
✅ SignalR              - Real-time features
```

## Architecture Evolution

### Phase 1: Current (Console App)
```
MathsEngine/
├── Menu/           # UI Layer
└── Modules/        # Business Logic
```

### Phase 2: Refactored (Layered)
```
MathsEngine.Core/           # Domain logic
MathsEngine.Services/       # Application services
MathsEngine.Console/        # Console UI
MathsEngine.Tests/          # Tests
```

### Phase 3: Multi-Platform
```
MathsEngine.Core/           # Shared calculation engine
MathsEngine.Services/       # Business services
MathsEngine.Desktop/        # Avalonia UI
MathsEngine.Console/        # Console UI
MathsEngine.Web/            # Blazor Web App
MathsEngine.Mobile/         # MAUI Mobile App
MathsEngine.Tests/          # Unit tests
MathsEngine.IntegrationTests/
```

## Recommended Implementation Order

### Phase 1 (Months 1-2): Foundation
1. ✅ Code quality improvements (from CODE_IMPROVEMENTS.md)
2. ✅ Fix failing tests
3. ✅ Add missing modules (Quadratics, Linear Equations)
4. ✅ Enhance console UI

### Phase 2 (Months 3-4): GUI Development
1. ✅ Set up Avalonia project
2. ✅ Implement basic calculator UI
3. ✅ Add graphing capability
4. ✅ Implement step-by-step solutions

### Phase 3 (Months 5-6): Advanced Features
1. ✅ Add formula library
2. ✅ Implement calculation history
3. ✅ Add export features (PDF, Excel)
4. ✅ Symbolic math integration

### Phase 4 (Months 7+): Expansion
1. ✅ Web application (if desired)
2. ✅ Mobile app (if desired)
3. ✅ AI features
4. ✅ Community features

## Getting Started with GUI Development

### Quick Start: Avalonia UI

1. **Install Avalonia Templates**:
```bash
dotnet new install Avalonia.Templates
```

2. **Create Avalonia Project**:
```bash
dotnet new avalonia.mvvm -o MathsEngine.Desktop
```

3. **Add Project Reference**:
```bash
cd MathsEngine.Desktop
dotnet add reference ../MathsEngine/MathsEngine.csproj
```

4. **Install Additional Packages**:
```bash
dotnet add package Material.Avalonia
dotnet add package OxyPlot.Avalonia
```

5. **Create First Calculator View**:
```xml
<Window xmlns="https://github.com/avaloniaui">
    <StackPanel Margin="20">
        <TextBlock>Pythagoras Theorem</TextBlock>
        <TextBox Watermark="Side A" Text="{Binding SideA}"/>
        <TextBox Watermark="Side B" Text="{Binding SideB}"/>
        <Button Command="{Binding CalculateCommand}">Calculate</Button>
        <TextBlock Text="{Binding Result}"/>
    </StackPanel>
</Window>
```

## Resources and Learning

### Avalonia UI
- Documentation: https://docs.avaloniaui.net/
- Samples: https://github.com/AvaloniaUI/Avalonia.Samples
- Community: Avalonia Discord, GitHub Discussions

### Graphing Libraries
- OxyPlot: https://oxyplot.github.io/
- LiveCharts: https://lvcharts.com/
- ScottPlot: https://scottplot.net/

### Mathematics Libraries
- MathNet: https://numerics.mathdotnet.com/
- AngouriMath: https://am.angouri.org/

## Success Metrics

Track these to measure project progress:
- Number of modules implemented
- Test coverage percentage
- User satisfaction (if sharing with others)
- Code quality metrics (SonarQube)
- Documentation completeness
- Performance benchmarks

## Conclusion

This roadmap provides a clear path forward for the Maths Engine project. The recommended approach is:

1. **Immediate**: Fix code quality issues and failing tests
2. **Short-term**: Complete module coverage and enhance console UI
3. **Medium-term**: Develop desktop GUI with Avalonia
4. **Long-term**: Consider web/mobile and AI features

The project has a solid foundation and with these enhancements, it can become a comprehensive mathematics learning and calculation tool suitable for GCSE and A-Level students.

**Next Immediate Actions**:
1. Review and prioritize improvements from CODE_IMPROVEMENTS.md
2. Fix the 12 failing tests
3. Choose between console enhancement or GUI development
4. Create a GitHub project board to track progress
5. Set up CI/CD pipeline for automated testing
