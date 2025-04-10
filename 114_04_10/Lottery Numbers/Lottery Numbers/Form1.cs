using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lottery_Numbers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            const int SIZE = 5; // 要生成的樂透號碼數量。
            int[] lotteryNumbers = new int[SIZE]; // 用於存放樂透號碼的陣列。
            Random rand = new Random(); // 隨機數生成器。

            for (int i = 0; i < lotteryNumbers.Length; i++)
            {
                int number;
                do
                {
                    number = rand.Next(1, 43); // 生成一個介於 1 到 42 之間的隨機數。
                } while (lotteryNumbers.Contains(number)); // 檢查該數字是否已在陣列中。
                lotteryNumbers[i] = number; // 將隨機數存入陣列。
            }

            //將lotteryNumbers陣列中的數字由小到大排序。
            Array.Sort(lotteryNumbers);

            // firstLabel.Text = lotteryNumbers[0].ToString();
            // secondLabel.Text = lotteryNumbers[1].ToString();
            // thirdLabel.Text = lotteryNumbers[2].ToString();
            // fourthLabel.Text = lotteryNumbers[3].ToString();
            // fifthLabel.Text = lotteryNumbers[4].ToString();

            Label[] showLabels = { firstLabel, secondLabel, thirdLabel, fourthLabel, fifthLabel };
            for (int i = 0; i < SIZE; i++)
            {
                showLabels[i].Text = lotteryNumbers[i].ToString();
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單。
            this.Close();
        }
    }
}

