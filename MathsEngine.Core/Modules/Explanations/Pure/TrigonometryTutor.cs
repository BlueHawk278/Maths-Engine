using System;
using System.Collections.Generic;
using MathsEngine.Modules.Pure.Trigonometry;

namespace MathsEngine.Modules.Explanations.Pure
{
    /// <summary>
    /// Provides step-by-step explanations for trigonometry calculations.
    /// </summary>
    public static class TrigonometryTutor
    {
        public static CalculationResult CalculateMissingSideWithSteps(
            double? knownSideLength,
            double? angle,
            SideType knownSideType,
            SideType sideToFind)
        {
            // Validate inputs early to provide better error messages
            // The underlying calculation will also validate, but we access .Value before calling it
            if (knownSideLength is null || angle is null)
                throw new Utils.NullInputException();

            var steps = new List<string>();

            // Step 1: Identify known values
            steps.Add("Step 1: Identify known values");
            steps.Add($"  {knownSideType} = {knownSideLength}");
            steps.Add($"  Angle = {angle}°");
            steps.Add("");

            // Step 2: Choose the trigonometric ratio
            steps.Add("Step 2: Choose the trigonometric ratio");
            string rule = GetTrigRule(knownSideType, sideToFind);
            steps.Add($"  {rule}");
            steps.Add("");

            // Step 3: Convert angle to radians
            steps.Add("Step 3: Convert angle to radians");
            double radians = angle.Value * Math.PI / 180.0;
            steps.Add($"  {angle}° × π / 180 = {radians:F4} radians");
            steps.Add("");

            // Step 4: Set up the equation
            steps.Add("Step 4: Set up the equation");
            string equation = GetEquation(knownSideType, sideToFind, knownSideLength.Value, angle.Value);
            steps.Add($"  {equation}");
            steps.Add("");

            // Step 5: Calculate the result
            steps.Add("Step 5: Calculate the missing side");
            double value = Trigonometry.CalculateMissingSide(
                knownSideLength, angle, knownSideType, sideToFind);
            steps.Add($"  {sideToFind} = {value:F2}");
            steps.Add("");

            // Final answer
            steps.Add("Final Answer:");
            steps.Add($"  The {sideToFind} is {value:F2} units");

            return new CalculationResult(value, steps);
        }

        public static CalculationResult CalculateMissingAngleWithSteps(
            double? side1Length,
            SideType side1Type,
            double? side2Length,
            SideType side2Type)
        {
            // Validate inputs early to provide better error messages
            if (side1Length is null || side2Length is null)
                throw new Utils.NullInputException();

            var steps = new List<string>();

            // Step 1: Identify known sides
            steps.Add("Step 1: Identify known sides");
            steps.Add($"  {side1Type} = {side1Length}");
            steps.Add($"  {side2Type} = {side2Length}");
            steps.Add("");

            // Step 2: Choose the trigonometric ratio
            steps.Add("Step 2: Choose the trigonometric ratio");
            string rule = GetTrigRule(side1Type, side2Type);
            steps.Add($"  {rule}");
            steps.Add("");

            // Step 3: Set up the inverse trig function
            steps.Add("Step 3: Calculate using inverse trigonometric function");
            string inverseFunc = GetInverseFunction(side1Type, side2Type, side1Length.Value, side2Length.Value);
            steps.Add($"  {inverseFunc}");
            steps.Add("");

            // Step 4: Calculate
            steps.Add("Step 4: Compute the angle");
            double angle = Trigonometry.CalculateMissingAngle(
                side1Length, side1Type, side2Length, side2Type);
            steps.Add($"  Angle = {angle:F2}°");
            steps.Add("");

            // Final answer
            steps.Add("Final Answer:");
            steps.Add($"  The angle is {angle:F2}°");

            return new CalculationResult(angle, steps);
        }

        private static string GetTrigRule(SideType type1, SideType type2)
        {
            if ((type1 == SideType.Opposite && type2 == SideType.Hypotenuse) ||
                (type1 == SideType.Hypotenuse && type2 == SideType.Opposite))
                return "SOH → sin(θ) = opposite / hypotenuse";

            if ((type1 == SideType.Adjacent && type2 == SideType.Hypotenuse) ||
                (type1 == SideType.Hypotenuse && type2 == SideType.Adjacent))
                return "CAH → cos(θ) = adjacent / hypotenuse";

            return "TOA → tan(θ) = opposite / adjacent";
        }

        private static string GetEquation(SideType known, SideType find, double knownValue, double angle)
        {
            // SOH - Sine
            if (known == SideType.Opposite && find == SideType.Hypotenuse)
                return $"sin({angle}°) = {knownValue} / hypotenuse  →  hypotenuse = {knownValue} / sin({angle}°)";

            if (known == SideType.Hypotenuse && find == SideType.Opposite)
                return $"sin({angle}°) = opposite / {knownValue}  →  opposite = {knownValue} × sin({angle}°)";

            // CAH - Cosine
            if (known == SideType.Adjacent && find == SideType.Hypotenuse)
                return $"cos({angle}°) = {knownValue} / hypotenuse  →  hypotenuse = {knownValue} / cos({angle}°)";

            if (known == SideType.Hypotenuse && find == SideType.Adjacent)
                return $"cos({angle}°) = adjacent / {knownValue}  →  adjacent = {knownValue} × cos({angle}°)";

            // TOA - Tangent
            if (known == SideType.Opposite && find == SideType.Adjacent)
                return $"tan({angle}°) = {knownValue} / adjacent  →  adjacent = {knownValue} / tan({angle}°)";

            if (known == SideType.Adjacent && find == SideType.Opposite)
                return $"tan({angle}°) = opposite / {knownValue}  →  opposite = {knownValue} × tan({angle}°)";

            return "Equation setup";
        }

        private static string GetInverseFunction(SideType type1, SideType type2, double val1, double val2)
        {
            // SOH - Sine
            if ((type1 == SideType.Opposite && type2 == SideType.Hypotenuse) ||
                (type1 == SideType.Hypotenuse && type2 == SideType.Opposite))
            {
                double opp = type1 == SideType.Opposite ? val1 : val2;
                double hyp = type1 == SideType.Hypotenuse ? val1 : val2;
                return $"θ = sin⁻¹({opp} / {hyp}) = sin⁻¹({opp / hyp:F4})";
            }

            // CAH - Cosine
            if ((type1 == SideType.Adjacent && type2 == SideType.Hypotenuse) ||
                (type1 == SideType.Hypotenuse && type2 == SideType.Adjacent))
            {
                double adj = type1 == SideType.Adjacent ? val1 : val2;
                double hyp = type1 == SideType.Hypotenuse ? val1 : val2;
                return $"θ = cos⁻¹({adj} / {hyp}) = cos⁻¹({adj / hyp:F4})";
            }

            // TOA - Tangent
            if ((type1 == SideType.Opposite && type2 == SideType.Adjacent) ||
                (type1 == SideType.Adjacent && type2 == SideType.Opposite))
            {
                double opp = type1 == SideType.Opposite ? val1 : val2;
                double adj = type1 == SideType.Adjacent ? val1 : val2;
                return $"θ = tan⁻¹({opp} / {adj}) = tan⁻¹({opp / adj:F4})";
            }

            return "Inverse function";
        }
    }
}
