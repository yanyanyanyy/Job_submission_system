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
            comboBox1.SelectedIndex = 0;//设置该下拉框默认选中第一项。
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Add("学生");
            comboBox1.Items.Add("老师");
            if (comboBox1.SelectedItem.ToString() == "选项1")
            {
                // 执行选项1的操作
            }
            else if (comboBox1.SelectedItem.ToString() == "选项2")
            {
                // 执行选项2的操作
            }
            else
            {
                // 执行其他选项的操作
            }
        }
    }
    

}