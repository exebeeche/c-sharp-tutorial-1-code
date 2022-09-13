using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsTest3
{
    public partial class Form1 : Form
    {
        int topChange = 5;
        int leftChange = 5;
        int score1 = 0;
        int score2 = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Left = pictureBox1.Left + leftChange;
            pictureBox1.Top = pictureBox1.Top + topChange;

            if (pictureBox1.Left > 260)
            {
                leftChange = -5;
            }
            if (pictureBox1.Left < 0)
            {
                leftChange = 5;
            }
            if (pictureBox1.Top > 245)
            {
                topChange = -5;
            }
            if (pictureBox1.Top < 0)
            {
                topChange = 5;
            }

            pictureBox2.Left = pictureBox2.Left + leftChange;
            pictureBox2.Top = pictureBox2.Top + topChange;

            if (pictureBox2.Left > 260)
            {
                leftChange = -5;
            }
            if (pictureBox2.Left < 0)
            {
                leftChange = 5;
            }
            if (pictureBox2.Top > 245)
            {
                topChange = -5;
            }
            if (pictureBox2.Top < 0)
            {
                topChange = 5;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, 50, 50);
            Region rgn = new Region(path);
            pictureBox1.Region = rgn;
            pictureBox1.BackColor = Color.Red;
            pictureBox2.Region = rgn;
            pictureBox2.BackColor = Color.Green;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        
    }
}
