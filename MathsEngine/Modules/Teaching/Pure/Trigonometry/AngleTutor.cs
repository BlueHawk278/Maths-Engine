using PureTrig = MathsEngine.Modules.Pure.Trigonometry;
using MathsEngine.Modules.Pure.Trigonometry;

namespace MathsEngine.Modules.Teaching.Pure.Trigonometry;

public class AngleTutor
{
    public static CalculationResult CalculateMissingAngleWithSteps(
        double side1Length, SideType side1Type,
        double side2Length, SideType side2Type)
    {
        var steps = new List<string>();

        steps.Add("Step 1: Identify known sides");
        steps.Add($"{side1Type} = {side1Length}");
        steps.Add($"{side2Type} = {side2Length}");
        steps.Add("");

        steps.Add("Step 2: Choose the trigonometric ratio");
        steps.Add(GetRule(side1Type, side2Type));
        steps.Add("");

        steps.Add("Step 3: Calculate the angle");
        double angle = PureTrig.Trigonometry.CalculateMissingAngle(
            side1Length, side1Type, side2Length, side2Type);

        steps.Add($"Angle = {angle:F2}°");
        steps.Add("");

        steps.Add("Step 4: Final Answer");
        steps.Add($"The angle is {angle:F2}°");

        return new CalculationResult(angle, steps);
    }

    private static string GetRule(SideType a, SideType b)
    {
        if ((a == SideType.Opposite && b == SideType.Hypotenuse) ||
            (a == SideType.Hypotenuse && b == SideType.Opposite))
            return "SOH → sin(angle) = opposite / hypotenuse";

        if ((a == SideType.Adjacent && b == SideType.Hypotenuse) ||
            (a == SideType.Hypotenuse && b == SideType.Adjacent))
            return "CAH → cos(angle) = adjacent / hypotenuse";

        return "TOA → tan(angle) = opposite / adjacent";
    }
}