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

            switch (n1)
            {
                case 1:
                    pictureBox1.Image = Properties.Resources._1Die;
                    break;
                case 2:
                    pictureBox1.Image = Properties.Resources._2Die;
                    break;
                case 3:
                    pictureBox1.Image = Properties.Resources._3Die;
                    break;
                case 4:
                    pictureBox1.Image = Properties.Resources._4Die;
                    break;
                case 5:
                    pictureBox1.Image = Properties.Resources._5Die;
                    break;
                case 6:
                    pictureBox1.Image = Properties.Resources._6Die;
                    break;


            }

            switch (n2)
            {
                case 1:
                    pictureBox2.Image = Properties.Resources._1Die;
                    break;
                case 2:
                    pictureBox2.Image = Properties.Resources._2Die;
                    break;
                case 3:
                    pictureBox2.Image = Properties.Resources._3Die;
                    break;
                case 4:
                    pictureBox2.Image = Properties.Resources._4Die;
                    break;
                case 5:
                    pictureBox2.Image = Properties.Resources._5Die;
                    break;
                case 6:
                    pictureBox2.Image = Properties.Resources._6Die;
                    break;
            }
        }
    }
}
