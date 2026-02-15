using MathsEngine.Console.Menu.Statistics;
using MathsEngine.Menu.Mechanics;
using MathsEngine.Menu.Pure;
using MathsEngine.Utils;

namespace MathsEngine.Console.Menu
{
    internal static class Menu
    {
        public static void MainMenu()
        {
            while (true)
            {
                System.Console.Clear();
                System.Console.WriteLine("Welcome to the Maths Engine");
                System.Console.WriteLine("1. Pure");
                System.Console.WriteLine("2. Mechanics");
                System.Console.WriteLine("3. Statistics");
                System.Console.WriteLine("4. Exit Program");
                int response = Parsing.GetMenuInput("Input: ", 4);

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
                    case 4: return;
                }
            }
        }
        private static void PureMenu()
        {
            while (true)
            {
                System.Console.Clear();
                System.Console.WriteLine("Welcome to the Pure Maths Menu");
                System.Console.WriteLine("1. Pythagoras Theorem");
                System.Console.WriteLine("2. Trigonometry");
                System.Console.WriteLine("3. Matrices");
                System.Console.WriteLine("4. Algebra");
                System.Console.WriteLine("5. Coordinate Geometry");
                System.Console.WriteLine("6. Back");
                int response = Parsing.GetMenuInput("Input: ", 6);

                switch (response)
                {
                    case 1:
                        PythagorasMenu.Menu();
                        break;
                    case 2:
                        TrigonometryMenu.Menu();
                        break;
                    case 3:
                        MatrixMenu.Menu();
                        break;
                    case 5:
                        CoordinateGeometryMenu.Menu();
                        break;
                    case 6: return;
                }
            }
        }
        private static void MechanicsMenu()
        {
            while (true)
            {
                System.Console.Clear();
                System.Console.WriteLine("Welcome to the Mechanics Menu");
                System.Console.WriteLine("1. Uniform Acceleration");
                System.Console.WriteLine("2. Newton's Laws Calculations");
                System.Console.WriteLine("3. Main Menu");
                int response = Parsing.GetMenuInput("Input: ", 3);
                System.Console.Clear();

                switch (response)
                {
                    case 1:
                        UniformAccelerationMenu.Menu();
                        break;
                    case 2:
                        NewtonsLawsMenu.Menu();
                        break;
                    case 3: return;
                }
            }
        }
        private static void StatisticsMenu()
        {
            while (true)
            {
                System.Console.Clear();
                System.Console.WriteLine("Welcome to the Statistics Menu");
                System.Console.WriteLine("1. Bivariate Analysis");
                System.Console.WriteLine("2. Standard Deviation");
                System.Console.WriteLine("3. Main Menu");
                int response = Parsing.GetMenuInput("Input: ", 3);
                System.Console.Clear();

                switch (response)
                {
                    case 1:
                        BivariateAnalysisMenu.Menu(); // 
                        break;
                    case 2:
                        DispersionMenu.Menu();
                        break;
                    case 3: return;
                }
            }
        }
    }
}