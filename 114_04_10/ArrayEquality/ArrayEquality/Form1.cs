namespace ArrayEquality
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "皚单┦浪琩";
            button1.Text = "浪琩皚";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] array1 = { 1, 2, 3, 4, 5 };
            int[] array2 = { 1, 2, 3, 4, 5 };

            // 浪琩皚琌单
            bool areEqual = isArrayEqual(array1, array2);

            if (areEqual)
            {
                MessageBox.Show("皚单");
            }
            else
            {
                MessageBox.Show("皚ぃ单");
            }
        }

        private bool isArrayEqual(int[] array1, int[] array2)
        {
            // 浪琩琌ぃ
            if (array1.Length != array2.Length)
            {
                return false;
            }
            // 浪琩–じ琌单
            for (int i = 0; i < array1.Length; i++)
            {
                if (array1[i] != array2[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
                                                                                                                                                                                                                                                                                                  