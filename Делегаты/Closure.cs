using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Делегаты
{
    // https://ulearn.me/Courses/BasicProgramming2/L030_Delegates/map2.png
    class Closure
    {
        #region 1
        public static void Sort<T>(T[] array, Func<T, T, int> comparer)
        {
            for (int i = array.Length - 1; i > 0; i--)
            for (int j = 1; j <= i; j++)
            {
                var element1 = array[j - 1];
                var element2 = array[j];
                if (comparer(element1, element2) > 0)
                {
                    var temporary = array[j];
                    array[j] = array[j - 1];
                    array[j - 1] = temporary;
                }
            }
        }

        static void MainX()
        {
            //Когда локальная переменная используется внутри лямбда-выражения - это замыкание
            bool Descending = true;
            /*
             * Для того, чтобы "закинуть" в анонимный метод, реализованный через лямбда-выражение,
             * поле Descending метода Main
             * компилятор создает анонимный КЛАСС для того,
             * чтобы там хранить значение этого поля
             * так и для остальных полей, используемых в замыкании
             */
            Func<string, string, int> cmp =
                (x, y) => x.CompareTo(y) * (Descending ? -1 : 1);
            /*
             * Лямбда-выражением при этом становится динамическим методом,
             * а не статическим. Тем самым объект из которого вызывается лямбда (Target)
             * и является тем самым объектом анонимного типа
             */
            var strings = new[] { "A", "B", "AA" };
            Sort(strings, cmp);
            Descending = false;
            Sort(strings, cmp);
        }
        #endregion

        #region 2

        public static void Mainx()
        {
            var functions = new List<Func<int, int>>();

            for (int i = 0; i < 10; i++)
                functions.Add(x => x + i);

            //Этот код выведет десять раз "10", потому что i ушла в замыкание
            //и общая для всех лямбд в списке
            foreach (var e in functions)
                Console.WriteLine(e(0));

            functions = new List<Func<int, int>>();

            for (int i = 0; i < 10; i++)
            {
                var j = i;
                functions.Add(x => x + j);
            }

            //Этот код выведет числа от 0 до 10,
            //потому что j - локальная для цикла,
            //и соответственно своя на каждой итерации и у каждой лямбды
            foreach (var e in functions)
                Console.WriteLine(e(0));
        }

        #endregion
    }
}
