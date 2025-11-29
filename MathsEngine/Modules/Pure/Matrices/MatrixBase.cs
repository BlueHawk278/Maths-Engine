using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsEngine.Modules.Pure.Matrices
{
    internal class MatrixBase
    {
        public int NumRows { get; set; }
        public int NumCols { get; set; }
        public double[,] Matrix {  get; set; }

        public MatrixBase(int rows, int cols)
        {
            NumRows = rows;
            NumCols = cols;
            Matrix = new double[NumRows, NumCols];

            GetMatrice();
        }

        public void GetMatrice()
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
    }
}