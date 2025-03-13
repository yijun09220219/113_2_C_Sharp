using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Program5_9
{
    public partial class Form1 : Form
    {
        Random rand = new Random();//create a random object

        public Form1()
        {
            InitializeComponent();
        }



        private void button1_Click(object sender, EventArgs e)
        {
            int n1 = rand.Next(1, 7);//generate a random number between 1 and 6
            int n2 = rand.Next(1, 7);//generate a random number between 1 and 6

            showPictureBox(n1,pictureBox1);

            showPictureBox(n2,pictureBox2);
        }

        private void showPictureBox(int n,PictureBox pic)
        {
            switch (n)
            {
                case 1:
                    pic.Image = Properties.Resources._1Die;
                    break;
                case 2:
                    pic.Image = Properties.Resources._2Die;
                    break;
                case 3:
                    pic.Image = Properties.Resources._3Die;
                    break;
                case 4:
                    pic.Image = Properties.Resources._4Die;
                    break;
                case 5:
                    pic.Image = Properties.Resources._5Die;
                    break;
                case 6:
                    pic.Image = Properties.Resources._6Die;
                    break;


            }
        }
    }
}
