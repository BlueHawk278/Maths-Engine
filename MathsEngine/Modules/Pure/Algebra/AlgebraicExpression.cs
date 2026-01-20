using System;
using System.Collections.Generic;
using System.Linq;

namespace MathsEngine.Modules.Pure.Algebra
{
    /// <summary>
    /// Represents a term in an algebraic expression, e.g., 3x² (coefficient=3, variable='x', power=2)
    /// </summary>
    public class Term
    {
        /// <summary>
        /// The coefficient of the term.
        /// </summary>
        public double Coefficient { get; set; }

        /// <summary>
        /// The variable symbol (e.g., 'x', 'y', 't').
        /// </summary>
        public char Variable { get; set; }

        /// <summary>
        /// The power/exponent of the variable.
        /// </summary>
        public int Power { get; set; }

        /// <summary>
        /// Indicates if this is a constant term (no variable).
        /// </summary>
        public bool IsConstant => Power == 0;

        public Term(double coefficient, char variable = 'x', int power = 1)
        {
            Coefficient = coefficient;
            Variable = variable;
            Power = power;
        }

        /// <summary>
        /// Evaluates the term at a given value.
        /// </summary>
        public double Evaluate(double value)
        {
            return Coefficient * Math.Pow(value, Power);
        }

        /// <summary>
        /// Creates a copy of this term.
        /// </summary>
        public Term Clone() => new Term(Coefficient, Variable, Power);

        public override string ToString()
        {
            if (Math.Abs(Coefficient) < 1e-9)
                return "0";

            if (IsConstant)
                return Coefficient.ToString();

            string coeffStr = Math.Abs(Coefficient - 1) < 1e-9 ? "" :
                             Math.Abs(Coefficient + 1) < 1e-9 ? "-" :
                             Coefficient.ToString();

            if (Power == 1)
                return $"{coeffStr}{Variable}";

            return $"{coeffStr}{Variable}^{Power}";
        }
    }

    /// <summary>
    /// Represents an algebraic expression as a collection of terms.
    /// This serves as the foundation for symbolic differentiation and integration.
    /// </summary>
    /// <remarks>
    /// This class provides the infrastructure for calculus operations:
    /// 
    /// DIFFERENTIATION:
    /// - Power Rule: d/dx[x^n] = n*x^(n-1)
    /// - Constant Rule: d/dx[c] = 0
    /// - Sum Rule: d/dx[f + g] = f' + g'
    /// 
    /// INTEGRATION:
    /// - Power Rule: ∫x^n dx = x^(n+1)/(n+1) + C (n ≠ -1)
    /// - Constant Rule: ∫c dx = cx + C
    /// - Sum Rule: ∫(f + g) dx = ∫f dx + ∫g dx
    /// 
    /// Future extensions will support:
    /// - Product rule, quotient rule, chain rule (differentiation)
    /// - Substitution, integration by parts (integration)
    /// - Partial fractions (rational function integration)
    /// - Taylor series expansion
    /// </remarks>
    public class AlgebraicExpression
    {
        /// <summary>
        /// The terms that make up this expression.
        /// </summary>
        private List<Term> Terms { get; set; }

        /// <summary>
        /// The primary variable used in this expression.
        /// </summary>
        public char Variable { get; set; }

        /// <summary>
        /// Creates an empty algebraic expression.
        /// </summary>
        public AlgebraicExpression(char variable = 'x')
        {
            Terms = new List<Term>();
            Variable = variable;
        }

        /// <summary>
        /// Creates an algebraic expression from a list of terms.
        /// </summary>
        public AlgebraicExpression(List<Term> terms, char variable = 'x')
        {
            Terms = terms ?? new List<Term>();
            Variable = variable;
        }

        /// <summary>
        /// Adds a term to the expression.
        /// </summary>
        public void AddTerm(double coefficient, int power)
        {
            Terms.Add(new Term(coefficient, Variable, power));
        }

        /// <summary>
        /// Adds a term to the expression.
        /// </summary>
        public void AddTerm(Term term)
        {
            Terms.Add(term);
        }

        /// <summary>
        /// Simplifies the expression by combining like terms.
        /// </summary>
        /// <returns>A new simplified expression.</returns>
        /// <example>
        /// <code>
        /// // Expression: 3x² + 2x + x² - x
        /// var expr = new AlgebraicExpression();
        /// expr.AddTerm(3, 2);  // 3x²
        /// expr.AddTerm(2, 1);  // 2x
        /// expr.AddTerm(1, 2);  // x²
        /// expr.AddTerm(-1, 1); // -x
        /// 
        /// var simplified = expr.Simplify();
        /// // Result: 4x² + x
        /// </code>
        /// </example>
        public AlgebraicExpression Simplify()
        {
            var simplified = new Dictionary<int, double>();

            foreach (var term in Terms)
            {
                if (simplified.ContainsKey(term.Power))
                    simplified[term.Power] += term.Coefficient;
                else
                    simplified[term.Power] = term.Coefficient;
            }

            var newTerms = simplified
                .Where(kvp => Math.Abs(kvp.Value) > 1e-9) // Remove zero terms
                .Select(kvp => new Term(kvp.Value, Variable, kvp.Key))
                .OrderByDescending(t => t.Power) // Order by descending power
                .ToList();

            return new AlgebraicExpression(newTerms, Variable);
        }

        /// <summary>
        /// Evaluates the expression at a given value.
        /// </summary>
        /// <param name="value">The value to substitute for the variable.</param>
        /// <returns>The result of the evaluation.</returns>
        /// <example>
        /// <code>
        /// // Evaluate 2x² + 3x - 1 at x = 2
        /// var expr = new AlgebraicExpression();
        /// expr.AddTerm(2, 2);   // 2x²
        /// expr.AddTerm(3, 1);   // 3x
        /// expr.AddTerm(-1, 0);  // -1
        /// 
        /// double result = expr.Evaluate(2);
        /// // Returns 2(4) + 3(2) - 1 = 8 + 6 - 1 = 13
        /// </code>
        /// </example>
        public double Evaluate(double value)
        {
            return Terms.Sum(term => term.Evaluate(value));
        }

        /// <summary>
        /// Differentiates the expression with respect to its variable.
        /// </summary>
        /// <returns>A new expression representing the derivative.</returns>
        /// <remarks>
        /// Uses the power rule: d/dx[ax^n] = a*n*x^(n-1)
        /// This is a foundational operation in calculus for:
        /// - Finding rates of change
        /// - Optimization (finding maxima/minima)
        /// - Tangent lines to curves
        /// - Velocity and acceleration in physics
        /// </remarks>
        /// <example>
        /// <code>
        /// // Differentiate 3x² + 2x + 1
        /// var expr = new AlgebraicExpression();
        /// expr.AddTerm(3, 2);   // 3x²
        /// expr.AddTerm(2, 1);   // 2x
        /// expr.AddTerm(1, 0);   // 1
        /// 
        /// var derivative = expr.Differentiate();
        /// // Returns 6x + 2
        /// // (3*2)x^(2-1) + (2*1)x^(1-1) + 0 = 6x + 2
        /// </code>
        /// </example>
        public AlgebraicExpression Differentiate()
        {
            var derivativeTerms = new List<Term>();

            foreach (var term in Terms)
            {
                if (term.Power == 0)
                {
                    // Derivative of constant is 0 (we skip it)
                    continue;
                }

                // Power rule: d/dx[ax^n] = a*n*x^(n-1)
                double newCoefficient = term.Coefficient * term.Power;
                int newPower = term.Power - 1;

                derivativeTerms.Add(new Term(newCoefficient, Variable, newPower));
            }

            // If no terms remain, the derivative is 0
            if (derivativeTerms.Count == 0)
                derivativeTerms.Add(new Term(0, Variable, 0));

            return new AlgebraicExpression(derivativeTerms, Variable);
        }

        /// <summary>
        /// Integrates the expression with respect to its variable.
        /// </summary>
        /// <param name="includeConstant">Whether to include the constant of integration.</param>
        /// <returns>A new expression representing the indefinite integral.</returns>
        /// <remarks>
        /// Uses the power rule: ∫ax^n dx = a*x^(n+1)/(n+1) + C
        /// Note: This doesn't handle the special case ∫x^(-1) dx = ln|x| + C
        /// 
        /// This is fundamental for:
        /// - Finding areas under curves
        /// - Solving differential equations
        /// - Computing displacement from velocity
        /// - Accumulation functions
        /// </remarks>
        /// <example>
        /// <code>
        /// // Integrate 6x + 2
        /// var expr = new AlgebraicExpression();
        /// expr.AddTerm(6, 1);   // 6x
        /// expr.AddTerm(2, 0);   // 2
        /// 
        /// var integral = expr.Integrate();
        /// // Returns 3x² + 2x (plus C, constant of integration)
        /// // 6*x^2/2 + 2*x^1/1 = 3x² + 2x
        /// </code>
        /// </example>
        public AlgebraicExpression Integrate(bool includeConstant = false)
        {
            var integralTerms = new List<Term>();

            foreach (var term in Terms)
            {
                if (term.Power == -1)
                {
                    // Special case: ∫x^(-1) dx = ln|x| + C
                    // This requires logarithm support, which is beyond polynomial expressions
                    throw new InvalidExpressionException(
                        "Integration of x^(-1) requires logarithms (ln|x|), which is not supported in polynomial expressions");
                }

                // Power rule: ∫ax^n dx = a*x^(n+1)/(n+1) + C
                int newPower = term.Power + 1;
                double newCoefficient = term.Coefficient / newPower;

                integralTerms.Add(new Term(newCoefficient, Variable, newPower));
            }

            // Optionally add constant of integration
            if (includeConstant)
            {
                // We can't represent arbitrary constants, so we add a symbolic note
                // In a full implementation, this would be a special constant term
            }

            return new AlgebraicExpression(integralTerms, Variable);
        }

        /// <summary>
        /// Returns the expression as a string.
        /// </summary>
        public override string ToString()
        {
            if (Terms.Count == 0)
                return "0";

            var simplified = Simplify();
            var termStrings = new List<string>();

            for (int i = 0; i < simplified.Terms.Count; i++)
            {
                var term = simplified.Terms[i];
                string termStr = term.ToString();

                if (i > 0 && term.Coefficient > 0)
                    termStrings.Add("+ " + termStr);
                else if (i > 0 && term.Coefficient < 0)
                    termStrings.Add("- " + termStr.TrimStart('-'));
                else
                    termStrings.Add(termStr);
            }

            return string.Join(" ", termStrings);
        }

        // TODO: Future enhancements for full calculus support
        // - Product rule for differentiation: (fg)' = f'g + fg'
        // - Quotient rule for differentiation: (f/g)' = (f'g - fg') / g²
        // - Chain rule for differentiation: (f(g(x)))' = f'(g(x)) * g'(x)
        // - Integration by parts: ∫u dv = uv - ∫v du
        // - Substitution for integration
        // - Partial fraction decomposition (for rational functions)
        // - Taylor series expansion
        // - Finding critical points (where derivative = 0)
        // - Second derivative test for concavity
        // - Definite integration (with limits)
        // - Numerical integration (trapezoidal rule, Simpson's rule)
        // - Expression parsing from strings (e.g., "3x^2 + 2x - 1")
        // - Support for trigonometric, exponential, and logarithmic functions
        // - Multivariable expressions and partial derivatives
        
        /// <summary>
        /// EXAMPLE: How this would be used for calculus problems
        /// </summary>
        /// <example>
        /// Finding the tangent line to f(x) = x² + 2x at x = 3:
        /// 
        /// <code>
        /// // Define function f(x) = x² + 2x
        /// var f = new AlgebraicExpression();
        /// f.AddTerm(1, 2);  // x²
        /// f.AddTerm(2, 1);  // 2x
        /// 
        /// // Find derivative f'(x) = 2x + 2
        /// var fPrime = f.Differentiate();
        /// 
        /// // Evaluate f(3) and f'(3)
        /// double y = f.Evaluate(3);          // f(3) = 9 + 6 = 15
        /// double slope = fPrime.Evaluate(3); // f'(3) = 6 + 2 = 8
        /// 
        /// // Create tangent line: y - 15 = 8(x - 3)
        /// var tangent = LinearEquations.FromPointAndSlope(3, 15, 8);
        /// // Result: y = 8x - 9
        /// </code>
        /// 
        /// Finding the area under f(x) = 2x from x = 0 to x = 3:
        /// 
        /// <code>
        /// // Define function f(x) = 2x
        /// var f = new AlgebraicExpression();
        /// f.AddTerm(2, 1);  // 2x
        /// 
        /// // Find antiderivative F(x) = x²
        /// var F = f.Integrate();
        /// 
        /// // Evaluate definite integral: F(3) - F(0)
        /// double area = F.Evaluate(3) - F.Evaluate(0);
        /// // Result: 9 - 0 = 9
        /// </code>
        /// </example>
    }

    /// <summary>
    /// Provides utility methods for working with algebraic expressions.
    /// </summary>
    public static class AlgebraicExpressionHelpers
    {
        /// <summary>
        /// Creates a polynomial expression from coefficients.
        /// </summary>
        /// <param name="coefficients">Coefficients in descending order of powers.</param>
        /// <param name="variable">The variable to use.</param>
        /// <returns>An algebraic expression.</returns>
        /// <example>
        /// <code>
        /// // Create 3x² + 2x + 1
        /// var expr = AlgebraicExpressionHelpers.FromCoefficients(
        ///     new[] { 3.0, 2.0, 1.0 });
        /// </code>
        /// </example>
        public static AlgebraicExpression FromCoefficients(double[] coefficients, char variable = 'x')
        {
            var expr = new AlgebraicExpression(variable);
            int degree = coefficients.Length - 1;

            for (int i = 0; i < coefficients.Length; i++)
            {
                if (Math.Abs(coefficients[i]) > 1e-9) // Skip zero terms
                {
                    expr.AddTerm(coefficients[i], degree - i);
                }
            }

            return expr;
        }

        /// <summary>
        /// Creates a monomial ax^n.
        /// </summary>
        public static AlgebraicExpression Monomial(double coefficient, int power, char variable = 'x')
        {
            var expr = new AlgebraicExpression(variable);
            expr.AddTerm(coefficient, power);
            return expr;
        }

        /// <summary>
        /// Creates a constant expression.
        /// </summary>
        public static AlgebraicExpression Constant(double value, char variable = 'x')
        {
            return Monomial(value, 0, variable);
        }

        // TODO: Add expression parsing
        // public static AlgebraicExpression Parse(string expression);
        // This would parse strings like "3x^2 + 2x - 1" into an AlgebraicExpression
    }
}
