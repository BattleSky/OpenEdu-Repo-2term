using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Списки_и_словари
{
    class PointOne
    {
        public int X { get; set; }
        public int Y { get; set; }
        /*
         * Причина такой организации: желание показать, что в словаре находятся 
         * одинаковые объекты. Эти объекты, конечно, указывают на разные объекты
         * в памяти, но по логике программы они одинаковые.
         * Поэтому переопределяется метод Equals и GetHashCode.
         * Если сделать структуру, то Equals и GetHashCode будут работать верно, а значит
         * переопределеять его не нужно и всё будет работать
         */
        public override bool Equals(object obj)
        {
            var point = obj as Point;
            return X == point.X && Y == point.Y;
        }
        /*
         * Метод вычисляет хэш, который должен получать хэшкод
         * одинаковый для одинаковых с нашей точки зрения объектов
         * Это делается из-за построения в Dictionary способа поиска:
         * [список хэшей ключей] -> [список пар ключ-значение]
         */
        public override int GetHashCode()
        {
            /*
             * При вычислении хеш-функций может случаться арифметическое переполнение.
             * Компилятор по-разному обрабатывает переполнение в зависимости от настроек
             * (см. свойства проекта → Build → Advanced) — либо игнорирует,
             * отбрасывая старшие лишние биты, либо генерирует ошибку.
             * При вычислении хеш-функции разумно всегда игнорировать переполнение.
             * Это можно сделать, обернув вычисление хеш-функции в конструкцию unchecked вот так:
             */
            unchecked
            {
                return X * 1023 + Y;
            }
        }
    }

    public class Program
    {
        static void Main7()
        {
            var point1 = new Point { X = 1, Y = 1 };
            var dictionary = new Dictionary<Point, string>();
            dictionary[point1] = "Test";
            Console.WriteLine(dictionary[point1]);
            var point2 = new Point { X = 1, Y = 1 };
            Console.WriteLine(dictionary[point2]);
        }
    }
}
