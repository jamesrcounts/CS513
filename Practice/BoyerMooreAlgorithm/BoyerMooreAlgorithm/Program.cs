using System;
using System.Collections.Generic;

namespace BoyerMooreAlgorithm
{
    public class Program
    {
        public static IDictionary<int, int> GoodSuffixTable(string pattern)
        {
            var table = new Dictionary<int, int>();
            int m = pattern.Length;
            int n = m - 1;
            for (int k = 1; k < m; k++)
            {
                int prefixLength = m - k;
                string suffix = pattern.Substring(prefixLength);
                int shift = 1;

                for (int j = n - k; j >= 0; j--)
                {
                    // Match?
                    int l = 0;
                    while (l < k && pattern[j + l] == suffix[l])
                    {
                        l++;
                    }
                    if (k == l &&
                        (j == 0 ||
                        pattern[j - 1] != pattern[prefixLength - 1]))
                    {
                        table[k] = shift;
                        break;
                    }
                    else
                    {
                        //no
                        shift++;
                    }
                }

                // Check for prefix;
                if (!table.ContainsKey(k) || table[k] == m)
                {
                    for (int x = k - 1; x >= 0; x--)
                    {
                        if (pattern.StartsWith(suffix.Substring(k - x)))
                        {
                            table[k] = pattern.Length - x;
                            break;
                        }
                    }
                }
            }
            return table;
        }

        private static int BoyerMoore(string pattern, string text)
        {
            /* Preprocessing */
            var suffix = GoodSuffixTable(pattern);
            suffix[0] = 0;

            var shift = ShiftTable(pattern, text);

            /* Searching */
            int m = pattern.Length;
            int patternSize = m - 1;
            int i = patternSize;
            while (i <= text.Length - 1)
            {
                Console.WriteLine(text);
                Console.WriteLine("{0}{1}", new string(' ', i - m + 1), pattern);

                // Figure out how many characters match
                int k = 0;
                while (k <= patternSize && pattern[patternSize - k] == text[i - k])
                {
                    k++;
                }

                // Did we find a complete match
                if (k == m)
                {
                    // i points at the end of the match,
                    // return the beginning
                    return i - m + 1;
                }
                else
                {
                    // Move as much as possible.
                    char c = text[i - k];
                    int d1 = Math.Max(shift[c] - k, 1);
                    int d = Math.Max(d1, suffix[k]);
                    i += d;
                }
            }

            return -1;
        }

        private static void Main()
        {
            string text = "BESS KNEW ABOUT BAOBABS";
            string pattern = "BAOBAB";

            Console.WriteLine("Found {0} at {1}", pattern, BoyerMoore(pattern, text));
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