using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_Practice
{
    class Practice
    {
		public class Node
        {
            public int NodeNumber;
            public List<Node> IncidentNodes = new List<Node>();
        }

        public static void Main()
        {
            // описание ребер разделены пробелами
            // дефисом разделены номера вершин ребра
            //CheckHasCycle("0-1", false);
            //CheckHasCycle("0-1 0-2", false);
            //CheckHasCycle("0-1 0-2 1-2", true);
            //CheckHasCycle("0-1 0-2 0-3", false);
            //CheckHasCycle("0-1 0-2 0-3 1-3", true);
            //RunSecretTests();
            Console.WriteLine("OK");
        }

        public static bool HasCycle(List<Node> graph)
        {
            var visited = new HashSet<Node>();  // Серые вершины
            var finished = new HashSet<Node>(); // Черные вершины
            var stack = new Stack<Node>();
            visited.Add(graph.First());
            stack.Push(graph.First());
            while (stack.Count != 0)
            {
                var node = stack.Pop();
                foreach (var nextNode in node.IncidentNodes)
                {
                    // TODO: доделать когда проснусь...
                    // ...
                    stack.Push(nextNode);
                }
                finished.Add(node); // красим в черный, когда рассмотрели все пути из node
            }
            return false;
        }


    }
}
