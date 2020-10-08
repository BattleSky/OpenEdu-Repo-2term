using System;

namespace DelegatesSample
{
    //Здесь объявляется тип указателей на функции, принимающие
    //две строки и возвращающие int.
    //Делегат - это не член класса! Это тип данных (указатель на функции,
    //которые принимают две строки в качестве аргумента и возвращают int)
    public delegate int StringComparer(string x, string y);
    // делегат объявляется не внутри класса, а внутри namespace
    // это не метод! это указатель на метод!
    
    public class Program
    {
        //Этот метод принимает указатель на соответствующие функции (принимающие две строки и вовзращающие инт)
        public static void SortStrings(string[] array, StringComparer comparer)
        {
            for (int i = array.Length - 1; i > 0; i--)
            for (int j = 1; j <= i; j++)
            {
                var element1 = array[j - 1];
                var element2 = array[j];
                //раз это указатель на функцию, значит, эту функцию можно вызвать
                if (comparer(element1, element2) > 0)
                {
                    var temporary = array[j];
                    array[j] = array[j - 1];
                    array[j - 1] = temporary;
                }
            }
        }

        //указатель на этот метод мередается в Main. 

        static int CompareStringLength(string x, string y)
        {
            return x.Length.CompareTo(y.Length);
        }


        static void MainX()
        {
            var strings = new[] { "A", "B", "AA" };
            //Здесь создается указатель на метод CompareStringLength
            var lengthComparer =
                new StringComparer(CompareStringLength);

            //... и передается в метод SortStrings
            SortStrings(strings, lengthComparer);

            //Можно писать так. Компилятор сам догадается, что вы хотели создать 
            //указатель на метод, а не вызвать его.
            SortStrings(strings, CompareStringLength);

        }
    }

    
    delegate void TellUser(string message);
    public class Practice
    {
        public static void Main2()
        {
            Run(Console.WriteLine);
        }

        static void Run(TellUser tellUser)
        {
            tellUser("hi!");
            tellUser("how r u?");
        }
    }
}