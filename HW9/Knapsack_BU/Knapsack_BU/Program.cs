using System;
using System.Linq;

namespace Knapsack_BU
{
    internal class Program
    {
        private static int Knapsack(int[] weights, int[] values, int capacity)
        {
            int[,] storage = new int[weights.Length + 1, capacity + 1];
            for (int i = 0; i <= weights.Length; i++)
            {
                storage[i, 0] = 0;
            }

            for (int j = 0; j <= capacity; j++)
            {
                storage[0, j] = 0;
            }

            for (int i = 1; i <= weights.Length; i++)
            {
                for (int j = 1; j <= capacity; j++)
                {
                    if (j - weights[i - 1] >= 0)
                    {
                        Console.WriteLine("V[{0},{1}] = max({2}, {3} + {4})", i, j, storage[i - 1, j], values[i - 1], storage[i - 1, j - weights[i - 1]]);
                        storage[i, j] = Math.Max(storage[i - 1, j], values[i - 1] + storage[i - 1, j - weights[i - 1]]);
                    }
                    else
                    {
                        Console.WriteLine("V[{0}.{1}] = V[{2},{1}]", i, j, i - 1);
                        storage[i, j] = storage[i - 1, j];
                    }
                }
                WriteTable(storage, capacity, weights.Length);
            }

            WriteTable(storage, capacity, weights.Length);
            return storage[weights.Length, capacity];
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Value: {0}", Knapsack(new[] { 3, 2, 1, 4, 5 }, new[] { 25, 20, 15, 40, 50 }, 6));
        }

        private static void WriteTable(int[,] storage, int capacity, int count)
        {
            Console.WriteLine();
            Console.WriteLine(" | {0}", string.Join("  | ", Enumerable.Range(0, capacity + 1)));
            for (int i = 0; i <= count; i++)
            {
                Console.Write(i);
                for (int j = 0; j <= capacity; j++)
                {
                    Console.Write("| {0}{1}", storage[i, j], new string(' ', 3 - storage[i, j].ToString().Length));
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}