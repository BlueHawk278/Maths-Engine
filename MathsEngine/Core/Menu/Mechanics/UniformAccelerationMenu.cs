using System;
using System.Collections.Generic;
using MathsEngine.Modules.Mechanics.UniformAcceleration;

namespace MathsEngine.Core.Menu.Mechanics
{
    public class UniformAccelerationMenu
    {
        public static void menu()
        {
            Console.WriteLine("Welcome to the Uniform Acceleration menu");
            Console.WriteLine("1. Horizontal Motion");    
            string response = Console.ReadLine();

            switch (response)
            {
                case "1":
                    horizontalMotionMenu();
                    break;
                default:
                    menu();
                    break;
            }
        }

        private static void horizontalMotionMenu()
        {

        }

        private static void handleAverageVelocity()
        {
            Console.Write("Enter the initial velocity: ");
            string initialVelocity = Console.ReadLine();
            Console.Write("Enter the final velocity: ");
            string finalVelocity = Console.ReadLine();

            double averageVelocity = UniformAccelerationCalculator.CalculateAverageVelocity(initialVelocity, finalVelocity);
            Console.WriteLine($"Average Velocity: {averageVelocity}");
        }
        private static void handleUVATS()
        {
            Console.Write("Enter the initial velocity: ");
            string u = Console.ReadLine();
            Console.Write("Enter the final velocity: ");
            string v = Console.ReadLine();
            Console.Write("Enter the acceleration: ");
            string a = Console.ReadLine();
            Console.Write("Enter the time taken: ");
            string t = Console.ReadLine();
            Console.Write("Enter the displacement: ");
            string s = Console.ReadLine();

            checkCalculation(u, v, a, t, s);
        }

        private static void checkCalculation(string u, string v, string a, string t, string s)
        {
            List<string> values = new List<string> { u, v, a, t, s };

            int invalidNums = 0;
            foreach(string value in values)
                if (value == null)
                    invalidNums++;
            if (invalidNums > 2)
                throw new ArgumentException("Too many null values");

            string U, V, A, T, S;

            if (u == null && s == null)
            {
                U = UniformAccelerationCalculator.CalculateVUAT(v, u, a, t);
                S = UniformAccelerationCalculator.CalculateVUAS(v, u, a, s);

                UniformAcceleration.displayCalculation(U, v, a, t, S);
            }
        }
    }
}