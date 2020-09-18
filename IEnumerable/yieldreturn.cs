using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IEnumerable
{
    public class Queue<T> : IEnumerable<T>
    {
        //А это - то же самое, записанное с помощью yield return
        public IEnumerator<T> GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Value;
                // по достижении yield return в элемент foreach записывается значение current.Value, оно обрабатывается в цикле
                // в конце цикла происходит возврат в GetEnumerator для продолжения выполнения цикла while
                // по суи конструкция сокращает реализацию IEnumerator (как в IEnumerable_foreach)
                
                current = current.Next;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public QueueItem<T> Head { get; private set; }
        QueueItem<T> tail;

        public bool IsEmpty { get { return Head == null; } }

        public void Enqueue(T value)
        {
            if (IsEmpty)
                tail = Head = new QueueItem<T> { Value = value, Next = null };
            else
            {
                var item = new QueueItem<T> { Value = value, Next = null };
                tail.Next = item;
                tail = item;
            }
        }

        public T Dequeue()
        {
            if (Head == null) throw new InvalidOperationException();
            var result = Head.Value;
            Head = Head.Next;
            if (Head == null)
                tail = null;
            return result;
        }
    }
}
