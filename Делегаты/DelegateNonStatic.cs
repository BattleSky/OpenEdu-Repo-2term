using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Делегаты
{
    // картинка https://courses.openedu.ru/assets/courseware/v1/e0f65aac904be975cf0c9f83ce67547a/asset-v1:urfu+PRGRMM+fall_2020+type@asset+block/e124f54d-e537-4d02-b526-a2e45278e54f1_map1.png
    public class Program3
    {
        public delegate int StringComparer(string x, string y);
        class Comparer
        {
            public bool Descending { get; set; }
            public int CompareStrings(string x, string y)
            {
                return x.CompareTo(y) * (Descending ? -1 : 1);
            }
        }

        static void Main8()
        {
            var strings = new[] { "A", "B", "AA" };
            var lengthComparer =
                new StringComparer(CompareStringLength);
            SortStrings(strings, lengthComparer);


            var obj = new Comparer { Descending = true };

            //Можно без проблем указывать на динамические методы.
            //Для того, чтобы указать на метод, нужно обратиться к нему как для вызова
            //(с указанием объекта для динамических методов, указанием класса 
            // для статических методов, определенных в другом классе),
            //НО БЕЗ КРУГЛЫХ СКОБОК.
            var simpleComparer =
                new StringComparer(obj.CompareStrings);
            SortStrings(strings, simpleComparer);
        }

        public static void SortStrings(string[] array, StringComparer comparer)
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


        static int CompareStringLength(string x, string y)
        {
            return x.Length.CompareTo(y.Length);
        }


    }
}
