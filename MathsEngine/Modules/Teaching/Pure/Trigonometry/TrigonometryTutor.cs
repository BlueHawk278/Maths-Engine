using PureTrig = MathsEngine.Modules.Pure.Trigonometry;
using MathsEngine.Modules.Pure.Trigonometry;

namespace MathsEngine.Modules.Teaching.Pure.Trigonometry
{
    public class TrigonometryTutor
    {
        public static CalculationResult CalculateMissingSideWithSteps(
            double knownSideLength, double angle, SideType knownSideType, SideType sideToFind)
        {
            var steps = new List<string>();

            steps.Add("Step 1: Identify known values");
            steps.Add($"{knownSideType} = {knownSideLength}");
            steps.Add($"Angle = {angle}°");
            steps.Add("");

            steps.Add("Step 2: Choose the trigonometric ratio");
            steps.Add(GetRule(knownSideType, sideToFind));
            steps.Add("");

            steps.Add("Step 3: Convert angle to radians");
            double radians = angle * Math.PI / 180.0;
            steps.Add($"{angle}° × π / 180 = {radians:F4}");
            steps.Add("");

            steps.Add("Step 4: Calculate the missing side");
            double value = PureTrig.Trigonometry.CalculateMissingSide(
                knownSideLength, angle, knownSideType, sideToFind);

            steps.Add($"{sideToFind} = {value:F2}");
            steps.Add("");

            steps.Add("Step 5: Final Answer");
            steps.Add($"The {sideToFind} is {value:F2}");

            return new CalculationResult(value, steps);
        }

        private static string GetRule(SideType known, SideType find)
        {
            if ((known == SideType.Opposite && find == SideType.Hypotenuse) ||
                (known == SideType.Hypotenuse && find == SideType.Opposite))
                return "SOH → sin(angle) = opposite / hypotenuse";

            if ((known == SideType.Adjacent && find == SideType.Hypotenuse) ||
                (known == SideType.Hypotenuse && find == SideType.Adjacent))
                return "CAH → cos(angle) = adjacent / hypotenuse";

            return "TOA → tan(angle) = opposite / adjacent";
        }
    }
}