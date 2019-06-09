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

        public bool holdingLeft { get; set; }
        public bool holdingRight { get; set; }

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            holdingLeft = false;
            holdingRight = false;

            testLevel = new Level1();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            testLevel.Draw(e.Graphics);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            testLevel.CheckPhysicalBoundries();
            Invalidate();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if ( e.KeyCode == Keys.Left || holdingLeft )
            {
                testLevel.MoveHero(Hero.DIRECTION.Left);
                //holdingLeft = true;
            }

            if ( e.KeyCode == Keys.Right || holdingRight )
            {
                testLevel.MoveHero(Hero.DIRECTION.Right);
                //holdingRight = true;
            }

            if ( e.Modifiers == Keys.Shift )
            {
                testLevel.Jump();
            }

            Invalidate();
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ( (int)e.KeyChar == 32)
            {
                testLevel.Jump();
            }

            Invalidate();
        }
    }
}
