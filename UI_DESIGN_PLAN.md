# Maths Engine - WinForms UI Design Plan

## Overview
This document outlines the user interface design for the Maths Engine WinForms application. The current console-based architecture provides a solid foundation of calculation modules that can be leveraged by a graphical interface.

## Design Principles

### 1. Educational Focus
- Clear visual hierarchy guiding users through calculations
- Prominent display of step-by-step explanations
- Visual feedback for input validation
- Mathematical notation rendered clearly

### 2. User-Friendly Navigation
- Intuitive topic categorization matching current structure (Pure, Statistics, Mechanics)
- Minimal clicks to reach desired calculations
- Persistent navigation allowing quick topic switching
- Breadcrumb trail showing current location

### 3. Professional Appearance
- Clean, modern interface suitable for educational settings
- Consistent spacing, fonts, and color scheme
- Professional mathematical typography
- Responsive layout adapting to window resizing

## Main Window Layout

### Window Structure
```
┌─────────────────────────────────────────────────────────────┐
│ Maths Engine - [Current Topic]                    [_][□][×] │
├─────────────────────────────────────────────────────────────┤
│ File   Edit   View   Tools   Help                            │
├──────────────┬──────────────────────────────────────────────┤
│              │                                               │
│  Navigation  │         Main Content Area                    │
│    Panel     │                                               │
│              │                                               │
│   [Topic     │  ┌────────────────────────────────────┐      │
│    Tree]     │  │  Calculation Input Panel           │      │
│              │  │                                     │      │
│              │  │  [Input fields and controls]       │      │
│              │  │                                     │      │
│              │  └────────────────────────────────────┘      │
│              │                                               │
│              │  ┌────────────────────────────────────┐      │
│              │  │  Results Display                   │      │
│              │  │                                     │      │
│              │  │  Answer: [value]                   │      │
│              │  │                                     │      │
│              │  └────────────────────────────────────┘      │
│              │                                               │
│              │  ┌────────────────────────────────────┐      │
│              │  │  Step-by-Step Explanation          │      │
│              │  │  (Collapsible/Expandable)          │      │
│              │  │                                     │      │
│              │  │  [Explanation steps listed]        │      │
│              │  │                                     │      │
│              │  └────────────────────────────────────┘      │
│              │                                               │
├──────────────┴──────────────────────────────────────────────┤
│ Status: Ready                                Last Calc: -- │
└─────────────────────────────────────────────────────────────┘
```

## Navigation Panel (Left Side)

### Tree Structure
```
├─ 📐 Pure Mathematics
│  ├─ Pythagoras Theorem
│  │  ├─ Calculate Hypotenuse
│  │  ├─ Calculate Other Side
│  │  └─ Validate Triangle
│  ├─ Trigonometry
│  │  ├─ Calculate Missing Side
│  │  └─ Calculate Missing Angle
│  ├─ Matrices
│  │  ├─ Matrix Addition
│  │  ├─ Matrix Subtraction
│  │  ├─ Scalar Multiplication
│  │  ├─ Matrix Multiplication
│  │  └─ Calculate Determinant
│  ├─ Coordinate Geometry
│  │  ├─ Distance Between Points
│  │  ├─ Midpoint
│  │  ├─ Gradient
│  │  └─ Equation of Line
│  └─ Algebra
│     └─ Factorisation
│
├─ 📊 Statistics
│  ├─ Averages
│  │  ├─ Mean (Raw Data)
│  │  ├─ Median (Raw Data)
│  │  ├─ Mode (Raw Data)
│  │  ├─ Range (Raw Data)
│  │  └─ Frequency Table Averages
│  ├─ Dispersion
│  │  ├─ Standard Deviation (Array)
│  │  ├─ Variance (Array)
│  │  ├─ Interquartile Range
│  │  ├─ Frequency Table Dispersion
│  │  └─ Combined Sets
│  └─ Bivariate Analysis
│     ├─ Spearman's Rank Correlation
│     └─ Scatter Diagram Data
│
└─ ⚙️ Mechanics
   ├─ Newton's Laws
   │  ├─ Calculate Force (F=ma)
   │  ├─ Calculate Mass
   │  └─ Calculate Acceleration
   └─ Uniform Acceleration (SUVAT)
      ├─ Find Displacement
      ├─ Find Initial Velocity
      ├─ Find Final Velocity
      ├─ Find Acceleration
      └─ Find Time
```

### Navigation Panel Features
- **Collapsible sections** with expand/collapse icons
- **Icons** for each category (Pure, Statistics, Mechanics)
- **Search box** at top to filter calculations
- **Favorites/Recent** section at the top showing recently used calculations
- **Tooltip support** showing brief description when hovering over items

## Main Content Area

### Input Panel Design

#### Standard Input Controls
- **Text boxes** for numeric inputs with validation
- **Labels** clearly identifying each input (e.g., "Side A:", "Angle:", "Mass:")
- **Unit dropdowns** where applicable (degrees/radians, kg/g, m/km/cm)
- **Validation indicators** (green checkmark for valid, red X for invalid)
- **Clear/Reset button** to clear all inputs
- **Calculate button** (large, prominent, enabled only when inputs are valid)

#### Specialized Input Controls

**For Matrices:**
```
Matrix A Dimensions: [2] × [2]
┌─────────┬─────────┐
│ [    ] │ [    ]  │
├─────────┼─────────┤
│ [    ] │ [    ]  │
└─────────┴─────────┘

Matrix B Dimensions: [2] × [2]
┌─────────┬─────────┐
│ [    ] │ [    ]  │
├─────────┼─────────┤
│ [    ] │ [    ]  │
└─────────┴─────────┘

[Calculate]
```

**For Frequency Tables:**
```
Number of Entries: [5]

Value    | Frequency
---------|----------
[     ]  | [     ]
[     ]  | [     ]
[     ]  | [     ]
[     ]  | [     ]
[     ]  | [     ]

[+ Add Row] [- Remove Row]

[Calculate Mean] [Calculate Median] [Calculate Mode]
```

**For Raw Data Arrays:**
```
Enter values (comma-separated):
┌──────────────────────────────────────┐
│ 5, 10, 15, 20, 25, 30               │
└──────────────────────────────────────┘

Or paste from clipboard: [Paste]
Current count: 6 values

[Calculate]
```

**For Coordinate Geometry:**
```
Point A:  x: [    ]  y: [    ]
Point B:  x: [    ]  y: [    ]

☑ Show on coordinate plane

[Calculate Distance] [Calculate Midpoint] [Calculate Gradient]
```

### Results Display Panel

#### Result Layout
```
┌─────────────────────────────────────────────────┐
│ RESULT                                          │
├─────────────────────────────────────────────────┤
│                                                 │
│ ✓ Calculation Successful                       │
│                                                 │
│ Answer: 15.8113883008                          │
│                                                 │
│ Rounded (2 d.p.): 15.81                        │
│ Rounded (3 d.p.): 15.811                       │
│                                                 │
│ [Copy to Clipboard] [Export Result]            │
│                                                 │
└─────────────────────────────────────────────────┘
```

#### Features
- **Large, clear display** of the primary result
- **Multiple precision options** (user can select rounding)
- **Copy to clipboard** button for easy result sharing
- **Export options** (copy as text, save to file)
- **Error messages** displayed prominently when calculations fail
- **Visual success/error indicators** (color coding, icons)

### Step-by-Step Explanation Panel

#### Expandable/Collapsible Design
```
┌─────────────────────────────────────────────────┐
│ ▼ Step-by-Step Explanation          [Hide/Show]│
├─────────────────────────────────────────────────┤
│                                                 │
│ Step 1: Identify the known values              │
│   • Adjacent side (a) = 10                     │
│   • Angle (θ) = 30°                            │
│   • Finding: Opposite side                     │
│                                                 │
│ Step 2: Choose appropriate formula             │
│   tan(θ) = opposite / adjacent                 │
│                                                 │
│ Step 3: Rearrange to solve for opposite        │
│   opposite = adjacent × tan(θ)                 │
│                                                 │
│ Step 4: Substitute values                      │
│   opposite = 10 × tan(30°)                     │
│                                                 │
│ Step 5: Calculate                              │
│   opposite = 10 × 0.5773502692                 │
│   opposite = 5.773502692                       │
│                                                 │
│ [Print Steps] [Copy Steps] [Save as PDF]       │
│                                                 │
└─────────────────────────────────────────────────┘
```

#### Features
- **Collapsible section** to save screen space when not needed
- **Numbered steps** with clear progression
- **Mathematical notation** properly formatted
- **Indentation** for sub-steps and details
- **Export options** (print, copy, save as PDF)
- **Font selection** for mathematical symbols
- **Highlighting** of key values and formulas

## Menu Bar

### File Menu
```
File
├─ New Calculation          Ctrl+N
├─ Open Saved Calculation   Ctrl+O
├─ Save Calculation         Ctrl+S
├─ Save Calculation As...   
├─ ───────────────────────
├─ Export Result            
│  ├─ As Text
│  ├─ As PDF
│  └─ To Clipboard
├─ ───────────────────────
├─ Recent Calculations     ▶
├─ ───────────────────────
└─ Exit                     Alt+F4
```

### Edit Menu
```
Edit
├─ Copy Result              Ctrl+C
├─ Copy Steps               Ctrl+Shift+C
├─ Paste Input              Ctrl+V
├─ ───────────────────────
├─ Clear Inputs             Ctrl+L
├─ Clear All                Ctrl+Shift+L
├─ ───────────────────────
└─ Preferences              Ctrl+,
```

### View Menu
```
View
├─ ☑ Navigation Panel
├─ ☑ Step-by-Step Explanations
├─ ☑ Status Bar
├─ ───────────────────────
├─ Zoom In                  Ctrl++
├─ Zoom Out                 Ctrl+-
├─ Reset Zoom               Ctrl+0
├─ ───────────────────────
└─ Full Screen              F11
```

### Tools Menu
```
Tools
├─ Calculator History
├─ Saved Calculations
├─ ───────────────────────
├─ Unit Converter
├─ Formula Reference
├─ ───────────────────────
├─ Settings                 
└─ Options
```

### Help Menu
```
Help
├─ User Guide               F1
├─ Mathematical Reference
├─ Video Tutorials
├─ ───────────────────────
├─ Check for Updates
├─ ───────────────────────
└─ About Maths Engine
```

## Settings/Preferences Dialog

### General Settings
```
┌──────────────────────────────────────────┐
│ Preferences                              │
├──────────────────────────────────────────┤
│                                          │
│ ┌─ General ─────────────────────────┐   │
│ │                                    │   │
│ │ Default Decimal Places: [2] ▼     │   │
│ │                                    │   │
│ │ Angle Units:                       │   │
│ │  ⚫ Degrees  ⚪ Radians             │   │
│ │                                    │   │
│ │ ☑ Show step-by-step by default    │   │
│ │ ☑ Confirm before clearing inputs   │   │
│ │ ☑ Auto-save calculation history    │   │
│ │                                    │   │
│ └────────────────────────────────────┘   │
│                                          │
│ ┌─ Display ──────────────────────────┐   │
│ │                                    │   │
│ │ Theme: [Light] ▼                   │   │
│ │                                    │   │
│ │ Font Size:                         │   │
│ │  Input: [10pt] ▼                   │   │
│ │  Results: [14pt] ▼                 │   │
│ │  Steps: [11pt] ▼                   │   │
│ │                                    │   │
│ │ ☑ Use high contrast colors         │   │
│ │                                    │   │
│ └────────────────────────────────────┘   │
│                                          │
│         [OK]  [Cancel]  [Apply]          │
│                                          │
└──────────────────────────────────────────┘
```

### Advanced Settings
```
┌─ Advanced ────────────────────────────┐
│                                        │
│ Calculation Settings:                  │
│                                        │
│ Maximum iterations: [1000]             │
│ Precision tolerance: [1e-10]           │
│                                        │
│ ☑ Show warnings for approximations    │
│ ☑ Validate all inputs before calculate│
│                                        │
│ Data Import/Export:                    │
│                                        │
│ Default export format: [PDF] ▼         │
│ Export path: [C:\Users\...\Exports]    │
│              [Browse...]               │
│                                        │
└────────────────────────────────────────┘
```

## Calculation History Feature

### History Window
```
┌─────────────────────────────────────────────────┐
│ Calculation History                   [_][□][×] │
├─────────────────────────────────────────────────┤
│                                                 │
│ Filter: [All Topics ▼]  Search: [        ] 🔍 │
│                                                 │
│ ┌───────────────────────────────────────────┐  │
│ │ Date/Time        Topic           Result   │  │
│ ├───────────────────────────────────────────┤  │
│ │ 15/02/26 20:15  Pythagoras       12.65   │  │
│ │ 15/02/26 20:10  Trigonometry     45.0    │  │
│ │ 15/02/26 19:58  Matrix Det.      -8.0    │  │
│ │ 15/02/26 19:45  Newton's Laws    150 N   │  │
│ │ 15/02/26 19:30  Statistics Mean  23.45   │  │
│ │ ...                                       │  │
│ └───────────────────────────────────────────┘  │
│                                                 │
│ [View Details] [Reload Calculation] [Delete]   │
│ [Export History] [Clear History]                │
│                                                 │
└─────────────────────────────────────────────────┘
```

### History Detail View
When double-clicking a history entry:
```
┌─────────────────────────────────────────┐
│ Calculation Details                     │
├─────────────────────────────────────────┤
│                                         │
│ Topic: Pythagoras Theorem               │
│ Type: Calculate Hypotenuse              │
│ Date: 15/02/2026 20:15:32              │
│                                         │
│ Inputs:                                 │
│   Side A: 5.0                          │
│   Side B: 12.0                         │
│                                         │
│ Result:                                 │
│   Hypotenuse: 13.0                     │
│                                         │
│ Steps: [View Full Explanation]          │
│                                         │
│ [Reload This Calculation] [Close]       │
│                                         │
└─────────────────────────────────────────┘
```

## Formula Reference Tool

### Formula Browser
```
┌─────────────────────────────────────────────────┐
│ Formula Reference                     [_][□][×] │
├─────────────────────────────────────────────────┤
│                                                 │
│ Category: [Pure Mathematics ▼]                  │
│                                                 │
│ ┌──────────────┬────────────────────────────┐  │
│ │ Topic        │ Formula Details            │  │
│ ├──────────────┼────────────────────────────┤  │
│ │ Pythagoras   │                            │  │
│ │ Trigonometry │ TRIGONOMETRY               │  │
│ │ Matrices     │                            │  │
│ │ Coord. Geom. │ SOH-CAH-TOA:               │  │
│ │              │                            │  │
│ │              │ sin(θ) = O/H               │  │
│ │              │ cos(θ) = A/H               │  │
│ │              │ tan(θ) = O/A               │  │
│ │              │                            │  │
│ │              │ Where:                     │  │
│ │              │   O = Opposite side        │  │
│ │              │   A = Adjacent side        │  │
│ │              │   H = Hypotenuse           │  │
│ │              │   θ = Angle                │  │
│ │              │                            │  │
│ │              │ [Use in Calculator]        │  │
│ └──────────────┴────────────────────────────┘  │
│                                                 │
│ Search formulas: [              ] 🔍           │
│                                                 │
└─────────────────────────────────────────────────┘
```

## Visualization Features (Future Enhancement)

### Graphical Displays

**For Coordinate Geometry:**
- Interactive coordinate plane showing points, lines, and distances
- Zoom and pan capabilities
- Grid lines with customizable spacing
- Export graph as image

**For Statistics:**
- Bar charts for frequency data
- Scatter plots for bivariate analysis
- Box plots showing quartiles and outliers
- Histogram displays

**For Trigonometry:**
- Right triangle visualization showing sides and angles
- Unit circle representation
- Animated angle and side relationships

**For Matrices:**
- Visual matrix representation with color coding
- Operation visualization (showing how multiplication works)
- Determinant calculation visualization

## Error Handling & Validation

### Input Validation
- **Real-time validation** as user types
- **Visual indicators** (border color changes)
- **Error messages** below input fields
- **Tooltip help** for correct input format
- **Example values** shown in placeholder text

### Error Message Display
```
┌─────────────────────────────────────────┐
│ ⚠ Input Error                           │
├─────────────────────────────────────────┤
│                                         │
│ The following errors must be corrected: │
│                                         │
│ • Side A must be a positive number      │
│ • Side B cannot be greater than the     │
│   hypotenuse                            │
│                                         │
│ Please correct these errors and try     │
│ again.                                  │
│                                         │
│              [OK]                       │
│                                         │
└─────────────────────────────────────────┘
```

### Calculation Errors
```
┌─────────────────────────────────────────┐
│ ❌ Calculation Error                    │
├─────────────────────────────────────────┤
│                                         │
│ The calculation cannot be completed:    │
│                                         │
│ Invalid triangle: The sum of two sides  │
│ must be greater than the third side.    │
│                                         │
│ Suggestion: Check your input values.    │
│                                         │
│              [OK]                       │
│                                         │
└─────────────────────────────────────────┘
```

## Accessibility Features

### Keyboard Navigation
- **Tab order** logically through all controls
- **Keyboard shortcuts** for common actions
- **Enter key** submits current calculation
- **Escape key** clears inputs or closes dialogs
- **Arrow keys** navigate through history and tree view

### Screen Reader Support
- **Alt text** for all buttons and controls
- **ARIA labels** for complex controls
- **Descriptive form labels** 
- **Status announcements** for calculation completion

### Visual Accessibility
- **High contrast mode** option
- **Adjustable font sizes**
- **Colorblind-friendly** color schemes
- **Scalable UI** for different screen sizes
- **Zoom functionality** (125%, 150%, 200%)

## User Workflows

### Basic Calculation Workflow
1. User launches application
2. Navigation panel shows all available topics
3. User expands category and selects calculation type
4. Main panel displays appropriate input form
5. User enters values (with real-time validation)
6. User clicks Calculate button
7. Result appears in result panel
8. Step-by-step explanation auto-expands (if enabled)
9. User can copy result, view steps, or start new calculation

### Working with History
1. User opens History (Tools → Calculator History)
2. History window shows recent calculations
3. User filters or searches for specific calculation
4. User double-clicks to view details
5. User clicks "Reload This Calculation"
6. Main window restores that calculation's inputs
7. User can modify values and recalculate

### Batch Calculations (Future Enhancement)
1. User selects "Batch Mode" option
2. User uploads CSV file with multiple input sets
3. Application validates all inputs
4. User clicks "Process Batch"
5. Results generated for all valid entries
6. Export all results to CSV or PDF report

## Technical Considerations

### Architecture Adaptation Notes

**Current Console Architecture:**
- Menu classes handle user interaction and input
- Module classes perform calculations
- Separation between UI and logic is maintained

**WinForms Adaptation Required:**
- Menu classes will be replaced by Form classes
- Each calculation type gets its own UserControl or Panel
- Calculation modules can be used directly (no changes needed)
- Input parsing/validation logic from Utils can be reused

**Recommended Structure:**
```
MathsEngine.WinForms/
├── Forms/
│   ├── MainForm.cs              (Main window)
│   ├── HistoryForm.cs           (History viewer)
│   ├── FormulaReferenceForm.cs  (Formula browser)
│   └── SettingsForm.cs          (Preferences)
├── Controls/
│   ├── CalculationInputControl.cs (Base control)
│   ├── PythagorasControl.cs
│   ├── TrigonometryControl.cs
│   ├── MatrixControl.cs
│   └── ... (one per calculation type)
├── Helpers/
│   ├── InputValidator.cs
│   ├── ResultFormatter.cs
│   └── ExportManager.cs
└── Resources/
    ├── Icons/
    ├── Styles/
    └── Templates/
```

### Data Binding
- Use **data binding** for input/output fields where appropriate
- Implement **INotifyPropertyChanged** for reactive updates
- **Validation rules** bound to input controls

### State Management
- **Calculation state** preserved when switching between topics
- **Recent calculations** stored in local application data
- **User preferences** saved to settings file
- **Window position/size** remembered between sessions

## Summary of Key Features

### Core Features (MVP)
1. ✓ Tree-based navigation of all calculation topics
2. ✓ Dynamic input forms for each calculation type
3. ✓ Clear result display with multiple precision options
4. ✓ Expandable step-by-step explanations
5. ✓ Input validation with helpful error messages
6. ✓ Copy/export functionality for results
7. ✓ Basic menu system (File, Edit, View, Help)
8. ✓ Settings/preferences dialog

### Enhanced Features (Phase 2)
1. ⭐ Calculation history with search and filter
2. ⭐ Formula reference browser
3. ⭐ Keyboard shortcuts and accessibility
4. ⭐ Multiple themes (light/dark)
5. ⭐ Export to PDF with formatting
6. ⭐ Recently used calculations quick access

### Advanced Features (Future)
1. 🔮 Graphical visualizations (graphs, diagrams)
2. 🔮 Batch calculation processing
3. 🔮 Custom formula builder
4. 🔮 Integration with learning management systems
5. 🔮 Cloud sync for history and settings
6. 🔮 Mobile companion app

## Design Mockup Notes

### Color Scheme Suggestions
- **Primary**: Professional blue (#0078D4 - Microsoft blue)
- **Success**: Green (#107C10)
- **Error**: Red (#E81123)
- **Warning**: Orange (#FF8C00)
- **Background**: White (#FFFFFF) or Light Gray (#F3F3F3)
- **Text**: Dark Gray (#323130)
- **Borders**: Medium Gray (#EDEBE9)

### Typography
- **Headings**: Segoe UI Semibold, 14pt
- **Input Labels**: Segoe UI Regular, 10pt
- **Input Values**: Segoe UI Regular, 11pt
- **Results**: Segoe UI Bold, 16pt
- **Steps**: Consolas (monospace), 10pt for formulas
- **Menu Items**: Segoe UI Regular, 9pt

### Icon Set
- Use modern, flat icons (Material Design or Fluent UI style)
- Consistent icon size (16x16 for toolbar, 24x24 for primary actions)
- Icons for: Calculate, Clear, Copy, Export, Save, History, Settings

### Spacing and Layout
- **Padding**: 8-12px between elements
- **Margins**: 16px around major sections
- **Button spacing**: 8px between adjacent buttons
- **Input field height**: 24-28px
- **Min button width**: 80px

## Conclusion

This UI design provides a comprehensive, user-friendly interface for the Maths Engine while maintaining the separation between UI and calculation logic. The design prioritizes:

1. **Educational value** - Clear step-by-step explanations
2. **Ease of use** - Intuitive navigation and input
3. **Professional appearance** - Modern, clean design
4. **Accessibility** - Keyboard navigation and screen reader support
5. **Extensibility** - Easy to add new calculation types

The modular design allows for phased implementation, starting with core features and progressively adding enhanced capabilities based on user feedback and needs.
