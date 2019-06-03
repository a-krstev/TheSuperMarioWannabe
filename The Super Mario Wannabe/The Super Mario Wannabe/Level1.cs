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
        private readonly Image blockImage1 = Properties.Resources.GenericBlock1;
        private readonly Image blockImage2 = Properties.Resources.GenericBackground;

        public Hero hero { get; set; }

        public int firstFloorY { get; set; }
        public int firstFloorX1 { get; set; }
        public int firstFloorX2 { get; set; }
        public int firstFloorX3 { get; set; }
        public int firstFloorX4 { get; set; }
        public bool isOnFirstFloor = true;

        public int secondFloorY { get; set; }
        public int secondFloorX1 { get; set; }
        public int secondFloorX2 { get; set; }
        public int secondFloorX3 { get; set; }
        public int secondFloorX4 { get; set; }
        public bool isOnSecondFloor = false;

        public int leftBorder { get; set; }
        public int rightBorder { get; set; }

        public Level1()
        {
            this.hero = new Hero(new Point(5 * blockImage.Width, blockImage.Height));

            leftBorder = blockImage.Width;
            rightBorder = 24 * blockImage.Width;

            firstFloorY = 3 * blockImage.Height;
            firstFloorX1 = blockImage.Width;
            firstFloorX2 = 19 * blockImage.Width;
            firstFloorX3 = 22 * blockImage.Width;
            firstFloorX4 = 24 * blockImage.Width;

            secondFloorY = 7 * blockImage.Height;
            secondFloorX1 = blockImage.Width;
            secondFloorX2 = 3 * blockImage.Width;
            secondFloorX3 = 6 * blockImage.Width;
            secondFloorX4 = 24 * blockImage.Width;
        }

        public void CheckPhysicalBoundries()
        {
            if ( (hero.topLeftCorner.Y + hero.height + hero.fallSpeed < firstFloorY) && 
                 ((firstFloorX1 < hero.topLeftCorner.X && hero.topLeftCorner.X < firstFloorX2) ||
                 (firstFloorX3 < hero.topLeftCorner.X && hero.topLeftCorner.X < firstFloorX4)) )
            {
                hero.Fall();
                hero.isFalling = true;
            }
            else
            {
                hero.isFalling = false;
            }

            if (((firstFloorX2 < hero.topLeftCorner.X && hero.topLeftCorner.X < firstFloorX3) || isOnSecondFloor) &&
                (hero.topLeftCorner.Y + hero.height + hero.fallSpeed < secondFloorY) &&
                ((secondFloorX1 < hero.topLeftCorner.X && hero.topLeftCorner.X < secondFloorX2) ||
                (secondFloorX3 < hero.topLeftCorner.X && hero.topLeftCorner.X < secondFloorX4)))
            {
                hero.Fall();
                isOnFirstFloor = false;
                isOnSecondFloor = true;

                hero.isFalling = true;
            }
            else
            {
                hero.isFalling = false;
            }
        }

        public void Draw(Graphics g)
        {
            for (int i = 0; i < 19; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    if ( j == 3  || j == 19 )
                    {
                        g.DrawImage(blockImage2, new Rectangle(j * blockImage.Width, i * blockImage.Height,
                            3 * blockImage.Width, (int)(blockImage.Height * 1.1)));
                    }

                    if ( j == 0 || j == 24 ) 
                    {
                        g.DrawImageUnscaled(blockImage, new Point(j * blockImage.Width, i * blockImage.Height));
                    }
                    else if ( i == 0 && (j < 3 || j > 5) )
                    {
                        g.DrawImageUnscaled(blockImage, new Point(j * blockImage.Width, i * blockImage.Height));
                    }
                    else if ( (i == 7 || i == 15) && (j < 3 || j > 5) )
                    {
                        g.DrawImageUnscaled(blockImage1, new Point(j * blockImage.Width, i * blockImage.Height));
                    }
                    else if ( (i == 3 || i == 11) && (j < 19 || j > 21) )
                    {
                        g.DrawImageUnscaled(blockImage1, new Point(j * blockImage.Width, i * blockImage.Height));
                    }
                }
            }

            hero.Draw(g);

        }

        public void MoveHero(Hero.DIRECTION direction)
        {
            hero.Move(direction, leftBorder, rightBorder);
        }
    }
}
