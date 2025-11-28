using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsEngine.Modules.Pure.Matrices
{
    internal class MatriceBase
    {
        public int NumRows { get; set; }
        public int NumCols { get; set; }
        public double[,] Matrice {  get; set; }

        public MatriceBase(int rows, int cols)
        {
            NumRows = rows;
            NumCols = cols;
            Matrice = new double[NumRows, NumCols];
        }

        public void GetMatrice()
        {
            for(int i = 0; i < NumRows; i++)
            {
                for(int j = 0; j < NumCols; j++)
                {
                    Console.Write($"Enter matrice index {i},{j}: ");
                    double value = Convert.ToDouble(Console.ReadLine());
                    Matrice[i, j] = value;
                }
            }
        }
    }
}