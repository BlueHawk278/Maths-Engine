using MathsEngine.Console.Menu;
using MathsEngine.Core.Modules.Pure.Algebra.Core;

Term term1 = new Term(-5.0, new Dictionary<char, double>
{
    { 'x', 2 },
    { 'y', 1 }
});

Term term2 = new Term(20, new Dictionary<char, double>
{
    { 'x', 2 },
    { 'y', 1 }
});

Term term3 = new Term(20, new Dictionary<char, double>
{
    { 'x', 2 },
    { 'y', 1 },
    { 'z', 3}
});

Console.WriteLine(term1.ToString());
Console.WriteLine(term2.ToString());
Console.WriteLine(term3.ToString());

Console.WriteLine();

Console.WriteLine(Term.IsLikeTerm(term1, term2));
Console.WriteLine(Term.IsLikeTerm(term1, term3));
Console.WriteLine(Term.IsLikeTerm(term2, term3));