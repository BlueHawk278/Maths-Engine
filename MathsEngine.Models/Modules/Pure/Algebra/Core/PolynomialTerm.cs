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
    /// Gets the variable symbol for the term (for example, <c>x</c>).
    /// </summary>
    public string Variable { get; }
    /// <summary>
    /// Gets the exponent (power) applied to <see cref="Variable"/>.
    /// </summary>
    public int Power { get; set; }



    /// <summary>
    /// Initializes a new <see cref="Term"/> using a specified variable.
    /// </summary>
    /// <param name="coefficient">The coefficient of the term.</param>
    /// <param name="variable">The variable symbol. Must be a single character string.</param>
    /// <param name="power">The exponent applied to <paramref name="variable"/>.</param>
    /// <exception cref="Exception">Thrown when <paramref name="variable"/> is not a single character.</exception>
    public Term(double coefficient, string variable, int power)
    {
        if (!IsValidVariable(variable))
            throw new Exception("The term variable must be a single character");

        Variable = variable;

        Coefficient = coefficient;
        
        Power = power;
    }

    /// <summary>
    /// Initializes a new <see cref="Term"/> using the default variable <c>x</c>.
    /// </summary>
    /// <param name="coefficient">The coefficient of the term.</param>
    /// <param name="power">The exponent applied to <c>x</c>.</param>
    public Term(double coefficient, int power)
    {
        Coefficient = coefficient;
        Variable = "x";
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
        return term1.Variable == term2.Variable && term1.Power == term2.Power;
    }
    public bool IsLikeTerm(Term other)
    {
        if (other is null) throw new ArgumentNullException(nameof(other));
        return ((Power == other.Power) && (Variable == other.Variable));
    }

    public bool IsValidVariable(string variable) => variable.Length == 1;

    public bool IsEqualTerm(Term other)
    {
        if (Coefficient == other.Coefficient && Variable == other.Variable && Power == other.Power) 
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

        if (term1.Variable != term2.Variable)
            throw new InvalidOperationException("Multivariable multiplication not supported yet...");

        return new Term(
            term1.Coefficient * term2.Coefficient,
            term1.Power + term2.Power
        );
    }

    public static Term operator * (Term term, int constant) => new Term(term.Coefficient * constant, term.Variable, term.Power);

    public static Term operator /(Term term1, Term term2)
    {
        if (term1 is null || term2 is null) throw new ArgumentNullException();
        if (!IsLikeTerm(term1, term2))
            throw new InvalidOperationException("Cannot divide unlike terms.");

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
            powerPart = $"{Variable}";
        else
            powerPart = $"{Variable}^{Power}";

        return $"{coeffPart}{powerPart}";
    }
}