namespace MathsEngine.Modules.Pure.Algebra.Factorisation;

/// <summary>
/// Provides methods for factorising quadratic expressions (ax² + bx + c)
/// </summary>
public static class QuadraticFactorisation
{
    /// <summary>
    /// Attempts to factorise a quadratic expression ax² + bx + c into two binomial factors
    /// Returns null if the expression cannot be factorised using integers
    /// </summary>
    /// <param name="a">Coefficient of x²</param>
    /// <param name="b">Coefficient of x</param>
    /// <param name="c">Constant term</param>
    /// <returns>Tuple of (coeff1, const1, coeff2, const2) representing (coeff1·x + const1)(coeff2·x + const2), or null if not factorisable</returns>
    public static (int Coeff1, int Const1, int Coeff2, int Const2)? Factorise(int a, int b, int c)
    {
        if (a == 0)
            throw new ArgumentException("Coefficient 'a' cannot be zero for a quadratic expression");

        // Special case: perfect square trinomial
        // a²x² + 2abx + b² = (ax + b)²
        int sqrtA = (int)Math.Sqrt(Math.Abs(a));
        if (sqrtA * sqrtA == Math.Abs(a))
        {
            int sqrtC = (int)Math.Sqrt(Math.Abs(c));
            if (sqrtC * sqrtC == Math.Abs(c))
            {
                if (b == 2 * sqrtA * sqrtC || b == -2 * sqrtA * sqrtC)
                {
                    int sign = b / (2 * sqrtA * sqrtC);
                    return (sqrtA, sign * sqrtC, sqrtA, sign * sqrtC);
                }
            }
        }

        // Try to find factors using the AC method
        // We need to find two numbers that multiply to a*c and add to b
        int ac = a * c;
        
        // Find all factor pairs of ac
        for (int i = -Math.Abs(ac); i <= Math.Abs(ac); i++)
        {
            if (i == 0) continue;
            if (ac % i != 0) continue;
            
            int j = ac / i;
            
            // Check if i + j = b
            if (i + j == b)
            {
                // Found the pair! Now we can factorise
                // ax² + bx + c = ax² + ix + jx + c
                // Group: (ax² + ix) + (jx + c)
                // Factor each group and find the common binomial
                
                // Using the formula for factoring ax² + bx + c
                // where we found i and j such that i*j = a*c and i + j = b
                
                // Try direct factorisation approach
                // For each divisor pair (p, q) where p*q = a
                for (int p = 1; p <= Math.Abs(a); p++)
                {
                    if (a % p != 0) continue;
                    int q = a / p;
                    
                    // For each divisor pair (r, s) where r*s = c
                    for (int r = -Math.Abs(c); r <= Math.Abs(c); r++)
                    {
                        if (r == 0) continue;
                        if (c % r != 0) continue;
                        int s = c / r;
                        
                        // Check if (px + r)(qx + s) = ax² + bx + c
                        // Expanding: pqx² + psx + qrx + rs
                        //          = pqx² + (ps + qr)x + rs
                        if (p * q == a && r * s == c && p * s + q * r == b)
                        {
                            return (p, r, q, s);
                        }
                    }
                }
            }
        }

        // Cannot be factorised with integer coefficients
        return null;
    }

    /// <summary>
    /// Checks if a quadratic expression can be factorised using integer coefficients
    /// </summary>
    /// <param name="a">Coefficient of x²</param>
    /// <param name="b">Coefficient of x</param>
    /// <param name="c">Constant term</param>
    /// <returns>True if the expression can be factorised with integers</returns>
    public static bool IsFactorisable(int a, int b, int c)
    {
        return Factorise(a, b, c) != null;
    }

    /// <summary>
    /// Calculates the discriminant of a quadratic expression (b² - 4ac)
    /// </summary>
    /// <param name="a">Coefficient of x²</param>
    /// <param name="b">Coefficient of x</param>
    /// <param name="c">Constant term</param>
    /// <returns>The discriminant value</returns>
    public static int CalculateDiscriminant(int a, int b, int c)
    {
        return b * b - 4 * a * c;
    }
}
