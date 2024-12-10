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
            btnLogin = new Button();
            txtUser = new TextBox();
            txtPassword = new TextBox();
            panel1 = new Panel();
            pictureBoxLogo = new PictureBox();
            label3 = new Label();
            label2 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(363, 433);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(112, 34);
            btnLogin.TabIndex = 1;
            btnLogin.Text = "Log in";
            btnLogin.UseVisualStyleBackColor = true;
            // 
            // txtUser
            // 
            txtUser.Location = new Point(337, 326);
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(164, 31);
            txtUser.TabIndex = 3;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(337, 378);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(164, 31);
            txtPassword.TabIndex = 4;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(14, 36, 66);
            panel1.Controls.Add(pictureBoxLogo);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtPassword);
            panel1.Controls.Add(btnLogin);
            panel1.Controls.Add(txtUser);
            panel1.Location = new Point(-1, -3);
            panel1.Name = "panel1";
            panel1.Size = new Size(799, 563);
            panel1.TabIndex = 5;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Location = new Point(251, 59);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(250, 250);
            pictureBoxLogo.TabIndex = 7;
            pictureBoxLogo.TabStop = false;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(236, 378);
            label3.Name = "label3";
            label3.Size = new Size(91, 25);
            label3.TabIndex = 6;
            label3.Text = "Password:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(236, 326);
            label2.Name = "label2";
            label2.Size = new Size(95, 25);
            label2.TabIndex = 5;
            label2.Text = "Username:";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 556);
            Controls.Add(panel1);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Home";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Button btnLogin;
        private TextBox txtUser;
        private TextBox txtPassword;
        private PictureBox pictureBoxLogo;
        private Panel panel1;
        private Label label3;
        private Label label2;
    }
}
