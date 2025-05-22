﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Linq.Expressions;

namespace Phonebook
{
    struct PhoneBookEntry
    {
        public string name;
        public string phone;
    }

    public partial class Form1 : Form
    {
        // Field to hold a list of PhoneBookEntry objects.  
        private List<PhoneBookEntry> phoneList =
            new List<PhoneBookEntry>();

        public Form1()
        {
            InitializeComponent();
        }

        // The ReadFile method reads the contents of the  
        // PhoneList.txt file and stores it as PhoneBookEntry  
        // objects in the phoneList.  
        private void ReadFile()
        {
            StreamReader inputFile;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    inputFile = File.OpenText(openFileDialog1.FileName);
                    string line;
                    while (!inputFile.EndOfStream)
                    {
                        line = inputFile.ReadLine().Trim();
                        string[] parts = line.Split(',');
                        if (parts.Length == 2)
                        {
                            PhoneBookEntry entry;
                            entry.name = parts[0].Trim();
                            entry.phone = parts[1].Trim();
                            phoneList.Add(entry);
                        }
                        else
                        {
                            MessageBox.Show("檔案格式錯誤");
                        }
                    }
                    inputFile.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("檔案讀取錯誤: " + ex.Message);
                }
            }
        } // <-- Missing closing brace added here  

        // The DisplayNames method displays the list of names  
        // in the namesListBox control.  
        private void DisplayNames()
        {
            foreach (PhoneBookEntry entry in phoneList)
            {
                nameListBox.Items.Add(entry.name);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ReadFile();

            DisplayNames();
        }

        private void nameListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = nameListBox.SelectedIndex;
            if (index != -1) 
            {
                // Display the selected phone number.  
                phoneLabel.Text = phoneList[index].phone;
            }
            else
            {
                // Clear the label if no item is selected.  
                phoneLabel.Text = "無資料";
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.  
            this.Close();
        }
    }
}
