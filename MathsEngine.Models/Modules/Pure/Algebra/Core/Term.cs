namespace MathsEngine.Core.Modules.Pure.Algebra.Core;

/// <summary>
/// Represents a single algebraic term (e.g., 3x^2).
/// </summary>
public sealed class Term
{
    /// <summary>
    /// Gets the numeric coefficient of the term.
    /// </summary>
    public double Coefficient { get; set; }
    
    /// <summary>
    /// Gets the exponent (power) applied to 'x'.
    /// </summary>
    public int Power { get; set; }

    /// <summary>
    /// Initializes a new <see cref="Term"/> using the default variable <c>x</c>.
    /// </summary>
    /// <param name="coefficient">The coefficient of the term.</param>
    /// <param name="power">The exponent applied to <c>x</c>.</param>
    public Term(double coefficient, int power)
    {
        Coefficient = coefficient;
        Power = power;
    }

    public Term()
    {
        Coefficient = 0;
        Power = 0;
    }


    public static bool IsLikeTerm(Term term1, Term term2)
    {
        if (term1 is null || term2 is null) return false;
        return term1.Power == term2.Power;
    }
    public bool IsLikeTerm(Term other)
    {
        if (other is null) throw new ArgumentNullException(nameof(other));
        return Power == other.Power;
    }
    public bool IsValidVariable(string variable) => variable.Length == 1;
    public bool IsEqualTerm(Term other)
    {
        if (Coefficient == other.Coefficient && Power == other.Power) 
            return true;
        return false;
    }
    

    /// <summary>
    /// This method provides the degree of the term. This is just the exponent.
    /// This can be used in polynomials by sorting the presentation of the terms in descending degree order.
    /// For example: 5x^2 + 3x - 5
    /// </summary>
    /// <returns> The exponent of the Term</returns>
    public int Degree() => Power;
    
    public static Term operator + (Term term1, Term term2)
    {
        if (term1 is null || term2 is null) throw new ArgumentNullException();
        if (!IsLikeTerm(term1, term2))
            throw new InvalidOperationException("Cannot add unlike terms.");

        return new Term(term1.Coefficient + term2.Coefficient, term1.Power);
    }
    public static Term operator - (Term term1, Term term2)
    {
        if (term1 is null || term2 is null) throw new ArgumentNullException();
        if (!IsLikeTerm(term1, term2))
            throw new InvalidOperationException("Cannot subtract unlike terms.");

        return new Term(term1.Coefficient - term2.Coefficient, term1.Power);
    }
    public static Term operator * (Term term1, Term term2)
    {
        if (term1 is null || term2 is null) throw new ArgumentNullException();

        return new Term(
            term1.Coefficient * term2.Coefficient,
            term1.Power + term2.Power
        );
    }
    public static Term operator * (Term term, int constant) => new Term(term.Coefficient * constant, term.Power);
    public static Term operator / (Term term1, Term term2)
    {
        if (term1 is null || term2 is null) throw new ArgumentNullException();
        if (term2.Coefficient == 0)
            throw new DivideByZeroException("Cannot divide by a term with a zero coefficient.");

        return new Term(term1.Coefficient / term2.Coefficient, term1.Power - term2.Power);
    }

    public double Evaluate(double variable)
    {
        if (variable == 0 && Power < 0)
            throw new DivideByZeroException("Cannot evaluate negative powers at x = 0.");

        return Coefficient * Math.Pow(variable, Power);
    }

    public static string FormatTermForDisplay(Term term, bool isFirst)
    {
        double coeff = Math.Abs(term.Coefficient);

        if (coeff == 0) return "";

        string coeffPart = "";
        if (term.Power == 0)
            coeffPart = coeff.ToString();
        else if (coeff != 1)
            coeffPart = coeff.ToString();

        string powerPart = "";
        if (term.Power == 0)
            powerPart = "";
        else if (term.Power == 1)
            powerPart = "x";
        else
            powerPart = $"x^{term.Power}";

        return $"{coeffPart}{powerPart}";
    }
    public override string ToString()
    {
        if (Coefficient == 0) return "0";

        // Constant
        if (Power == 0)
            return Coefficient.ToString();

        string coeffPart;

        if (Coefficient == 1)
            coeffPart = "";
        else if (Coefficient == -1)
            coeffPart = "-";
        else
            coeffPart = Coefficient.ToString();

        string powerPart;

        if (Power == 1)
            powerPart = $"x";
        else
            powerPart = $"x^{Power}";

        return $"{coeffPart}{powerPart}";
    }
}