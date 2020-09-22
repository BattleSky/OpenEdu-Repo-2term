using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace yield
{

	public static class MovingMaxTask
	{
		public static IEnumerable<DataPoint> MovingMax(this IEnumerable<DataPoint> data, int windowWidth)
		{
            var maxCandidate = new LinkedList<double>();
            var window = new Queue<double>();

            foreach (var element in data)
            {
                window.Enqueue(element.OriginalY);
                // если вышли за пределы окна
                if (window.Count > windowWidth)
                    maxCandidate.Remove(window.Dequeue());
                

                // добавляем maxcandidate
                MaxCandidate(element, maxCandidate.Last, maxCandidate);

                element.MaxY = maxCandidate.First.Value;
                yield return element;
            }
        }

        public static void MaxCandidate(DataPoint element, LinkedListNode<double> maxCandidateCurrentNode, LinkedList<double> maxCandidate)
        {
            if (maxCandidate.Count == 0 || element.OriginalY > maxCandidate.First.Value)
                maxCandidate.AddFirst(element.OriginalY);
            else
            {
                if (element.OriginalY > maxCandidateCurrentNode.Value)
                {
                    MaxCandidate(element, maxCandidateCurrentNode.Previous, maxCandidate);
                    maxCandidate.RemoveLast();
                }
                // проверка на previous != null реализована выше (сравнение с first value и count == 0)
                if (element.OriginalY <= maxCandidateCurrentNode.Value && element.OriginalY != 0)
                {
                    maxCandidate.AddAfter(maxCandidateCurrentNode, element.OriginalY);
                }
                    
            }
        }
    }
}