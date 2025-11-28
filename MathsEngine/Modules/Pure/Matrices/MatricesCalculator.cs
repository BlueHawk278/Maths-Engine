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
        /// <param name="matrice1"> The matrix that will be subtracted from. </param>
        /// <param name="matrice2"> The matrix that will be subtracted by. </param>
        public static MatriceBase AddMatrice(MatriceBase matrice1, MatriceBase matrice2, string operation)
        {
            if (matrice1 == null || matrice2 == null)
                throw new ArgumentException("Matrices are empty");

            if (matrice1.NumRows != matrice2.NumRows || matrice1.NumCols != matrice2.NumCols)
                throw new ArgumentException("Matrices can't be added, they are not the same size");

            var result = new MatriceBase(matrice1.NumRows, matrice1.NumCols);

            for(int i = 0; i <  matrice1.NumRows; i++)
            {
                for(int j = 0; j < matrice1.NumCols; j++)
                {
                    if(operation == "Add")
                        result.Matrice[i, j] = matrice1.Matrice[i, j] + matrice2.Matrice[i, j];
                    if(operation == "Subtract")
                        result.Matrice[i, j] = matrice1.Matrice[i, j] - matrice2.Matrice[i, j];
                }
            }
            return result;
        }
    }
}
