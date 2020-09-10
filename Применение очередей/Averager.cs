using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Применение_очередей
{ /*
   * Очередь для использования скользящей средней
   * Позволяет усреднять значение почти "в онлайне" в отличие от массива
   */
    public class Sensor
    {
        double x;
        Random rnd = new Random();
        public double Measure()
        {
            x += 0.02;
            return Math.Sin(x) + (rnd.NextDouble() - 0.5);
        }
    }

    public class Averager
    {
        Sensor sensor;
        Queue<double> queue;
        int bufferLength;
        double sum; // сумма всех элементов
        public Averager(Sensor sensor, int bufferLength)
        {
            this.bufferLength = bufferLength;
            this.sensor = sensor;
            //если совпадает имя поля класса и имя аргумента, то можно использовать this.
            queue = new Queue<double>();
        }

        public double Measure()
        {
            var value = sensor.Measure();
            // берет значение из сенсора
            queue.Enqueue(value);// складывает в очередь
            sum += value; // когда добавляем элемент в очередь, то его суммируем с текущей суммой
            if (queue.Count > bufferLength) // если в очереди лежит больше чем нужно значений
            {
                sum -= queue.Dequeue(); //когда извлекаем из очереди - отнимает от суммы его значение
                // в итоге мы всегда имеем сумму bufferLength элементов
            }
            return sum / queue.Count;
        }
    }

    public class Program
    {
        public static void Main()
        {
            var sensor = new Sensor();
            var averager = new Averager(sensor, 1000);

            var chart = new Chart();
            chart.ChartAreas.Add(new ChartArea());
            var raw = new Series();

            for (int i = 0; i < 1000; i++)
                //raw.Points.Add(new DataPoint(i, sensor.Measure())); //данные с сенсора
                raw.Points.Add(new DataPoint(i, averager.Measure())); //данные с усреднителя
            
            raw.ChartType = SeriesChartType.FastLine;
            raw.Color = Color.Red;
            chart.Series.Add(raw);

            chart.Dock = System.Windows.Forms.DockStyle.Fill;
            var form = new Form();
            form.Controls.Add(chart);
            form.WindowState = FormWindowState.Maximized;
            Application.Run(form);

        }
    }
}
