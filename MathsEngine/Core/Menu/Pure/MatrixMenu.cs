using MathsEngine.Modules.Pure.Matrices;
using MathsEngine.Utils;
using System;

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
            Console.WriteLine("4. Divide a matrix by a number");
            Console.WriteLine("5. Solving simple matrix equations");
            Console.WriteLine("6. Multiply matrices by matrices");
            Console.WriteLine("7. Calculate the determinant of a square matrix");
            Console.WriteLine("8. Main Menu");
            int response = Parsing.GetMenuInput("Input: ", 8);

            switch (response)
            {
                case 1:
                    HandleAddMatrix();
                    break;
                case 2:
                    HandleSubtractMatrix();
                    break;
                case 3:
                    HandleScalarMultiplication();
                    break;
                case 4:
                    HandleScalarDivision();
                    break;
                case 5:
                    HandleMatrixEquations();
                    break;
                case 6:
                    HandleMatrixMultiplication();
                    break;
                case 7:
                    HandleDeterminant();
                    break;
                case 8:
                    Menu.MainMenu();
                    break;
            }
            // After a calculation, return to the main menu
            Menu.MainMenu();
        }

        private static void HandleAddMatrix()
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

            var result = MatrixCalculator.AddMatrix(matrix1, matrix2);
            DisplayMatrix(result);

            Console.WriteLine("\nPress Enter to return to the menu.");
            Console.ReadLine();
        }
        private static void HandleSubtractMatrix()
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

            var result = MatrixCalculator.SubtractMatrix(matrix1, matrix2);
            DisplayMatrix(result);

            Console.WriteLine("\nPress Enter to return to the menu.");
            Console.ReadLine();
        }

        private static void HandleScalarMultiplication()
        {
            Console.Clear();
            Console.Write("How many rows in the matrix: ");
            int rows = Convert.ToInt16(Console.ReadLine());
            Console.Write("How many columns in the matrix: ");
            int columns = Convert.ToInt16(Console.ReadLine());

            Console.Write("\nWhat number would you like to multiply this matrix by: ");
            int number = Convert.ToInt16(Console.ReadLine());

            MatrixBase matrix = new MatrixBase(rows, columns);
            var result = MatrixCalculator.ScalarMultiplication(matrix, number);
            DisplayMatrix(result);

            Console.WriteLine("\nPress Enter to return to the menu.");
            Console.ReadLine();
        }
        private static void HandleScalarDivision()
        {
            Console.Clear();
            Console.Write("How many rows in the matrix: ");
            int rows = Convert.ToInt16(Console.ReadLine());
            Console.Write("How many columns in the matrix: ");
            int columns = Convert.ToInt16(Console.ReadLine());

            Console.Write("\nWhat number would you like to multiply this matrix by: ");
            int number = Convert.ToInt16(Console.ReadLine());

            MatrixBase matrix = new MatrixBase(rows, columns);
            var result = MatrixCalculator.ScalarDivision(matrix, number);
            DisplayMatrix(result);

            Console.WriteLine("\nPress Enter to return to the menu.");
            Console.ReadLine();
        }

        private static void HandleMatrixEquations() //X - matrix = matrix
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

            var result = MatrixCalculator.MatrixEquations(matrix1, matrix2, x);
            DisplayMatrix(result);

            Console.WriteLine("Press Enter to return to the main menu.");
            Console.ReadLine();
        }

        private static void HandleMatrixMultiplication()
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

            var result = MatrixCalculator.MatrixMultiplication(matrix1, matrix2);
            DisplayMatrix(result);

            Console.WriteLine("Press Enter to return to the main menu.");
            Console.ReadLine();
        }

        private static void HandleDeterminant()
        {
            Console.Clear();

            MatrixBase matrix = new MatrixBase(2, 2);

            var determinant = MatrixCalculator.CalculateDeterminant(matrix);
            Console.WriteLine($"Determinant: {determinant}");

            Console.WriteLine("Press Enter to return to the main menu.");
            Console.ReadLine();
        }

        private static void DisplayMatrix(double[,] matrix)
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