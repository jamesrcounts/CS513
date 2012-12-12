using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HornersRule
{
    internal class Program
    {
        private static int Horner(int[] coefficients, int x)
        {
            int p = coefficients.Last();
            for (int i = coefficients.Length - 2; 0 <= i; i--)
            {
                Console.WriteLine("Intermediate: p = {0}", p);
                Console.WriteLine("p = {0} * {1} + {2}", x, p, coefficients[i]);
                p = x * p + coefficients[i];
            }

            return p;
        }

        private static void Main()
        {
            // p(x) = 2x^4 - x^3 + 3x^2 + x - 5 = 3; let x = 3
            Console.WriteLine("Result: {0}", Horner(new int[] { -5, 1, 3, -1, 2 }, 3));
        }
    }
}