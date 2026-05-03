namespace MathsEngine.Core.Modules.Pure.Algebra.Core;

public sealed class Term
{
    public double Coefficient { get; }
    public int Power { get; }

    public Term(double coefficient, int power)
    {
        Coefficient = coefficient;
        Power = power;
    }

    public bool IsLikeTerm(Term other)
    {
        if (other is null) throw new ArgumentNullException(nameof(other));
        return Power == other.Power;
    }

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

    public double Evaluate(double x)
    {
        if (x == 0 && Power < 0)
            throw new DivideByZeroException("Cannot evaluate negative powers at x = 0.");

        return Coefficient * Math.Pow(x, Power);
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
            powerPart = "x";
        else
            powerPart = $"x^{Power}";

        return $"{coeffPart}{powerPart}";
    }
}