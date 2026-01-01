using MathsEngine.Menu.Mechanics;
using MathsEngine.Menu.Pure;
using MathsEngine.Menu.Statistics;
using MathsEngine.Modules.Statistics.BivariateAnalysis;
using MathsEngine.Utils;

namespace MathsEngine.Menu
{
    internal static class Menu // check, also test everything in the menu
    {
        public static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Maths Engine");
            Console.WriteLine("1. Pure");
            Console.WriteLine("2. Mechanics");
            Console.WriteLine("3. Statistics");
            Console.WriteLine("4. Exit Program");
            int response = Parsing.GetMenuInput("Input: ", 4);
            Console.Clear();

            switch (response)
            {
                case 1:
                    PureMenu();
                    break;
                case 2:
                    MechanicsMenu();
                    break;
                case 3:
                    StatisticsMenu();
                    break;
                case 4:
                    return;
            }
        }
        public static void PureMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Pure Maths Menu");
            Console.WriteLine("1. Pythagoras Theorem");
            Console.WriteLine("2. Trigonometry");
            Console.WriteLine("3. Matrices");
            Console.WriteLine("4. Main Menu");
            int response = Parsing.GetMenuInput("Input: ", 4);
            Console.Clear();

            switch (response)
            {
                case 1:
                    PythagorasMenu.menu();
                    break;
                case 2:
                    TrigonometryMenu.Menu();
                    break;
                case 3:
                    MatrixMenu.menu();
                    break;
                case 4:
                    MainMenu();
                    break;
            }
        }
        public static void MechanicsMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Mechanics Menu");
            Console.WriteLine("1. Uniform Acceleration");
            Console.WriteLine("2. Newton's Laws Calculations");
            Console.WriteLine("3. Main Menu");
            int response = Parsing.GetMenuInput("Input: ", 3);
            Console.Clear();

            switch (response)
            {
                case 1:
                    UniformAccelerationMenu.menu();
                    break;
                case 2:
                    NewtonsLawsMenu.menu();
                    break;
                case 3:
                    MainMenu();
                    break;
            }
        }
        public static void StatisticsMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Statistics Menu");
            Console.WriteLine("1. Bivariate Analysis");
            Console.WriteLine("2. Standard Deviation");
            Console.WriteLine("3. Main Menu");
            int response = Parsing.GetMenuInput("Input: ", 3);
            Console.Clear();

            switch (response)
            {
                case 1:
                    BivariateAnalysis.Start(); // 
                    break;
                case 2:
                    DispersionMenu.menu();
                    break;
                case 3:
                    MainMenu();
                    break;
            }
        }
    }
}