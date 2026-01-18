namespace MathsEngine.Utils;

public static class ErrorDisplay
{
    public static void ShowError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"\nError: {message}");
        Console.ResetColor();
    }

    public static void ShowValidationError()
    {
        ShowError("Invalid input. Please enter valid numbers.");
    }
}