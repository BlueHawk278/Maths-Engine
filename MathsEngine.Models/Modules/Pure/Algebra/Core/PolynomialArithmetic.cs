namespace MathsEngine.Core.Modules.Pure.Algebra.Core;

public class PolynomialArithmetic
{
    public Polynomial Add(Polynomial other)
    {
        return new Polynomial(new List<Term>());
    }

    public Polynomial Subtract(Polynomial other)
    {
        return new Polynomial(new List<Term>());
    }

    public Polynomial Multiply(Polynomial other)
    {
        return new Polynomial(new List<Term>());
    }

    public Polynomial ScalarMultiply(Polynomial other, int constant)
    {
        var multipliedTerms = new List<Term>();
        foreach (var term in other.Terms)
            multipliedTerms.Add(term * constant);

        return new Polynomial(multipliedTerms);
    }
}