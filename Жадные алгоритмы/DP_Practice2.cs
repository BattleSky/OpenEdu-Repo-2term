using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Жадные_алгоритмы
{
    class DP_Practice2
    {
        public static void Main()
        {

            var result1 = LevenshteinDistance("a", "a");
            var result2 = LevenshteinDistance("a", "aa");
            var result3 = LevenshteinDistance("кот", "клон");
            var result4 = LevenshteinDistance("yabx", "abcd");
            var result5 = LevenshteinDistance("студент", "солдат");
            var result6 = LevenshteinDistance("жизньпрекраснакогдамногоденег", "жизньпрекрасна");
            var result7 = LevenshteinDistance("жизньпрекрасна", "жизньпрекраснакогдамногоденег");


            Console.WriteLine("Result1 (must be 0): {0}, \nResult2(must be 1): {1}, \nResult3 (must be 2): {2}, \nResult4 (must be 3): {3}, \nResult5 (must be 4): {4}\nResult6(long->short) (must be 15): {5}\nResult7(short->long) (must be 15): {6}",
                result1, result2, result3, result4, result5, result6, result7);
            Console.Read();
        }

        public static int LevenshteinDistance(string first, string second)
        {
            var opt = new int[first.Length + 1, second.Length + 1];

            for (var i = 1; i <= first.Length; ++i) opt[i, 0] = opt[i-1, 0] + 1;
            for (var i = 1; i <= second.Length; ++i) opt[0, i] = opt[0, i-1] + 1;

            for (var i = 1; i <= first.Length; ++i)
                for (var j = 1; j <= second.Length; ++j)
                {
                    if (first[i - 1] == second[j - 1])
                    {
                        opt[i, j] = Math.Min(opt[i - 1, j], Math.Min(opt[i, j - 1], opt[i - 1, j - 1]));

                        if (i == first.Length && first.Length < second.Length)
                            opt[first.Length, second.Length] = opt[i, j] + (second.Length - first.Length);
                    }
                    else
                        opt[i, j] = Math.Min(opt[i - 1, j] + 1, Math.Min(opt[i, j - 1] + 1, opt[i - 1, j - 1] + 1));
                }
            return opt[first.Length, second.Length];
        }
    }
}
