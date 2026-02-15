using MathsEngine.Utils;

namespace MathsEngine.Menu.Pure.Algebra;

public class FactorisationMenu
{
    public static void Menu()
    {
        while (true)
        {
            System.Console.Clear();
            System.Console.WriteLine("Algebra - Factorisation");
            System.Console.WriteLine("1. Common factors");
            System.Console.WriteLine("2. Grouping (4-terms)");
            System.Console.WriteLine("3. Difference of two squares");
            System.Console.WriteLine("4. Quadratic factorisation (ax^2 + bx + c");
            System.Console.WriteLine("5. Back");
            int response = Parsing.GetMenuInput("Input: ", 5);
        }
    }
}