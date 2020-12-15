using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Графы_и_обходы
{

    // Обход лабиринта в глубину с помощью Рекурсии
    enum State1
    {
        Empty,
        Wall,
        Visited
    };

    public class Program1
    {
        static void Visit(State1[,] map, int x, int y)
        {
            if (x < 0 || x >= map.GetLength(0) || y < 0 || y >= map.GetLength(1)) return;
            if (map[x, y] != State1.Empty) return;
            map[x, y] = State1.Visited;
            Print(map);

            for (var dy = -1; dy <= 1; dy++)
            for (var dx = -1; dx <= 1; dx++)
                if (dx != 0 && dy != 0) continue;
                else Visit(map, x + dx, y + dy);
        }

        static void Main1()
        {
            var map = new State1[labyrinth[0].Length, labyrinth.Length];

            for (int x = 0; x < map.GetLength(0); x++)
            for (int y = 0; y < map.GetLength(1); y++)
                map[x, y] = labyrinth[y][x] == ' ' ? State1.Empty : State1.Wall;

            Print(map);
            Visit(map, 0, 0);
        }

        static string[] labyrinth = new string[]
        {
            " X   X    ",
            " X XXXXX X",
            "      X   ",
            "XXXX XXX X",
            "         X",
            " XXX XXXXX",
            " X        ",
        };

        static void Print(State1[,] map)
        {

            Console.CursorLeft = 0;
            Console.CursorTop = 0;
            for (int x = 0; x < map.GetLength(0) + 2; x++)
                Console.Write("X");
            Console.WriteLine();
            for (int y = 0; y < map.GetLength(1); y++)
            {
                Console.Write("X");
                for (int x = 0; x < map.GetLength(0); x++)
                    switch (map[x, y])
                    {
                        case State1.Wall: Console.Write("X"); break;
                        case State1.Empty: Console.Write(" "); break;
                        case State1.Visited: Console.Write("."); break;
                    }
                Console.WriteLine("X");
            }
            for (int x = 0; x < map.GetLength(0) + 2; x++)
                Console.Write("X");
            Console.ReadKey();
        }
    }
}
