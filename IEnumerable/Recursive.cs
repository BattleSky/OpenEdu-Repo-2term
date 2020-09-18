using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerable
{
    public class Program
    {
        /*
         * Использовался в решении задачи разбиения:
         * Есть некое множество чисел, и надо разбить на две части так,
         * чтобы сумма чисел в каждой из частей была одинакова
         */
        static int[] weights = new int[] { 2, 3, 5 };

        // проверяет удовлетворяет ли subset критерию
        static void Evaluate(bool[] subset)
        {
            var delta = 0;
            for (int i = 0; i < subset.Length; i++)
                if (subset[i]) delta += weights[i];
                else delta -= weights[i];
            foreach (var e in subset)
                Console.Write(e ? 1 : 0);
            Console.Write(" ");
            if (delta == 0)
                Console.Write("OK");
            Console.WriteLine();
        }


        static IEnumerable<bool[]> MakeSubsets(bool[] subset, int position)
        {
            if (position == subset.Length)
            {
                yield return subset; //будет возвращать всегда один и тот же массив, заполненный разными числами
                //yield return subset.ToArray(); //будет возвращать разные массивы
                yield break; // завершает выполнение ленивого метода - выход из метода навсегда
            }
            subset[position] = false; // position номер множества
            foreach (var e in MakeSubsets(subset, position + 1))
                yield return e;
            subset[position] = true;
            foreach (var e in MakeSubsets(subset, position + 1))
                yield return e;
        }

        static void Main()
        {
            foreach (var subset in MakeSubsets(new bool[weights.Length], 0))
            {
                foreach (var e in subset)
                    Console.Write(e ? 1 : 0);
                Console.WriteLine();
            }

            foreach (var subset in MakeSubsets(new bool[weights.Length], 0))
            {
                Evaluate(subset);
            }
        }
    }
}
