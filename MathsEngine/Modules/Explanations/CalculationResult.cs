using MathsEngine.Modules.Pure.CoordinateGeometry;
using System;
using System.Collections.Generic;
using System.Text;

namespace MathsEngine.Modules.Explanations
{
    /// <summary>
    /// Represents a calculation result with explanatory steps.
    /// </summary>
    public class CalculationResult
    {
        public double Value { get; }
        public double[,]? MatrixValue { get; }
        public Coordinate? CoordinateValue { get; }
        public StraightLine? StraightLineValue { get; }
        public IReadOnlyList<string> Steps { get; }
        public bool IsMatrix => MatrixValue != null;
        public bool IsCoordinate => CoordinateValue != null;
        public bool IsStraightLine => StraightLineValue != null;

        public CalculationResult(double value, List<string> steps)
        {
            Value = value;
            Steps = steps.AsReadOnly();
        }

        public CalculationResult(double[,] matrixValue, List<string> steps)
        {
            MatrixValue = matrixValue;
            Steps = steps.AsReadOnly();
        }

        public CalculationResult(Coordinate coordinate, List<string> steps)
        {
            CoordinateValue = coordinate;
            Steps = steps;
        }

        public CalculationResult(StraightLine straightLine, List<String> steps)
        {
            StraightLineValue = straightLine;
            Steps = steps;
        }

        /// <summary>
        /// Returns all steps as a single formatted string.
        /// </summary>
        public string GetStepsAsString()
        {
            var builder = new StringBuilder();
            foreach (var step in Steps)
            {
                builder.AppendLine(step);
            }
            return builder.ToString();
        }
    }
}
