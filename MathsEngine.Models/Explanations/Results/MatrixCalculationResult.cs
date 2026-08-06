namespace MathsEngine.Core.Modules.Explanations.Pure.Matrices;

public class MatrixCalculationResult : BaseCalculationResult
{
    public double[,] MatrixValue { get; }
    public bool IsMatrix => MatrixValue != null;

    public MatrixCalculationResult(double[,] matrixValue, List<string> steps) : base(steps)
    {
        MatrixValue = matrixValue;
    }
}