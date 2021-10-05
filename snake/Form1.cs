using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace snake
{
    public partial class Form1 : Form
    {
        Timer timer;
        PictureBox player1;
        PictureBox player2;
        int speed;
        double direction;
        public Form1()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 50;
            timer.Tick += Timer_Tick;
            speed = 4;
            direction = Math.PI / 4;
            player1 = new PictureBox();
            player1.Width = 50;
            player1.Height = 50;
            player1.Location = new Point(0, 0);
            player1.BackColor = Color.Blue;
            this.Controls.Add(player1);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var x = Math.Sin(direction) * speed;
            var y = Math.Cos(direction) * speed;
            player1.Location = new Point(player1.Location.X + Convert.ToInt32(Math.Round(x)), player1.Location.Y + Convert.ToInt32(Math.Round(y)));
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.A)
            {
                direction += 0.1;
            }
            else if(e.KeyCode == Keys.D)
            {
                direction -= 0.1;
            }
        }
    }
}
