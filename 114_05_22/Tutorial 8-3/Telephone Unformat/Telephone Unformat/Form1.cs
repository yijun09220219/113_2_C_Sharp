using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Telephone_Unformat
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // `IsValidFormat` 方法接受一個字串參數，並檢查該字串是否符合美國電話號碼的格式。
        // 格式要求如下：(XXX)XXX-XXXX，其中：
        // - `XXX` 是三位數字。
        // - 中間沒有空格，括號和連字符必須正確放置。
        // 如果字串符合格式，則返回 `true`，否則返回 `false`。
        private bool IsValidFormat(string str)
        {
            if (str.Length == 13 &&
                str[0] == '(' &&
                 str[3] == ')' &&
                 str[8] == '-') 
            {
                string areaCode = str.Substring(1, 2); // 取得區域碼。
                string firstPart = str.Substring(4, 4); // 取得第一部分。
                string secondPart = str.Substring(9, 4); // 取得第二部分。

                if (IsAllDigits(areaCode) &&
                    IsAllDigits(firstPart) &&
                    IsAllDigits(secondPart)) 
                {
                    return true; // 如果所有部分都是數字，則返回 true。
                }
                return false;
            }
            return false; // 如果字串長度不正確或格式不正確，則返回 false。
        }

        // `IsAllDigits` 方法接受一個字串參數，並檢查該字串是否全部由數字組成。
        // 如果字串全部由數字組成，則返回 `true`，否則返回 `false`。
        private bool IsAllDigits(string str)
        {
            foreach (char c in str)
            {
                if (!char.IsDigit(c))
                {
                    return false; // 如果有任何字符不是數字，則返回 false。
                }
            }
            return true; // 如果所有字符都是數字，則返回 true。
        }

        // `Unformat` 方法接受一個字串參數（以引用方式傳遞），該字串假設為格式化的電話號碼。
        // 格式化的電話號碼格式為：(XXX)XXX-XXXX。
        // 此方法的功能是移除字串中的括號 `()` 和連字符 `-`，將其轉換為純數字格式。
        private void Unformat(ref string str)
        {
            str = str.Remove(0, 1); // 移除開頭的括號 `(`。
            str = str.Remove(2, 1); // 移除結尾的括號 `)`。
            str = str.Remove(6, 1); // 移除連字符 `-`。
        }

        // 當使用者點擊「取消格式化」按鈕時，執行此事件處理方法。
        // 此方法會檢查輸入的電話號碼是否符合格式，並嘗試將其取消格式化。
        private void unformatButton_Click(object sender, EventArgs e)
        {
            string input = numberTextBox.Text; // 取得使用者輸入的電話號碼。
            input = input.Trim();


            if (IsValidFormat(input)) 
            {
                Unformat(ref input); // 如果格式正確，則取消格式化電話號碼。
                MessageBox.Show("去格式化後的電話號碼為: " + input,"結果",MessageBoxButtons.OK); // 顯示取消格式化後的電話號碼。
            }
            else
            {
                MessageBox.Show("請輸入正確的電話號碼格式: (XXX)XXX-XXXX", "錯誤", MessageBoxButtons.OK); // 如果格式不正確，則顯示錯誤訊息。
            }
        }

        // 當使用者點擊「退出」按鈕時，執行此事件處理方法。
        // 此方法的功能是關閉表單，結束應用程式。
        private void exitButton_Click(object sender, EventArgs e)
        {
            // 關閉表單。
            this.Close();
        }
    }
}
