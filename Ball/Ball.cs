using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Bouncing_balls
{
    public partial class Ball : UserControl
    {
        public Ball()
        {
            InitializeComponent();
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, 50, 50);
            Region rgn = new Region(path);
            pictureBox1.Region = rgn;
        }
        //Specify the color of balls using the ForeColor parameter
        public Color FigureColor { get; set; }
        protected override void OnPaint(PaintEventArgs e)
        {
            pictureBox1.BackColor = ForeColor;
            base.OnPaint(e);
        }
        //Declare the variables of the ball position
        int dx; //the X position
        int dy; //the Y position
        //Initiate the ball position
        public void Init(int left, int top, int dx, int dy)

        {
            Left = left;
            Top = top;
            this.dx = dx;
            this.dy = dy;
        }
        //Enumerate four directions
        public enum Direction
        {
            Left, Right, Top, Bottom
        }
        //Create properties of the current direction
        public Direction CurrentDirectionX { get; private set; }
        public Direction CurrentDirectionY { get; private set; }
        //Declare the speed variable and property
        private int speed;
        public int Speed
        {
            get => speed;
            set
            {
                OnSpeedChanged(value);
            }
        }
        //Create the method that checks if the speed value is not negative and assigns 
        //the new values for the `dx` and `dy` variables depending on the `speed` 
        //value.
        private void OnSpeedChanged(int value)
        {
            if (value >= 0)
            {
                speed = value;
                dx = dx != 0 ? dx / Math.Abs(dx) * value : value;
                dy = dy != 0 ? dy / Math.Abs(dy) * value : value;
            }
        }
        //Declare the Counter property
        public int Counter { get; private set; }
        //Create an action event with four directions
        public event Action<Direction, Direction, Direction, Direction> OnCollision;
        //Create the method that updates the ball position and counts collisions
        public void UpdatePosition()
        {
            if (Left + dx <= 0 || Left + Width + dx >= Parent.Width)
            {
                Counter++;
                OnCollision?.Invoke(CurrentDirectionX, CurrentDirectionY, dx > 0 ? Direction.Right : Direction.Left, CurrentDirectionY);
                dx = -dx;

            }

            if (Top + dy <= 0 || Top + Height + dy >= Parent.Height)
            {
                Counter++;
                OnCollision?.Invoke(CurrentDirectionX, CurrentDirectionY, CurrentDirectionX, dy > 0 ? Direction.Bottom : Direction.Top);
                dy = -dy;
            }

            CurrentDirectionX = dx > 0 ? Direction.Left : Direction.Right;
            CurrentDirectionY = dy > 0 ? Direction.Top : Direction.Bottom;
            Left += dx;
            Top += dy;
        }


    }
}
