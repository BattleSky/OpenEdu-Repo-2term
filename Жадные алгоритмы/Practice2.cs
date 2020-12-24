using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Жадные_алгоритмы
{
    // Реализация алгоритма Краскала
    public struct Edge
    {
        public int From;
        public int To;
        public int Weight;
    }

    class Practice2
    {
        public static bool HasCycle(List<Edge> edges)
        {
            throw new NotImplementedException(); //в лекции не предоставлен код для этого метода 
        }

        public static IEnumerable<Edge> FindMinimumSpanningTree(IEnumerable<Edge> edges)
        {
            var tree = new List<Edge>();
            foreach (var edge in edges.OrderBy(x => x.Weight))
            {
                tree.Add(edge);
                if (!HasCycle(tree)) continue;
                tree.Remove(edge);
                break;
            }
            return tree;
        }
    }
}
