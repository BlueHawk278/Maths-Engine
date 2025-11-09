using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathsEngine.Modules.Statistics.BivariateAnalysis;
using MathsEngine.Modules.Statistics.StandardDeviation;

namespace MathsEngine.Modules.Core
{
    internal class MenuSystem
    {
        public static void showMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("##### Welcome to the Maths Engine #####");
                Console.WriteLine("1. Pure");
                Console.WriteLine("2. Mechanics");
                Console.WriteLine("3. Statistics");
                Console.WriteLine("4. Exit");
                string choice = Console.ReadLine().ToLower();

                switch (choice)
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
                        Console.WriteLine("Goodbye");
                        return;

                    default:
                        Console.WriteLine("Invalid Input. Try again");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private static void pureMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Pure Maths section");
            Console.ReadLine();
        }

        private static void mechanicsMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Mechanics section");
            Console.ReadLine();
        }

        private static void statisticsMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Statistics section");
            Console.WriteLine("1. Bivariate Analysis");
            Console.WriteLine("2. Standard Deviation");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    BAController.Calculate();
                    break;
                case "2":
                    SDController.
            }
        }
    }
}
