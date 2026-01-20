using System;

namespace MathsEngine.Modules.Pure.Algebra
{
    /// <summary>
    /// Represents an immutable fraction with integer numerator and denominator.
    /// </summary>
    public readonly struct Fraction : IEquatable<Fraction>
    {
        /// <summary>
        /// The numerator of the fraction.
        /// </summary>
        public int Numerator { get; }

        /// <summary>
        /// The denominator of the fraction.
        /// </summary>
        public int Denominator { get; }

        /// <summary>
        /// Initializes a new instance of the Fraction struct.
        /// </summary>
        /// <param name="numerator">The numerator.</param>
        /// <param name="denominator">The denominator (cannot be zero).</param>
        /// <exception cref="ZeroDenominatorException">Thrown when denominator is zero.</exception>
        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ZeroDenominatorException();

            // Normalize: keep denominator positive
            if (denominator < 0)
            {
                numerator = -numerator;
                denominator = -denominator;
            }

            Numerator = numerator;
            Denominator = denominator;
        }

        /// <summary>
        /// Converts the fraction to a decimal representation.
        /// </summary>
        /// <returns>The decimal value (approximation for repeating decimals).</returns>
        public double ToDecimal() => (double)Numerator / Denominator;

        /// <summary>
        /// Returns a string representation of the fraction.
        /// </summary>
        /// <returns>String in "numerator/denominator" format.</returns>
        public override string ToString() => $"{Numerator}/{Denominator}";

        /// <summary>
        /// Determines whether the specified fraction is equal to the current fraction.
        /// </summary>
        public bool Equals(Fraction other) => 
            Numerator == other.Numerator && Denominator == other.Denominator;

        /// <summary>
        /// Determines whether the specified object is equal to the current fraction.
        /// </summary>
        public override bool Equals(object? obj) => 
            obj is Fraction other && Equals(other);

        /// <summary>
        /// Returns the hash code for this fraction.
        /// </summary>
        public override int GetHashCode() => HashCode.Combine(Numerator, Denominator);

        public static bool operator ==(Fraction left, Fraction right) => left.Equals(right);
        public static bool operator !=(Fraction left, Fraction right) => !left.Equals(right);
    }

    /// <summary>
    /// Provides static methods for fraction operations and simplification.
    /// </summary>
    /// <remarks>
    /// This class demonstrates foundational fraction arithmetic that maintains exact rational values.
    /// These operations are essential for algebraic manipulations and serve as building blocks
    /// for more complex operations like partial fraction decomposition (used in integration).
    /// </remarks>
    public static class FractionSimplifier
    {
        /// <summary>
        /// Simplifies a fraction to its lowest terms using the Greatest Common Divisor.
        /// </summary>
        /// <param name="numerator">The numerator of the fraction.</param>
        /// <param name="denominator">The denominator of the fraction.</param>
        /// <returns>A simplified fraction.</returns>
        /// <exception cref="ZeroDenominatorException">Thrown when denominator is zero.</exception>
        /// <example>
        /// <code>
        /// var result = FractionSimplifier.Simplify(8, 12);
        /// // Returns Fraction { Numerator = 2, Denominator = 3 }
        /// </code>
        /// </example>
        public static Fraction Simplify(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ZeroDenominatorException();

            // Find GCD and simplify
            int gcd = GreatestCommonDivisor(Math.Abs(numerator), Math.Abs(denominator));
            return new Fraction(numerator / gcd, denominator / gcd);
        }

        /// <summary>
        /// Adds two fractions and returns the result in simplified form.
        /// </summary>
        /// <param name="a">First fraction.</param>
        /// <param name="b">Second fraction.</param>
        /// <returns>The sum of the two fractions, simplified.</returns>
        /// <example>
        /// <code>
        /// var a = new Fraction(1, 2);  // 1/2
        /// var b = new Fraction(1, 3);  // 1/3
        /// var sum = FractionSimplifier.Add(a, b);
        /// // Returns 5/6
        /// </code>
        /// </example>
        public static Fraction Add(Fraction a, Fraction b)
        {
            // a/b + c/d = (ad + bc) / bd
            long numerator = (long)a.Numerator * b.Denominator + (long)b.Numerator * a.Denominator;
            long denominator = (long)a.Denominator * b.Denominator;

            // Check for overflow
            if (numerator > int.MaxValue || numerator < int.MinValue ||
                denominator > int.MaxValue || denominator < int.MinValue)
                throw new FractionOverflowException();

            return Simplify((int)numerator, (int)denominator);
        }

        /// <summary>
        /// Subtracts the second fraction from the first and returns the result in simplified form.
        /// </summary>
        /// <param name="a">First fraction.</param>
        /// <param name="b">Second fraction.</param>
        /// <returns>The difference of the two fractions, simplified.</returns>
        /// <example>
        /// <code>
        /// var a = new Fraction(3, 4);  // 3/4
        /// var b = new Fraction(1, 2);  // 1/2
        /// var diff = FractionSimplifier.Subtract(a, b);
        /// // Returns 1/4
        /// </code>
        /// </example>
        public static Fraction Subtract(Fraction a, Fraction b)
        {
            // a/b - c/d = (ad - bc) / bd
            long numerator = (long)a.Numerator * b.Denominator - (long)b.Numerator * a.Denominator;
            long denominator = (long)a.Denominator * b.Denominator;

            // Check for overflow
            if (numerator > int.MaxValue || numerator < int.MinValue ||
                denominator > int.MaxValue || denominator < int.MinValue)
                throw new FractionOverflowException();

            return Simplify((int)numerator, (int)denominator);
        }

        /// <summary>
        /// Multiplies two fractions and returns the result in simplified form.
        /// </summary>
        /// <param name="a">First fraction.</param>
        /// <param name="b">Second fraction.</param>
        /// <returns>The product of the two fractions, simplified.</returns>
        /// <example>
        /// <code>
        /// var a = new Fraction(2, 3);  // 2/3
        /// var b = new Fraction(3, 4);  // 3/4
        /// var product = FractionSimplifier.Multiply(a, b);
        /// // Returns 1/2
        /// </code>
        /// </example>
        public static Fraction Multiply(Fraction a, Fraction b)
        {
            // (a/b) * (c/d) = (ac) / (bd)
            long numerator = (long)a.Numerator * b.Numerator;
            long denominator = (long)a.Denominator * b.Denominator;

            // Check for overflow
            if (numerator > int.MaxValue || numerator < int.MinValue ||
                denominator > int.MaxValue || denominator < int.MinValue)
                throw new FractionOverflowException();

            return Simplify((int)numerator, (int)denominator);
        }

        /// <summary>
        /// Divides the first fraction by the second and returns the result in simplified form.
        /// </summary>
        /// <param name="a">Dividend fraction.</param>
        /// <param name="b">Divisor fraction.</param>
        /// <returns>The quotient of the two fractions, simplified.</returns>
        /// <exception cref="ZeroDenominatorException">Thrown when dividing by a fraction with zero numerator.</exception>
        /// <example>
        /// <code>
        /// var a = new Fraction(3, 4);  // 3/4
        /// var b = new Fraction(2, 3);  // 2/3
        /// var quotient = FractionSimplifier.Divide(a, b);
        /// // Returns 9/8
        /// </code>
        /// </example>
        public static Fraction Divide(Fraction a, Fraction b)
        {
            if (b.Numerator == 0)
                throw new ZeroDenominatorException("Cannot divide by a fraction with numerator of zero");

            // (a/b) / (c/d) = (a/b) * (d/c) = (ad) / (bc)
            long numerator = (long)a.Numerator * b.Denominator;
            long denominator = (long)a.Denominator * b.Numerator;

            // Check for overflow
            if (numerator > int.MaxValue || numerator < int.MinValue ||
                denominator > int.MaxValue || denominator < int.MinValue)
                throw new FractionOverflowException();

            return Simplify((int)numerator, (int)denominator);
        }

        /// <summary>
        /// Calculates the Greatest Common Divisor using Euclid's algorithm.
        /// </summary>
        /// <param name="a">First integer.</param>
        /// <param name="b">Second integer.</param>
        /// <returns>The GCD of a and b.</returns>
        /// <remarks>
        /// This is the foundation of fraction simplification. The Euclidean algorithm
        /// is one of the oldest algorithms still in common use (circa 300 BC).
        /// </remarks>
        private static int GreatestCommonDivisor(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }

        /// <summary>
        /// Converts a decimal to an approximate fraction.
        /// </summary>
        /// <param name="value">The decimal value to convert.</param>
        /// <param name="maxDenominator">Maximum allowed denominator (default: 10000).</param>
        /// <returns>An approximate fraction representation.</returns>
        /// <remarks>
        /// This uses a continued fraction algorithm for best approximation.
        /// Note: For repeating decimals, this provides an approximation, not exact value.
        /// </remarks>
        /// <example>
        /// <code>
        /// var fraction = FractionSimplifier.FromDecimal(0.75);
        /// // Returns 3/4
        /// 
        /// var fraction2 = FractionSimplifier.FromDecimal(0.333333);
        /// // Returns approximately 1/3
        /// </code>
        /// </example>
        public static Fraction FromDecimal(double value, int maxDenominator = 10000)
        {
            // Handle whole numbers
            if (Math.Abs(value % 1) < 1e-9)
                return new Fraction((int)Math.Round(value), 1);

            // Extract sign
            int sign = value < 0 ? -1 : 1;
            value = Math.Abs(value);

            // Continued fraction algorithm
            int numerator = 0, denominator = 1;
            int previousNumerator = 1, previousDenominator = 0;

            while (denominator <= maxDenominator)
            {
                int digit = (int)value;
                
                int tempNumerator = numerator;
                int tempDenominator = denominator;

                numerator = digit * numerator + previousNumerator;
                denominator = digit * denominator + previousDenominator;

                previousNumerator = tempNumerator;
                previousDenominator = tempDenominator;

                // Check if we've found a good enough approximation
                double approximation = (double)numerator / denominator;
                if (Math.Abs(approximation - value) < 1e-9)
                    break;

                // Get the fractional part and continue
                value = value - digit;
                if (value < 1e-9)
                    break;
                value = 1.0 / value;
            }

            return new Fraction(sign * numerator, denominator);
        }

        // TODO: Future enhancements for calculus integration
        // - Partial fraction decomposition (for integration of rational functions)
        // - Mixed number conversion
        // - Continued fraction representation
        // - Egyptian fraction representation
    }
}
