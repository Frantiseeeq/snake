using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        bool a, d;
        Timer timer;
        Snake snake1;
        PictureBox player1;
        List<PictureBox> player1tail;

        bool KeyLeft, KeyRight;
        Timer timer2;
        Snake2 snake2;
        PictureBox player2;
        List<PictureBox> player2tail;

        public Form1()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 50;
            timer.Tick += Timer_Tick;
            snake1 = new Snake();
            snake1.Speed = 5;
            player1tail = new List<PictureBox>();
            player1 = snake1.GetHead(Color.Blue, 10);
            this.Controls.Add(player1);

            snake2 = new Snake2();
            snake2.Speed = 5;
            player2tail = new List<PictureBox>();
            player2 = snake2.GetHead(Color.Red, 10);
            this.Controls.Add(player2);

            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (a)
            {
                snake1.TurnLeft();
            }
            else if (d)
            {
                snake1.TurnRight();
            }

            if (KeyLeft)
            {
                snake2.TurnLeft();
            }
            else if (KeyRight)
            {
                snake2.TurnRight();
            }

            player1tail.Add(player1);
            snake1.Forward();
            player1 = snake1.GetHead(Color.Blue, 10);
            this.Controls.Add(player1);

            player2tail.Add(player2);
            snake2.Forward();
            player2 = snake2.GetHead(Color.Red, 10);
            this.Controls.Add(player2);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                a = false;
            }
            else if (e.KeyCode == Keys.D)
            {
                d = false;
            }

            if (e.KeyCode == Keys.Left)
            {
                KeyLeft = false;
            }
            else if (e.KeyCode == Keys.Right)
            {
                KeyRight = false;
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A)
            {
                a = true;
            }
            else if (e.KeyCode == Keys.D)
            {
                d = true;
            }

            if (e.KeyCode == Keys.Left)
            {
                KeyLeft = true;
            }
            else if (e.KeyCode == Keys.Right)
            {
                KeyRight = true;
            }
        }
    }
}
