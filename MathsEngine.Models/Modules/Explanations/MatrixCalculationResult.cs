namespace MathsEngine.Core.Modules.Explanations;

public class MatrixCalculationResult : BaseCalculationResult
{
    public double[,] MatrixValue { get; }
    public bool IsMatrix => MatrixValue != null;

    public MatrixCalculationResult(double[,] matrixValue, List<string> steps) : base(steps)
    {
        MatrixValue = matrixValue;
    }
}