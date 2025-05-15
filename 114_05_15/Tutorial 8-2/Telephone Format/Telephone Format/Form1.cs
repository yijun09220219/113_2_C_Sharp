using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telephone_Format
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // IsValidNumber 方法接受一個字串，若該字串包含 10 位數字則回傳 true，否則回傳 false。  
        private bool IsValidNumber(string str)
        {
            const int VALID_LENGTH = 10; // 定義有效字串的長度為 10 位數字。  

            if (str.Length == VALID_LENGTH) // 檢查字串長度是否為 10。  
            {
                for (int i = 0; i < str.Length; i++) // 遍歷字串中的每個字元。  
                {
                    if (!char.IsDigit(str[i])) // 檢查字元是否為數字。  
                    {
                        return false; // 若有非數字字元，則回傳 false。  
                    }
                }
                return true; // 若字串長度為 10 且所有字元皆為數字，則回傳 true。  
            }
            return false; // 若字串長度不為 10，則回傳 false。  
        }

        // TelephoneFormat 方法接受一個字串參數（以引用方式傳遞），並將其格式化為電話號碼。  
        private void TelephoneFormat(ref string str)
        {
            //if (str.Length == 10)
            //{
            //    str = $"{str.Substring(0, 2)}-{str.Substring(2, 4)}-{str.Substring(6, 4)}"; // 格式化字串為 xxx-xxx-xxxx。  
            //}
            str = str.Insert(0, "("); // 在字串開頭插入左括號。
            str = str.Insert(3, ") "); // 在字串第 3 個位置插入右括號和空格。
            str = str.Insert(9, "-"); // 在字串第 9 個位置插入連字號。
        }

        private void formatButton_Click(object sender, EventArgs e)
        {
            string input = numberTextBox.Text; // 取得使用者輸入的字串。  

            if (IsValidNumber(input)) // 檢查字串是否有效。  
            {
                TelephoneFormat(ref input); // 格式化字串。  
                MessageBox.Show(input, "格式化結果", MessageBoxButtons.OK); // 顯示格式化後的字串。  
            }
            else
            {
                MessageBox.Show("請輸入 10 位數字。", "錯誤", MessageBoxButtons.OK); // 顯示錯誤訊息。  
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單。  
            this.Close();
        }
    }
}
