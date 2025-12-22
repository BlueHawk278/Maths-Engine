using System;

namespace MathsEngine.Utils
{
    internal class Exceptions
    {
        // Pythagoras Theorem
        public static readonly Exception negativeSideLengthException = 
            new Exception("Side lengths must be positive.");
        public static readonly Exception hyptonenuseNotLongestSideException =
            new Exception("Hypotenuse must be the longest side");
    }
}
