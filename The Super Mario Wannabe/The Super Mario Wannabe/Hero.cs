using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace The_Super_Mario_Wannabe
{
    public class Hero
    {
        public enum DIRECTION
        {
            Left, Right
        }

        public Point topLeftCorner { get; set; }
        public int width { get; set; }
        public int height { get; set; }

        public readonly int fallSpeed = 3;
        public readonly int moveSpeed = 5;
        public readonly int jumpSpeed = 5;

        public bool isFalling { get; set; }
        public bool isJumping { get; set; }

        public Hero(Point topLeftCorner)
        {
            this.topLeftCorner = topLeftCorner;
            width = 15;
            height = 20;

            isFalling = false;
            isJumping = false;
        }

        public void Draw(Graphics g)
        {
            //g.DrawRectangle(new Pen(new SolidBrush(Color.Blue)), topLeftCorner.X, topLeftCorner.Y, width, height);
            g.FillRectangle(new SolidBrush(Color.Black), topLeftCorner.X, topLeftCorner.Y, width, height);
        }

        public void Fall()
        {
            topLeftCorner = new Point(topLeftCorner.X, topLeftCorner.Y + fallSpeed);
        }

        public void Jump()
        {
            topLeftCorner = new Point(topLeftCorner.X, topLeftCorner.Y - jumpSpeed);
        }

        public void Move(DIRECTION direction, int leftBorder, int rightBorder)
        {
            int moveSpeed = this.moveSpeed;
            if ( isFalling || isJumping )
            {
                moveSpeed = moveSpeed - 2;
            }

            if ( direction == DIRECTION.Left && topLeftCorner.X - moveSpeed >= leftBorder )
            {
                topLeftCorner = new Point(topLeftCorner.X - moveSpeed, topLeftCorner.Y);
            }

            if ( direction == DIRECTION.Right && topLeftCorner.X + width + moveSpeed <= rightBorder )
            {
                topLeftCorner = new Point(topLeftCorner.X + moveSpeed, topLeftCorner.Y);
            }
        }
    }
}
