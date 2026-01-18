namespace MathsEngine.Utils
{
    /// <summary>
    /// Mathematical constants used throughout the application.
    /// </summary>
    public static class MathConstants
    {
        /// <summary>
        /// Tolerance for floating-point equality comparisons.
        /// </summary>
        public const double EQUALITY_TOLERANCE = 1e-9;

        /// <summary>
        /// Default number of decimal places for display.
        /// </summary>
        public const int DEFAULT_DECIMAL_PLACES = 2;

        /// <summary>
        /// Maximum decimal places for precise calculations.
        /// </summary>
        public const int MAX_DECIMAL_PLACES = 6;
    }

    /// <summary>
    /// Menu configuration constants.
    /// </summary>
    public static class MenuConstants
    {
        public const int MAIN_MENU_OPTIONS = 4;
        public const int PURE_MENU_OPTIONS = 5;
        public const int MECHANICS_MENU_OPTIONS = 3;
        public const int STATISTICS_MENU_OPTIONS = 3;
        public const int PYTHAGORAS_MENU_OPTIONS = 4;
    }

    /// <summary>
    /// Input validation constants.
    /// </summary>
    public static class ValidationConstants
    {
        /// <summary>
        /// Maximum length for user input strings.
        /// </summary>
        public const int MAX_INPUT_LENGTH = 100;

        /// <summary>
        /// Maximum size for arrays/matrices to prevent memory issues.
        /// </summary>
        public const int MAX_ARRAY_SIZE = 10000;
    }

    /// <summary>
    /// Display formatting constants.
    /// </summary>
    public static class DisplayConstants
    {
        public const string MENU_SEPARATOR = "====================";
        public const string RESULT_HEADER = "#----- Calculation Result -----#";
    }
}
