using MathsEngine.Modules.Pure.Algebra.Factorisation;
using MathsEngine.Modules.Pure.Algebra.General;
using MathsEngine.Utils;
using System.Linq;
using System.Text;

namespace MathsEngine.Menu.Pure.Algebra;

public class FactorisationMenu
{
    public static void Menu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Algebra - Factorisation");
            Console.WriteLine("1. Common factors");
            Console.WriteLine("2. Grouping (4-terms)");
            Console.WriteLine("3. Difference of two squares");
            Console.WriteLine("4. Quadratic factorisation (ax^2 + bx + c)");
            Console.WriteLine("5. Back");
            int response = Parsing.GetMenuInput("Input: ", 5);

            switch (response)
            {
                case 1:
                    HandleCommonFactors();
                    break;
                case 5: return;
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    private static void HandleCommonFactors()
    {
        int termCount = Parsing.GetIntInput("How many terms do you want to find the common factor for? ");
        if (termCount < 2)
        {
            ErrorDisplay.ShowError("You need at least two terms to find a common factor.");
            return;
        }

        var terms = new List<Term>();
        for (int i = 0; i < termCount; i++)
        {
            while (true)
            {
                try
                {
                    string prompt = $"Enter term #{i + 1} (e.g., 12x^2y): ";
                    var term = Parsing.ParseTerm(prompt);
                    terms.Add(term);
                    Console.WriteLine($"  -> Parsed as: {term}"); // Give user feedback
                    break; // Exit the inner while loop on success
                }
                catch (Exception ex)
                {
                    ErrorDisplay.ShowError(ex.Message);
                    Console.WriteLine("   Please try again.");
                }
            }
        }

        // Call the calculator to get the HCF and the remaining terms
        var (hcf, remainingTerms) = FactorisationCalculator.FactorByCommonFactors(terms);

        // Build the final output string
        var builder = new StringBuilder();
        // Only show the HCF if it's not just '1'
        if (hcf.Coefficient != 1 || hcf.Variables.Any())
        {
            builder.Append(hcf.ToString());
        }
        builder.Append('(');
        for (int i = 0; i < remainingTerms.Count; i++)
        {
            var term = remainingTerms[i];
            string termStr = term.ToString();

            // Add a '+' sign for positive terms after the first one
            if (i > 0 && term.Coefficient > 0)
            {
                builder.Append(" + ");
            }
            // Add a space before negative terms (that aren't the first term)
            else if (i > 0)
            {
                builder.Append(" ");
            }
            builder.Append(termStr);
        }
        builder.Append(')');

        Console.WriteLine($"\nFactorised Expression: {builder.ToString()}");
    }
}