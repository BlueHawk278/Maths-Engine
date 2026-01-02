using MathsEngine.Modules.Pure.Matrices;
using MathsEngine.Utils;

namespace MathsEngine.Menu.Pure
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
            Console.WriteLine("5. Multiply matrices by matrices");
            Console.WriteLine("6. Calculate the determinant of a square matrix");
            Console.WriteLine("7. Back");
            int response = Parsing.GetMenuInput("Input: ", 7);

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
                    HandleMatrixMultiplication();
                    break;
                case 6:
                    HandleDeterminant();
                    break;
                case 7:
                    Menu.PureMenu();
                    break;
            }

            Console.WriteLine("\nPress Enter to return...");
            Console.ReadLine();

            Menu.MainMenu();
        }

        private static void HandleAddMatrix()
        {
            Console.Clear();

            int rows1 = Parsing.GetIntInput("First Matrix - How many rows: ");
            int columns1 = Parsing.GetIntInput("First Matrix - How many columns: ");
            MatrixBase matrix1 = new MatrixBase(rows1, columns1);

            int rows2 = Parsing.GetIntInput("Second Matrix - How many rows: ");
            int columns2 = Parsing.GetIntInput("Second Matrix - How many columns: ");
            MatrixBase matrix2 = new MatrixBase(rows2, columns2);

            try
            {
                var result = MatrixCalculator.AddMatrix(matrix1, matrix2);
                DisplayMatrix(result);
            }
            catch (NullInputException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError: Empty Input - Please enter values for the matrices.");
                Console.ResetColor();
            }
            catch (IncompatibleMatrixAdditionException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError: Matrices are not the same size.");
                Console.ResetColor();
            }
        }
        private static void HandleSubtractMatrix()
        {
            Console.Clear();

            int rows1 = Parsing.GetIntInput("First Matrix - How many rows: ");
            int columns1 = Parsing.GetIntInput("First Matrix - How many columns: ");
            MatrixBase matrix1 = new MatrixBase(rows1, columns1);

            int rows2 = Parsing.GetIntInput("Second Matrix - How many rows: ");
            int columns2 = Parsing.GetIntInput("Second Matrix - How many columns: ");
            MatrixBase matrix2 = new MatrixBase(rows2, columns2);

            try
            {
                var result = MatrixCalculator.SubtractMatrix(matrix1, matrix2);
                DisplayMatrix(result);
            }
            catch (NullInputException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError: Empty Input - Please enter values for the matrices.");
                Console.ResetColor();
            }
            catch (IncompatibleMatrixAdditionException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError: Matrices are not the same size.");
                Console.ResetColor();
            }
        }

        private static void HandleScalarMultiplication()
        {
            Console.Clear();

            int rows = Parsing.GetIntInput("How many rows in the matrix: ");
            int columns = Parsing.GetIntInput("How many columns in the matrix: ");

            int number = Parsing.GetIntInput("What number would you like to multiply this matrix by: ");

            MatrixBase matrix = new MatrixBase(rows, columns);

            try
            {
                var result = MatrixCalculator.ScalarMultiplication(matrix, number);
                DisplayMatrix(result);
            }
            catch (NullInputException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError: Empty Input - Please enter values for the matrices.");
                Console.ResetColor();
            }
        }
        private static void HandleScalarDivision()
        {
            Console.Clear();

            int rows = Parsing.GetIntInput("How many rows in the matrix: ");
            int columns = Parsing.GetIntInput("How many columns in the matrix: ");

            int number = Parsing.GetIntInput("What number would you like to divide this matrix by: ");

            MatrixBase matrix = new MatrixBase(rows, columns);

            try
            {
                var result = MatrixCalculator.ScalarDivision(matrix, number);
                DisplayMatrix(result);
            }
            catch (NullInputException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError: Empty Input - Please enter values for the matrices.");
                Console.ResetColor();
            }
        }

        private static void HandleMatrixMultiplication()
        {
            Console.Clear();

            int rows1 = Parsing.GetIntInput("First Matrix - How many rows: ");
            int columns1 = Parsing.GetIntInput("First Matrix - How many columns: ");
            MatrixBase matrix1 = new MatrixBase(rows1, columns1);

            int rows2 = Parsing.GetIntInput("Second Matrix - How many rows: ");
            int columns2 = Parsing.GetIntInput("Second Matrix - How many columns: ");
            MatrixBase matrix2 = new MatrixBase(rows2, columns2);

            try
            {
                var result = MatrixCalculator.MatrixMultiplication(matrix1, matrix2);
                DisplayMatrix(result);
            }
            catch (IncompatibleMatrixMultiplicationException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError: These matrices are not compatible for multiplication");
                Console.ResetColor();
            }
        }

        private static void HandleDeterminant()
        {
            Console.Clear();

            MatrixBase matrix = new MatrixBase(2, 2);

            try
            {
                var determinant = MatrixCalculator.CalculateDeterminant(matrix);
                Console.WriteLine($"Determinant: {determinant}");
            }
            catch (NullInputException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError: Null Input - Please enter a valid matrix please");
                Console.ResetColor();
            }
        }

        private static void DisplayMatrix(double[,] matrix)
        {
            try
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
            catch (NullInputException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError: Null Input - Please enter a valid matrix please");
                Console.ResetColor();
            }
            catch (NotSquareMatrixException)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nError: Must be a square matrix to calculate the determinant");
                Console.ResetColor();
            }
        }
    }
}