using System;
using System.Collections.Generic;

namespace StackAndQueue
{
    public class Stack //результат работы стека - первый вошел, последний вышел
    {
        private readonly List<int> list = new List<int>();

        public void Push(int value)
        {
            list.Add(value);
        }

        public int Pop()
        {
            if (list.Count == 0) throw new InvalidOperationException();
            var result = list[list.Count - 1];
            list.RemoveAt(list.Count - 1);
            return result;
        }
    }

    internal class Queue // результат работы очереди - первый вошел - первый вышел.
    {
        private readonly List<int> list = new List<int>();

        public void Enqueue(int value)
        {
            list.Add(value);
        }

        public int Dequeue()
        {
            if (list.Count == 0) throw new InvalidOperationException();
            var result = list[0];
            list.RemoveAt(0); //в этом месте реализация неэффективна,
            //поскольку RemoveAt имеет линейную от размеров листа сложность
            return result;
        }
    }

    internal class Program
    {
        private static void Main(string[] args)
        {
            var stack = new Stack();
            var queue = new Queue();
            var index = 5;
            Console.WriteLine("Результат работы стека (первый вошел - последний вышел): ");
            for (var i = 0; i < index; i++)
                stack.Push(i);
            for (var i = 0; i < index; i++)
                Console.WriteLine(stack.Pop());

            Console.WriteLine("\nРезультат работы очереди (первый вошел - первый вышел):");

            for (var i = 0; i < index; i++)
                queue.Enqueue(i);
            for (var i = 0; i < index; i++)
                Console.WriteLine(queue.Dequeue());


            Console.ReadLine();
        }
    }
}