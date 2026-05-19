using MathsEngine.Core.Modules.Pure.Algebra.Core;

namespace MathsEngine.Console;

internal static class Program
{
    private static void Main()
    {
        List<Term> terms1 = new List<Term>
        {
            new Term(5, 2),
            new Term(4, 3),
            new Term(2, 2),
            new Term(5, 3),
            new Term(3, 4),
            new Term(4, 5),
        };
        Polynomial p1 = new Polynomial(terms1);

        List<Term> terms2 = new List<Term>
        {
            new Term(4, 2),
            new Term(2, 3),
            new Term(5, 2),
            new Term(3, 3),
            new Term(4, 5),
            new Term(5, 7),
        };
        
        Polynomial p2 = new Polynomial(terms2);

        System.Console.WriteLine(p1.ToString());
        System.Console.WriteLine(p2.ToString());
    }
}