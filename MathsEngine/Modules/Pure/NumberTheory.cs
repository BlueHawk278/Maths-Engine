namespace MathsEngine.Modules.Pure;

public class NumberTheory
{
    public static (int Hcf, int Lcm) GetLcmAndHcf(int a, int b)
    {
        int hcf = 1;

        for (int i = 2; i < a + 1; i++)
            if (a % i == 0 && b % i == 0)
                hcf = i;

        int lcm = Convert.ToInt16((a * b) / hcf);

        return (hcf, lcm);
    }
}