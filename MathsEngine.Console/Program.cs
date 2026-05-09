using MathsEngine.Core.Modules.Pure.Algebra.Core;

namespace MathsEngine.Console;

internal static class Program
{
    private static void Main()
    {
        List<Term> terms = new List<Term>
        {
            new Term(5, 2),
            new Term(4, 3),
            new Term(2, 2),
            new Term(5, 3),
        };

        foreach (var term  in terms)
            System.Console.WriteLine(term.ToString());

        Polynomial p1 = new Polynomial(terms);
        p1.Simplify();
        System.Console.WriteLine(p1.ToString());
        System.Console.WriteLine(p1.Evaluate(5));
    }
}