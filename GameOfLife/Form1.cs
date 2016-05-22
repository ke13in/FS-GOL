using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameOfLife.Properties;
using System.IO;
namespace GameOfLife
{
    public partial class Form1 : Form
    {
        // init variables
        bool[,] universe = new bool[Settings.Default.gridX, Settings.Default.gridY];
        bool[,] update = new bool[Settings.Default.gridX, Settings.Default.gridY];
        float generations = 0;
        bool timerState = true;
        int cellsAlive = 0;
        bool displayCC = true;
        Color boldGrid = new Color();
        Color gridColor = new Color();
        Color cellColor = new Color();
        int timerCount, xcount, ycount;
        int seed;

        Timer timer = new Timer();

        public Form1()
        {
            InitializeComponent();

            timer.Enabled = true;
            timer.Tick += Timer_Tick;
        }

        // Timer to keep track of generations and cells alive

        private void Timer_Tick(object sender, EventArgs e)
        {
            generations++;
            countCells();
            toolStripStatusLabel1.Text = "Generations: " + generations.ToString() + "         Cells Alive: " + cellsAlive.ToString();
            checkCell();

            graphicsPanel1.Invalidate();
}
        // Exit the application

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // Paint to fill in each square based on if it is alive

        private void graphicsPanel1_Paint(object sender, PaintEventArgs e)
        {

            boldGrid = Settings.Default.gridBold;
            gridColor = Settings.Default.gridColor;
            graphicsPanel1.BackColor = Settings.Default.panelColor;
            cellColor = Settings.Default.cellColor;

            timerCount = Settings.Default.time;
            timer.Interval = timerCount;
            xcount = Settings.Default.gridX;
            ycount = Settings.Default.gridY;
            seed = Settings.Default.seed;

            float width = (float)graphicsPanel1.ClientSize.Width / (float)universe.GetLength(0);
            float height = (float)graphicsPanel1.ClientSize.Height / (float)universe.GetLength(1);

            Pen p1 = new Pen(cellColor, .01f);
            Pen p2 = new Pen(boldGrid, .02f);

            for (int y = 0; y < universe.GetLength(1); y++)
            {
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    RectangleF rect = RectangleF.Empty;
                    Font font = new Font("Arial", 5f);
                    StringFormat stringFormat = new StringFormat();
                    int neighbours = countNeighbours(x, y, -1, -1) + countNeighbours(x, y, -1, 0) + countNeighbours(x, y, -1, 1) + countNeighbours(x, y, 0, -1) + countNeighbours(x, y, 0, 1) + countNeighbours(x, y, 1, 1) + countNeighbours(x, y, 1, -1) + countNeighbours(x, y, 1, 0);
                    rect.X = width * x;
                    rect.Y = height * y;
                    rect.Width = width;
                    rect.Height = height;

                    stringFormat.Alignment = StringAlignment.Center;
                    stringFormat.LineAlignment = StringAlignment.Center;

                    if (universe[x,y] == true)
                    {
                        e.Graphics.FillRectangle(Brushes.Black, rect.X, rect.Y, rect.Width, rect.Height);
                    }

                    // Displays how many neighbors a cell has based on a bool + if has more than 0 neighbors

                    if (displayCC && neighbours > 0)
                    {
                        e.Graphics.DrawString(neighbours.ToString(), font, Brushes.Red, rect, stringFormat);
                    }

                    e.Graphics.DrawRectangle(p1, rect.X, rect.Y, rect.Width, rect.Height);

                    if (x % 10 == 0)
                        e.Graphics.DrawLine(p2, rect.Width * x, 0.0f, rect.Width * x, graphicsPanel1.Height);
                    if (y % 10 == 0)
                        e.Graphics.DrawLine(p2, 0.0f, rect.Height * y, graphicsPanel1.Width, rect.Height * y);

                }
            }

        }

        // Allows user to click cells on/off

        private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            float width = (float)graphicsPanel1.ClientSize.Width / (float)universe.GetLength(0);
            float height = (float)graphicsPanel1.ClientSize.Height / (float)universe.GetLength(1);

            if (e.Button == MouseButtons.Left)
            {
                float x = Convert.ToSingle(e.X) / width;
                float y = Convert.ToSingle(e.Y) / height;

                universe[(int)x, (int)y] = !universe[(int)x, (int)y];

                graphicsPanel1.Invalidate();
            }
        }

        // Empties the universe

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    universe[x, y] = false;
                }
            }
            generations = 0;
            cellsAlive = 0;
            toolStripStatusLabel1.Text = "Generations: " + generations.ToString() + "         Cells Alive: " + cellsAlive.ToString();
            graphicsPanel1.Invalidate();
        }

        // Counts how many cells are alive

        private int countCells()
        {
            cellsAlive = 0;
            int value = 0;
            for (int a = 0; a < universe.GetLength(1); a++)
            {
                for (int b = 0; b < universe.GetLength(0); b++)
                {
                    if (universe[a, b] == true)
                        cellsAlive++;
                }
            }
            return value;
        }

        

        // Counts how many alive cells are surrounding each cell

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


        // Checks every cell to see whether or not they should be alive in the next generation

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

        // Starts the time in the universe and lets the cell function as intended

        private void StartToolStripButton_Click(object sender, EventArgs e)
        {
            if (timerState != true)
            {
                timerState = !timerState;
                timer.Start();
            }
        }

        // Pauses the current generation

        private void PauseToolStripButton_Click(object sender, EventArgs e)
        {
            if (timerState != false)
            {
                timerState = !timerState;
                timer.Stop();
            }
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.Reload();
            boldGrid = Settings.Default.gridBold;
            gridColor = Settings.Default.gridColor;
            graphicsPanel1.BackColor = Settings.Default.panelColor;
            cellColor = Settings.Default.cellColor;
            timerCount = Settings.Default.time;
            xcount = Settings.Default.gridX;
            ycount = Settings.Default.gridY;
            seed = Settings.Default.seed;

            universe = new bool[xcount, ycount];
            graphicsPanel1.Invalidate();
            
        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.Default.Reset();
            boldGrid = Settings.Default.gridBold;
            gridColor = Settings.Default.gridColor;
            graphicsPanel1.BackColor = Settings.Default.panelColor;
            cellColor = Settings.Default.cellColor;
            timerCount = Settings.Default.time;
            xcount = Settings.Default.gridX;
            ycount = Settings.Default.gridY;
            seed = Settings.Default.seed;

            universe = new bool[xcount, ycount];
            graphicsPanel1.Invalidate();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Default.gridBold = boldGrid;
            Settings.Default.gridColor = gridColor;
            Settings.Default.panelColor = graphicsPanel1.BackColor;
            Settings.Default.cellColor = cellColor;
            Settings.Default.time = timerCount;
            Settings.Default.gridX = xcount;
            Settings.Default.gridY = ycount;
            Settings.Default.seed = seed;
            Settings.Default.Save();
        }

        //Allows the user to save

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "All Files|*.*|Cells|*.cells";
            save.FilterIndex = 2; save.DefaultExt = "cells";


            if (DialogResult.OK == save.ShowDialog())
            {
                StreamWriter write = new StreamWriter(save.FileName);

                write.WriteLine("!This is my comment.");

                for (int y = 0; y < xcount; y++)
                {
                    String currentRow = string.Empty;

                    for (int x = 0; x < ycount; x++)
                    {
                        if (universe[x, y] == true)
                        {
                            currentRow = currentRow + "O";
                        }
                        else
                        {
                            if (universe[x, y] == false)
                            {
                                currentRow = currentRow + ".";
                            }
                        }
                    }
                    write.WriteLine(currentRow);
                }
                write.Close();
            }
        }

        //Allows the user to open a generation

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "All Files|*.*|Cells|*.cells";
            open.FilterIndex = 2;

            if (DialogResult.OK == open.ShowDialog())
            {
                StreamReader read = new StreamReader(open.FileName);
                int mWidth = 0;
                int mHeight = 0;

                while (!read.EndOfStream)
                {
                    string row = read.ReadLine();

                    if (row.Contains("!"))
                    {

                    }
                    else
                    {
                        mHeight++;
                    }
                    mWidth = row.Length;
                }

                xcount = mWidth;
                ycount = mHeight;
                universe = new bool[xcount, ycount];
                update = new bool[xcount, ycount];

                read.BaseStream.Seek(0, SeekOrigin.Begin);
                int ypos = 0;

                while (!read.EndOfStream)
                {
                    string row = read.ReadLine();

                    if (row.Contains("!"))
                    {}
                    else
                    {
                        for (int xPos = 0; xPos < row.Length; xPos++)
                        {

                            if (row[xPos].Equals('O'))
                            {
                                universe[xPos, ypos] = true;
                            }
                            else if (row[xPos].Equals('.'))
                            {
                                universe[xPos, ypos] = false;
                            }
                        }
                        ypos++;
                    }
                }
                read.Close();
                graphicsPanel1.Invalidate();
            }
    }
        //Seeds from new

        private void fromNewSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 dlg = new Form3();
            if (DialogResult.OK == dlg.ShowDialog())
            {
                seed = Settings.Default.seed;
            }
            Random rand = new Random(seed);
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    if (rand.Next() % 2 == 0) { universe[x, y] = true; update[x, y] = true; }
                    else { universe[x, y] = false; update[x, y] = false; }
                }
            }
            graphicsPanel1.Invalidate();
        }

        //Seeds from current

        private void fromCurrentSeedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Random rand = new Random(seed);
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    if (rand.Next() % 2 == 0) { universe[x, y] = true; update[x, y] = true; }
                    else { universe[x, y] = false; update[x, y] = false; }
                }
            }
            graphicsPanel1.Invalidate();
        }

        //Seeds from time

        private void fromTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Random rand = new Random();
            for (int y = 0; y < universe.GetLength(1); y++)
            {
                for (int x = 0; x < universe.GetLength(0); x++)
                {
                    if (rand.Next() % 2 == 0) { universe[x, y] = true; update[x, y] = true; }
                    else { universe[x, y] = false; update[x, y] = false; }
                }
            }
            graphicsPanel1.Invalidate();
        }

        // Advances the universe to the next generation

        private void NextToolStripButton_Click(object sender, EventArgs e)
        {
           
                generations++;
                countCells();
                toolStripStatusLabel1.Text = "Generations: " + generations.ToString() + "         Cells Alive: " + cellsAlive.ToString();
                checkCell();

                graphicsPanel1.Invalidate();
            
        }

        // Opens the second form and allows the user to customize as wanted

        private void customizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();

            if (DialogResult.OK == form.ShowDialog())
            {
                boldGrid = Settings.Default.gridBold;
                gridColor = Settings.Default.gridColor;
                graphicsPanel1.BackColor = Settings.Default.panelColor;
                cellColor = Settings.Default.cellColor;
                timerCount = Settings.Default.time;
                xcount = Settings.Default.gridX;
                ycount = Settings.Default.gridY;
                seed = Settings.Default.seed;

                universe = new bool[xcount, ycount];
            }
            graphicsPanel1.Invalidate();
        }
    }
}
