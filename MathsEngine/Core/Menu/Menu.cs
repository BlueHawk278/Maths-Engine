using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathsEngine.Core.Menu.Pure;
using MathsEngine.Modules.Statistics.BivariateAnalysis;
using MathsEngine.Modules.Statistics.Dispersion.ArrayOfNumbers;

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
                    mainMenu();
                    break;
            }
        }
        private static void pureMenu()
        {
            Console.WriteLine("Welcome to the Pure Maths Menu");
            Console.WriteLine("1. Pythagoras Theorem");
            int response = Convert.ToInt16(Console.ReadLine());

            switch (response)
            {
                case 1:
                    PythagorasMenu.menu();
                    break;
            }
        }
        private static void mechanicsMenu()
        {
            Console.WriteLine("Welcome to the Mechanics Menu");
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
                    StandardDeviationArray.Start();
                    break;
            }
        }
    }
}