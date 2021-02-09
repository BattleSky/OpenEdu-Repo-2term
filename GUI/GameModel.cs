using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    class GameModel
	{
        
            bool[,] game;
        public readonly int Size;

        public GameModel(int size)
        {
            Size = size;
            game = new bool[size, size];
        }

        public void Start()
        {
            for (int row = 0; row < Size; row++)
            for (int column = 0; column < Size; column++)
                SetState(row, column, (row + column) % 2 == 0);
        }

        void SetState(int row, int column, bool state)
        {
            game[row, column] = state;
            if (StateChanged != null) StateChanged(row, column, game[row, column]);
        }

        void FlipState(int row, int column)
        {
            SetState(row, column, !game[row, column]);
        }

        public void Flip(int row, int column)
        {
            for (int iRow = 0; iRow < Size; iRow++)
                if (iRow != row) FlipState(iRow, column);
            for (int iColumn = 0; iColumn < Size; iColumn++)
                if (iColumn != column) FlipState(row, iColumn);
            FlipState(row, column);
        }

        public event Action<int, int, bool> StateChanged;
    }

    class MyForm1 : Form
    {
        GameModel game;
        TableLayoutPanel table;

        public MyForm1(GameModel game)
        {
            this.game = game;
            table = new TableLayoutPanel();
            for (int i = 0; i < game.Size; i++)
            {
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / game.Size));
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / game.Size));
            }
            for (int column = 0; column < game.Size; column++)
            for (int row = 0; row < game.Size; row++)
            {
                var iRow = row;
                var iColumn = column;
                var button = new Button();
                button.Dock = DockStyle.Fill;
                button.Click += (sender, args) => game.Flip(iRow, iColumn);
                table.Controls.Add(button, iColumn, iRow);
            }
            table.Dock = DockStyle.Fill;
            Controls.Add(table);
            game.StateChanged += (row, column, state) => ((Button)table.GetControlFromPosition(column, row)).BackColor = state ? Color.Black : Color.White;
            game.Start();
        }

        public static void Mainx()
        {
            var game = new GameModel(5);
            Application.Run(new MyForm1(game) { ClientSize = new Size(300, 300) });
        }
	}
}
