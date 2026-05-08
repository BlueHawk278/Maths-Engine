using MathsEngine.Core.Modules.Pure.Algebra.Core;

Term term1 = new Term(5, 2); // 5x^2
Term term2 = new Term(1, 2); // x^2
Term term3 = new Term(5, 0); // 5
Term term4 = new Term(5, 1); // 5x
Term term5 = new Term(4, -1); // 4x^-1

Term term6 = new Term(5, "x", 2); // 5x^2
Term term7 = new Term(1, "y", 2); // x^2
Term term8 = new Term(5, "z",  0); // 5
Term term9 = new Term(5, "a",  1); // 5x
Term term10 = new Term(4, "b", -1); // 4x^-1

Console.WriteLine(term1.ToString());
Console.WriteLine(term2.ToString());
Console.WriteLine(term3.ToString());
Console.WriteLine(term4.ToString());
Console.WriteLine(term5.ToString());
Console.WriteLine(term6.ToString());
Console.WriteLine(term7.ToString());
Console.WriteLine(term8.ToString());
Console.WriteLine(term9.ToString());
Console.WriteLine(term10.ToString());