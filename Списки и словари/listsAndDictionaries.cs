using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Списки_и_словари
{
    public partial class MyList<T> : IEnumerable<T>
    {
        public T[] collection;
        int count = 0;
        public MyList()
        {
            collection = new T[100];
        }
        void Enlarge()
        {
            throw new NotImplementedException();
        }
        public void Add(T value)
        {
            if (count == collection.Length)
                Enlarge();
            collection[count++] = value;
        }
        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < count; i++)
                yield return collection[i];
        }
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        /*
         * Для того, чтобы можно было обратиться к index элементу нашего листа, нужно сделать вот такую конструкцию:
         * По сути индексация в листе реализуется именно так.
         * Не обязательно чтобы index был интом, можно и любой другой тип данных
         */
        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count) throw new IndexOutOfRangeException();
                return collection[index];
            }
            set
            {
                if (index < 0 || index >= count) throw new IndexOutOfRangeException();
                collection[index] = value;
            }
        }
    }

    public class Program1
    {
        public static void Main()
        {
            var list = new MyList<int>();
            list.Add(1);
            list.Add(2);
            list.Add(3);

            foreach (var e in list)
                Console.WriteLine(e);
        }
    }
}
