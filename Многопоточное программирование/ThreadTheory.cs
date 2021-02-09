using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Многопоточное_программирование
{
    class ThreadTheory
    {
        static void MakeWork(int number)
        {
            double a = 1e10;
            while (true)
            {
                for (int i = 0; i < 1000000; i++)
                    a /= 1.001;
                Console.WriteLine(number + " " + a);
            }
        }

        public static void Mainx()
        {
            var thread = new Thread(() => MakeWork(1));
            thread.Start();
            thread = new Thread(() => MakeWork(2));
            thread.Start();
            thread = new Thread(() => MakeWork(3));
            thread.Start();
            thread = new Thread(() => MakeWork(4));
            thread.Start();
            thread = new Thread(() => MakeWork(5));
            thread.Start();
            thread = new Thread(() => MakeWork(6));
            thread.Start();
            thread = new Thread(() => MakeWork(7));
            thread.Start();
            thread = new Thread(() => MakeWork(8));
            thread.Start();
            thread = new Thread(() => MakeWork(9));
            thread.Start();
            thread = new Thread(() => MakeWork(10));
            thread.Start();
            thread = new Thread(() => MakeWork(11));
            thread.Start();
            thread = new Thread(() => MakeWork(12));
            thread.Start();
            Thread.Sleep(Timeout.Infinite);
        }
    }
}
