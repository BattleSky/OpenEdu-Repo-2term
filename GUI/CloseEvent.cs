using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    static class CloseEvent
    {
        public static void Mainx()
        {
            var form = new Form();
            form.FormClosing += (sender, args) =>
            {
                var result = MessageBox.Show("Действительно закрыть?", "", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes) args.Cancel = true;
            };
            Application.Run(form);
        }
	}
}
