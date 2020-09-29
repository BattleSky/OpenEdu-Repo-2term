using System;

namespace Списки_и_словари
{
    #region Теоретическая часть

    public class Program2
    {
        public static void Main2()
        {
            var p1 = new Point {X = 1, Y = 2};
            var p2 = new Point {X = 1, Y = 2};
            var p3 = p1;
            Console.WriteLine(p1 == p1); // true
            Console.WriteLine(p1 == p2); // false
            Console.WriteLine(p1 == p3); // true
            // сравнение ссылочных типов - это сравнение указателя на область памяти:
            // указывает ли ссылка на ту же область памяти или нет
            // для ссылочных типов эта вещь по умолчанию
            // по умолчанию ссылочные типы сравнивают:
            // равна ли ссылка на объект (тотже ли этот объект)?

            var s1 = new Size {Height = 1, Width = 2};
            var s2 = new Size {Height = 1, Width = 2};
            //Console.WriteLine(s1 == s2);
            //Ошибка компиляции: невозможно сравнивать структуры по умолчанию
        }
    }

    #endregion

    internal class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        //Equals позволяет определять логику "быть равным" для наших типов данных
        //Перегрузка оператора Equals не меняет работу оператора сравнения
        //Для структур Equals по умолчанию определен верно, для классов такие нужно создавать 
        public override bool Equals(object obj)
        {
            if (!(obj is Point)) return false;
            var point = obj as Point;
            return X == point.X && Y == point.Y;
        }

        // Переопределить также можно и оператор ==, но потребуется и переопределение оператора !=, так как они ходят парами
        // для структур используется аналогичная схема
        // equals и оператор сравнения (==) не одинаковы. 
        public static bool operator ==(Point p1, Point p2)
        {
            return p1.X == p2.X && p1.Y == p2.Y;
        }
        public static bool operator !=(Point p1, Point p2)
        {
            return !(p1 == p2);
        }

        // можно переопределить и операторы сложения
        public static Point operator +(Point p1, Point p2)
        {
            return new Point {X = p1.X + p2.X, Y = p1.Y + p2.Y};
        }
        // умножения, когда вторым аргументом приходит не поинт
        public static Point operator *(Point p1, int value)
        {
            return new Point { X = p1.X * value, Y = p1.Y * value };
        }
        // если перегружать оператор с аргументами не типа поинт в классе поинт,
        // то будет ошибка компиляции

        public override string ToString()
        {
            return string.Format("{0} {1}", X, Y);
        }

    }

    internal struct Size
    {
        public int Width { get; set; }
        public int Height { get; set; }
    }

    partial class MyList<T>
    {

        //Это неправильный метод Contains
        public bool WrongContains(T value)
        {
            for (var i = 0; i < count; i++)
                //if (collection[i] == value) return true; // == не определено для всех типов данных
                if ((object) collection[i] == (object) value)
                    return true; // - не имеет смысла, потому что будут сравниваться ссылки на объекты
            return false;
        }

        //Правильный метод Contains использует для сравнения виртуальный метод Equals
        public bool Contains(T value)
        {
            for (var i = 0; i < count; i++)
                if (collection[i].Equals(value))
                    return true;
            return false;
        }
    }

    internal class Program3
    {
        public static void Main5()
        {
            var point = new Point {X = 1, Y = 1};

            var list = new MyList<Point>();
            //var list = new List<PointOne>();

            list.Add(point);
            Console.WriteLine(list.Contains(point));
            Console.WriteLine(list.Contains(new Point {X = 1, Y = 1}));
        }
    }
}