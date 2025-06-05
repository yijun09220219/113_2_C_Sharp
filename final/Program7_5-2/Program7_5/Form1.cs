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
        string teamFilePath = string.Empty;
        string winnerFilePath = string.Empty;

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("請選擇球隊資料檔案", "檔案載入", MessageBoxButtons.OK, MessageBoxIcon.Information);

            if (!LoadTeamFile())
            {
                MessageBox.Show("未載入球隊檔案，程式將關閉。", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
                return;
            }

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
                    teamFilePath = ofd.FileName;
                    teams = new List<string>(File.ReadAllLines(teamFilePath));
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
                    winnerFilePath = ofd.FileName;
                    winners = new List<string>(File.ReadAllLines(winnerFilePath));
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

        private void btnAddData_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Title = "請選擇 2010 年以後的 WorldSeries 資料",
                Filter = "文字檔案 (*.txt)|*.txt"
            };

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var newWinners = new List<string>(File.ReadAllLines(ofd.FileName));
                    winners.AddRange(newWinners);

                    foreach (var team in newWinners)
                    {
                        if (!teams.Contains(team))
                        {
                            teams.Add(team);
                            listBox1.Items.Add(team);
                        }
                    }

                    MessageBox.Show("資料已成功新增！", "成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("讀取新資料檔時發生錯誤：" + ex.Message);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(teamFilePath))
                    File.WriteAllLines(teamFilePath, teams);

                if (!string.IsNullOrEmpty(winnerFilePath))
                    File.WriteAllLines(winnerFilePath, winners);

                MessageBox.Show("資料已儲存，程式即將關閉。", "結束", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show("儲存檔案時發生錯誤：" + ex.Message);
            }
        }
    }
}

