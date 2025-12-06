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
                    Menu.mainMenu();
                    break;
            }
        }

        private static void horizontalMotionMenu()
        {
            Console.WriteLine("1. Average Velocity");
            Console.WriteLine("2. UVATS equations");
            string response = Console.ReadLine();

            switch (response)
            {
                case "1":
                    handleAverageVelocity();
                    menu();
                    break;
                case "2":
                    handleUVATS();
                    menu();
                    break;
                default:
                    Menu.mainMenu();
                    break;
            }
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

            for(int i = 0; i < values.Count; i++)
                if (values[i] == null)
                    invalidNums++;
                

            if (invalidNums > 2)
                throw new ArgumentException("Too many null values");

            // This loop runs twice. If we solve for one value on the first pass,
            // the second pass can use that new value to solve for another.
            for (int i = 0; i < 2; i++)
            {
                // Try to find s (Displacement)
                if (s == null)
                {
                    if (u != null && v != null && t != null)
                        s = UniformAccelerationCalculator.CalculateSUVT(null, u, v, t);
                    else if (u != null && a != null && t != null)
                        s = UniformAccelerationCalculator.CalculateSUTAT(null, u, a, t);
                    else if (v != null && u != null && a != null)
                        s = UniformAccelerationCalculator.CalculateVUAS(v, u, a, null);
                }

                // Try to find u (Initial Velocity)
                if (u == null)
                {
                    if (v != null && a != null && t != null)
                        u = UniformAccelerationCalculator.CalculateVUAT(v, null, a, t);
                    else if (v != null && a != null && s != null)
                        u = UniformAccelerationCalculator.CalculateVUAS(v, null, a, s);
                    else if (s != null && v != null && t != null)
                        u = UniformAccelerationCalculator.CalculateSUVT(s, null, v, t);
                    else if (s != null && a != null && t != null)
                        u = UniformAccelerationCalculator.CalculateSUTAT(s, null, a, t);
                }

                // Try to find v (Final Velocity)
                if (v == null)
                {
                    if (u != null && a != null && t != null)
                        v = UniformAccelerationCalculator.CalculateVUAT(null, u, a, t);
                    else if (u != null && a != null && s != null)
                        v = UniformAccelerationCalculator.CalculateVUAS(null, u, a, s);
                    else if (s != null && u != null && t != null)
                        v = UniformAccelerationCalculator.CalculateSUVT(s, u, null, t);
                }

                // Try to find a (Acceleration)
                if (a == null)
                {
                    if (v != null && u != null && t != null)
                        a = UniformAccelerationCalculator.CalculateVUAT(v, u, null, t);
                    else if (v != null && u != null && s != null)
                        a = UniformAccelerationCalculator.CalculateVUAS(v, u, null, s);
                    else if (s != null && u != null && t != null)
                        a = UniformAccelerationCalculator.CalculateSUTAT(s, u, null, t);
                }

                // Try to find t (Time)
                if (t == null)
                {
                    if (v != null && u != null && a != null)
                        t = UniformAccelerationCalculator.CalculateVUAT(v, u, a, null);
                    else if (s != null && u != null && v != null)
                        t = UniformAccelerationCalculator.CalculateSUVT(s, u, v, null);
                    else if (s != null && u != null && a != null)
                        t = UniformAccelerationCalculator.CalculateSUTAT(s, u, a, null);
                }
            }

            UniformAcceleration.displayCalculation(s, u, v, a, t);
        }
    }
}