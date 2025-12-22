using System;
using System.Collections.Generic;

namespace MathsEngine.Modules.Mechanics.Dynamics
{
    public class NewtonsLawsCalculator // Integrate uniform acceleration equations
    {
        public static double calculateFma(string F, string m, string a)
        {
            F = string.IsNullOrEmpty(F) ? "0" : F;
            m = string.IsNullOrEmpty(m) ? "0" : m;
            a = string.IsNullOrEmpty(a) ? "0" : a;

            if (m == "")
                throw Utils.Exceptions.nullMassException;

            int numNullValues = 0;

            List<string> values = new List<string> { F, m, a };
            foreach(string val in values)
                if (Convert.ToDouble(val) == 0)
                    numNullValues++;

            if (numNullValues >= 2)
                throw Utils.Exceptions.nullValuesException;

            if (F == "")
                return Convert.ToDouble(m) * Convert.ToDouble(a);
            if (m == "")
                return Convert.ToDouble(F) / Convert.ToDouble(a);
            if (a == "")
                return Convert.ToDouble(F) / Convert.ToDouble(m);
            return 0;
        }
    }
}