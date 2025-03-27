namespace NumberFrequency
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            numberTextBox = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // numberTextBox
            // 
            numberTextBox.CausesValidation = false;
            numberTextBox.Font = new Font("Microsoft JhengHei UI", 20F);
            numberTextBox.Location = new Point(59, 50);
            numberTextBox.Name = "numberTextBox";
            numberTextBox.Size = new Size(209, 41);
            numberTextBox.TabIndex = 0;
            numberTextBox.TextAlign = HorizontalAlignment.Center;
            // 
            // button1
            // 
            button1.Location = new Point(109, 119);
            button1.Name = "button1";
            button1.Size = new Size(109, 42);
            button1.TabIndex = 1;
            button1.Text = "出現次數";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(335, 197);
            Controls.Add(button1);
            Controls.Add(numberTextBox);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox numberTextBox;
        private Button button1;
    }
}
