using MathsEngine.Modules.Pure.Matrices;

namespace MathsEngine.Utils
{
    public static class MatrixHelper
    {
        public static void PopulateMatrix(MatrixBase matrix)
        {
            for (int i = 0; i < matrix.NumRows; i++)
            {
                for (int j = 0; j < matrix.NumCols; j++)
                {
                    double value = Parsing.GetDoubleInput($"Enter Matrix index [{i},{j}]: ");
                    matrix.Matrix[i, j] = value;
                }
            }
        }
    }
}
