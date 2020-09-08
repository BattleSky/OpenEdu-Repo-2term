using System;

namespace Дженерик_классы
{
    public class QueueItem<T> // T - это какой-то тип данных
    {
        //Внутри класса QueueItem, T может использоваться везде,
        //где может использоваться тип данных:
        //при объявлении свойств, в аргументах методов, и т.д.
        public T Value { get; set; }
        public QueueItem<T> Next { get; set; }
    }

    public class Queue<T>
    {
        private QueueItem<T> head;
        private QueueItem<T> tail;

        public bool IsEmpty => head == null;

        public void Enqueue(T value)
        {
            if (IsEmpty)
            {
                tail = head = new QueueItem<T> {Value = value, Next = null};
            }
            else
            {
                var item = new QueueItem<T> {Value = value, Next = null};
                tail.Next = item;
                tail = item;
            }
        }

        public T Dequeue()
        {
            if (head == null) throw new InvalidOperationException();
            var result = head.Value;
            head = head.Next;
            if (head == null)
                tail = null;
            return result;
        }
    }

    public class Programm
    {
        private static void Main()
        {
            var myIntQueue = new Queue<int>();
            // здесь мы создаем очередь с уже конкретным T=int. 
            //(так как типа Queue в программе уже нет, есть тип Queue от дженерик параметра)
            // всюду, где в определении класса Queue<T> был написан T,
            // для объекта myIntQueue будет как бы написан int.


            myIntQueue.Enqueue(10);
            myIntQueue.Enqueue(20);
            myIntQueue.Enqueue(30);

            // myIntQueue.Enqueue("Surprise"); 
            // - здесь будет ошибка компиляции, т.к. метод Enqueue принимает значение T
            // а T для myIntQueue равно int.
        }
    }
}