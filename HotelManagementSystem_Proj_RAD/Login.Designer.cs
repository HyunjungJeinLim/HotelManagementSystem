namespace HotelManagementSystem_Proj_RAD
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
            label1 = new Label();
            btnLogin = new Button();
            txtUser = new TextBox();
            txtPassword = new TextBox();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Lavender;
            label1.Location = new Point(311, 67);
            label1.Name = "label1";
            label1.Size = new Size(164, 25);
            label1.TabIndex = 0;
            label1.Text = "Manage Your Hotel";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(334, 262);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(112, 34);
            btnLogin.TabIndex = 1;
            btnLogin.Text = "Log in";
            btnLogin.UseVisualStyleBackColor = true;
            // 
            // txtUser
            // 
            txtUser.Location = new Point(311, 131);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(164, 31);
            txtUser.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(311, 183);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(164, 31);
            txtPassword.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Lavender;
            panel1.Location = new Point(-1, -3);
            panel1.Name = "panel1";
            panel1.Size = new Size(799, 456);
            panel1.TabIndex = 5;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtPassword);
            Controls.Add(txtUser);
            Controls.Add(btnLogin);
            Controls.Add(label1);
            Controls.Add(panel1);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Home";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnLogin;
        private TextBox txtUser;
        private TextBox txtPassword;
        private PictureBox pictureBox1;
        private Panel panel1;
    }
}
