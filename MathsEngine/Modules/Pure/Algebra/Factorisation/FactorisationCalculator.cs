using MathsEngine.Modules.Pure.Algebra.General;
using System.Collections.Generic;
using System.Linq;

namespace MathsEngine.Modules.Pure.Algebra.Factorisation;

/// <summary>
/// A static class containing methods for algebraic factorisation techniques.
/// </summary>
public static class FactorisationCalculator
{
    /// <summary>
    /// Factorises a list of algebraic terms by finding the highest common factor.
    /// </summary>
    /// <param name="terms">A list of Term objects.</param>
    /// <returns>A tuple containing the HCF Term and a List of the remaining terms inside the brackets.</returns>
    public static (Term Hcf, List<Term> RemainingTerms) FactorByCommonFactors(List<Term> terms)
    {
        if (terms == null || terms.Count == 0)
            return (new Term(1, new Dictionary<char, int>()), new List<Term>());

        // 1. Find HCF of the coefficients
        var termCoefficients = terms.Select(t => (int)t.Coefficient).ToArray();
        var hcfCoefficient = NumberTheory.GetHcf(termCoefficients);

        // 2. Find common variables and their lowest powers
        var hcfVariables = new Dictionary<char, int>();
        if (terms.Count > 0)
        {
            // Start with variables from the first term as potential common variables
            var potentialCommonVars = terms[0].Variables.Keys;

            foreach (var variable in potentialCommonVars)
            {
                // Check if this variable exists in ALL other terms
                if (terms.All(t => t.Variables.ContainsKey(variable)))
                {
                    // If it's common, find its lowest power across all terms
                    int lowestPower = terms.Min(t => t.Variables[variable]);
                    hcfVariables.Add(variable, lowestPower);
                }
            }
        }

        // 3. Build the final HCF term
        var hcfTerm = new Term(hcfCoefficient, hcfVariables);

        // 4. Divide each original term by the HCF to find what remains
        var remainingTerms = new List<Term>();
        foreach (var originalTerm in terms)
        {
            var remainingTerm = Term.Divide(originalTerm, hcfTerm);
            remainingTerms.Add(remainingTerm);
        }

        return (hcfTerm, remainingTerms);
    }
}