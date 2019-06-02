using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Super_Mario_Wannabe
{
    public partial class Form1 : Form
    {
        public Level1 testLevel { get; set; }
        public Form1()
        {
            InitializeComponent();
            testLevel = new Level1();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.Clear(Color.White);
            testLevel.Draw(e.Graphics);
        }
    }
}
