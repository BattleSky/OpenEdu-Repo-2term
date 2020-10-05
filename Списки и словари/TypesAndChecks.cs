using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Списки_и_словари
{
    class TypesAndChecks
    {

        //Оператор is проверяет, совместим ли тип среды
        //выполнения для результата определенного
        //выражения с указанным типом.

        public class Base { }
        public class Derived : Base { }
        public static class IsOperatorExample
        {
            public static void MainX()
            {
                object b = new Base();
                Console.WriteLine(b is Base);  // output: True
                Console.WriteLine(b is Derived);  // output: False

                object d = new Derived();
                Console.WriteLine(d is Base);  // output: True
                Console.WriteLine(d is Derived); // output: True
            }
        }

        //Оператор typeof получает экземпляр System.Type
        //для указанного типа.
        //ператор typeof принимает в качестве аргумента
        //имя типа или параметр типа

        void PrintType<T>() => Console.WriteLine(typeof(T));

        public void MainX()
        {
            Console.WriteLine(typeof(List<string>));
            PrintType<int>();
            PrintType<System.Int32>();
            PrintType<Dictionary<int, char>>();
        }
        // Output:
        // System.Collections.Generic.List`1[System.String]
        // System.Int32
        // System.Int32
        // System.Collections.Generic.Dictionary`2[System.Int32,System.Char]
        

        // Используйте оператор typeof для проверки,
        // совместим ли тип среды выполнения для
        // определенного выражения с указанным типом.
        // В следующем примере показано различие
        // между проверкой типов с помощью оператора
        // typeof и оператора is:

        public class Animal { }
        public class Giraffe : Animal { }
        public static class TypeOfExample
        {
            public static void MainX()
            {
                object b = new Giraffe();
                Console.WriteLine(b is Animal);  // output: True
                Console.WriteLine(b.GetType() == typeof(Animal));  // output: False

                Console.WriteLine(b is Giraffe);  // output: True
                Console.WriteLine(b.GetType() == typeof(Giraffe));  // output: True
            }
        }
    }
}
