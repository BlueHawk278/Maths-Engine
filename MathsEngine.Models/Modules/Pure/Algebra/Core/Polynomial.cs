using System.Text;

namespace MathsEngine.Core.Modules.Pure.Algebra.Core;

public class Polynomial
{
    public List<Term> Terms { get; private set; }

    public Polynomial(List<Term> terms)
    {
        if (terms is null) throw new ArgumentNullException(nameof(terms));

        Terms = new List<Term>(terms);
        Simplify();
    }
    public Polynomial(string expression)
    {
        if (expression is null) throw new ArgumentNullException(nameof(expression));
        
        Terms = ParseExpression(expression);
        Simplify();
    }
    
    public static Polynomial operator + (Polynomial a, Polynomial b)
    {
        if (a is null || b is null) throw new ArgumentNullException();
        
        Dictionary<int, double> map = new Dictionary<int, double>();

        foreach (var term in a.Terms)
        {
            if(map.ContainsKey(term.Degree()))
                map[term.Degree()] += term.Coefficient;
            else
                map[term.Degree()] = term.Coefficient;
        }

        foreach (var term in b.Terms)
        {
            if (map.ContainsKey(term.Degree()))
                map[term.Degree()] += term.Coefficient;
            else
                map[term.Degree()] = term.Coefficient;
        }
        
        List<Term> resultTerms = new List<Term>();

        foreach (var pair in map)
        {
            if (pair.Value != 0)
                resultTerms.Add(new Term(pair.Value, pair.Key));
        }

        return new Polynomial(resultTerms);
    }
    
    public static Polynomial operator - (Polynomial a, Polynomial b)
    {
        if (a is null ||  b is null) throw new ArgumentNullException();
        
        Dictionary<int, double> map = new Dictionary<int, double>();

        foreach (var term in a.Terms)
        {
            if (map.ContainsKey(term.Degree()))
                map[term.Degree()] -= term.Coefficient;
            else
                map[term.Degree()] = term.Coefficient;
        }
        
        foreach (var term in b.Terms)
        {
            if (map.ContainsKey(term.Degree()))
                map[term.Degree()] -= term.Coefficient;
            else
                map[term.Degree()] = -term.Coefficient;
        }

        List<Term> resultTerms = new List<Term>();

        foreach (var pair in map)
        {
            if (pair.Value != 0)
                resultTerms.Add(new Term(pair.Value, pair.Key));
        }

        return new Polynomial(resultTerms);
    }

    public static Polynomial operator * (Polynomial a, Polynomial b)
    {
        if (a is null ||  b is null) throw new ArgumentNullException();

        List<Term> resultTerms = new List<Term>();
        
        foreach(var termA in  a.Terms)
            foreach (var termB in b.Terms)
                resultTerms.Add(termA * termB);
        
        return new Polynomial(resultTerms);
    }

    public static Polynomial operator * (Polynomial polynomial, int constant)
    {
        if (polynomial is null) throw new ArgumentNullException(nameof(polynomial));
        
        var multipliedTerms = new List<Term>();
        foreach (var term in polynomial.Terms)
            multipliedTerms.Add(term * constant);

        return new Polynomial(multipliedTerms);
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

        Terms = new List<Term>();

        foreach (var pair in map)
        {
            if (pair.Value != 0)
                Terms.Add(new Term(pair.Value, pair.Key));
        }

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
    
    public static List<Term> ParseExpression(string expression)
    {
        return new List<Term>();
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