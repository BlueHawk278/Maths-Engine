using System;
using MathsEngine.Utils;

namespace MathsEngine.Modules.Pure.Matrices
{
    public class MatrixCalculator
    {
        /// <summary>
        /// A method to take add or subtract matrices together based on user input
        /// </summary>
        /// <param name="matrix1"> The matrix that will be subtracted from or added to. </param>
        /// <param name="matrix2"> The matrix that will be subtracted by or added to. </param>
        public static double[,] AddMatrix(MatrixBase matrix1, MatrixBase matrix2)
        {
            if (matrix1 == null || matrix2 == null)
                throw new NullInputException();
            if (MatrixBase.CheckEmptyMatrix(matrix1)|| MatrixBase.CheckEmptyMatrix(matrix2))
                throw new NullInputException();

            if (matrix1.NumRows != matrix2.NumRows || matrix1.NumCols != matrix2.NumCols)
                throw new IncompatibleMatrixAdditionException();

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
        public static double[,] SubtractMatrix(MatrixBase matrix1, MatrixBase matrix2)
        {
            if (matrix1 == null || matrix2 == null)
                throw new NullInputException();
            if (MatrixBase.CheckEmptyMatrix(matrix1) || MatrixBase.CheckEmptyMatrix(matrix2))
                throw new NullInputException();

            if (matrix1.NumRows != matrix2.NumRows || matrix1.NumCols != matrix2.NumCols)
                throw new IncompatibleMatrixAdditionException();

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
        public static double[,] ScalarMultiplication(MatrixBase matrix, int number)
        {
            if (matrix == null || MatrixBase.CheckEmptyMatrix(matrix))
                throw new NullInputException();

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
        public static double[,] ScalarDivision(MatrixBase matrix, int number)
        {
            if (matrix == null || MatrixBase.CheckEmptyMatrix(matrix))
                throw new NullInputException();

            if (number == 0)
                throw new DivideByZeroException();

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

        public static double[,] MatrixEquations(MatrixBase matrix1, MatrixBase matrix2, int number)
        {
            if (matrix1 == null || matrix2 == null)
                throw new NullInputException();

            if (matrix1.NumRows != matrix2.NumRows || matrix1.NumCols != matrix2.NumCols)
                throw new IncompatibleSubtractionMatricesException();

            var result = SubtractMatrix(matrix1, matrix2);
            MatrixBase Matrix = new MatrixBase(result);
            result = ScalarDivision(Matrix, 2);

            return result;
        }

        /// <summary>
        /// A method to multiply matrices. They multiply by going across rows and down columns
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static double[,] MatrixMultiplication(MatrixBase matrix1, MatrixBase matrix2)
        {
            if (!IsValidForMultiplication(matrix1, matrix2))
                throw new IncompatibleMatrixMultiplicationException();

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
        private static bool IsValidForMultiplication(MatrixBase matrix1, MatrixBase matrix2)
        {
            if (matrix1 == null || matrix2 == null)
                throw new NullInputException();

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
        public static double CalculateDeterminant(MatrixBase matrix)
        {
            if (matrix == null)
                throw new NullInputException();

            if (matrix.NumCols != 2 || matrix.NumRows != 2)
                throw new NotSquareMatrixException("Must be a 2x2 Square matrix");

            double ad = matrix.Matrix[0, 0] * matrix.Matrix[1, 1];
            double bc = matrix.Matrix[0, 1] * matrix.Matrix[1, 0];

            return ad - bc;
        }
    }
}