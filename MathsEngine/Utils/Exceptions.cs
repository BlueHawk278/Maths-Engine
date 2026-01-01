using System;

namespace MathsEngine.Utils
{
    // General
    public class NullInputException : Exception
    {
        public NullInputException() : base("Values entered must not be null") { }
        public NullInputException(string message) : base(message) { }
    }

    public class NullValuesException : Exception
    {
        public NullValuesException() : base("Cannot have more than one null value") { }
        public NullValuesException(string message) : base(message) { }
    }

    ///// PURE
    
    // Pythagoras Theorem
    public class NegativeSideLengthException : Exception
    {
        public NegativeSideLengthException() : base("Side lengths must be positive.") { }
        public NegativeSideLengthException(string message) : base(message) { }
    }

    public class HypotenuseNotLongestSideException : Exception
    {
        public HypotenuseNotLongestSideException() : base("Hypotenuse must be the longest side") { }
        public HypotenuseNotLongestSideException(string message) : base(message) { }
    }

    // Trigonometry
    public class AcuteAngleException : Exception
    {
        public AcuteAngleException() : base("Angle must be between 0 and 90 degrees") { }
        public AcuteAngleException(string message) : base(message) { }
    }

    public class DuplicateSideException : Exception
    {
        public DuplicateSideException() : base("Known side and the side to find cannot be the same") { }
        public DuplicateSideException(string message) : base(message){ }
    }

    // Matrices
    public class IncompatibleMatrixAdditionException : Exception
    {
        public IncompatibleMatrixAdditionException() : base("Matrices can't be added, they are not the same size") { }
        public IncompatibleMatrixAdditionException(string message) : base(message) { }
    }

    public class IncompatibleSubtractionMatricesException : Exception
    {
        public IncompatibleSubtractionMatricesException() : base("Matrices can't be subtracted, they are not the same size") { }
        public IncompatibleSubtractionMatricesException(string message) : base(message) { }
    }

    public class IncompatibleMatrixMultiplicationException : Exception
    {
        public IncompatibleMatrixMultiplicationException() : base("Cannot multiply these matrices") { }
        public IncompatibleMatrixMultiplicationException(string message) : base(message) { }
    }

    public class NotSquareMatrixException : Exception
    {
        public NotSquareMatrixException(string message) : base(message) { }
    }

    ///// Statistics

    // Bivariate Analysis
    public class ListsNotSameSizeException : Exception
    {
        public ListsNotSameSizeException() : base("Inputs must have the same amount of data points") { }
        public ListsNotSameSizeException(string message) : base(message) { }
    }

    ///// Mechanics

    // Dynamics
    public class NullMassException : Exception
    {
        public NullMassException() : base("Mass cannot be 0") { }
        public NullMassException(string message) : base(message) { }
    }
}
