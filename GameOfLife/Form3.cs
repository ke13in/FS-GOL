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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            seedUpDown.Maximum = int.MaxValue;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            Settings.Default.seed = (int)seedUpDown.Value;
        }
    }
}
