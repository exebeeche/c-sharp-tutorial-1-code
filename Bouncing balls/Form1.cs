using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bouncing_balls
{
    public partial class Form1 : Form
    {
        //Add the ball list and create the method that returns the balls from the list
        private List<Ball> balls;
        private List<Ball> GetAllBalls()
        {
            CreateOrInitBall("Ball1", listBox1, label1, numericUpDown1, panel1, ball1);
            CreateOrInitBall("Ball2", listBox2, label2, numericUpDown2, panel2, ball2);
            return new List<Ball>
       {
           ball1,
           ball2
       };
        }

        public Form1()
        {
            InitializeComponent();
            InitBalls();
        }
        //Initialize the ball list
        private void InitBalls()
        {
            balls = GetAllBalls();
        }
        //Create the method that accepts the control elements as balls parameters
        //and sets a dependency between the ball position and the control elements
        private void CreateOrInitBall(string name, ListBox listbox, Label output, NumericUpDown num, Panel parent, Ball ball = null)
        {
            var currentBall = ball ?? new Ball();
            currentBall.Name = name;

            if (ball == null)
            {
                parent.Controls.Add(currentBall);
            }

            num.ValueChanged += (sender, e) =>
            {
                currentBall.Speed = (int)(sender as NumericUpDown).Value;
            };

            currentBall.OnCollision += (oldX, oldY, newX, newY) =>
            {
                output.Text = $"#{currentBall.Name}: {currentBall.Counter} collisions";
                listbox.Items.Add($"{DateTime.Now.ToString("HH:mm:ss")} {oldX}{oldY} => {newX}{newY}");
            };
        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            //Update the position of each ball
            int total = 0;
            total++;
            balls.ForEach(y => y.UpdatePosition());
        }
    }
}
