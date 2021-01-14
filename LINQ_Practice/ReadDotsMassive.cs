using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace LINQ_Practice
{
    class ReadDotsMassive
    {
        public class Point
        {
            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
            public int X, Y;
        }

        public static void MainX()
        {
            // Функция тестирования ParsePoints

            foreach (var point in ParsePoints(new[] { "1 -2", "-3 4", "0 2" }))
                Console.WriteLine(point.X + " " + point.Y);
            foreach (var point in ParsePoints(new List<string> { "+01 -0042" }))
                Console.WriteLine(point.X + " " + point.Y);
        }
        
        public static List<Point> ParsePoints(IEnumerable<string> lines)
        {
            return lines
                .Select(oneString => oneString
                    .Split(' ')
                    .Select(int.Parse)
                    .ToArray())
                .Select(x => new Point(x[0], x[1]))
                .ToList();
        }
    }
}
