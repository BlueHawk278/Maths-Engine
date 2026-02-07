using MathsEngine.Utils;

namespace MathsEngine.Menu.Pure.Algebra;

public class FactorisationMenu
{
    public static void Menu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Algebra - Factorisation");
            Console.WriteLine("1. Common factors");
            Console.WriteLine("2. Grouping (4-terms)");
            Console.WriteLine("3. Difference of two squares");
            Console.WriteLine("4. Quadratic factorisation (ax^2 + bx + c");
            Console.WriteLine("5. Back");
            int response = Parsing.GetMenuInput("Input: ", 5);
        }
    }
}