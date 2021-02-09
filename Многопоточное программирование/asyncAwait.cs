using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Многопоточное_программирование
{
    public class MyForm1 : Form
    {
        private readonly Label label;
        private readonly Button button;
        public MyForm1()
        {
            label = new Label { Size = new Size(ClientSize.Width, 30) };
            button = new Button
            {
                Location = new Point(0, label.Bottom),
                Text = "Start",
                Size = label.Size
            };
            button.Click += MakeWork;
            Controls.Add(label);
            Controls.Add(button);
        }

        Task<string> MakeWorkInThread()
        {
            var task = new Task<string>(
                () => { Thread.Sleep(5000); return "Completed"; }
            );
            task.Start();
            return task;
            // Вместо создания задачи, тут мог быть вызов какой-либо полезной асинхронной операции. 
            // Имена методов асинхронных операций обычно заканчиваются словом Async, 
            // например, метод ReadLineAsync у класса StreamReader.
        }

        async void MakeWork(object sender, EventArgs e)
        {
            var labelText = await MakeWorkInThread();
            label.Text = labelText;
        }

        /* 
        Компилятор превратит код выше в аналог такого кода:

        void MakeWork(object sender, EventArgs e)
        {
            var task = MakeWorkInThread();
            task.ContinueWith(
                z => label.Text = z.Result,
                TaskScheduler.FromCurrentSynchronizationContext());
        }
        */
        public static void Main()
        {
            Application.Run(new MyForm());
        }

    }
}
