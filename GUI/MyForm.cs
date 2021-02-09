using System.Drawing;
using System.Windows.Forms;

namespace GUI
{
    class MyForm : Form
    {
        public MyForm()
        {
            var label = new Label
            {
                Location = new Point(0, 0),
                Size = new Size(ClientSize.Width, 30),
                Text = "Enter a number"
            };
            var box = new TextBox
            {
                Location = new Point(0, label.Bottom),
                Size = label.Size
            };
            var button = new Button
            {
                Location = new Point(0, box.Bottom),
                Size = label.Size,
                Text = "Increment!"
            };
            Controls.Add(label);
            Controls.Add(box);
            Controls.Add(button);
            button.Click += (sender, args) => box.Text = (int.Parse(box.Text) + 1).ToString();
        }

        public static void Mainx()
        {
            Application.Run(new MyForm());
        }
	}
}
