using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Возврат_из_метода_нескольких_значений
{
    /* При помощи ref и out можно объявить несколько возвращаемых методом полей
     Но ref устанавливает двусторонее соответствие: можно изменить значение до входа в метод и 
    этим повлиять на работу метода. 
    Out работает в одностороннем порядке, надо указать, что мы хотим получить
    Без инициализации поля не получится получить значение из метода. При наличии инструкции out
    */
    class Out
    {
        static Random rnd = new Random();

        public static bool GetNumber3(ref int value)
        {
            for (int i = 0; i < 10; i++)
            {
                if (Console.KeyAvailable)
                {
                    value = rnd.Next(100);
                    return true;
                }
                Thread.Sleep(100);
            }
            return false;
        }

        static void Main3()
        {
            int value = 0;
            if (!GetNumber3(ref value))
                Console.WriteLine("Error");
            else
                Console.WriteLine(value);
        }

        public static bool GetNumber4(out int value)
        {
            //Console.WriteLine(value); // value не может быть использовано до присвоения внутри метода
            for (int i = 0; i < 10; i++)
            {
                if (Console.KeyAvailable)
                {
                    value = rnd.Next(100);
                    return true;
                }
                Thread.Sleep(100);
            }
            //value обязано быть присвоено до выхода из метода
            value = 0;
            return false;
        }

        static void Main4()
        {
            int value;
            if (!GetNumber4(out value))
                Console.WriteLine("Error");
            else
                Console.WriteLine(value);
        }
    }
}
