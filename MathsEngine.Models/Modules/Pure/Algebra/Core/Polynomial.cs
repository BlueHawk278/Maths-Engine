namespace MathsEngine.Core.Modules.Pure.Algebra.Core;

public class Polynomial
{
    private List<Term> Terms { get; }

    public Polynomial(List<Term> terms)
    {
        Terms = terms;
    }

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
        foreach(var term in other.Terms)
            multipliedTerms.Add(term.ScalarMultiply(constant));

        return new Polynomial(multipliedTerms);
    }

    public void Simplify()
    {

    }

    public void RearrangePolynomial()
    {

    }

    public override string ToString()
    {
        return base.ToString();
    }
}