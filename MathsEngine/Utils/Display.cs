using static MathsEngine.Utils.MathConstants;
using static MathsEngine.Utils.DisplayConstants;

namespace MathsEngine.Utils;

public class Display
{
    public static void DisplayResult(Dictionary<string, double?> ResultDict)
    {
        Console.WriteLine(RESULT_HEADER);
        foreach (KeyValuePair<string, double?> kvp in ResultDict)
            Console.WriteLine($"{kvp.Key}: {FormatValue(kvp.Value)}");
    }

    private static string FormatValue(double? value)
    {
        if (value == null)
            return "Not Calculated";

        return value.Value.ToString($"F{DEFAULT_DECIMAL_PLACES}");
    }
}