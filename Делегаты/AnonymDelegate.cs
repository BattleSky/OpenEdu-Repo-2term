using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Делегаты
{
    class AnonymDelegate
    {
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

        static void Main5()
        {
            var strings = new[] { "A", "B", "AA" };
            //Анонимный делегат позволяет не писать метод, а определить его по месту использования
            //Компилятор напишет метод за вас и сам придумает ему имя и тип возвращаемого значения
            //Это позволяет еще больше сократить объем инфраструктурного кода.
            Sort(strings,
                delegate (string x, string y) 
                    {
                    return x.Length.CompareTo(y.Length);
                    }
                );
        }
	}
}
