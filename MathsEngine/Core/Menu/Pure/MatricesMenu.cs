using MathsEngine.Modules.Pure.Matrices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsEngine.Core.Menu.Pure
{
    internal class MatricesMenu
    {
        public static void menu()
        {
            Console.WriteLine("Matrices Calculator");
            Console.WriteLine("1. Adding matrices");
            Console.WriteLine("2. Subtract matrices");
            string response = Console.ReadLine();

            switch (response)
            {
                case "1":
                    handleAddOrSubtractMatrices("Add");
                    break;
                case "2":
                    handleAddOrSubtractMatrices("Subtract");
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
            MatriceBase matrice1 = new MatriceBase(rows1, columns1);

            Console.Write("Second Matrice: How many rows? ");
            int rows2 = Convert.ToInt16(Console.ReadLine());
            Console.Write("Second Matrice: How many columns? ");
            int columns2 = Convert.ToInt16(Console.ReadLine());
            MatriceBase matrice2 = new MatriceBase(rows2, columns2);

            MatricesCalculator.AddMatrice(matrice1, matrice2, operation);
        }
    }
}
