using System;

namespace Очередь_на_связных_списках__теория_
{
    internal class QueueItem
    {
        public int Value { get; set; }
        public QueueItem Next { get; set; }
    }

    internal class Queue // элементы в очереди при добавлении запоминают ссылку на предыдущий элемент (указывает)
        // и при добавлении tail = item
    {
        // И операция добавления и операция вынимания из очереди не находятся в циклах (в т.ч. неявных)
        private QueueItem head; // голове очереди (1 элемент)
        private QueueItem tail; // хвост очереди (последний элемент)

        public void Enqueue(int value)
        {
            var item = new QueueItem {Value = value};
            if (head == null) // если в очереди никого - то первый и есть последний
            {
                head = tail = item;
            }
            else
            {
                // хвост предыдущего запоминает текущего
                tail.Next = item;
                tail = item; // и сам становится текущим
            }
        }

        public int Dequeue()
        {
            if (head == null) // Если головной null - то в очереди и не было ничего
                throw new InvalidOperationException();
            var result = head.Value; //значение первого в очереди 
            head = head.Next; // указатель должен сдвинуться на следующего в очереди, чтобы он стал первым
            if (head == null) // если вышедший из очереди был последним, то в хвосте - никого
                tail = null;
            return result;
        }
    }

    internal class Program
    {
        private static void Main1(string[] args)
        {
            var queue = new Queue();
            var index = 5;
            for (var i = 0; i < index; i++) queue.Enqueue(i);
            for (var i = 0; i < index; i++) Console.WriteLine(queue.Dequeue());
            Console.ReadLine();
        }
    }
}