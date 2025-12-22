using System;

namespace MathsEngine.Utils
{
    internal class Exceptions
    {
        // General
        public static readonly Exception nullInputException = 
            new Exception("Values entered mustnot be null");
        public static readonly Exception nullValuesException =
            new Exception("Cannot have more than one null value");

        // Pythagoras Theorem
        public static readonly Exception negativeSideLengthException = 
            new Exception("Side lengths must be positive.");
        public static readonly Exception hyptonenuseNotLongestSideException =
            new Exception("Hypotenuse must be the longest side");

        // Dynamics
        public static readonly Exception nullMassException =
            new Exception("Mass cannot be 0");
    }
}
