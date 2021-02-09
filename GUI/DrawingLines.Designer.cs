using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    partial class DrawingLines
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            var graphics = e.Graphics;

            graphics.DrawLine(new Pen(Color.Red, 5), new Point(0, 0), new Point(50, 100));
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            graphics.DrawLine(new Pen(Color.Green, 5), 0, 0, 100, 50);
            graphics.FillRectangle(Brushes.Green, 100, 100, 100, 100);
            graphics.DrawString("Some text here", new Font("Arial", 16), Brushes.Black, new Point(0, 250));
            graphics.DrawString(
                "Some very long text",
                new Font("Arial", 16),
                Brushes.White,
                new Rectangle(100, 100, 100, 100),
                new StringFormat { Alignment = StringAlignment.Near, LineAlignment = StringAlignment.Center, FormatFlags = StringFormatFlags.FitBlackBox }
            );
        }

        public static void Mainx()
        {
            Application.Run(new MyForm { ClientSize = new Size(300, 300) });
        }
	}
}