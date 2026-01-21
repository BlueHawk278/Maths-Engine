using MathsEngine.Utils;

namespace MathsEngine.Menu.Pure.Algebra;

public class AlgebraMenu
{
    public static void Menu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Algebra");
            Console.WriteLine("1. Factorising");
            int response = Parsing.GetMenuInput("Input: ", 1);
        }
    }
}