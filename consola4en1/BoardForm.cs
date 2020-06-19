using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace consola4en1
{
    public partial class BoardForm : Form
    {
        static int[,] coords = new int[7, 6];
        List<PictureBox> boxes = new List<PictureBox>();
        List<EventHandler> handlers;
        GameController game = new GameController();

        public BoardForm()
        {
            InitializeComponent(); 
        }

        private void Board_load(object sender, EventArgs e)
        {
            handlers = new List<EventHandler>() { Col_0, Col_1, Col_2, Col_3, Col_4, Col_5 };

            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    game.board[i, j] = 0;
                    PictureBox p = new PictureBox();
                    p.Dock = DockStyle.Fill;
                    p.Click += new EventHandler(handlers[j]);
                    boxes.Add(p);
                    Grid.Controls.Add(p, j, i);
                    coords[i, j] = boxes.Count - 1;
                }
            }
        }

        private void Col_0 (object sender, EventArgs e)
        {
            game.SumarFicha(1, 0, out int i);
            if (i > -1) boxes[coords[i, 0]].BackColor = Color.Red;
        }

        private void Col_1(object sender, EventArgs e)
        {
            game.SumarFicha(1, 1, out int i);
            if (i > -1) boxes[coords[i, 1]].BackColor = Color.Red;
        }

        private void Col_2(object sender, EventArgs e)
        {
            game.SumarFicha(1, 2, out int i);
            if (i > -1) boxes[coords[i, 2]].BackColor = Color.Red;
        }

        private void Col_3(object sender, EventArgs e)
        {
            game.SumarFicha(1, 3, out int i);
            if (i > -1) boxes[coords[i, 3]].BackColor = Color.Red;
        }

        private void Col_4(object sender, EventArgs e)
        {
            game.SumarFicha(1, 4, out int i);
            if (i > -1) boxes[coords[i, 4]].BackColor = Color.Red;
        }

        private void Col_5(object sender, EventArgs e)
        {
            game.SumarFicha(1, 5, out int i);
            if (i > -1) boxes[coords[i, 5]].BackColor = Color.Red;
        }
    }
}
