using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class Student1
    {
        public string LastName { get; set; }
        public string Group { get; set; }
    }

    // Как уложить знания по всему курсу в 5 строчек.
    public static class IEnumerableExtensions //IEnumerable, Extensions
    {
        public static IEnumerable<T> Where<T>(this IEnumerable<T> enumerable, Func<T, bool> predicate) // Дженерики, делегаты
        {
            foreach (var e in enumerable)
                if (predicate(e))
                    yield return e; // yield return
        }
    }

    public class Program1
    {
        public static void MainX()
        {
            var students = new List<Student1>
            {
                new Student1 { LastName="Jones", Group="FT-1" },
                new Student1 { LastName="Adams", Group="FT-1" },
                new Student1 { LastName="Williams", Group="KN-1"},
                new Student1 { LastName="Brown", Group="KN-1"}
            };

            var result = students
                .Where(z => z.Group == "KN-1");
            //.Select(z => z.LastName).
            //ToList();
        }
    }
}
