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
            Console.Write("Input: ");
            string response = Console.ReadLine();
            Console.Clear();

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
            Console.Write("Input: ");
            string response = Console.ReadLine();
            Console.Clear();

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
            }

            Console.WriteLine("\nPress Enter to return...");
            Console.ReadLine();
            menu();
            
        }

        private static void handleAverageVelocity()
        {
            Console.Write("Enter the initial velocity: ");
            string initialVelocity = Console.ReadLine();
            Console.Write("Enter the final velocity: ");
            string finalVelocity = Console.ReadLine();

            try
            {
                double averageVelocity = UniformAccelerationCalculator.CalculateAverageVelocity(initialVelocity, finalVelocity);
                Console.WriteLine($"\nAverage Velocity: {averageVelocity:F2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
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

            try
            {
                checkCalculation(s, u, v, a, t);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nError: {ex.Message}");
            }
        }

        private static void checkCalculation(string u, string v, string a, string t, string s)
        {
            // Convert empty strings to null to easily check what's missing
            s = string.IsNullOrEmpty(s) ? null : s;
            u = string.IsNullOrEmpty(u) ? null : u;
            v = string.IsNullOrEmpty(v) ? null : v;
            a = string.IsNullOrEmpty(a) ? null : a;
            t = string.IsNullOrEmpty(t) ? null : t;

            var values = new List<string> { s, u, v, a, t };
            int nullNums = 0;

            foreach(string str in values)
                if (str == null)
                    nullNums++;

            if (nullNums > 2)
            {
                Console.WriteLine("\nCannot solve. Please provide at least 3 values.");
                return;
            }

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

            UniformAcceleration.displayCalculation(u, v, a, t, s);
        }
    }
}