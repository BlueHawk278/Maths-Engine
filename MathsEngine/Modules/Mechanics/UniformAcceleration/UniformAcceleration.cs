using System;

namespace MathsEngine.Modules.Mechanics.UniformAcceleration
{
    public class UniformAcceleration
    {
        public static void Start()
        {

        }

        public static void displayCalculation(string u, string v, string a, string t, string s)
        {
            Console.WriteLine("Initial Velocity: " + u);
            Console.WriteLine("Final Velocity: " + v);
            Console.WriteLine("Acceleration: " + a);
            Console.WriteLine("Time: " + t);
            Console.WriteLine("Displacement: " + s);
        }
    }
}