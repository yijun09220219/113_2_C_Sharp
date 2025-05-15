using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Password_Validation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // 設定元件的文字屬性為繁體中文  
            this.Text = "密碼驗證";
            checkPasswordButton.Text = "檢查密碼";
            exitButton.Text = "退出";
        }

        // The NumberUpperCase method accepts a string argument  
        // and returns the number of uppercase letters it contains.  
        private int NumberUpperCase(string str)
        {
            int upperCaseCount = 0; // To hold the number of uppercase letters  
            foreach (char ch in str)
            {
                if (char.IsUpper(ch))
                {
                    upperCaseCount++; // Increment the count  
                }
            }
            return upperCaseCount; // Return the count  
        }

        // The NumberLowerCase method accepts a string argument  
        // and returns the number of lowercase letters it contains.  
        private int NumberLowerCase(string str)
        {
            int lowerCaseCount = 0; // To hold the number of lowercase letters  
            for (int i = 0; i < str.Length; i++) // Fixed loop syntax  
            {
                if (char.IsLower(str[i]))
                {
                    lowerCaseCount++; // Increment the count  
                }
            }
            return lowerCaseCount; // Return the count  
        }

        // The NumberDigits method accepts a string argument  
        // and returns the number of numeric digits it contains.  
        private int NumberDigits(string str)
        {
            int digits = 0; // To hold the number of digits  
            foreach (char c in str)
            {
                if (char.IsDigit(c))
                {
                    digits++; // Increment the count  
                }
            }
            return digits; // Return the count  
        }

        private void checkPasswordButton_Click(object sender, EventArgs e)
        {
            const int MINIMUM_LENGTH = 8; // Minimum password length  
            string password = passwordTextBox.Text; // To hold the password  
            if (password.Length >= MINIMUM_LENGTH &&
                NumberUpperCase(password) > 0 &&
                NumberLowerCase(password) > 0 &&
                NumberDigits(password) > 0)
            {
                MessageBox.Show("密碼有效!", "密碼檢查結果", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("密碼無效!", "密碼檢查結果", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // Close the form.  
            this.Close();
        }
    }
}
