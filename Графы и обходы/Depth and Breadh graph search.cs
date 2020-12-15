using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Графы_и_обходы
{
    public static class NodeExtensions
    {
        public static IEnumerable<Node> DepthSearch(this Node startNode)
        {
            var visited = new HashSet<Node>();
            var stack = new Stack<Node>();
            visited.Add(startNode);
            stack.Push(startNode);
            while (stack.Count != 0)
            {
                var node = stack.Pop();
                yield return node;
                foreach (var nextNode in node.IncidentNodes.Where(n => !visited.Contains(n)))
                {
                    visited.Add(nextNode);
                    stack.Push(nextNode);
                }
            }
        }

        public static IEnumerable<Node> BreadthSearch(this Node startNode)
        {
            var visited = new HashSet<Node>();
            var queue = new Queue<Node>();
            visited.Add(startNode);
            queue.Enqueue(startNode);
            while (queue.Count != 0)
            {
                var node = queue.Dequeue();
                yield return node;
                foreach (var nextNode in node.IncidentNodes.Where(n => !visited.Contains(n)))
                {
                    visited.Add(nextNode);
                    queue.Enqueue(nextNode);
                }

            }
        }

        /*
         * Реализация поиска компонента связности
         * Надо найти все вершины, которые связаны друг с другом.
        */

        public static List<List<Node>> FindConnectedComponents(Graph graph)
        {
            var result = new List<List<Node>>();
            var markedNodes = new HashSet<Node>();
            while (true)
            {
                var nextNode = graph.Nodes.Where(node => !markedNodes.Contains(node)).FirstOrDefault();
                if (nextNode == null) break;
                var breadthSearch = nextNode.BreadthSearch().ToList();
                ;
                result.Add(breadthSearch.ToList());
                foreach (var node in breadthSearch)
                    markedNodes.Add(node);
            }

            return result;
        }

        public static List<Node> FindPath(Node start, Node end)
        {
            var track = new Dictionary<Node, Node>();
            track[start] = null;
            var queue = new Queue<Node>();
            queue.Enqueue(start);
            while (queue.Count != 0)
            {
                var node = queue.Dequeue();
                foreach (var nextNode in node.IncidentNodes)
                {
                    if (track.ContainsKey(nextNode)) continue;
                    track[nextNode] = node;
                    queue.Enqueue(nextNode);
                }
                if (track.ContainsKey(end)) break;
            }
            var pathItem = end;
            var result = new List<Node>();
            while (pathItem != null)
            {
                result.Add(pathItem);
                pathItem = track[pathItem];
            }
            result.Reverse();
            return result;
        }

        class Program
        {
            public static void MainX()
            {
                var graph = Graph.MakeGraph(
                    0, 1,
                    0, 2,
                    1, 4,
                    2, 3,
                    3, 4
                );

                var path = FindPath(graph[0], graph[4]);
                Console.WriteLine(
                    path.Select(z => z.NodeNumber.ToString()).Aggregate((a, b) => a + " " + b));
            }



            public static void Mainx()
            {
                var graph = Graph.MakeGraph(
                    0, 1,
                    0, 2,
                    1, 3,
                    1, 4,
                    2, 3,
                    3, 4);


                Console.WriteLine(graph[0]
                    .DepthSearch()
                    .Select(z => z.NodeNumber.ToString())
                    .Aggregate((a, b) => a + " " + b));

                Console.WriteLine(graph[0]
                    .BreadthSearch()
                    .Select(z => z.NodeNumber.ToString())
                    .Aggregate((a, b) => a + " " + b));

            }
        }
    }
}
