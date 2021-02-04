using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace LINQ_Practice
{
    /*
     * Еще одно полезное свойство кортежей — они реализуют интерфейс IComparable,
     * сравнивающий кортежи по компонентам.
     * То есть Tuple.Create(1, 2) будет меньше Tuple.Create(2, 1).
     * Этот интерфейс по умолчанию используется
     * в методах сортировки и поиска минимума и максимума.
     *
       Используя этот факт, решите следующую задачу.
       
       Дан текст, нужно составить список всех встречающихся в тексте слов, 
    упорядоченный сначала по возрастанию длины слова, а потом лексикографически.
       
       Запрещено использовать ThenBy и ThenByDescending.
     */
    class TupleSort
    {
        public static void Mainx()
        {
            var vocabulary = GetSortedWords(
                "Hello, hello, hello, how low With the lights out, it's less dangerous " +
                "Here we are now; entertain us" +
                "I feel stupid and contagious" +
                "Here we are now; entertain us" +
                "A mulatto, an albino, a mosquito, my libido..." +
                "Yeah, hey"
            );
            foreach (var word in vocabulary)
                Console.WriteLine(word);
        }


        public static List<string> GetSortedWords(string text)
        {
            var result =
                text.Split(" ").Select(word =>
                    {
                        var resultword = Regex.Replace(word, @"\W+", "").ToLower();
                        return new Tuple<int, string>(resultword.Length, resultword);
                    })
                    .Where(tuple => tuple.Item2 != "")
                    .OrderBy(tuple => tuple.Item2)
                    .OrderBy(tuple => tuple.Item1)
                    .Distinct()
                    .Select(tuple => tuple.Item2)
                    .ToList();

            return result;
        }
    }
}
