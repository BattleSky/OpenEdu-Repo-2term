using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Возврат_из_метода_нескольких_значений
{
    // Для возврата из метода нескольких значений лучше всего использовать класс
    // Так как он явлется простым в понимании,  а также расширяемым.
    class ClassSolution
    {
        static Random rnd = new Random();

        public class IntReply
        {
            public int Number { get; set; }
            public bool Available { get; set; }
        }

        public static IntReply GetNumber5()
        {
            for (int i = 0; i < 10; i++)
            {
                if (Console.KeyAvailable)
                    return new IntReply { Available = true, Number = rnd.Next(100) };
                Thread.Sleep(100);
            }
            return new IntReply { Available = false };
        }

        static void Main5()
        {
            var value = GetNumber5();
            if (value.Available)
                Console.WriteLine(value.Number);
            else
                Console.WriteLine("Error");
        }
    }
    
    // Но для решения локальных задач, можно использовать дженерик-класс Tuple
    // (чтобы не плодить классы)
    // Если пара имеет самостоятельный вид, то лучше использовать класс
    // (вместо tuple <int,int,int> для 3-мерной системы координат)
    class TupleGeneric
    {
        public static Tuple<bool, int> TryGetNumber()
        {
            var rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                if (Console.KeyAvailable)
                    return new Tuple<bool, int>(true, rnd.Next(100));
                Thread.Sleep(100);
            }

            return Tuple.Create(false, 0);
        }

        public static void Main7()
        {
            var value = TryGetNumber();
            if (value.Item1)
                Console.WriteLine(value.Item2);
            else
                Console.WriteLine("Nothing");
        }
    }
}
