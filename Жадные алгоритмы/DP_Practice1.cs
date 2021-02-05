using System;
using System.Linq;


namespace Динамическое_Программирование
{
    public class Event
    {
        public int Price;
        public int StartTime, FinishTime;
        // Для удобства дебага
        public override string ToString()
        {
            return "Price: " + Price + " Start: " + StartTime + " Finish: " + FinishTime;
        }
    } 
    /*
         Нужно найти такое ближайшее подходящее событие, 
         которое заканчивается раньше или вовремя 
         с началом нового события
         найти оптимальное среди предыдущего и найденного
         и записать в массивчик
    */

    class DpPractice1
    {
        public static int GetOptimalScheduleGain(params Event[] events)
        {
            // добавление fakeBorderEvent позволяет не обрабатывать некоторые граничные случаи
            var fakeBorderEvent = new Event { StartTime = int.MinValue, FinishTime = int.MinValue, Price = 0 };
            events = events.Concat(new[] { fakeBorderEvent }).OrderBy(e => e.FinishTime).ToArray();

            // OPT(k) = Max(OPT(k-1), w(k) + OPT(p(k))
            var opt = new int[events.Length];
            opt[0] = 0; // нулевым всегда будет fakeBorderEvent
            for (var k = 1; k < events.Length; k++)
            {
                var optOfClosestEvent = 0;
                for (var i = k-1; i >= 1; i--)
                {
                    if ((events[i].FinishTime >= events[k].StartTime) || (events[i].FinishTime <= 0)) continue;
                    optOfClosestEvent = opt[i];
                    break;
                }
                opt[k] = Math.Max(opt[k - 1], optOfClosestEvent + events[k].Price);
            }
            return opt.Last();
        }

        public static void Mainx()
        {
            var result1 = GetOptimalScheduleGain(new Event[0]); //0
            var result2 = GetOptimalScheduleGain(new Event {StartTime = 1, FinishTime = 11, Price = 50}); //50
            var resultUlearnMe = GetOptimalScheduleGain(
                new Event {StartTime = 9, FinishTime = 11, Price = 50},
                new Event {StartTime = 10, FinishTime = 13, Price = 190},
                new Event {StartTime = 14, FinishTime = 16, Price = 90},
                new Event {StartTime = 12, FinishTime = 15, Price = 200},
                new Event {StartTime = 16, FinishTime = 18, Price = 50 }
            ); //300
            var resultOpenEdu = GetOptimalScheduleGain(
                new Event {StartTime = 9, FinishTime = 11, Price = 50},
                new Event {StartTime = 10, FinishTime = 13, Price = 190},
                new Event {StartTime = 14, FinishTime = 16, Price = 90},
                new Event {StartTime = 12, FinishTime = 15, Price = 200}); //280

            Console.WriteLine("Result1 (must be 0): {0}, \nResult2(must be 50): {1}, \nResultOpenEdu (must be 280): {2}, \nResultUlearnMe (must be 300): {3}", 
                  result1, result2, 
                resultOpenEdu, resultUlearnMe);
            Console.Read();
        }
    }

    //public static int GetOptimalScheduleGainBRUH(params Event[] events)
    //{
    //// добавление fakeBorderEvent позволяет не обрабатывать некоторые граничные случаи
    //var fakeBorderEvent = new Event { StartTime = int.MinValue, FinishTime = int.MinValue, Price = 0 };
    //events = events.Concat(new[] { fakeBorderEvent }).OrderBy(e => e.FinishTime).ToArray();

    //// OPT(k) = Max(OPT(k-1), w(k) + OPT(p(k))
    //var opt = new int[events.Length];
    //opt[0] = 0; // нулевым всегда будет fakeBorderEvent
    //for (var k = 1; k < events.Length; k++)
    //{
    //    //выбираем подходящее мероприятие
    //    var chosenMeeting = new Event { StartTime = int.MinValue, FinishTime = int.MaxValue, Price = 0 };
    //    var chosenFlag = false;
    //    var resultPrice = 0;

    //    foreach (var e in events)
    //    {
    //        if (e.StartTime >= events[k].FinishTime && e.FinishTime < chosenMeeting.FinishTime)
    //        {
    //            chosenMeeting = e;
    //            chosenFlag = true;
    //        }
    //    }
    //    //TODO: плак плак, напиши все заново
    //    if (chosenFlag || k == 1)
    //        resultPrice = chosenMeeting.Price + events[k].Price;

    //    opt[k] = Math.Max(opt[k - 1], resultPrice);
    //}

    //return opt.Last();
    //}
}
