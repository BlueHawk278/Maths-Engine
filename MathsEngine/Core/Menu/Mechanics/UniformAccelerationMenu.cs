using System;

namespace MathsEngine.Core.Menu.Mechanics
{
    public class UniformAccelerationMenu
    {
        public static void menu()
        {
            Console.WriteLine("Welcome to the Uniform Acceleration menu");
            Console.WriteLine("1. Calculate average velocity");
        }

        private static void handleAverageVelocity()
        {
            Console.Write("Enter the initial velocity: ");
            string initialVelocity = Console.ReadLine();
            Console.Write("Enter the final velocity: ");
            string finalVelocity = Console.ReadLine();

            Modules.Mechanics.UniformAcceleration.UniformAccelerationCalculator
        }
    }
}