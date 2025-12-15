using System;
using System.Security.Cryptography.X509Certificates;
using MathsEngine.Modules.Pure.Matrices;

namespace MathsEngine.Core.Menu.Pure
{
    internal class MatrixMenu
    {
        public static void menu()
        {
            Console.Clear();
            Console.WriteLine("Matrices Calculator");
            Console.WriteLine("1. Adding matrices");
            Console.WriteLine("2. Subtract matrices");
            Console.WriteLine("3. Multiply a matrix by a number");
            Console.WriteLine("4. Solving simple matrix equations");
            Console.Write("Input: ");
            string response = Console.ReadLine();

            switch (response)
            {
                case "1":
                    handleAddMatrix();
                    break;
                case "2":
                    handleSubtractMatrix();
                    break;
                case "3":
                    handleScalarMultiplication();
                    break;
                case "4":
                    handleMatrixEquations();
                    break;
                default:
                    Console.WriteLine("Enter a valid number please");
                    break;
            }
            // After a calculation, return to the main menu
            Menu.mainMenu();
        }

        private static void handleAddMatrix()
        {
            Console.Clear();
            Console.Write("First Matrix: How many rows? ");
            int rows1 = Convert.ToInt16(Console.ReadLine());
            Console.Write("First Matrix: How many columns? ");
            int columns1 = Convert.ToInt16(Console.ReadLine());
            MatrixBase matrix1 = new MatrixBase(rows1, columns1);

            Console.Write("\nSecond Matrix: How many rows? ");
            int rows2 = Convert.ToInt16(Console.ReadLine());
            Console.Write("Second Matrix: How many columns? ");
            int columns2 = Convert.ToInt16(Console.ReadLine());
            MatrixBase matrix2 = new MatrixBase(rows2, columns2);

            var result = MatrixCalculator.addMatrix(matrix1, matrix2);
            displayMatrix(result);

            Console.WriteLine("\nPress Enter to return to the menu.");
            Console.ReadLine();
        }
        private static void handleSubtractMatrix()
        {
            Console.Clear();
            Console.Write("First Matrix: How many rows? ");
            int rows1 = Convert.ToInt16(Console.ReadLine());
            Console.Write("First Matrix: How many columns? ");
            int columns1 = Convert.ToInt16(Console.ReadLine());
            MatrixBase matrix1 = new MatrixBase(rows1, columns1);

            Console.Write("\nSecond Matrix: How many rows? ");
            int rows2 = Convert.ToInt16(Console.ReadLine());
            Console.Write("Second Matrix: How many columns? ");
            int columns2 = Convert.ToInt16(Console.ReadLine());
            MatrixBase matrix2 = new MatrixBase(rows2, columns2);

            var result = MatrixCalculator.subtractMatrix(matrix1, matrix2);
            displayMatrix(result);

            Console.WriteLine("\nPress Enter to return to the menu.");
            Console.ReadLine();
        }

        private static void handleScalarMultiplication()
        {
            Console.Clear();
            Console.Write("How many rows in the matrix: ");
            int rows = Convert.ToInt16(Console.ReadLine());
            Console.Write("How many columns in the matrix: ");
            int columns = Convert.ToInt16(Console.ReadLine());

            Console.Write("\nWhat number would you like to multiply this matrix by: ");
            int number = Convert.ToInt16(Console.ReadLine());

            MatrixBase matrix = new MatrixBase(rows, columns);
            var result = MatrixCalculator.scalarMultiplication(matrix, number);
            displayMatrix(result);

            Console.WriteLine("\nPress Enter to return to the menu.");
            Console.ReadLine();
        }

        private static void handleMatrixEquations() //X - matrix = matrix
        {
            Console.Clear(); // Matrix1 - x = Matrix 2

            Console.Write("First Matrix: How many rows? ");
            int rows1 = Convert.ToInt16(Console.ReadLine());
            Console.Write("First Matrix: How many columns? ");
            int columns1 = Convert.ToInt16(Console.ReadLine());
            MatrixBase matrix1 = new MatrixBase(rows1, columns1);

            Console.WriteLine("What is the integer value of X");
            int x = Convert.ToInt16(Console.ReadLine());

            Console.Write("\nSecond Matrix: How many rows? ");
            int rows2 = Convert.ToInt16(Console.ReadLine());
            Console.Write("Second Matrix: How many columns? ");
            int columns2 = Convert.ToInt16(Console.ReadLine());
            MatrixBase matrix2 = new MatrixBase(rows2, columns2);

            var result = MatrixCalculator.matrixEquations(matrix1, matrix2, x);
            displayMatrix(result);

            Console.WriteLine("Press Enter to return to the main menu.");
            Console.ReadLine();
        }

        private static void displayMatrix(double[,] matrix)
        {
            Console.WriteLine("\nResult Matrix: ");

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}