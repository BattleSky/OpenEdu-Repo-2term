using System.Windows.Forms;
using System.Drawing;
using System;

namespace GUI
{
    /*
     * Изменение окна происходит по подписке на событие SizeChanged.
     * Оно работает, но если использовать лямбду как указано ниже,
     * то это превращает конструктор в большую кашу.
     *
     * Чтобы это избежать все контролы нужно делать полями,
     * а обработчик события SizeChanged выносить в отдельный метод
     */
    class AdaptiveForm : Form
        {
            public AdaptiveForm()
            {
                var label = new Label();
                label.Text = "Введите число";
                Controls.Add(label);

                var input = new TextBox();
                Controls.Add(input);

                var button = new Button();
                button.Text = "Увеличить!";
                button.Click += (sender, args) =>
                {
                    var number = int.Parse(input.Text);
                    number++;
                    input.Text = number.ToString();
                };
                Controls.Add(button);

                SizeChanged += (sender, args) =>
                {
                    var height = 30;

                    label.Location = new Point(0, (ClientSize.Height - height * 3) / 2);
                    label.Size = new Size(ClientSize.Width, height);
                    input.Location = new Point(0, label.Bottom);
                    input.Size = label.Size;
                    button.Location = new Point(0, input.Bottom);
                    button.Size = label.Size;

                };

                Load += (sender, args) => OnSizeChanged(EventArgs.Empty);

            }

            public static void Mainx()
            {
                Application.Run(new AdaptiveForm());
            }
        }
	}