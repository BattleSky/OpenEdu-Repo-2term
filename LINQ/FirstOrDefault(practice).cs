using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace LINQ
{
    /*
     * Реализуйте метод FirstOrDefault, который принимает на вход
     * последовательность и предикат,
     * а возвращает первый элемент, который удовлетворяет предикату.
     * Если последовательность пуста или не удалось найти ни один элемент,
     * удовлетворяющий предикату, то необходимо вернуть default(T).
     */
    class FirstDefault
    {
        private static T FirstOrDefault1<T>(IEnumerable<T> source, Func<T, bool> filter)
        {
            foreach (var element in source)
                if (filter(element))
                    return element;
            return default;
        }

        // Неплохой вариант с лямбдой

        private static T FirstOrDefault<T>(IEnumerable<T> source, Func<T, bool> filter)
        {
            return source.FirstOrDefault(e => filter(e));
        }



        public static void Mainx()
        {
            Assert.AreEqual(0, FirstOrDefault(new int[0], x => true)); // default(int) == 0
            Assert.AreEqual(null, FirstOrDefault(new string[0], x => true)); // default(string) == null
            Assert.AreEqual(3, FirstOrDefault(new[] { 1, 2, 3 }, x => x > 2));
            Assert.AreEqual(3, FirstOrDefault(new[] { 3, 2, 1 }, x => x > 2));
            Assert.AreEqual(3, FirstOrDefault(new[] { 2, 3, 1 }, x => x > 2));
          //  CheckYieldReturn();

            Console.WriteLine("OK");
        }

	}
}
