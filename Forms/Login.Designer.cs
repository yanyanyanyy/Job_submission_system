namespace Forms
{
    partial class Login
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
            comboBox1 = new ComboBox();
            ID = new Label();
            textBox1 = new TextBox();
            Password = new Label();
            textBox2 = new TextBox();
            SignIn = new Button();
            register = new Button();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(271, 49);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(269, 32);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // ID
            // 
            ID.AutoSize = true;
            ID.Location = new Point(275, 107);
            ID.Name = "ID";
            ID.Size = new Size(29, 24);
            ID.TabIndex = 1;
            ID.Text = "ID";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(271, 134);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(269, 30);
            textBox1.TabIndex = 2;
            // 
            // Password
            // 
            Password.AutoSize = true;
            Password.Location = new Point(271, 189);
            Password.Name = "Password";
            Password.Size = new Size(91, 24);
            Password.TabIndex = 3;
            Password.Text = "Password";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(271, 216);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(269, 30);
            textBox2.TabIndex = 4;
            // 
            // SignIn
            // 
            SignIn.Location = new Point(473, 300);
            SignIn.Name = "SignIn";
            SignIn.Size = new Size(146, 41);
            SignIn.TabIndex = 5;
            SignIn.Text = "登录";
            SignIn.UseVisualStyleBackColor = true;
            // 
            // register
            // 
            register.Location = new Point(636, 300);
            register.Name = "register";
            register.Size = new Size(134, 41);
            register.TabIndex = 6;
            register.Text = "注册";
            register.UseVisualStyleBackColor = true;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(register);
            Controls.Add(SignIn);
            Controls.Add(textBox2);
            Controls.Add(Password);
            Controls.Add(textBox1);
            Controls.Add(ID);
            Controls.Add(comboBox1);
            Name = "Login";
            Text = "Form1";
            Load += Login_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private Label ID;
        private TextBox textBox1;
        private Label Password;
        private TextBox textBox2;
        private Button SignIn;
        private Button register;
    }
}