using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Transactions;

namespace LINQ_Practice
{
    class SortWords
    {
        /*
         * Текст задан массивом строк. Вам нужно составить лексикографически
         * упорядоченный список всех встречающихся в этом тексте слов.
         * Слова нужно сравнивать регистронезависимо, а выводить в нижнем регистре.            
         */
        public static void MainX()
        {
            var vocabulary = GetSortedWords(
                "Hello, hello, hello, how low",
                "",
                "With the lights out, it's less dangerous",
                "Here we are now; entertain us",
                "I feel stupid and contagious",
                "Here we are now; entertain us",
                "A mulatto, an albino, a mosquito, my libido...",
                "Yeah, hey"
            );
            foreach (var word in vocabulary)
                Console.WriteLine(word);
        }

        public static string[] GetSortedWords(params string[] textLines)
        {
            return textLines
                .SelectMany(line => Regex.Split(line, @"\W+"))
                .Select(word => Regex.Replace(word, @"\W+", "").ToLower())
                .Where(word => word != "")
                .ToList().OrderBy(n => n).Distinct()
                .ToArray();
        }

        public static string[] GetSortedWordsBAD(params string[] textLines)
        {
            var charsToRemove = new[] { ",", ";", "."};
            var listOfWords = textLines
                .SelectMany(line => 
                    line.Split(' ', '\''), (line, word) => charsToRemove
                        .Aggregate(word, (current, c) => current.Replace(c, "")
                    .ToLower()))
                .Where(resultWord => resultWord != "")
                .ToList();
            var result = listOfWords.OrderBy(n => n).Distinct().ToArray();
            return result;
        }
    }
}
