using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathsEngine.Core.Menu.Mechanics;
using MathsEngine.Core.Menu.Pure;
using MathsEngine.Core.Menu.Statistics;
using MathsEngine.Modules.Statistics.BivariateAnalysis;

namespace MathsEngine.Core.Menu
{
    internal static class Menu // check, also test everything in the menu
    {
        public static void mainMenu()
        {
            Console.WriteLine("Welcome to the Maths Engine");
            Console.WriteLine("1. Pure");
            Console.WriteLine("2. Mechanics");
            Console.WriteLine("3. Statistics");
            Console.WriteLine("4. Exit Program");
            string response = Console.ReadLine();

            switch (response)
            {
                case "1":
                    pureMenu();
                    break;
                case "2":
                    mechanicsMenu();
                    break;
                case "3":
                    statisticsMenu();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Please enter a valid number");
                    mainMenu();
                    break;
            }
        }
        private static void pureMenu()
        {
            Console.WriteLine("Welcome to the Pure Maths Menu");
            Console.WriteLine("1. Pythagoras Theorem");
            Console.WriteLine("2. Matrices");
            string response = Console.ReadLine();

            switch (response)
            {
                case "1":
                    PythagorasMenu.menu();
                    break;
                case "2":
                    MatrixMenu.menu();
                    break;
                default:
                    Console.WriteLine("Please enter a valid number");
                    mainMenu();
                    break;
            }
        }
        private static void mechanicsMenu()
        {
            Console.WriteLine("Welcome to the Mechanics Menu");
            Console.WriteLine("1. Uniform Acceleration");
            string response = Console.ReadLine();

            switch (response)
            {
                case "1":
                    UniformAccelerationMenu.menu();
                    break;
                default:
                    Console.WriteLine("Please enter a valid number");
                    mainMenu();
                    break;
            }
        }
        private static void statisticsMenu()
        {
            Console.WriteLine("Welcome to the Statistics Menu");
            Console.WriteLine("1. Bivariate Analysis");
            Console.WriteLine("2. Standard Deviation");
            int response = Convert.ToInt16(Console.ReadLine());

            switch (response)
            {
                case 1:
                    BivariateAnalysis.Start(); // 
                    break;
                case 2:
                    DispersionMenu.menu();
                    break;
                default:
                    Console.WriteLine("Please enter a valid number");
                    mainMenu();
                    break;
            }
        }
    }
}