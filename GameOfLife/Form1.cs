using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class Form1 : Form
    {
        bool[,] universe = new bool[5, 5];
        bool[,] update = new bool[5, 5];
        float generations = 0;
        bool timerState = true;

        Timer timer = new Timer();

        public Form1()
        {
            InitializeComponent();

            timer.Interval = 20;
            timer.Enabled = true;
            timer.Tick += Timer_Tick;
            //universe[2, 2] = true;
            //universe[2, 1] = true;
            //universe[2, 3] = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            generations++;

            toolStripStatusLabel1.Text = "Generations: " + generations.ToString();
            checkCell();

            graphicsPanel1.Invalidate();
}

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {
            float width = graphicsPanel1.ClientSize.Width / universe.GetLength(0);
            float height = graphicsPanel1.ClientSize.Height / universe.GetLength(1);

            for (int y = 0; y < universe.GetLength(1); y++)
            {
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    RectangleF rect = RectangleF.Empty;
                    rect.X = width * x;
                    rect.Y = height * y;
                    rect.Width = width;
                    rect.Height = height;

                    if (universe[x,y] == true)
                    {
                        e.Graphics.FillRectangle(Brushes.Black, rect.X, rect.Y, rect.Width, rect.Height);
                    }

                    e.Graphics.DrawRectangle(Pens.Black, rect.X, rect.Y, rect.Width, rect.Height);
                }
            }
        }

        private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            float width = graphicsPanel1.ClientSize.Width / universe.GetLength(0);
            float height = graphicsPanel1.ClientSize.Height / universe.GetLength(1);

            if (e.Button == MouseButtons.Left)
            {
                float x = Convert.ToSingle(e.X) / width;
                float y = Convert.ToSingle(e.Y) / height;

                universe[(int)x, (int)y] = !universe[(int)x, (int)y];

                graphicsPanel1.Invalidate();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    universe[x, y] = false;
                }
            }
            graphicsPanel1.Invalidate();
        }
        private int countNeighbours(int x, int y, int dx, int dy)
        {
            int value = 0;

            bool oob = x + dx < 0 || y + dy < 0 || x + dx >= universe.GetLength(0) || y + dy >= universe.GetLength(1);

            if (!oob)
            {
                value = universe[x + dx, y + dy] ? 1 : 0;
            }
            
            return value;
        }

        private void checkCell()
        {
            for (int a = 0; a < universe.GetLength(1); a++)
            {
                for (int b = 0; b < universe.GetLength(0); b++)
                {
                    update[a, b] = universe[a, b];
                }
            }

            for (int a = 0; a < universe.GetLength(1); a++)
            {
                for (int b = 0; b < universe.GetLength(0); b++)
                {
                    int neighbours = countNeighbours(a,b, -1, -1) + countNeighbours(a, b, -1, 0) + countNeighbours(a, b, -1, 1) + countNeighbours(a, b, 0, -1) + countNeighbours(a, b, 0 , 1) + countNeighbours(a, b, 1,1) + countNeighbours(a, b, 1, -1) + countNeighbours(a, b, 1, 0);
                    bool check1 = false;
                    bool check2 = universe[a,b];
                    if (check2 == true && (neighbours == 2 || neighbours == 3))
                    {
                        check1 = true;
                    }
                    else if(neighbours == 3 && check2 == false)
                    {
                        check1 = true;
                    }
                    else if(check2 == true && neighbours == 1)
                    {
                        check1 = false;
                    }
                    else if(check2 == true && neighbours >= 3)
                    {
                        check1 = false;
                    }
                    update[a,b] = check1;
                }
            }

            for (int a = 0; a < universe.GetLength(1); a++)
            {
                for (int b = 0; b < universe.GetLength(0); b++)
                {
                    universe[a, b] = update[a, b];
                }
            }
        }

        private void StartToolStripButton_Click(object sender, EventArgs e)
        {
            if (timerState != true)
            {
                timerState = !timerState;
                timer.Start();
            }
        }

        private void PauseToolStripButton_Click(object sender, EventArgs e)
        {
            if (timerState != false)
            {
                timerState = !timerState;
                timer.Stop();
            }
        }

        private void NextToolStripButton_Click(object sender, EventArgs e)
        {
           
                generations++;

                toolStripStatusLabel1.Text = "Generations: " + generations.ToString();
                checkCell();

                graphicsPanel1.Invalidate();
            
        }
    }
}
