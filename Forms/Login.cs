namespace Forms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.Load += new EventHandler(Login_Load);
        }

        private void Login_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;//���ø�������Ĭ��ѡ�е�һ�
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Add("ѧ��");
            comboBox1.Items.Add("��ʦ");
            if (comboBox1.SelectedItem.ToString() == "ѡ��1")
            {
                // ִ��ѡ��1�Ĳ���
            }
            else if (comboBox1.SelectedItem.ToString() == "ѡ��2")
            {
                // ִ��ѡ��2�Ĳ���
            }
            else
            {
                // ִ������ѡ��Ĳ���
            }
        }
    }
    

}