using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace Program7_5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<string> teams = new List<string>();
        List<string> winners = new List<string>();
        bool filesLoaded = false;

        private void Form1_Load(object sender, EventArgs e)
        {
            // 顯示提示訊息
            MessageBox.Show("請選擇球隊資料檔案", "檔案載入", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (!LoadTeamFile())
            {
                MessageBox.Show("未載入球隊檔案，程式將關閉。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            // 顯示第二個提示訊息
            MessageBox.Show("請選擇冠軍紀錄資料檔案", "檔案載入", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (!LoadWinnerFile())
            {
                MessageBox.Show("未載入冠軍紀錄檔案，程式將關閉。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

            filesLoaded = true;
        }

        private bool LoadTeamFile()
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "請選擇 Teams.txt 檔案",
                Filter = "文字檔案 (*.txt)|*.txt"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    teams = new List<string>(File.ReadAllLines(ofd.FileName));
                    listBox1.Items.Clear();
                    foreach (var team in teams)
                    {
                        listBox1.Items.Add(team);
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("讀取 Teams 檔案時發生錯誤：" + ex.Message);
                    return false;
                }
            }

            return false;
        }

        private bool LoadWinnerFile()
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "請選擇 WorldSeries.txt 檔案",
                Filter = "文字檔案 (*.txt)|*.txt"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    winners = new List<string>(File.ReadAllLines(ofd.FileName));
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("讀取 Winners 檔案時發生錯誤：" + ex.Message);
                    return false;
                }
            }

            return false;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!filesLoaded || listBox1.SelectedItem == null)
                return;

            string selectedTeam = listBox1.SelectedItem.ToString();
            int numWins = 0;
            List<int> years = new List<int>();

            int startYear = 1903;
            int skipYear1 = 1904;
            int skipYear2 = 1994;

            for (int i = 0, year = startYear; i < winners.Count; year++)
            {
                if (year == skipYear1 || year == skipYear2)
                    continue;

                if (i >= winners.Count) break;

                if (winners[i] == selectedTeam)
                {
                    numWins++;
                    years.Add(year);
                }

                i++;
            }

            if (numWins == 0)
            {
                label1.Text = $"【{selectedTeam}】尚未獲得MLB冠軍。";
            }
            else
            {
                label1.Text = $"【{selectedTeam}】共獲得 {numWins} 次MLB冠軍。\n年份如下：\n{string.Join("、", years)}";
            }
        }
    }
}


