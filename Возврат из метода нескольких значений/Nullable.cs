using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Возврат_из_метода_нескольких_значений
{
    class Nullable
    {

        static Random rnd = new Random();

        // в данном случае int? является nullable int
        // делается это для возможности работы с полем, как с null-типом
        static int? GetNumber7()
        {
            //это может выглядеть вот так
            //var nullable = new Nullable<int>();
            for (int i = 0; i < 10; i++)
            {
                if (Console.KeyAvailable)
                    return rnd.Next(100);
                Thread.Sleep(100);
            }
            return null;
        }

        static void Main7()
        {
            var value = GetNumber7();
            // например можно использовать сравнение с null тут
            // при том, что Nullable - это структура
            if (value != null)
                Console.WriteLine(value);
            else
                Console.WriteLine("Error");
        }
    }
}
