using System;
using System.Collections.Generic;

namespace HorspoolsAlgorithm
{
    internal class Program
    {
        private static int Horspool(string pattern, string text)
        {
            Dictionary<char, int> shift = ShiftTable(pattern, text);
            int m = pattern.Length;
            int i = m - 1;

            while (i <= text.Length - 1)
            {
                Console.WriteLine(text);
                Console.WriteLine("{0}{1}", new string(' ', i - m + 1), pattern);
                int k = 0;
                while (k <= m - 1 && pattern[m - 1 - k] == text[i - k])
                {
                    k++;
                }
                if (k == m)
                {
                    return i - m + 1;
                }
                else
                {
                    i += shift[text[i]];
                }
            }
            return -1;
        }

        private static void Main(string[] args)
        {
            string text = "BESS KNEW ABOUT BAOBABS";
            string pattern = "BAOBAB";

            Console.WriteLine("Found {0} at {1}", pattern, Horspool(pattern, text));
        }

        private static Dictionary<char, int> ShiftTable(string pattern, string text)
        {
            Dictionary<char, int> table = new Dictionary<char, int>();
            foreach (var c in text)
            {
                table[c] = pattern.Length;
            }

            for (int i = 0; i < pattern.Length - 1; i++)
            {
                table[pattern[i]] = pattern.Length - 1 - i;
            }

            return table;
        }
    }
}