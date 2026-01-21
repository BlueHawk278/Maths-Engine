using System.Text;

namespace MathsEngine.Modules.Pure.Algebra.General;

/// <summary>
/// Represents a single algebraic term, such as 3x^2
/// </summary>

public class Term
{
    /// <summary>
    /// The numerical part of the term e.g. 3 in 3x^2
    /// </summary>
    public double Coefficient { get; set; }

    /// <summary>
    /// A dictionary mapping each variable to its power.
    /// e.g., { 'x': 2, 'y': 3 } for the term 3x^2y^3
    /// </summary>
    public Dictionary<char, double> Variables { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Term"/> class for a simple, single-variable term.
    /// </summary>
    public Term(double coefficient, char? variable, double power)
    {
        Coefficient = coefficient;
        Variables = new Dictionary<char, double>();
        if (variable.HasValue)
        {
            Variables[variable.Value] = power;
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Term"/> class with a dictionary of variables and powers.
    /// </summary>
    public Term(double coefficient, Dictionary<char, double> variables)
    {
        Coefficient = coefficient;
        Variables = variables ?? new Dictionary<char, double>();
    }

    /// <summary>
    /// Returns a string representation of the term.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        if (Coefficient == 0) return "0";

        var hasVariables = Variables != null && Variables.Count > 0;

        var coefficientString = Coefficient.ToString();
        if (Coefficient == 1 && hasVariables) coefficientString = "";
        if (Coefficient == -1 && hasVariables) coefficientString = "-";

        if (!hasVariables)
        {
            return coefficientString; // It's just a constant
        }

        var variablesString = new StringBuilder();
        // Order variables alphabetically for consistent output (e.g., always xy, not yx)
        foreach (var variable in Variables.OrderBy(v => v.Key))
        {
            variablesString.Append(variable.Key);
            if (variable.Value != 1)
            {
                variablesString.Append($"^{variable.Value}");
            }
        }

        return $"{coefficientString}{variablesString}";
    }
}