using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsEngine.Modules.Pure.Matrices
{
    internal class MatricesCalculator
    {
        /// <summary>
        /// A method to take add matrices together
        /// </summary>
        /// <param name="matrice1"> The matrice that will be substracted from. </param>
        /// <param name="matrice2"> The matrice that will be subtracted by. </param>
        private MatriceBase AddMatrice(MatriceBase matrice1, MatriceBase matrice2) // validate if same size
        {
            if (matrice1 == null || matrice2 == null)
                throw new ArgumentException("Matrices are empty");

            var result = new MatriceBase(matrice1.NumRows, matrice1.NumCols);

            for(int i = 0; i <  matrice1.NumRows; i++)
            {
                for(int j = 0; j < matrice1.NumCols; j++)
                {
                    result.Matrice[i, j] = matrice1.Matrice[i, j] + matrice2.Matrice[i, j];
                }
            }
            return result;
        }

        /// <summary>
        /// A method to subtract two matrices from each other
        /// </summary>
        /// <param name="matrice1"></param>
        /// <param name="matrice2"></param>
        /// <returns> The values at each index pf matrice1 - matrice2 </returns>
        /// <exception cref="ArgumentException"></exception>
        private MatriceBase SubtractMatrice(MatriceBase matrice1, MatriceBase matrice2)
        {
            if (matrice1 == null || matrice2 == null)
                throw new ArgumentException("Matrices are empty");

            var result = new MatriceBase(matrice1.NumRows, matrice1.NumCols);

            for (int i = 0; i < matrice1.NumRows; i++)
            {
                for (int j = 0; j < matrice1.NumCols; j++)
                {
                    result.Matrice[i, j] = matrice1.Matrice[i, j] - matrice2.Matrice[i, j];
                }
            }
            return result;
        }
    }
}
