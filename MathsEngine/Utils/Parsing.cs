using MathsEngine.Modules.Pure.Trigonometry;

namespace MathsEngine.Utils;

public class Parsing
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
                
            Console.WriteLine("Invalid input. Try again");
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
                
            Console.WriteLine("Invalid input. Try again");
        }
    }

    public static int GetMenuInput(string prompt, int maxNum, int minNum = 1)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine()?.Trim();

            if (int.TryParse(input, out int value) && value >= minNum && value <= maxNum)
                return value;

            Console.WriteLine($"Invalid input. Please enter a number between {minNum} and {maxNum}.");
        }
    }

    public static SideType GetSideType(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string? input = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(input))
            {
                Console.WriteLine("Input cannot be empty. Try again.");
                continue;
            }

            if (input.Equals("Hypotenuse", StringComparison.OrdinalIgnoreCase))
                return SideType.Hypotenuse;
            if (input.Equals("Opposite", StringComparison.OrdinalIgnoreCase))
                return SideType.Opposite;
            if (input.Equals("Adjacent", StringComparison.OrdinalIgnoreCase))
                return SideType.Adjacent;
                
            Console.WriteLine("You have not entered a valid side. Try Again");
        }
    }
}