using System.Collections.Generic;
using System.Text;

namespace MathsEngine.Core.Modules.Pure.Algebra.Core;

public class Polynomial
{
    public List<Term> Terms { get; set; }

    public Polynomial(List<Term> terms)
    {
        Terms = terms;
    }
    public Polynomial(string expression)
    {
        Terms = PolynomialUtils.ParseExpression(expression);
    }
    
    public static Polynomial operator + (Polynomial a, Polynomial b)
    {
        return new Polynomial(new List<Term>());
    }

    public static Polynomial operator - (Polynomial a, Polynomial b)
    {
        return new Polynomial(new List<Term>());
    }

    public static Polynomial operator * (Polynomial a, Polynomial b)
    {
        return new Polynomial(new List<Term>());
    }

    public static Polynomial operator * (Polynomial polynomial, int constant)
    {
        var multipliedTerms = new List<Term>();
        foreach (var term in polynomial.Terms)
            multipliedTerms.Add(term * constant);

        return new Polynomial(multipliedTerms);
    }

    public double Evaluate(double value)
    {
        double total = 0;

        foreach (Term term in Terms)
            total += term.Evaluate(value);

        return total;
    }

    public override string ToString()
    {
        if (Terms.Count == 0) return "0";

        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < Terms.Count; i++)
        {
            Term term = Terms[i];

            if (term.Coefficient == 0) continue;

            if (i > 0)
            {
                if (term.Coefficient > 0)
                {
                    sb.Append(" + ");
                }
                else
                {
                    sb.Append(" - ");
                }
            }
            else if (term.Coefficient < 0)
            {
                sb.Append("-");
            }

            sb.Append(Term.FormatTermForDisplay(term, i == 0));
        }

        return sb.ToString();
    }
}