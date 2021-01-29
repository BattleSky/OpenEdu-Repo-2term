using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace LINQ_Practice
{
    class CartesianProduct
    {
        public static void MainX()
        {
            foreach (var point in GetNeighbours(new Point(1, 2)))
            {
                Console.WriteLine(point.X + " " + point.Y);
            }
            Console.ReadLine();
        }

        public static IEnumerable<Point> GetNeighbours(Point p)
        {
            int[] d = { -1, 0, 1 }; // используйте подсказку, если не понимаете зачем тут этот массив :)
            
            return d.SelectMany(x => d.Select(y =>new Point(x: p.X+x, y: p.Y+y)))
                .Where(x => !x.Equals(p))
                .ToList();

            // Логика без LINQ (для удобства описания
            // var points = new List<Point>();
            //foreach (var x in d)
            //{
            //    var point = new Point();
            //    foreach (var y in d)
            //    {
            //        point.X = x + p.X;
            //        point.Y = y + p.Y;
            //            if (point == p) continue;
            //        Console.WriteLine(point.X + " " + point.Y);
            //    }
            //    points.Add(point);
            //}
            //return points;
        }
    }
}
