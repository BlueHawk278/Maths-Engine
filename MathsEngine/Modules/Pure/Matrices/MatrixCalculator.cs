using System;
using MathsEngine.Utils;

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
                throw new NullInputException("Side lengths must not be negative");

            if (matrix1.NumRows != matrix2.NumRows || matrix1.NumCols != matrix2.NumCols)
                throw new IncompatibleAdditionMatricesException("Side lengths must not be negative");

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
                throw new NullInputException("Side lengths must not be negative");

            if (matrix1.NumRows != matrix2.NumRows || matrix1.NumCols != matrix2.NumCols)
                throw new IncompatibleSubtractionMatricesException("Side lengths must not be negative");

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
        /// Multiplying or dividing, all the values in a matrix by an integer
        /// </summary>
        /// <param name="matrix"> The matrix being multiplied by. </param>
        /// <param name="number"> The number to multiply the matrix by. </param>
        /// <returns> The result of the matrix * number.</returns>
        /// <exception cref="ArgumentException"></exception>
        public static double[,] scalarMultiplication(MatrixBase matrix, int number)
        {
            if (matrix == null)
                throw new NullInputException("Side lengths must not be negative");

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
                throw new NullInputException("Side lengths must not be negative");

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
                throw new NullInputException("Side lengths must not be negative");

            if (matrix1.NumRows != matrix2.NumRows || matrix1.NumCols != matrix2.NumCols)
                throw new IncompatibleSubtractionMatricesException("Side lengths must not be negative");

            var result = subtractMatrix(matrix1, matrix2);
            MatrixBase Matrix = new MatrixBase(result);
            result = scalarDivision(Matrix, 2);

            return result;
        }

        /// <summary>
        /// A method to multiply matrices. They multiply by going across rows and down columns
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static double[,] matrixMultiplication(MatrixBase matrix1, MatrixBase matrix2)
        {
            if (!isValidForMultiplication(matrix1, matrix2))
                throw new IncompatibleMatrixMultiplicationException("Side lengths must not be negative");

            double[,] resultMatrix = new double[matrix1.NumRows, matrix2.NumCols];

            for (int i = 0; i < matrix1.NumRows; i++)
            {
                for (int j = 0; j < matrix2.NumCols; j++)
                {
                    double sum = 0;

                    for (int k = 0; k < matrix1.NumCols; k++)
                    {
                        sum += matrix1.Matrix[i, k] * matrix2.Matrix[k, j];
                    }
                    resultMatrix[i, j] = sum;
                }
            }

            return resultMatrix;
        }

        /// <summary>
        /// Checks if matrices are compatible for multiplication.
        /// The number of columns for matrix 1 must equal the number of rows for matrix 2
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        private static bool isValidForMultiplication(MatrixBase matrix1, MatrixBase matrix2)
        {
            if (matrix1 == null || matrix2 == null)
                throw new NullInputException("Side lengths must not be negative");

            if (matrix1.NumCols == matrix2.NumRows)
                return true;
            return false;
        }

        /// <summary>
        /// Calculates the determinant for any given matrix. ***AD - BC***
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static double calculateDeterminant(MatrixBase matrix)
        {
            if (matrix == null)
                throw new NullInputException("Side lengths must not be negative");

            if (matrix.NumCols != 2 || matrix.NumRows != 2)
                throw new ArgumentException("Must be a 2x2 Square matrix");

            double ad = matrix.Matrix[0, 0] * matrix.Matrix[1, 1];
            double bc = matrix.Matrix[0, 1] * matrix.Matrix[1, 0];

            return ad - bc;
        }
    }
}