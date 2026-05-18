namespace MathsEngine.Core.Modules.Pure.Algebra.Core;

public class PolynomialUtils
{
    public static Polynomial Simplify(Polynomial  polynomial)
    {
        // Dictionary to store the Exponent and Sum of Coefficients.
        Dictionary<int, double> map = new Dictionary<int, double>();

        foreach (Term term in polynomial.Terms)
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

        polynomial.Terms = resultList;

        RearrangePolynomial(polynomial);
        
        return polynomial;
    }

    public static Polynomial RearrangePolynomial(Polynomial  polynomial)
    {
        for (int i = 0; i < polynomial.Terms.Count; i++)
        {
            for (int j = 0; j < polynomial.Terms.Count - 1; j++)
            {
                if (polynomial.Terms[j].Degree() < polynomial.Terms[j + 1].Degree())
                {
                    Term temp = polynomial.Terms[j];
                    polynomial.Terms[j] = polynomial.Terms[j + 1];
                    polynomial.Terms[j + 1] = temp;
                }
            }
        }
        return polynomial;
    }
    
    public static List<Term> ParseExpression(string expression)
    {
        return new List<Term>();
    }
}