using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQ_Practice
{
    class ReadNumberMassive
    {
        /*
         * Пусть у вас есть файл, в котором каждая строка либо пустая,
         * либо содержит одно целое число.
         * Кто-то уже вызвал метод File.ReadAllLines(filename)
         * и теперь у вас есть массив всех строк этого файла.
         *
         * У вас даже есть метод Main, запускающий ваш метод на тестовых данных:
         */
        public static void Mainx()
        {
            foreach (var num in ParseNumbers(new[] { "-0", "+0000" }))
                Console.WriteLine(num);
            foreach (var num in ParseNumbers(new List<string> { "1", "", "-03", "0" }))
                Console.WriteLine(num);
        }

        public static int[] ParseNumbers(IEnumerable<string> lines)
        {
            return lines
                .Where(x => x != "")
                .Select(int.Parse) // аналог x => int.Parse(x)
                .ToArray();
        }
    }
}
