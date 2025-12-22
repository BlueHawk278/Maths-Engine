using System;

namespace MathsEngine.Utils
{
    internal class Exceptions
    {
        // General
        public static readonly Exception nullInputException = 
            new Exception("Values entered must not be null");
        public static readonly Exception nullValuesException =
            new Exception("Cannot have more than one null value");

        // Pythagoras Theorem
        public static readonly Exception negativeSideLengthException = 
            new Exception("Side lengths must be positive.");
        public static readonly Exception hyptonenuseNotLongestSideException =
            new Exception("Hypotenuse must be the longest side");

        // Matrices
        public static readonly Exception incompatibleAdditionMatricesException = 
            new Exception("Matrices can't be added, they are not the same size");
        public static readonly Exception incompatibleSubtractionMatricesException =
            new Exception("Matrices can't be subtracted, they are not the same size");
        public static readonly Exception incompatibleMatrixMultiplicationException =
            new Exception("Cannot multiply these matrices");

        // Dynamics
        public static readonly Exception nullMassException =
            new Exception("Mass cannot be 0");
    }
}
