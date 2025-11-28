using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathsEngine.Modules.Pure.Matrices;

namespace MathsEngine.Core.Menu.Pure
{
    internal class MatrixMenu
    {
        public static void menu()
        {
            Console.WriteLine("Matrices Calculator");
            Console.WriteLine("1. Adding matrices");
            Console.WriteLine("2. Subtract matrices");
            Console.WriteLine("3. Multiply a matrix by a number");
            string response = Console.ReadLine();

            switch (response)
            {
                case "1":
                    handleAddOrSubtractMatrices("Add");
                    break;
                case "2":
                    handleAddOrSubtractMatrices("Subtract");
                    break;
                case "3":
                    handleScalarMultiplication();
                    break;
                default:
                    Console.WriteLine("Enter a valid number please");
                    menu();
                    break;
            }
        }

        private static void handleAddOrSubtractMatrices(string operation)
        {
            Console.Write("First Matrice: How many rows? ");
            int rows1 = Convert.ToInt16(Console.ReadLine());
            Console.Write("First Matrice: How many columns? ");
            int columns1 = Convert.ToInt16(Console.ReadLine());
            MatrixBase matrice1 = new MatrixBase(rows1, columns1);

            Console.Write("Second Matrice: How many rows? ");
            int rows2 = Convert.ToInt16(Console.ReadLine());
            Console.Write("Second Matrice: How many columns? ");
            int columns2 = Convert.ToInt16(Console.ReadLine());
            MatrixBase matrice2 = new MatrixBase(rows2, columns2);

            MatrixCalculator.AddOrSubtractMatrice(matrice1, matrice2, operation);
        }

        private static void handleScalarMultiplication()
        {
            Console.Write("How many rows in the matrix: ");
            int rows = Convert.ToInt16(Console.ReadLine());
            Console.Write("How many columns in the matrix: ");
            int columns = Convert.ToInt16(Console.ReadLine());

            Console.Write("What number would you like to multiply this matrix by: ");
            int number = Convert.ToInt16(Console.ReadLine());

            MatrixBase matrix = new MatrixBase(rows, columns);
            
        }
    }
}
