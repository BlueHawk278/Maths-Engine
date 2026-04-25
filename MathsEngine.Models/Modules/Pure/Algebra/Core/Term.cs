using System.Text;

namespace MathsEngine.Core.Modules.Pure.Algebra.Core;

public class Term
{
    public double Coefficient { get; set; }
    public Dictionary<char, double> Variables { get; set; }

    public Term(double coefficient, Dictionary<char, double> variables)
    {
        Coefficient = coefficient;

        if (variables != null) Variables = variables;
        else Variables = new Dictionary<char, double>();
    }

    public bool IsLikeTerm(Term other)
    {
        var variables1 = Variables.OrderBy(x => x.Key);
        var variables2 = other.Variables.OrderBy(x => x.Key);

        if (Variables is null) throw new ArgumentNullException();
        if (other is null) throw new ArgumentNullException();

        // Normalize: ignore variables with exponent 0 (x^0 == 1)
        var vars1 = Variables.Where(kvp => kvp.Value != 0).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
        var vars2 = other.Variables.Where(kvp => kvp.Value != 0).ToDictionary(kvp => kvp.Key, kvp => kvp.Value);

        if (vars1.Count != vars2.Count) return false;

        foreach (var (variable, exponent1) in vars1)
        {
            if (!vars2.TryGetValue(variable, out var exponent2)) return false;
            if (exponent1 != exponent2) return false;
        }

        return true;
    }

    public static Term Add(Term other){}
    public static Term Subtract(Term other){}
    public static Term Multiply(Term other){}

    public override string ToString()
    {
        if (Coefficient == 0) return "0";

        StringBuilder sb = new StringBuilder();

        if (Coefficient == -1 && Variables.Count > 0)
            sb.Append("-");
        else if (Coefficient != 1 || Variables.Count == 0)
            sb.Append(Coefficient);

        foreach (var (variable, exponent) in Variables.OrderBy(x => x.Key))
        {
            if (exponent == 0) continue; // x^0 is 1, so skip it

            sb.Append(variable);

            if (exponent != 1)
                sb.Append($"^{exponent}");
        }

        return sb.ToString();
    }
    public static void Evaluate(){}
}