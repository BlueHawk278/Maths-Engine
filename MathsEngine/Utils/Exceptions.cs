using System;

namespace MathsEngine.Utils
{
    internal class Exceptions
    {
        // General
        public static readonly Exception NullInputException = 
            new Exception("Values entered must not be null");
        public static readonly Exception NullValuesException =
            new Exception("Cannot have more than one null value");

        // Pythagoras Theorem
        public static readonly Exception NegativeSideLengthException = 
            new Exception("Side lengths must be positive.");
        public static readonly Exception HypotenuseNotLongestSideException =
            new Exception("Hypotenuse must be the longest side");
        
        // Trigonometry
        public static readonly Exception AcuteAngleException =
            new Exception("Angle is Acute (Must be between 0 and 90 degrees)");

        // Matrices
        public static readonly Exception IncompatibleAdditionMatricesException = 
            new Exception("Matrices can't be added, they are not the same size");
        public static readonly Exception IncompatibleSubtractionMatricesException =
            new Exception("Matrices can't be subtracted, they are not the same size");
        public static readonly Exception IncompatibleMatrixMultiplicationException =
            new Exception("Cannot multiply these matrices");

        // Bivariate Analysis
        public static readonly Exception ListsNotSameSizeException =
            new Exception("Inputs must have the same amount of data points");

        // Dynamics
        public static readonly Exception NullMassException =
            new Exception("Mass cannot be 0");
    }
}
