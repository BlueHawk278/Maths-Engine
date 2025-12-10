using System;
using System.Globalization;

namespace MathsEngine.Modules.Mechanics.UniformAcceleration
{
    public class UniformAcceleration
    {
        public static void Start()
        {

        }

        public static void displayCalculation(string u, string v, string a, string t, string s)
        {
            Console.WriteLine("--- Calculation results ---");
            Console.WriteLine($"Initial Velocity (u): {FormatValue(u)}");
            Console.WriteLine($"Final Velocity (v): {FormatValue(v)}");
            Console.WriteLine($"Acceleration (a): {FormatValue(a)}");
            Console.WriteLine($"Time (t): {FormatValue(t)}");
            Console.WriteLine($"Displacement (s): {FormatValue(s)}");
        }

        private static string FormatValue(string value)
        {
            if (value == null)
                return "Not Calculated";

            // Convert to double to format it to 2 decimal places.
            return Convert.ToDouble(value).ToString("F2");
        }
    }
}