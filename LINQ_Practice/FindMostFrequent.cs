using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LINQ_Practice
{
    class FindMostFrequent
    {
        public static void Mainx()
        {
            var words = "a a A A A b s w e f s r w s s s s a w zs eqw eqw das da sd";

            GetMostFrequentWords(words, 5);
        }


        public static Tuple<string, int>[] GetMostFrequentWords(string text, int count)
        {
            return Regex.Split(text.ToLower(), @"\W+")
                .Where(word => word != "")
                .GroupBy(name => name)
                .Select(word => Tuple.Create(word.Key, word.Count()))
                .OrderByDescending(tuple => tuple.Item2)
                .ThenBy(tuple => tuple.Item1)
                .Take(count)
                .ToArray();
        }

    }
}
