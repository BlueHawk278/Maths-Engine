using System.Collections.Generic;

namespace MathsEngine.Modules.Teaching
{
    /// <summary>
    /// Represents a calculation result with explanatory steps
    /// </summary>

    public class CalculationResult
    {
        public double Value { get; }
        public IReadOnlyList<string> Steps { get; }

        public CalculationResult(double value, List<string> steps)
        {
            Value = value;
            Steps = steps;
        }
    }
}

