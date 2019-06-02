using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Super_Mario_Wannabe
{
    public class Level1 : ILevel
    {
        private readonly Image blockImage = Properties.Resources.GenericBlock;
        public int MyProperty { get; set; }

        public Level1()
        {

        }

        public void Draw(Graphics g)
        {
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    if ( j == 0 || j == 24)
                    {
                        g.DrawImageUnscaled(blockImage, new Point(j * blockImage.Width, i * blockImage.Height));
                    }

                    if ( (i == 0 || i == 7 || i == 15) && (j < 3 || j > 5) )
                    {
                        g.DrawImageUnscaled(blockImage, new Point(j * blockImage.Width, i * blockImage.Height));
                    }

                    if ( (i == 3 || i == 11) && (j < 19 || j > 21))
                    {
                        g.DrawImageUnscaled(blockImage, new Point(j * blockImage.Width, i * blockImage.Height));
                    }
                }
            }
        }
    }
}
