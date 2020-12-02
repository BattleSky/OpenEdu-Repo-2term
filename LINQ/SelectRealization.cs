using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class Student2
    {
        public string LastName { get; set; }
        public string Group { get; set; }
    }

    // Вот так выглядит в целом реализация методов Where и Select в LINQ. 
    public static class IEnumerableExtensions2
    {
        public static IEnumerable<T> Where1<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate)
        {
            foreach (var e in enumerable)
                if (predicate(e))
                    yield return e;
        }

        public static IEnumerable<TOut> Select<TIn, TOut>(this IEnumerable<TIn> enumerable, Func<TIn, TOut> selector)
        {
            foreach (var e in enumerable)
                yield return selector(e);
        }

        public static List<T> ToList<T>(this IEnumerable<T> enumerable)
        {
            var list = new List<T>();
            foreach (var e in enumerable)
                list.Add(e);
            return list;
        }
    }

    public class Program2
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
                .Where1(z => z.Group == "KN-1")
                .Select(z => z.LastName)
                .ToList();
        }
    }
}
