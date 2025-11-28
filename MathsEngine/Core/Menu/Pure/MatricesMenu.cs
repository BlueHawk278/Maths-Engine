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
            string response = Console.ReadLine();

            switch (response)
            {
                case "1":
                    break;
                default:
                    Console.WriteLine("Enter a valid number please");
                    menu();
                    break;
            }
        }
    }
}
