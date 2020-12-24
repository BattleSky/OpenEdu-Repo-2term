using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Графы_и_обходы;

namespace Жадные_алгоритмы
{
	class DijkstraData
    {
        public Node Previous { get; set; }
        public double Price { get; set; }
    }

    public class Program
    {
        public static List<Node> Dijkstra(Graph graph, Dictionary<Графы_и_обходы.Edge, double> weights, Node start, Node end)
        {
            var notVisited = graph.Nodes.ToList();
            var track = new Dictionary<Node, DijkstraData>();
            track[start] = new DijkstraData { Price = 0, Previous = null };

            while (true)
            {
                Node toOpen = null;
                var bestPrice = double.PositiveInfinity;
                foreach (var e in notVisited)
                {
                    if (track.ContainsKey(e) && track[e].Price < bestPrice)
                    {
                        bestPrice = track[e].Price;
                        toOpen = e;
                    }
                }

                if (toOpen == null) return null;
                if (toOpen == end) break;

                foreach (var e in toOpen.IncidentEdges.Where(z => z.From == toOpen))
                {
                    var currentPrice = track[toOpen].Price + weights[e];
                    var nextNode = e.OtherNode(toOpen);
                    if (!track.ContainsKey(nextNode) || track[nextNode].Price > currentPrice)
                    {
                        track[nextNode] = new DijkstraData { Previous = toOpen, Price = currentPrice };
                    }
                }

                notVisited.Remove(toOpen);
            }

            var result = new List<Node>();
            while (end != null)
            {
                result.Add(end);
                end = track[end].Previous;
            }
            result.Reverse();
            return result;
        }
        public static void MainX()
        {
            var graph = new Graph(4);
            var weights = new Dictionary<Edge, double>();
            // в лекции указано, что была реализована индексация для удобства расположения веса.
            // как она была реализована - не указано
            //weights[graph.Connect(0, 1)] = 1;
            //weights[graph.Connect(0, 2)] = 2;
            //weights[graph.Connect(0, 3)] = 6; 
            //weights[graph.Connect(1, 3)] = 4;
            //weights[graph.Connect(2, 3)] = 2;

          //  var path = Dijkstra(graph, weights, graph[0], graph[3]).Select(n => n.NodeNumber);
          //  CollectionAssert.AreEqual(new[] { 0, 2, 3 }, path);
        }
    }
}
