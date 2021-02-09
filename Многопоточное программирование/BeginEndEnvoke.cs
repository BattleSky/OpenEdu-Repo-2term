using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Многопоточное_программирование
{
    class BeginEndEnvoke
    {
        static double MakeWork(int number)
        {
            double a = 1;

            for (int i = 0; i < 1000000; i++)
            for (int j = 0; j < 10; j++)
                a /= 1.01;
            Console.WriteLine(number);
            return a;
        }

        public static void Mainx()
        {
            var func = new Func<int, double>(MakeWork);
            var result = func.BeginInvoke(1, null, null);
            while (!result.IsCompleted)
                Console.Write(".");
            //в этом моменте основной тред ждет выполнения func, и
            // до конца его выполнения рисует точки на экране
            var returnedValue = func.EndInvoke(result);
            Console.WriteLine(returnedValue);
        }
	}
}
