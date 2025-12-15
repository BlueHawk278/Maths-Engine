using System;

namespace MathsEngine.Modules.Pure.Matrices
{
    internal class MatrixCalculator
    {
        /// <summary>
        /// A method to take add or subtract matrices together based on user input
        /// </summary>
        /// <param name="matrix1"> The matrix that will be subtracted from or added to. </param>
        /// <param name="matrix2"> The matrix that will be subtracted by or added to. </param>
        public static double[,] addMatrix(MatrixBase matrix1, MatrixBase matrix2)
        {
            if (matrix1 == null || matrix2 == null)
                throw new ArgumentException("Matrices are empty");

            if (matrix1.NumRows != matrix2.NumRows || matrix1.NumCols != matrix2.NumCols)
                throw new ArgumentException("Matrices can't be added, they are not the same size");

            var result = new double[matrix1.NumRows, matrix1.NumCols];

            for(int i = 0; i <  matrix1.NumRows; i++)
            {
                for(int j = 0; j < matrix1.NumCols; j++)
                {
                    result[i, j] = matrix1.Matrix[i, j] + matrix2.Matrix[i, j];
                }
            }
            return result;
        }
        public static double[,] subtractMatrix(MatrixBase matrix1, MatrixBase matrix2)
        {
            if (matrix1 == null || matrix2 == null)
                throw new ArgumentException("Matrices are empty");

            if (matrix1.NumRows != matrix2.NumRows || matrix1.NumCols != matrix2.NumCols)
                throw new ArgumentException("Matrices can't be added, they are not the same size");

            var result = new double[matrix1.NumRows, matrix1.NumCols];

            for (int i = 0; i < matrix1.NumRows; i++)
            {
                for (int j = 0; j < matrix1.NumCols; j++)
                {
                    result[i, j] = matrix1.Matrix[i, j] - matrix2.Matrix[i, j];
                }
            }
            return result;
        }


        /// <summary>
        /// Multiplying all of the values in a matrix by an integer
        /// </summary>
        /// <param name="matrix"> The matrix being multiplied by. </param>
        /// <param name="number"> The number to multiply the matrix by. </param>
        /// <returns> The result of the matrix * number.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static double[,] scalarMultiplication(MatrixBase matrix, int number)
        {
            if (matrix == null)
                throw new ArgumentException("Matrices can't empty");

            var result = new double[matrix.NumRows, matrix.NumCols];

            for (int i = 0; i < matrix.NumRows; i++)
            {
                for (int j = 0; j < matrix.NumCols; j++)
                {
                    result[i, j] = matrix.Matrix[i, j] * number;
                }
            }
            return result;
        }
        public static double[,] scalarDivision(MatrixBase matrix, int number)
        {
            if (matrix == null)
                throw new ArgumentException("Matrices can't empty");

            var result = new double[matrix.NumRows, matrix.NumCols];

            for (int i = 0; i < matrix.NumRows; i++)
            {
                for (int j = 0; j < matrix.NumCols; j++)
                {
                    result[i, j] = matrix.Matrix[i, j] / number;
                }
            }
            return result;
        }

        public static double[,] matrixEquations(MatrixBase matrix1, MatrixBase matrix2, int number)
        {
            if (matrix1 == null || matrix2 == null)
                throw new ArgumentException("Matrices are empty");

            if (matrix1.NumRows != matrix2.NumRows || matrix1.NumCols != matrix2.NumCols)
                throw new ArgumentException("Matrices can't be added, they are not the same size");

            var result = subtractMatrix(matrix1, matrix2);
            MatrixBase Matrix = new MatrixBase(result);
            result = scalarDivision(Matrix, 2);

            return result;
        }

        private static bool isValidForMultiplication(MatrixBase matrix1, MatrixBase matrix2)
        {
            if(matrix1.NumCols == matrix2.NumRows)
                return true;
            return false;
        }    
    }
}