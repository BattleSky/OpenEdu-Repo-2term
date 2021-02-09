using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GUI
{
    class Timer
    {
        public int Interval { get; set; }
        public Action<int> Tick;
        public void Start()
        {
            for (int i = 0; ; i++)
            {
                Tick(i);
                Thread.Sleep(Interval);
            }
        }
    }

    public class Program
    {
        public static void Mainx()
        {
            var timer = new Timer();
            timer.Interval = 500;
            timer.Tick = tickNumber => Console.WriteLine(tickNumber);
            //Проблема: никто не помешает написать так:
            timer.Tick(100);
            //Это нарушает целостность событийной модели.
            //Введение свойств не спасает: если есть доступ на чтение, есть и доступ на вызов
            //А именно его нужно закрыть.
            timer.Start();
        }
    }
}
