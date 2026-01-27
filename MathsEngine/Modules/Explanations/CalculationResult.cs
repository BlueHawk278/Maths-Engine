using System;
using System.Collections.Generic;

namespace MathsEngine.Modules.Explanations
{
    /// <summary>
    /// Represents a calculation result with explanatory steps.
    /// </summary>
    public class CalculationResult
    {
        public double Value { get; }
        public double[,]? MatrixValue { get; }
        public IReadOnlyList<string> Steps { get; }
        public bool IsMatrix { get; }

        public CalculationResult(double value, List<string> steps)
        {
            Value = value;
            Steps = steps.AsReadOnly();
            IsMatrix = false;
        }

        public CalculationResult(double[,] matrixValue, List<string> steps)
        {
            MatrixValue = matrixValue;
            Steps = steps.AsReadOnly();
            IsMatrix = true;
        }

        /// <summary>
        /// Returns all steps as a single formatted string.
        /// </summary>
        public string GetStepsAsString()
        {
            return string.Join(Environment.NewLine, Steps);
        }
    }
}
