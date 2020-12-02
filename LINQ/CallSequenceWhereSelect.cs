using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{

    // Вот так выглядит в целом реализация методов Where и Select в LINQ. 
    public static class IEnumerableExtensions3
    {
        public static IEnumerable<T> Where2<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
        {
            foreach (var e in enumerable)
                if (predicate(e))
                    yield return e;
        }

        public static IEnumerable<TOut> Select2<TIn, TOut>(this IEnumerable<TIn> enumerable, Func<TIn, TOut> selector)
        {
            foreach (var e in enumerable)
                yield return selector(e);
        }

        public static List<T> ToList2<T>(this IEnumerable<T> enumerable)
        {
            var list = new List<T>();
            foreach (var e in enumerable)
                list.Add(e);
            return list;
        }
    }

    public class Program3
    {
        public static void MainX()
        {
            var students = new List<Student2>
            {
                new Student2 { LastName="Jones", Group="FT-1" },
                new Student2 { LastName="Adams", Group="FT-1" },
                new Student2 { LastName="Williams", Group="KN-1"},
                new Student2 { LastName="Brown", Group="KN-1"}
            };

            var result = students
                .Where2(z => z.Group == "KN-1")
                .Select2(z => z.LastName);

            /* 
             * Без метода ToList:
             * При таком вызове, сначала выполняется foreach из-за того, что
             * Where и Select - это методы, возвращающие перечисления с помощью конструкции
             * yield return - ленивые методы. Они не возвращают значения пока не будут востребованы.
             * После того, как нам понадобится значение - мы сначала войдем в метод Select.
             * При достижении predicate в методе Where, мы опускаемся в лямбда-выражение z => z.Group == "KN-1"
             */
            var result2 = students
                .Where2(z => z.Group == "KN-1")
                .Select2(z => z.LastName)
                .ToList();
            /*
             * С методом ToList:
             * В метод ToList мы зайдем сразу при выполнении программы, так как это НЕ ленивый метод.
             * Из него мы будем заходить в Where и Select 
             */
            var result3 = students
                .Where2(z => z.Group == "KN-1")
                .Select2(z => z.LastName)
                .ToList()
                .Where2(z => z[0] == 'B')
                .Select2(z => z.Length);
            /*
             * С такой констуркцией мы всё равно сначала войдем в метод ToList, потому что это нормальный метод
             * После его выполнения мы перейдем к foreach, так как другие методы являются ленивыми
             */


            foreach (var e in result)
            {
                Console.WriteLine(e);
            }
        }
    }
}
