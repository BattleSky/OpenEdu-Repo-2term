using System;

namespace Очередь_универсальная
{
    /*
     * Очередь - достаточно сложная структура данных,
     * и хочется сделать ее сразу для всех типов - 
     * очередь чисел, строк, и т.д.,
     * а не переписывать для каждого типа данных.
     * Простейшее решение - хранить value в виде object
     */
    public class QueueItem
    {
        public object Value { get; set; }
        public QueueItem Next { get; set; }
    }

    public class Queue
    {
        private QueueItem head;
        private QueueItem tail;

        public bool IsEmpty => head == null;

        public void Enqueue(object value)
        {
            if (IsEmpty)
            {
                tail = head = new QueueItem { Value = value, Next = null };
            }
            else
            {
                var item = new QueueItem { Value = value, Next = null };
                tail.Next = item;
                tail = item;
            }
        }

        public object Dequeue()
        {
            if (head == null) throw new InvalidOperationException();
            var result = head.Value;
            head = head.Next;
            if (head == null)
                tail = null;
            return result;
        }
    }

    public class Program
    {
        private static void Main()
        {
            var myIntQueue = new Queue();
            myIntQueue.Enqueue(10);
            myIntQueue.Enqueue(20);
            myIntQueue.Enqueue(30);

            //Но что, если кто-то напишет так?
            myIntQueue.Enqueue("Surprise!");

            var sum = 0;
            while (!myIntQueue.IsEmpty)
            {
                var value = (int)myIntQueue.Dequeue(); //здесь будет InvalidCastException
                sum += value;
            }
        }
    }
}
