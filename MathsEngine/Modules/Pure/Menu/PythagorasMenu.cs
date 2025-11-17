using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathsEngine.Modules.Pure.Menu
{
    internal static class PythagorasMenu // fix this
    {
        internal static void menu()
        {
            Console.WriteLine("Welcome to the Pythagoras Theorem Menu");
            Console.WriteLine("1. Check valid values"); // idk
            Console.WriteLine("2. Calculate a missing side");
            int response = Convert.ToInt16(Console.ReadLine());

            switch (response)
            {
                case 1:
                    var values = getValues();
                    Core.PureHelpers.PythagorasTheorem.checkValidResult(values);
                    break;
                case 2:
                    break;
            }
        }

        private static Dictionary<string, double> getValues()
        {
            Console.Write("What length is the hypotenuse ( 0 if unknown ): ");
            double hypotenuse = Convert.ToDouble(Console.ReadLine());
            Console.Write("What length is side A ( 0 if unknown");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.Write("What length is side B ( 0 if unknown");
            double b = Convert.ToDouble(Console.ReadLine());

            var values = new Dictionary<string, double>
            {
                { "Hypotenuse", hypotenuse },
                { "A", a },
                { "B", b }
            };
            return values;
        }
    }
}
