using System.Collections.Generic;

namespace yield
{
    public static class ExpSmoothingTask
    {
        public static IEnumerable<DataPoint> SmoothExponentialy(this IEnumerable<DataPoint> data, double alpha)
        {
            // нельзя проверять на ноль, нельзя перебирать снова data
            double prevSmoothedElement = 0;
            var firstRun = true;
            foreach (var element in data)
            {
                if (firstRun)
                {
                    prevSmoothedElement = element.OriginalY;
                    firstRun = false;
                }
                prevSmoothedElement =
                    element.ExpSmoothedY = alpha * element.OriginalY + (1 - alpha) * prevSmoothedElement;
                yield return element;
            }
        }
    }
}