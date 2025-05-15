using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CSV_Reader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void getScoresButton_Click(object sender, EventArgs e)
        {
            try 
            {
                StreamReader inputFile;
                string line;
                int count = 0;
                int total = 0;
                double average;

                char[] delim = { ',' ,' '};

                if (openFile.ShowDialog() == DialogResult.OK)
                {
                    inputFile = File.OpenText(openFile.FileName);

                    while (!inputFile.EndOfStream)
                    {
                        line = inputFile.ReadLine();
                        line = line.Trim();
                        string[] tokens = line.Split(delim);
                        total = 0;

                        for (int i = 0; i < tokens.Length; i++)
                        {
                            total +=int.Parse(tokens[i]);
                        }

                        average =(double)total / tokens.Length;
                        averagesListBox.Items.Add("第" + (++count)+"位同學的平均分數為:"+ average.ToString("F2"));
                    }
                }
                else 
                {
                    MessageBox.Show("未選擇任何檔案。");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("檔案讀取錯誤: " + ex.Message);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.
            this.Close();
        }
    }
}
