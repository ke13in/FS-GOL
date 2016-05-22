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

namespace GameOfLife
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            milliUpDown.Value = Settings.Default.time;
            xUpDown.Value = Settings.Default.gridX;
            yUpDown.Value = Settings.Default.gridY;

            backgroundColor.BackColor = Settings.Default.panelColor;
            glColor.BackColor = Settings.Default.gridColor;
            tenGlColor.BackColor = Settings.Default.gridBold;
            liveCellColor.BackColor = Settings.Default.cellColor;

        }

        private void backgroundColor_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.Color = backgroundColor.BackColor;

            if (DialogResult.OK == color.ShowDialog())
            {
                backgroundColor.BackColor = color.Color;
                Settings.Default.panelColor = backgroundColor.BackColor;
            }
        }

        private void glColor_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.Color = glColor.BackColor;

            if (DialogResult.OK == color.ShowDialog())
            {
                glColor.BackColor = color.Color;
                Settings.Default.gridColor = glColor.BackColor;
            }
        }

        private void tenGlColor_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.Color = tenGlColor.BackColor;

            if (DialogResult.OK == color.ShowDialog())
            {
                tenGlColor.BackColor = color.Color;
                Settings.Default.gridBold = tenGlColor.BackColor;
            }
        }

        private void liveCellColor_Click(object sender, EventArgs e)
        {
            ColorDialog color = new ColorDialog();
            color.Color = liveCellColor.BackColor;

            if (DialogResult.OK == color.ShowDialog())
            {
                liveCellColor.BackColor = color.Color;
                Settings.Default.cellColor = liveCellColor.BackColor;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Settings.Default.time = (int)milliUpDown.Value;
            Settings.Default.gridX = (int)xUpDown.Value;
            Settings.Default.gridY = (int)yUpDown.Value;
        }
    }
}
