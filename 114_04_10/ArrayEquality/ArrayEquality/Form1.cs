namespace ArrayEquality
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Text = "�}�C�۵����ˬd";
            button1.Text = "�ˬd�}�C";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] array1 = { 1, 2, 3, 4, 5 };
            int[] array2 = { 1, 2, 3, 4, 5 };

            // �ˬd�}�C�O�_�۵�
            bool areEqual = isArrayEqual(array1, array2);

            if (areEqual)
            {
                MessageBox.Show("�}�C�۵��C");
            }
            else
            {
                MessageBox.Show("�}�C���۵��C");
            }
        }

        private bool isArrayEqual(int[] array1, int[] array2)
        {
            // �ˬd���׬O�_���P
            if (array1.Length != array2.Length)
            {
                return false;
            }
            // �ˬd�C�Ӥ����O�_�۵�
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
                                                                                                                                                                                                                                                                                                  