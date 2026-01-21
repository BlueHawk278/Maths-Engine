namespace MathsEngine.Modules.Pure.Algebra.Factorisation;

/// <summary>
/// Provides methods for factorising difference of two squares (a² - b²)
/// </summary>
public static class DifferenceOfSquares
{
    /// <summary>
    /// Checks if a number is a perfect square
    /// </summary>
    /// <param name="n">The number to check</param>
    /// <returns>True if the number is a perfect square, false otherwise</returns>
    public static bool IsPerfectSquare(int n)
    {
        if (n < 0) return false;
        
        int sqrt = (int)Math.Sqrt(n);
        return sqrt * sqrt == n;
    }

    /// <summary>
    /// Checks if an expression ax² + bx + c is a difference of two squares (b must be 0, a and c must be perfect squares with opposite signs)
    /// </summary>
    /// <param name="a">Coefficient of x²</param>
    /// <param name="b">Coefficient of x</param>
    /// <param name="c">Constant term</param>
    /// <returns>True if the expression is a difference of two squares</returns>
    public static bool IsDifferenceOfSquares(int a, int b, int c)
    {
        // Must have no middle term (b = 0)
        if (b != 0) return false;

        // Must have opposite signs
        if (a * c >= 0) return false;

        // Both coefficients must be perfect squares
        return IsPerfectSquare(Math.Abs(a)) && IsPerfectSquare(Math.Abs(c));
    }

    /// <summary>
    /// Factorises a difference of two squares expression ax² - c (where a > 0 and c > 0)
    /// Returns the factors as (coefficient1, constant1, coefficient2, constant2)
    /// representing (coefficient1·x + constant1)(coefficient2·x + constant2)
    /// </summary>
    /// <param name="a">Coefficient of x² (must be positive perfect square)</param>
    /// <param name="c">Constant term (must be negative, representing -c where c is positive)</param>
    /// <returns>Tuple of (coeff1, const1, coeff2, const2) representing the factors</returns>
    /// <exception cref="ArgumentException">Thrown when expression is not a difference of squares</exception>
    public static (int Coeff1, int Const1, int Coeff2, int Const2) Factorise(int a, int c)
    {
        if (!IsDifferenceOfSquares(a, 0, c))
            throw new ArgumentException("Expression is not a difference of two squares");

        if (a < 0 || c >= 0)
            throw new ArgumentException("For difference of squares, 'a' must be positive and 'c' must be negative");

        int sqrtA = (int)Math.Sqrt(a);
        int sqrtC = (int)Math.Sqrt(-c);  // c is negative, so -c is positive

        // For ax² - c where a > 0, c < 0 (so -c > 0)
        // ax² - c = (√a·x)² - (√(-c))² = (√a·x + √(-c))(√a·x - √(-c))
        return (sqrtA, sqrtC, sqrtA, -sqrtC);
    }
}
