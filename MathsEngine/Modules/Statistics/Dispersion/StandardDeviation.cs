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
            Methods.getNumDataPoints();

            Methods.getValues();
            Methods.sortValues();

            Methods.getMean();
            Methods.getMode();
            Methods.getMedian();
            Methods.getRange();

            Methods.displayData();

            Console.ReadKey();
        }
    }
}
