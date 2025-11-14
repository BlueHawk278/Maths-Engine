using MathsEngine.Modules.Statistics.Dispersion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsEngine.Modules.Statistics.StandardDeviation
{
    internal class StandardDeviation
    {
        // Basic version
        internal static void calculate()
        {
            Variables.numValues = StandardDeviationLogic.getNumDataPoints();

            Console.ReadKey();
        }
    }
}
