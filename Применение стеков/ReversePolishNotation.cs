using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;

namespace Применение_стеков
{

    public class ReversePolishNotation
    {
        public static void Main()
        {
            Console.WriteLine(Compute("32-4*"));
            Console.WriteLine(Compute1("32-4*"));
        }

        public static int Compute(string str)
        {
            var stack = new Stack<int>();
            foreach (var e in str)
            {
                if (e <= '9' && e >= '0')
                {
                    stack.Push(e - '0');
                    continue;
                }
                switch (e)
                {
                    case '+':
                        stack.Push(stack.Pop() + stack.Pop());
                        break;
                    case '-':
                        stack.Push(-stack.Pop() + stack.Pop());
                        break;
                    case '*':
                        stack.Push(stack.Pop() * stack.Pop());
                        break;
                    case '/':
                        stack.Push((1 / stack.Pop()) * stack.Pop());
                        break;
                    default:
                        throw new ArgumentException();
                }
            }
            return stack.Pop();
        }
        // в соответствии с DRY

        public static int Compute1(string str)
        {
            var operations = new Dictionary<char, Func<int, int, int>>();
            operations.Add('+', (y, x) => x + y);
            operations.Add('-', (y, x) => x - y);
            operations.Add('*', (y, x) => x * y);
            operations.Add('/', (y, x) => x / y);

            var stack = new Stack<int>();
            foreach (var e in str)
            {
                if (e <= '9' && e >= '0')
                    stack.Push(e - '0');
                else if (operations.ContainsKey(e))
                    stack.Push(operations[e](stack.Pop(), stack.Pop()));
                else
                    throw new ArgumentException();
            }
            return stack.Pop();
        }

    }
}
