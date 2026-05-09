using System.Collections.Generic;
using System.Text;

namespace MathsEngine.Core.Modules.Pure.Algebra.Core;

public class Polynomial
{
    public List<Term> Terms { get; private set; }

    public Polynomial(List<Term> terms)
    {
        Terms = terms;
    }

    public Polynomial(string terms)
    {
        Terms = new List<Term>();
    }

    public double Evaluate(double value)
    {
        double total = 0;

        foreach (Term term in Terms)
            total += term.Evaluate(value);

        return total;
    }

    public void Simplify()
    {
        // Dictionary to store the Exponent and Sum of Coefficients.
        Dictionary<int, double> map = new Dictionary<int, double>();

        foreach (Term term in Terms)
        {
            if (map.ContainsKey(term.Degree()))
            {
                map[term.Degree()] += term.Coefficient;
            }
            else
            {
                map[term.Degree()] = term.Coefficient;
            }
        }

        List<Term> resultList = new List<Term>();

        foreach (var pair in map)
        {
            Term t = new Term();
            t.Power = pair.Key;
            t.Coefficient = pair.Value;
            resultList.Add(t);
        }

        Terms = resultList;

        RearrangePolynomial();
    }

    public void RearrangePolynomial()
    {
        for (int i = 0; i < Terms.Count; i++)
        {
            for (int j = 0; j < Terms.Count - 1; j++)
            {
                if (Terms[j].Degree() < Terms[j + 1].Degree())
                {
                    Term temp = Terms[j];
                    Terms[j] = Terms[j + 1];
                    Terms[j + 1] = temp;
                }
            }
        }
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