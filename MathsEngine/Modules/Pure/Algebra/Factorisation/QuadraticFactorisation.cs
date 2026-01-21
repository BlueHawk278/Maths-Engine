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

        // Special case: perfect square trinomial (only when a > 0)
        // a²x² + 2abx + b² = (ax + b)²
        if (a > 0)
        {
            int sqrtA = (int)Math.Sqrt(a);
            if (sqrtA * sqrtA == a)
            {
                int sqrtC = (int)Math.Sqrt(Math.Abs(c));
                if (sqrtC * sqrtC == Math.Abs(c))
                {
                    if (sqrtA != 0 && sqrtC != 0 && (b == 2 * sqrtA * sqrtC || b == -2 * sqrtA * sqrtC))
                    {
                        int sign = b / (2 * sqrtA * sqrtC);
                        return (sqrtA, sign * sqrtC, sqrtA, sign * sqrtC);
                    }
                }
            }
        }

        // Try direct factorisation approach
        // For each divisor pair (p, q) where p*q = a
        for (int p = 1; p <= Math.Abs(a); p++)
        {
            if (a % p != 0) continue;
            int q = a / p;
            
            // Ensure correct sign for negative a
            if (a < 0)
            {
                q = -q;
            }
            
            // Get divisors of c
            int absC = Math.Abs(c);
            for (int absR = 1; absR <= absC; absR++)
            {
                if (absC % absR != 0) continue;
                int absS = absC / absR;
                
                // Try both positive and negative combinations
                foreach (int signR in new[] { 1, -1 })
                {
                    int r = signR * absR;
                    
                    foreach (int signS in new[] { 1, -1 })
                    {
                        int s = signS * absS;
                        
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
