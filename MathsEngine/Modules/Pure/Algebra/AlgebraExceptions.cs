using System;

namespace MathsEngine.Modules.Pure.Algebra
{
    // Fraction Exceptions

    /// <summary>
    /// Exception thrown when attempting to create a fraction with a zero denominator.
    /// </summary>
    public class ZeroDenominatorException : Exception
    {
        public ZeroDenominatorException() : base("Denominator cannot be zero") { }
        public ZeroDenominatorException(string message) : base(message) { }
    }

    /// <summary>
    /// Exception thrown when fraction operations result in overflow.
    /// </summary>
    public class FractionOverflowException : Exception
    {
        public FractionOverflowException() : base("Fraction operation resulted in overflow") { }
        public FractionOverflowException(string message) : base(message) { }
    }

    // Quadratic Equation Exceptions

    /// <summary>
    /// Exception thrown when the coefficient 'a' is zero in a quadratic equation.
    /// This would make it a linear equation, not quadratic.
    /// </summary>
    public class NotQuadraticException : Exception
    {
        public NotQuadraticException() : base("Coefficient 'a' cannot be zero in a quadratic equation") { }
        public NotQuadraticException(string message) : base(message) { }
    }

    /// <summary>
    /// Exception thrown when attempting to find real roots of a quadratic with negative discriminant.
    /// </summary>
    public class NoRealRootsException : Exception
    {
        public NoRealRootsException() : base("Equation has no real roots (discriminant is negative)") { }
        public NoRealRootsException(string message) : base(message) { }
    }

    // Linear Equation Exceptions

    /// <summary>
    /// Exception thrown when two lines are parallel and cannot intersect.
    /// </summary>
    public class ParallelLinesException : Exception
    {
        public ParallelLinesException() : base("Lines are parallel and do not intersect") { }
        public ParallelLinesException(string message) : base(message) { }
    }

    /// <summary>
    /// Exception thrown when two lines are identical (infinite intersection points).
    /// </summary>
    public class IdenticalLinesException : Exception
    {
        public IdenticalLinesException() : base("Lines are identical (infinite intersection points)") { }
        public IdenticalLinesException(string message) : base(message) { }
    }

    // Algebraic Expression Exceptions

    /// <summary>
    /// Exception thrown when an algebraic expression is malformed or cannot be parsed.
    /// </summary>
    public class InvalidExpressionException : Exception
    {
        public InvalidExpressionException() : base("Expression is invalid or malformed") { }
        public InvalidExpressionException(string message) : base(message) { }
    }

    /// <summary>
    /// Exception thrown when an undefined variable is referenced.
    /// </summary>
    public class UndefinedVariableException : Exception
    {
        public UndefinedVariableException() : base("Variable is undefined") { }
        public UndefinedVariableException(string message) : base(message) { }
    }

    /// <summary>
    /// Exception thrown when division by zero is attempted in algebraic operations.
    /// </summary>
    public class AlgebraicDivisionByZeroException : Exception
    {
        public AlgebraicDivisionByZeroException() : base("Division by zero in algebraic expression") { }
        public AlgebraicDivisionByZeroException(string message) : base(message) { }
    }
}
