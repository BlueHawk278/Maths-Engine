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
        internal static void calculate() // Initial logic as far as we can right now
        {
            StandardDeviationLogic.getNumDataPoints();
            StandardDeviationLogic.getValues();
            StandardDeviationLogic.sortValues();


            Console.ReadKey();
        }
    }
}
