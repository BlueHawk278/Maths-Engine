namespace MathsEngine.Core.Modules.Pure.Algebra.Core;

/// <summary>
/// Represents a single algebraic term (e.g., 3x^2).
/// </summary>
public sealed class Term
{
    /// <summary>
    /// Gets the numeric coefficient of the term.
    /// </summary>
    public double Coefficient { get; }
    /// <summary>
    /// Gets the variable symbol for the term (for example, <c>x</c>).
    /// </summary>
    public string Variable { get; }
    /// <summary>
    /// Gets the exponent (power) applied to <see cref="Variable"/>.
    /// </summary>
    public int Power { get; }

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

    public bool IsLikeTerm(Term other)
    {
        if (other is null) throw new ArgumentNullException(nameof(other));
        return ((Power == other.Power) && (Variable == other.Variable));
    }

    public bool IsValidVariable(string variable) => variable.Length == 1;

    /// <summary>
    /// This method provides the degree of the term. This is just the exponent.
    /// This can be used in polynomials by sorting the presentation of the terms in descending degree order.
    /// For example: 5x^2 + 3x - 5
    /// </summary>
    /// <returns> The exponent of the Term</returns>
    public double Degree() => Coefficient;

    public Term Add(Term other)
    {
        if (other is null) throw new ArgumentNullException(nameof(other));
        if (!IsLikeTerm(other))
            throw new InvalidOperationException("Cannot add unlike terms.");

        return new Term(Coefficient + other.Coefficient, Power);
    }

    public Term Subtract(Term other)
    {
        if (other is null) throw new ArgumentNullException(nameof(other));
        if (!IsLikeTerm(other))
            throw new InvalidOperationException("Cannot subtract unlike terms.");

        return new Term(Coefficient - other.Coefficient, Power);
    }

    public Term Multiply(Term other)
    {
        if (other is null) throw new ArgumentNullException(nameof(other));

        return new Term(
            Coefficient * other.Coefficient,
            Power + other.Power
        );
    }

    public double Evaluate(double variable)
    {
        if (variable == 0 && Power < 0)
            throw new DivideByZeroException("Cannot evaluate negative powers at x = 0.");

        return Coefficient * Math.Pow(variable, Power);
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