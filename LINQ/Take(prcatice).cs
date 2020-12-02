using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LINQ
{
    /*
     * Реализуйте метод Take с использованием yield return,
     * который принимает на вход последовательность source и число count,
     * а возвращает последовательность только из первых count элементов source.
     *
     * Если source содержит меньше count элементов, то вернуть нужно все элементы source.
     */

    class TakeLINQ
    {
        // моё решение
        private static IEnumerable<T> Take<T>(IEnumerable<T> source, int count)
        {
            var counter = 0;
            if (count == 0) yield break;
            foreach (var e in source)
            {
                yield return e;
                counter++;
                if (counter == count)
                    yield break;
            }
        }

        // решение через Интерфейсные методы

        private static IEnumerable<T> Take1<T>(IEnumerable<T> source, int count)
        {
            var e = source.GetEnumerator();
            while (count-- > 0 && e.MoveNext())
                yield return e.Current;
        }

        // Не надо создавать счетчик, отнимай от полученного 

        private static IEnumerable<T> Take2<T>(IEnumerable<T> source, int count)
        {
            if (count == 0)
                yield break;
            foreach (var e in source)
            {
                yield return e;
                if (--count == 0)
                    yield break;
            }
        }


        public static void Main()
        {
            Func<int[], int, string> take = (source, count) => string.Join(" ", Take(source, count));

            Assert.AreEqual("1 2", take(new[] { 1, 2, 3, 4 }, 2));
            Assert.AreEqual("4", take(new[] { 4 }, 1));
            Assert.AreEqual("", take(new[] { 5 }, 0));

            var num = new Random().Next(0, 1000);
            Assert.AreEqual(num.ToString(), take(new[] { num }, 100500));

            //CheckLazyness();
            Console.WriteLine("OK");
        }
	}
}
