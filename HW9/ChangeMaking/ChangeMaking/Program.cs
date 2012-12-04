using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMaking
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(ChangeMaking(new[] { 1, 2, 5 }, 8));
        }

        private static void WriteStorage(int[] storage, int cell)
        {
            var sb = new StringBuilder();
            sb.Append("F: [");
            sb.Append(string.Join("|", storage));
            sb.Append("]");
            Console.WriteLine("F[{1}]: [ {0} ]", string.Join(" | ", storage), cell);
        }

        private static int ChangeMaking(int[] denominations, int amount)
        {
            int[] storage = new int[amount + 1];
            storage[0] = 0;
            WriteStorage(storage, 0);
            for (int i = 1; i <= amount; i++)
            {
                int temp = int.MaxValue;
                int j = 0;
                int m = denominations.Length;
                while (j < m && i >= denominations[j])
                {
                    int prev = storage[i - denominations[j]];
                    Console.WriteLine("temp = min({0}, {1})", prev, temp == int.MaxValue ? "infinity" : temp.ToString());
                    temp = Math.Min(storage[i - denominations[j]], temp);
                    j++;
                }
                storage[i] = temp + 1;
                Console.WriteLine("F[{0}] = {1} + 1", i, temp);
                WriteStorage(storage, i);
            }
            return storage[amount];
        }
    }
}