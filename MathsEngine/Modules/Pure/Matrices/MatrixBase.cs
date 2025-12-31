using System;
using MathsEngine.Utils;

namespace MathsEngine.Modules.Pure.Matrices
{
    public class MatrixBase
    {
        public int NumRows { get; }
        public int NumCols { get; }
        public double[,] Matrix { get; }

        public MatrixBase(int rows, int cols)
        {
            NumRows = rows;
            NumCols = cols;
            Matrix = new double[NumRows, NumCols];

            PopulateMatrix();
        }

        public MatrixBase(double[,] array)
        {
            NumRows = array.GetLength(0);
            NumCols = array.GetLength(1);
            Matrix = array;
        }

        private void PopulateMatrix()
        {
            for(int i = 0; i < NumRows; i++)
            {
                for(int j = 0; j < NumCols; j++)
                {
                    double value = Parsing.GetDoubleInput($"Enter Matrix index [{i},{j}]: ");
                    Matrix[i, j] = value;
                }
            }
        }

        /// <summary>
        /// A method that provides the identity matrix for a square matrix of the given size
        /// </summary>
        /// <param name="size"> The matrix will be size * size. </param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static MatrixBase GetIdentityMatrix(int size)
        {
            if (size <= 0)
                throw new ArgumentException("Size must be a positive integer.");

            var identityMatrix = new MatrixBase(size, size);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    identityMatrix.Matrix[i, j] = (i == j) ? 1 : 0;
                }
            }
            return identityMatrix;
        }

        public static bool CheckEmptyMatrix(MatrixBase matrix)
        {
            if(matrix.Matrix.GetLength(0) == 0)
                return true;
            if(matrix.Matrix.GetLength(1) == 0)
                return true;
            return false;
        }
    }
}