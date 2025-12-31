using MathsEngine.Modules.Pure.Trigonometry;

namespace MathsEngine.Utils;

public class Parsing
{
    public static double? GetNullableDoubleInput(string prompt)
    {
        Console.Write(prompt);
        string input = Console.ReadLine()?.Trim();

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
            string input = Console.ReadLine()?.Trim();

            if (!string.IsNullOrEmpty(input))
                return Convert.ToDouble(input);
            Console.WriteLine("Invalid input. Try again");
        }
    }

    public static int GetIntInput(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine()?.Trim();

            if (!string.IsNullOrEmpty(input))
                return Convert.ToInt32(input);
            Console.WriteLine("Invalid input. Try again");
        }
    }

    public static int GetMenuInput(string prompt, int maxNum)
    {
        while (true)
        {
            Console.Write(prompt);
            var input = Console.ReadLine()?.Trim();

            if (int.TryParse(input, out int value))
                if(value <= maxNum)
                    return value;

            Console.WriteLine("Invalid input. Try again.");
        }
    }

    public static SideType GetSideType(string prompt)
    {
        while (true)
        {
            Console.WriteLine(prompt);
            string input = Console.ReadLine()?.Trim();

            if (input == "Hypotenuse" || input == "hypotenuse")
                return SideType.Hypotenuse;
            if (input == "Opposite" || input == "opposite")
                return SideType.Opposite;
            if (input == "Adjacent" || input == "adjacent")
                return SideType.Adjacent;
            Console.WriteLine("You have not entered a valid side. Try Again");
        }
    }
}