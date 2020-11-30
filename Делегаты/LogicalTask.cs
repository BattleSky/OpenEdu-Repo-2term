using System;
using System.Collections.Generic;
using System.Text;

namespace Применение_делегатов
{
    class Class1
    {
        private static Func<int, int, int> Apply1(Func<int, int, int, int> func, int arg)
        {
            return (x, y) => func(x, arg, y);
        }

        private static Func<int, int> Apply2(Func<int, int, int> func, int arg)
        {
            return x => func(arg, x);
        }

        public static void Main0()
        {
            Func<int, int, int, int> f = (x, y, z) => x * y + z;
            var x0 = f(1, 2, 3); // 5
                /*
                 * Просто подстановка в f
                 * x0 = 5;
                 */
            var x1 = Apply1(f, 100)(1, 11); // 111
            /*
             * Пояснение: (1,11) - это аргументы для лямбда-фукции Apply1
             *
             * 1. Заходим в Apply1 - получаем на ссылку на функцию f(x, 100, y).
             * 2. Выполняем переданную в Apply1 лямбда-функцию f (специально переименованную как func)
             * 3. Получаем 1, 100, 11.
             * 4. x1 = 111;
             */

            var g = Apply2(Apply1(f, 10), 5);
            var x2 = g(3); 

            /*
             * Пояснение g(3): (3) это аргумент для лямбда-функции Apply2. По аналогии с предыдущим примером
             *
             * 1. Передаем в Apply2 ссылку на Apply1, аргумент (arg=5) и X (x=3);
             * 2. Заходим в Apply2, получаем ссылку на Apply1 с аргументами (5,3); 
             * 3. Заходим в Apply1, передаем аргумент (arg=10) и полученные ранее аргументы (5,3).
             * 4. Заходим в f с переданными аргументами (5,10,3), получаем 53.
             * 5. Полученное значение и есть результат выполнения g(3).
             * 6. x2 = 53.
             */
        }
	}
}
