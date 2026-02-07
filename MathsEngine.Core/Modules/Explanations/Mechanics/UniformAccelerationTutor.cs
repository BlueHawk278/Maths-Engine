using System;
using System.Collections.Generic;
using MathsEngine.Modules.Mechanics.UniformAcceleration;

namespace MathsEngine.Modules.Explanations.Mechanics
{
    /// <summary>
    /// Provides step-by-step explanations for Uniform Acceleration (SUVAT) calculations.
    /// </summary>
    public static class UniformAccelerationTutor
    {
        public static CalculationResult CalculateAverageVelocityWithSteps(double? initialVelocity, double? finalVelocity)
        {
            // Validate inputs
            if (initialVelocity is null || finalVelocity is null)
                throw new InvalidOperationException("Initial and final velocity must have a value.");

            var steps = new List<string>();

            steps.Add("Step 1: Identify known values");
            steps.Add($"  Initial velocity (u) = {initialVelocity.Value:F2} m/s");
            steps.Add($"  Final velocity (v) = {finalVelocity.Value:F2} m/s");
            steps.Add("");

            steps.Add("Step 2: Apply the average velocity formula");
            steps.Add("  Average velocity = (u + v) / 2");
            steps.Add($"  Average velocity = ({initialVelocity.Value:F2} + {finalVelocity.Value:F2}) / 2");
            steps.Add("");

            steps.Add("Step 3: Calculate the sum");
            double sum = initialVelocity.Value + finalVelocity.Value;
            steps.Add($"  = {sum:F2} / 2");
            steps.Add("");

            double value = UniformAccelerationCalculator.CalculateAverageVelocity(initialVelocity, finalVelocity);

            steps.Add("Step 4: Divide by 2");
            steps.Add($"  = {value:F2} m/s");
            steps.Add("");

            steps.Add("Final Answer:");
            steps.Add($"  Average velocity = {value:F2} m/s");

            return new CalculationResult(value, steps);
        }

        public static CalculationResult CalculateVUATWithSteps(double? v, double? u, double? a, double? t)
        {
            int missingCount =
                (v is null ? 1 : 0) +
                (u is null ? 1 : 0) +
                (a is null ? 1 : 0) +
                (t is null ? 1 : 0);

            if (missingCount > 1)
                throw new InvalidOperationException("Exactly one parameter must be null to be calculated.");

            var steps = new List<string>();

            steps.Add("Step 1: Identify known values (SUVAT Equation: v = u + at)");
            steps.Add($"  Final velocity (v) = {(v.HasValue ? v.Value.ToString("F2") : "UNKNOWN")}");
            steps.Add($"  Initial velocity (u) = {(u.HasValue ? u.Value.ToString("F2") : "UNKNOWN")}");
            steps.Add($"  Acceleration (a) = {(a.HasValue ? a.Value.ToString("F2") : "UNKNOWN")}");
            steps.Add($"  Time (t) = {(t.HasValue ? t.Value.ToString("F2") : "UNKNOWN")}");
            steps.Add("");

            steps.Add("Step 2: State the equation");
            steps.Add("  v = u + at");
            steps.Add("");

            double value;
            string calculationVariable;

            if (v is null)
            {
                calculationVariable = "Final velocity (v)";
                steps.Add("Step 3: Calculate v = u + at");
                steps.Add($"  v = {u.Value:F2} + ({a.Value:F2} × {t.Value:F2})");
                steps.Add($"  v = {u.Value:F2} + {a.Value * t.Value:F2}");
                
                value = UniformAccelerationCalculator.CalculateVUAT(v, u, a, t).Value;
                steps.Add($"  v = {value:F2} m/s");
            }
            else if (u is null)
            {
                calculationVariable = "Initial velocity (u)";
                steps.Add("Step 3: Rearrange for u = v - at");
                steps.Add($"  u = {v.Value:F2} - ({a.Value:F2} × {t.Value:F2})");
                steps.Add($"  u = {v.Value:F2} - {a.Value * t.Value:F2}");
                
                value = UniformAccelerationCalculator.CalculateVUAT(v, u, a, t).Value;
                steps.Add($"  u = {value:F2} m/s");
            }
            else if (a is null)
            {
                calculationVariable = "Acceleration (a)";
                steps.Add("Step 3: Rearrange for a = (v - u) / t");
                steps.Add($"  a = ({v.Value:F2} - {u.Value:F2}) / {t.Value:F2}");
                steps.Add($"  a = {v.Value - u.Value:F2} / {t.Value:F2}");
                
                value = UniformAccelerationCalculator.CalculateVUAT(v, u, a, t).Value;
                steps.Add($"  a = {value:F2} m/s²");
            }
            else
            {
                calculationVariable = "Time (t)";
                steps.Add("Step 3: Rearrange for t = (v - u) / a");
                steps.Add($"  t = ({v.Value:F2} - {u.Value:F2}) / {a.Value:F2}");
                steps.Add($"  t = {v.Value - u.Value:F2} / {a.Value:F2}");
                
                value = UniformAccelerationCalculator.CalculateVUAT(v, u, a, t).Value;
                steps.Add($"  t = {value:F2} s");
            }

            steps.Add("");
            steps.Add("Final Answer:");
            steps.Add($"  {calculationVariable} = {value:F2}");

            return new CalculationResult(value, steps);
        }

        public static CalculationResult CalculateVUASWithSteps(double? v, double? u, double? a, double? s)
        {
            int missingCount =
                (v is null ? 1 : 0) +
                (u is null ? 1 : 0) +
                (a is null ? 1 : 0) +
                (s is null ? 1 : 0);

            if (missingCount > 1)
                throw new InvalidOperationException("Exactly one parameter must be null to be calculated.");

            var steps = new List<string>();

            steps.Add("Step 1: Identify known values (SUVAT Equation: v² = u² + 2as)");
            steps.Add($"  Final velocity (v) = {(v.HasValue ? v.Value.ToString("F2") : "UNKNOWN")}");
            steps.Add($"  Initial velocity (u) = {(u.HasValue ? u.Value.ToString("F2") : "UNKNOWN")}");
            steps.Add($"  Acceleration (a) = {(a.HasValue ? a.Value.ToString("F2") : "UNKNOWN")}");
            steps.Add($"  Displacement (s) = {(s.HasValue ? s.Value.ToString("F2") : "UNKNOWN")}");
            steps.Add("");

            steps.Add("Step 2: State the equation");
            steps.Add("  v² = u² + 2as");
            steps.Add("");

            double value;
            string calculationVariable;

            if (v is null)
            {
                calculationVariable = "Final velocity (v)";
                steps.Add("Step 3: Calculate v = √(u² + 2as)");
                steps.Add($"  v² = {u.Value:F2}² + 2 × {a.Value:F2} × {s.Value:F2}");
                steps.Add($"  v² = {Math.Pow(u.Value, 2):F2} + {2 * a.Value * s.Value:F2}");
                steps.Add($"  v² = {Math.Pow(u.Value, 2) + 2 * a.Value * s.Value:F2}");
                
                value = UniformAccelerationCalculator.CalculateVUAS(v, u, a, s).Value;
                steps.Add($"  v = {value:F2} m/s");
            }
            else if (u is null)
            {
                calculationVariable = "Initial velocity (u)";
                steps.Add("Step 3: Calculate u = √(v² - 2as)");
                steps.Add($"  u² = {v.Value:F2}² - 2 × {a.Value:F2} × {s.Value:F2}");
                steps.Add($"  u² = {Math.Pow(v.Value, 2):F2} - {2 * a.Value * s.Value:F2}");
                steps.Add($"  u² = {Math.Pow(v.Value, 2) - 2 * a.Value * s.Value:F2}");
                
                value = UniformAccelerationCalculator.CalculateVUAS(v, u, a, s).Value;
                steps.Add($"  u = {value:F2} m/s");
            }
            else if (a is null)
            {
                calculationVariable = "Acceleration (a)";
                steps.Add("Step 3: Calculate a = (v² - u²) / 2s");
                steps.Add($"  a = ({v.Value:F2}² - {u.Value:F2}²) / (2 × {s.Value:F2})");
                steps.Add($"  a = ({Math.Pow(v.Value, 2):F2} - {Math.Pow(u.Value, 2):F2}) / {2 * s.Value:F2}");
                steps.Add($"  a = {Math.Pow(v.Value, 2) - Math.Pow(u.Value, 2):F2} / {2 * s.Value:F2}");
                
                value = UniformAccelerationCalculator.CalculateVUAS(v, u, a, s).Value;
                steps.Add($"  a = {value:F2} m/s²");
            }
            else
            {
                calculationVariable = "Displacement (s)";
                steps.Add("Step 3: Calculate s = (v² - u²) / 2a");
                steps.Add($"  s = ({v.Value:F2}² - {u.Value:F2}²) / (2 × {a.Value:F2})");
                steps.Add($"  s = ({Math.Pow(v.Value, 2):F2} - {Math.Pow(u.Value, 2):F2}) / {2 * a.Value:F2}");
                steps.Add($"  s = {Math.Pow(v.Value, 2) - Math.Pow(u.Value, 2):F2} / {2 * a.Value:F2}");
                
                value = UniformAccelerationCalculator.CalculateVUAS(v, u, a, s).Value;
                steps.Add($"  s = {value:F2} m");
            }

            steps.Add("");
            steps.Add("Final Answer:");
            steps.Add($"  {calculationVariable} = {value:F2}");

            return new CalculationResult(value, steps);
        }

        public static CalculationResult CalculateSUVTWithSteps(double? s, double? u, double? v, double? t)
        {
            int missingCount =
                (s is null ? 1 : 0) +
                (u is null ? 1 : 0) +
                (v is null ? 1 : 0) +
                (t is null ? 1 : 0);

            if (missingCount > 1)
                throw new InvalidOperationException("Exactly one parameter must be null to be calculated.");

            var steps = new List<string>();

            steps.Add("Step 1: Identify known values (SUVAT Equation: s = 0.5(u + v)t)");
            steps.Add($"  Displacement (s) = {(s.HasValue ? s.Value.ToString("F2") : "UNKNOWN")}");
            steps.Add($"  Initial velocity (u) = {(u.HasValue ? u.Value.ToString("F2") : "UNKNOWN")}");
            steps.Add($"  Final velocity (v) = {(v.HasValue ? v.Value.ToString("F2") : "UNKNOWN")}");
            steps.Add($"  Time (t) = {(t.HasValue ? t.Value.ToString("F2") : "UNKNOWN")}");
            steps.Add("");

            steps.Add("Step 2: State the equation");
            steps.Add("  s = 0.5 × (u + v) × t");
            steps.Add("");

            double value;
            string calculationVariable;

            if (s is null)
            {
                calculationVariable = "Displacement (s)";
                steps.Add("Step 3: Calculate s = 0.5 × (u + v) × t");
                steps.Add($"  s = 0.5 × ({u.Value:F2} + {v.Value:F2}) × {t.Value:F2}");
                steps.Add($"  s = 0.5 × {u.Value + v.Value:F2} × {t.Value:F2}");
                
                value = UniformAccelerationCalculator.CalculateSUVT(s, u, v, t).Value;
                steps.Add($"  s = {value:F2} m");
            }
            else if (u is null)
            {
                calculationVariable = "Initial velocity (u)";
                steps.Add("Step 3: Calculate u = (2s / t) - v");
                steps.Add($"  u = (2 × {s.Value:F2} / {t.Value:F2}) - {v.Value:F2}");
                steps.Add($"  u = {2 * s.Value / t.Value:F2} - {v.Value:F2}");
                
                value = UniformAccelerationCalculator.CalculateSUVT(s, u, v, t).Value;
                steps.Add($"  u = {value:F2} m/s");
            }
            else if (v is null)
            {
                calculationVariable = "Final velocity (v)";
                steps.Add("Step 3: Calculate v = (2s / t) - u");
                steps.Add($"  v = (2 × {s.Value:F2} / {t.Value:F2}) - {u.Value:F2}");
                steps.Add($"  v = {2 * s.Value / t.Value:F2} - {u.Value:F2}");
                
                value = UniformAccelerationCalculator.CalculateSUVT(s, u, v, t).Value;
                steps.Add($"  v = {value:F2} m/s");
            }
            else
            {
                calculationVariable = "Time (t)";
                steps.Add("Step 3: Calculate t = 2s / (u + v)");
                steps.Add($"  t = (2 × {s.Value:F2}) / ({u.Value:F2} + {v.Value:F2})");
                steps.Add($"  t = {2 * s.Value:F2} / {u.Value + v.Value:F2}");
                
                value = UniformAccelerationCalculator.CalculateSUVT(s, u, v, t).Value;
                steps.Add($"  t = {value:F2} s");
            }

            steps.Add("");
            steps.Add("Final Answer:");
            steps.Add($"  {calculationVariable} = {value:F2}");

            return new CalculationResult(value, steps);
        }

        public static CalculationResult CalculateSUTATWithSteps(double? s, double? u, double? a, double? t)
        {
            int missingCount =
                (s is null ? 1 : 0) +
                (u is null ? 1 : 0) +
                (a is null ? 1 : 0) +
                (t is null ? 1 : 0);

            if (missingCount > 1)
                throw new InvalidOperationException("Exactly one parameter must be null to be calculated.");

            var steps = new List<string>();

            steps.Add("Step 1: Identify known values (SUVAT Equation: s = ut + 0.5at²)");
            steps.Add($"  Displacement (s) = {(s.HasValue ? s.Value.ToString("F2") : "UNKNOWN")}");
            steps.Add($"  Initial velocity (u) = {(u.HasValue ? u.Value.ToString("F2") : "UNKNOWN")}");
            steps.Add($"  Acceleration (a) = {(a.HasValue ? a.Value.ToString("F2") : "UNKNOWN")}");
            steps.Add($"  Time (t) = {(t.HasValue ? t.Value.ToString("F2") : "UNKNOWN")}");
            steps.Add("");

            steps.Add("Step 2: State the equation");
            steps.Add("  s = ut + 0.5at²");
            steps.Add("");

            double value;
            string calculationVariable;

            if (s is null)
            {
                calculationVariable = "Displacement (s)";
                steps.Add("Step 3: Calculate s = ut + 0.5at²");
                steps.Add($"  s = ({u.Value:F2} × {t.Value:F2}) + (0.5 × {a.Value:F2} × {t.Value:F2}²)");
                steps.Add($"  s = {u.Value * t.Value:F2} + {0.5 * a.Value * Math.Pow(t.Value, 2):F2}");
                
                value = UniformAccelerationCalculator.CalculateSUTAT(s, u, a, t).Value;
                steps.Add($"  s = {value:F2} m");
            }
            else if (u is null)
            {
                calculationVariable = "Initial velocity (u)";
                steps.Add("Step 3: Calculate u = (s - 0.5at²) / t");
                steps.Add($"  u = ({s.Value:F2} - (0.5 × {a.Value:F2} × {t.Value:F2}²)) / {t.Value:F2}");
                steps.Add($"  u = ({s.Value:F2} - {0.5 * a.Value * Math.Pow(t.Value, 2):F2}) / {t.Value:F2}");
                steps.Add($"  u = {s.Value - 0.5 * a.Value * Math.Pow(t.Value, 2):F2} / {t.Value:F2}");
                
                value = UniformAccelerationCalculator.CalculateSUTAT(s, u, a, t).Value;
                steps.Add($"  u = {value:F2} m/s");
            }
            else if (a is null)
            {
                calculationVariable = "Acceleration (a)";
                steps.Add("Step 3: Calculate a = 2(s - ut) / t²");
                steps.Add($"  a = 2 × ({s.Value:F2} - ({u.Value:F2} × {t.Value:F2})) / {t.Value:F2}²");
                steps.Add($"  a = 2 × ({s.Value:F2} - {u.Value * t.Value:F2}) / {Math.Pow(t.Value, 2):F2}");
                steps.Add($"  a = {2 * (s.Value - u.Value * t.Value):F2} / {Math.Pow(t.Value, 2):F2}");
                
                value = UniformAccelerationCalculator.CalculateSUTAT(s, u, a, t).Value;
                steps.Add($"  a = {value:F2} m/s²");
            }
            else
            {
                calculationVariable = "Time (t)";
                steps.Add("Step 3: Solve quadratic equation 0.5at² + ut - s = 0");
                steps.Add("  Using quadratic formula: t = (-b ± √(b² - 4ac)) / 2a");
                steps.Add($"  where a = {0.5 * a.Value:F2}, b = {u.Value:F2}, c = {-s.Value:F2}");
                
                double discriminant = Math.Pow(u.Value, 2) - 4 * (0.5 * a.Value) * (-s.Value);
                steps.Add($"  Discriminant = {u.Value:F2}² - 4({0.5 * a.Value:F2})({-s.Value:F2}) = {discriminant:F2}");
                
                value = UniformAccelerationCalculator.CalculateSUTAT(s, u, a, t).Value;
                steps.Add($"  Taking positive root: t = {value:F2} s");
            }

            steps.Add("");
            steps.Add("Final Answer:");
            steps.Add($"  {calculationVariable} = {value:F2}");

            return new CalculationResult(value, steps);
        }
    }
}
