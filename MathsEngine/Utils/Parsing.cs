using MathsEngine.Modules.Pure.Algebra.General;
using MathsEngine.Modules.Pure.Trigonometry;

namespace MathsEngine.Utils;

public static class Parsing
{
    public static double? GetNullableDoubleInput(string prompt)
    {
        Console.Write(prompt);
        string? input = Console.ReadLine()?.Trim();

        if (string.IsNullOrEmpty(input))
            return null;

        if (double.TryParse(input, out double value))
            return value;

        throw new ArgumentException("Invalid number entered.");
    }

    public static double GetDoubleInput(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine()?.Trim();

            if (!string.IsNullOrEmpty(input) && double.TryParse(input, out double value))
                return value;

            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }

    public static int GetIntInput(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine()?.Trim();

            if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int value))
                return value;

            Console.WriteLine("Invalid input. Please enter a valid number");
        }
    }

    public static int GetMenuInput(string prompt, int maxNum)
    {
        while (true)
        {
            Console.Write(prompt);
            var input = Console.ReadLine()?.Trim();

            if (int.TryParse(input, out int value))
                if (value <= maxNum && value > 0)
                    return value;

            Console.WriteLine("Invalid input. Try again.");
        }
    }

    public static SideType GetSideType(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string? input = Console.ReadLine()?.Trim();

            if (input == "Hypotenuse" || input == "hypotenuse")
                return SideType.Hypotenuse;
            if (input == "Opposite" || input == "opposite")
                return SideType.Opposite;
            if (input == "Adjacent" || input == "adjacent")
                return SideType.Adjacent;
            Console.WriteLine("You have not entered a valid side. Try Again");
        }
    }

    public static List<double> GetDoubleList(string prompt)
    {
        Console.WriteLine(prompt);
        string? input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input)) return new List<double>();
        return input.Split(',').Select(s => double.Parse(s.Trim())).ToList();
    }

    public static List<int> GetIntList(string prompt)
    {
        Console.WriteLine(prompt);
        string? input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input)) return new List<int>();
        return input.Split(',').Select(s => int.Parse(s.Trim())).ToList();
    }

    public static List<string> GetStringList(string prompt)
    {
        Console.WriteLine(prompt);
        string? input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input)) return new List<string>();
        return input.Split(',').Select(s => s.Trim()).ToList();
    }

    /// <summary>
    /// Parses a string representation of an algebraic term into a Term object.
    /// Handles coefficients, variables and powers e.g. "12x^2y", "-z", "15".
    /// </summary>
    /// <param name="prompt"> The output for user to respond to.</param>
    /// <returns> A new Term object.</returns>
    public static Term ParseTerm(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(input))
            {
                ErrorDisplay.ShowError("Input cannot be empty.");
                continue;
            }

            try
            {
                int i = 0;
                int originalLength = input.Length;

                // 1. Parse the Coefficient
                string coefficientString = "";
                if (i < input.Length && (input[i] == '+' || input[i] == '-'))
                {
                    coefficientString += input[i];
                    i++;
                }
                while (i < input.Length && (char.IsDigit(input[i]) || input[i] == '.'))
                {
                    coefficientString += input[i];
                    i++;
                }

                int  coefficient;
                if (coefficientString == "" || coefficientString == "+") coefficient = 1;
                else if (coefficientString == "-") coefficient = -1;
                else if (!int.TryParse(coefficientString, out coefficient))
                {
                    throw new FormatException($"Invalid coefficient format: '{coefficientString}'.");
                }

                // 2. Parse variables and powers
                var variables = new Dictionary<char, int>();
                while (i < input.Length)
                {
                    if (!char.IsLetter(input[i]))
                    {
                        throw new FormatException($"Unexpected character '{input[i]}' found. Expected a variable.");
                    }
                    char variable = input[i];
                    i++;

                    int power = 1;
                    if (i < input.Length && input[i] == '^')
                    {
                        i++; // Move past '^'
                        string powerString = "";
                        if (i < input.Length && input[i] == '-')
                        {
                            powerString += input[i];
                            i++;
                        }
                        while (i < input.Length && (char.IsDigit(input[i]) || input[i] == '.'))
                        {
                            powerString += input[i];
                            i++;
                        }

                        if (string.IsNullOrEmpty(powerString) || !int.TryParse(powerString, out power))
                        {
                            throw new FormatException($"Invalid power format for variable '{variable}'.");
                        }
                    }

                    if (variables.ContainsKey(variable))
                    {
                        variables[variable] += power;
                    }
                    else
                    {
                        variables.Add(variable, power);
                    }
                }

                // 3. Final validation: Ensure all characters were parsed
                if (i != originalLength)
                {
                    throw new FormatException("Term contains invalid characters at the end.");
                }

                return new Term(coefficient, variables);
            }
            catch (Exception e)
            {
                ErrorDisplay.ShowError(e.Message);
                Console.WriteLine("   Please try again.");
            }
        }
    }
}