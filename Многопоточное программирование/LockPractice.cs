using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Многопоточное_программирование
{
    class LockPractice
    {
        private static readonly List<int> list = new List<int>();

        static void MakeWork()
        {
            for (int i = 0; ; i++)
            {
                // если не поставить lock, возникнут странные,
                // плохо повторяемые и, возможно, редкие ошибки
                lock (list)
                {
                    list.Add(i);
                }
            }
        }

        static void MakeWorkNoLock()
        {
            for (int i = 0; ; i++) list.Add(i);
        }

        public static void Correct_syncronization()
        {
            new Action(MakeWork).BeginInvoke(null, null);
            var sw = Stopwatch.StartNew();
            while (sw.Elapsed < TimeSpan.FromSeconds(10))
            {
                lock (list)
                {
                    if (list.Count > 0) list.RemoveAt(0);
                }
            }
        }

        public static void Fail_without_syncronization()
        {
            new Action(MakeWorkNoLock).BeginInvoke(null, null);
            var sw = Stopwatch.StartNew();
            //Assert.That(
            //    () =>
            //    {
            //        while (sw.Elapsed < TimeSpan.FromSeconds(10))
            //        {
            //            if (list.Count > 0) list.RemoveAt(0);
            //        }
            //    }, Throws.Exception);
        }
    }
}
