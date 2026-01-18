namespace MathsEngine.Utils
{
    /// <summary>
    /// Utility class for displaying error messages to the console with consistent formatting.
    /// </summary>
    public static class ErrorDisplay
    {
        /// <summary>
        /// Displays an error message in red text.
        /// </summary>
        /// <param name="message">The error message to display.</param>
        public static void ShowError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\nError: {message}");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays a standard validation error message.
        /// </summary>
        public static void ShowValidationError()
        {
            ShowError("Invalid input. Please enter valid numbers.");
        }

        /// <summary>
        /// Displays an error message for invalid numeric input.
        /// </summary>
        public static void ShowInvalidNumberError()
        {
            ShowError("Invalid input. Please enter valid numbers for the side lengths.");
        }

        /// <summary>
        /// Displays a success message in green text.
        /// </summary>
        /// <param name="message">The success message to display.</param>
        public static void ShowSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n{message}");
            Console.ResetColor();
        }

        /// <summary>
        /// Displays an information message in cyan text.
        /// </summary>
        /// <param name="message">The information message to display.</param>
        public static void ShowInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\n{message}");
            Console.ResetColor();
        }
    }
}
