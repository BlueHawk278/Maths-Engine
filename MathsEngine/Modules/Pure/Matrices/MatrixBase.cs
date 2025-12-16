using System;

namespace MathsEngine.Modules.Pure.Matrices
{
    internal class MatrixBase
    {
        public int NumRows { get; }
        public int NumCols { get; }
        public double[,] Matrix { get; }

        public MatrixBase(int rows, int cols)
        {
            NumRows = rows;
            NumCols = cols;
            Matrix = new double[NumRows, NumCols];

            populateMatrix();
        }

        public MatrixBase(double[,] array)
        {
            NumRows = array.GetLength(0);
            NumCols = array.GetLength(1);
            Matrix = array;
        }

        private void populateMatrix()
        {
            for(int i = 0; i < NumRows; i++)
            {
                for(int j = 0; j < NumCols; j++)
                {
                    Console.Write($"Enter matrix index {i},{j}: ");
                    double value = Convert.ToDouble(Console.ReadLine());
                    Matrix[i, j] = value;
                }
            }
        }

        public static MatrixBase getIdentityMatrix(int size)
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
    }
}