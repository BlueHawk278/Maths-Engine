using MathsEngine.Utils;

namespace MathsEngine.Menu.Pure.Algebra;

public class AlgebraMenu : IMenu
{
    public static void Menu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("-----Algebra-----");
            Console.WriteLine("1. Factorising");
            Console.WriteLine("2. Back");
            int response = Parsing.GetMenuInput("Input: ", 2);

            switch (response)
            {
                case 1:
                    FactorisationMenu.Menu();
                    break;
                case 2: return;
            }
        }
    }
}