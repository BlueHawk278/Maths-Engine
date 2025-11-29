using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsEngine.Modules.Pure.Matrices
{
    internal class MatrixCalculator
    {
        /// <summary>
        /// A method to take add or subtract matrices together based on user input
        /// </summary>
        /// <param name="matrice1"> The matrix that will be subtracted from or added to. </param>
        /// <param name="matrice2"> The matrix that will be subtracted by or added to. </param>
        public static double[,] AddOrSubtractMatrice(MatrixBase matrice1, MatrixBase matrice2, string operation)
        {
            if (matrice1 == null || matrice2 == null)
                throw new ArgumentException("Matrices are empty");

            if (matrice1.NumRows != matrice2.NumRows || matrice1.NumCols != matrice2.NumCols)
                throw new ArgumentException("Matrices can't be added, they are not the same size");

            var result = new double[matrice1.NumRows, matrice1.NumCols];

            for(int i = 0; i <  matrice1.NumRows; i++)
            {
                for(int j = 0; j < matrice1.NumCols; j++)
                {
                    if(operation == "Add")
                        result[i, j] = matrice1.Matrix[i, j] + matrice2.Matrix[i, j];
                    if(operation == "Subtract")
                        result[i, j] = matrice1.Matrix[i, j] - matrice2.Matrix[i, j];
                }
            }
            return result;
        }

        public static double[,] ScalarMultiplication(MatrixBase matrix, int number)
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
    }
}
