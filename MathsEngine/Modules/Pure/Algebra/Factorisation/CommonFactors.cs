namespace MathsEngine.Modules.Pure.Algebra.Factorisation;

/// <summary>
/// Provides methods for finding common factors
/// </summary>
public static class CommonFactors
{
    /// <summary>
    /// Finds the Greatest Common Factor (GCF) of two integers
    /// </summary>
    /// <param name="a">First integer</param>
    /// <param name="b">Second integer</param>
    /// <returns>The greatest common factor</returns>
    public static int FindGcf(int a, int b)
    {
        a = Math.Abs(a);
        b = Math.Abs(b);

        if (a == 0) return b;
        if (b == 0) return a;

        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }

    /// <summary>
    /// Finds the Greatest Common Factor (GCF) of multiple integers
    /// </summary>
    /// <param name="numbers">Array of integers</param>
    /// <returns>The greatest common factor of all numbers</returns>
    /// <exception cref="ArgumentException">Thrown when array is null or empty</exception>
    public static int FindGcf(params int[] numbers)
    {
        if (numbers == null || numbers.Length == 0)
            throw new ArgumentException("At least one number is required");

        if (numbers.Length == 1)
            return Math.Abs(numbers[0]);

        int result = Math.Abs(numbers[0]);
        for (int i = 1; i < numbers.Length; i++)
        {
            result = FindGcf(result, Math.Abs(numbers[i]));
            if (result == 1)
                return 1;
        }

        return result;
    }

    /// <summary>
    /// Factors out the greatest common factor from an array of coefficients
    /// </summary>
    /// <param name="coefficients">Array of coefficients</param>
    /// <returns>Tuple containing the GCF and the factored coefficients</returns>
    public static (int Gcf, int[] Factored) FactorOut(params int[] coefficients)
    {
        if (coefficients == null || coefficients.Length == 0)
            throw new ArgumentException("At least one coefficient is required");

        int gcf = FindGcf(coefficients);
        int[] factored = new int[coefficients.Length];

        for (int i = 0; i < coefficients.Length; i++)
        {
            factored[i] = coefficients[i] / gcf;
        }

        return (gcf, factored);
    }
}
