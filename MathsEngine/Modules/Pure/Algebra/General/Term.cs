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
    public int Coefficient { get; set; }

    /// <summary>
    /// A dictionary mapping each variable to its power.
    /// e.g., { 'x': 2, 'y': 3 } for the term 3x^2y^3
    /// </summary>
    public Dictionary<char, int> Variables { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Term"/> class for a simple, single-variable term.
    /// </summary>
    public Term(int coefficient, char? variable, int power)
    {
        Coefficient = coefficient;
        Variables = new Dictionary<char, int>();
        if (variable.HasValue)
        {
            Variables[variable.Value] = power;
        }
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Term"/> class with a dictionary of variables and powers.
    /// </summary>
    public Term(int coefficient, Dictionary<char, int> variables)
    {
        Coefficient = coefficient;
        Variables = variables ?? new Dictionary<char, int>();
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

    public static Term Divide(Term dividend, Term divisor)
    {
        if (divisor.Coefficient == 0)
            throw new DivideByZeroException("Cannot divide a term by a zero coefficient");

        // 1. Divide the coefficients
        int newCoefficient = dividend.Coefficient / divisor.Coefficient;

        // 2. Subtract the powers of the variables
        var newVariables = new Dictionary<char, int>(dividend.Variables);

        foreach (var divisorVar in divisor.Variables)
        {
            if (newVariables.ContainsKey(divisorVar.Key))
            {
                // Subtract the power of the divisor from the dividend's power
                newVariables[divisorVar.Key] -= divisorVar.Value;
            }
            else
            {
                // If the dividend doesn't have the variable, it's like subtracting from a power of 0
                newVariables.Add(divisorVar.Key, -divisorVar.Value);
            }
        }

        // Clean up any variables with a power of 0
        var zeroPowerVars = newVariables.Where(kvp => kvp.Value == 0).Select(kvp => kvp.Key).ToList();
        foreach (var key in zeroPowerVars)
        {
            newVariables.Remove(key);
        }

        return new Term(newCoefficient, newVariables);
    }
}