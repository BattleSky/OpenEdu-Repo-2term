using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Делегаты
{
    class Lambda
    {
        #region Лямбда на сортировке

        

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
            var strings = new[] { "A", "B", "AA" };
            //Лямбда-выражение - еще более краткая форма записи.
            //Теперь компилятор догадывается не только до типа возвращаемого значения,
            //но и до типа аргументов. 
            //Обратите внимание, что типы во всей программе выводятся из строки с 
            //объявлением массива!
            Sort(strings, (x, y) => x.Length.CompareTo(y.Length));
        }

        #endregion


        #region Ещё примеры с лямбдой

        


        static Random rnd = new Random();

        static void MainY()
        {
            Func<int, int> f = x => x + 1;

            Console.WriteLine(f(1));

            //функция, выдающее новое случайное число
            //здесь лямбда выражение не принимает никаких параметров
            Func<int> generator = () => rnd.Next();

            Console.WriteLine(generator());

            //лямбда выражение из нескольких строчек
            //тут ставятся фигурные скобки и return
            Func<double, double, double> h = (a, b) =>
            {
                b = a % b;
                return b % a;
            };

            //лямбда ничего не возвращает
            Action<int> print = x => Console.WriteLine(x);

            print(generator());

            // лямбда, которая ничего не принимает и не возвращает
            Action printRandomNumber = () => Console.WriteLine(rnd.Next());
            //можно собрать из других делегатов
            Action printRandomNumber1 = () => print(generator());
        }
        #endregion

        #region Задачки с лямбдой

        private static readonly Func<int> zero = () => 0 ;
        private static readonly Func<int, string> toString = x => x.ToString();
        private static readonly Func<double, double, double> add = (a,b) => a+b;
        private static readonly Action<string> print = Console.WriteLine;


        private static void Main6()
        {
            Assert.AreEqual(0, zero());

            Assert.AreEqual("42", toString(42));
            Assert.AreEqual("123", toString(123));

            Assert.AreEqual(3.14, add(1.1, 2.04));
            Assert.AreEqual(0, add(-1, 1));

            print("passed!");
            Console.ReadLine();
        }

        static Func<T1, T3> Combine<T1, T2, T3>(Func<T1, T2> f, Func<T2, T3> g)
        {
            Func<T1, T3> result = (f, g) => g;
        }

        public static void Main()
        {
            Func<int, string> toString = x => x.ToString("X"); // hex
            Func<double, int> round = x => (int)Math.Round(x);
            var f1 = Combine(round, toString);
            Console.WriteLine(f1(3.14)); // 3
            Console.WriteLine(f1(10.9)); // B 

            Func<int, int> doubleValue = x => 2 * x;
            Func<int, int> minusOne = x => x - 1;
            var f2 = Combine(minusOne, doubleValue);
            Console.WriteLine(f2(2)); // 2
            Console.WriteLine(f2(5)); // 8

            Console.ReadLine();
        }

        #endregion
    }
}
