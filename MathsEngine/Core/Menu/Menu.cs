using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsEngine.Core.Menu
{
    internal class Menu
    {
        public static void mainMenu()
        {
            Console.WriteLine("Welcome to the Maths Engine");
            Console.WriteLine("1. Pure");
            Console.WriteLine("2. Mechanics");
            Console.WriteLine("3. Stats");
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
                default:
                    mainMenu();
                    break;
            }
        }

        public static void pureMenu()
        {
            Console.WriteLine("Welcome to the Pure Maths Menu");
        }
        public static void mechanicsMenu()
        {
            Console.WriteLine("Welcome to the Mechanics Menu");
        }
        public static void statisticsMenu()
        {
            Console.WriteLine("Welcome to the Statistics Menu");
            Console.WriteLine("1. Bivariate Analysis");
            Console.WriteLine("2. Standard Deviation");
            string response = Console.ReadLine();

            switch (response)
            {
                case "1":
                    Modules.Statistics.BivariateAnalysis.BivariateAnalysis.calculate();
                    break;
                case "2":
                    Modules.Statistics.StandardDeviation.StandardDeviation.calculate();
            }
        }
    }
}
