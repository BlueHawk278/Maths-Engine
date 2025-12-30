namespace MathsEngine.Utils;

public class Display
{
    public static void DisplayResult(Dictionary<string, double?> ResultDict)
    {
        foreach(KeyValuePair<string, double?> kvp in ResultDict)
            Console.WriteLine($"{kvp.Key}: {FormatValue(kvp.Value)}");
    }

    private static string FormatValue(double? value)
    {
        Console.WriteLine("#----- Calculation Result -----#");
        if (value == null)
            return "Not Calculated";

        return value.Value.ToString("F2");
    }
}