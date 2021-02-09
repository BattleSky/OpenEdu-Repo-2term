using System;
using System.Windows.Forms;
using System.Drawing;

namespace GUI
{
    partial class AnimateDrawing
    {
        class FormWithWrongTimer : Form
        {
            public FormWithWrongTimer()
            {
                ClientSize = new Size(600, 600);
                var centerX = ClientSize.Width / 2;
                var centerY = ClientSize.Height / 2;
                var size = 100;
                var radius = Math.Min(ClientSize.Width, ClientSize.Height) / 3;

                int time = 0;
                var timer = new Timer();
                timer.Interval = 500;
                timer.Tick += (args) =>
                {
                    time++;
                    var graphics = CreateGraphics();
                    graphics.TranslateTransform(centerX, centerY);
                    graphics.RotateTransform(-time * (360f / 12));
                    graphics.FillEllipse(
                        Brushes.Blue,
                        new Rectangle(radius - size / 2, -size / 2, size, size));

                };
                timer.Start();
            }
        }

        class FormWithRightTimer : Form
        {
            public FormWithRightTimer()
            {
                // Включает двойную буферизацию, чтобы изображение не мерцало при перерисовке.
                // В таком режиме OnPaint рисует не сразу на окне, а сначала на невидимой картинке (shadow buffer),
                // а потом одномоментно подменяет текущее изображение дорисованной картинкой.
                // Так окно не дорисованную картинку даже не показывает, что предотвращает мерцание.
                DoubleBuffered = true;
                ClientSize = new Size(600, 600);
                var centerX = ClientSize.Width / 2;
                var centerY = ClientSize.Height / 2;
                var size = 100;
                var radius = Math.Min(ClientSize.Width, ClientSize.Height) / 3;

                var time = 0;
                var timer = new Timer();
                timer.Interval = 500;
                timer.Tick += (args) =>
                {
                    time++;
                    Invalidate();
                };
                timer.Start();

                Paint += (sender, args) =>
                {
                    for (int i = 0; i <= time; i++)
                    {
                        args.Graphics.TranslateTransform(centerX, centerY);
                        args.Graphics.RotateTransform(i * 360f / 10);
                        args.Graphics.FillEllipse(Brushes.Blue, radius - size / 2, -size / 2, size, size);
                        args.Graphics.ResetTransform();
                    }
                };
            }
        }

        static void Main()
        {
            Application.Run(new FormWithRightTimer());
        }
	}
}