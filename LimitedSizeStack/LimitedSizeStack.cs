using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TodoApplication
{
    public class LimitedSizeStack<T>
    {
        public LinkedList<T> Stack;
        public int Limit;

        public LimitedSizeStack(int limit)
        {
            // ОБЪЯВЛЯЙ ЭКЗЕМПЛЯР КЛАССА, УЪУ!
            Stack = new LinkedList<T>();
            // ОБЪЯВЛЯЙ ЭКЗЕМПЛЯР КЛАССА, УЪУ!
            Limit = limit;
        }

        public void Push(T item)
        {
            Stack.AddLast(item);
            if (Stack.Count > Limit)
                Stack.RemoveFirst();
        }

        public T Pop()
        {
            var unit = Stack.Last;
            Stack.RemoveLast();
            return unit.Value;
        }

        public int Count
        {
            get
            {
                return Stack.Count;
            }
        }
    }
}
