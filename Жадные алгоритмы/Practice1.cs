using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Жадные_алгоритмы
{
    class Practice1
    {
        public static IEnumerable<Tuple<int, int>> PlanSchedule(IEnumerable<Tuple<int, int>> meetings)
        {
            var leftEdge = int.MinValue;
            var rightEdge = int.MaxValue; // YAGNI -_-
            foreach (var meeting in meetings.OrderBy(m => m.Item2))
            {
                if (meeting.Item1 >= leftEdge || meeting.Item2 < rightEdge)
                {
                    rightEdge = meeting.Item1;
                    leftEdge = meeting.Item2;
                    yield return meeting;
                }
            }
        }
    }
}
