namespace HotelManagementSystem_Proj.Customer_Platform
{
    partial class SignUp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            labelLogIn = new Label();
            lblLastName = new Label();
            txtLastName = new TextBox();
            label5 = new Label();
            lblPhoneNumber = new Label();
            txtPhoneNumber = new TextBox();
            btnSignUp = new Button();
            pictureBoxLogo = new PictureBox();
            lblFirstName = new Label();
            lblEmail = new Label();
            txtFirstName = new TextBox();
            txtEmail = new TextBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(14, 36, 66);
            panel1.Controls.Add(labelLogIn);
            panel1.Controls.Add(lblLastName);
            panel1.Controls.Add(txtLastName);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(lblPhoneNumber);
            panel1.Controls.Add(txtPhoneNumber);
            panel1.Controls.Add(btnSignUp);
            panel1.Controls.Add(pictureBoxLogo);
            panel1.Controls.Add(lblFirstName);
            panel1.Controls.Add(lblEmail);
            panel1.Controls.Add(txtFirstName);
            panel1.Controls.Add(txtEmail);
            panel1.Location = new Point(-2, -5);
            panel1.Name = "panel1";
            panel1.Size = new Size(809, 773);
            panel1.TabIndex = 6;
            // 
            // labelLogIn
            // 
            labelLogIn.AutoSize = true;
            labelLogIn.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            labelLogIn.ForeColor = Color.White;
            labelLogIn.Location = new Point(413, 694);
            labelLogIn.Name = "labelLogIn";
            labelLogIn.Size = new Size(65, 25);
            labelLogIn.TabIndex = 18;
            labelLogIn.Text = "Log In";
            labelLogIn.Click += btnLogin_Click;
            // 
            // lblLastName
            // 
            lblLastName.AutoSize = true;
            lblLastName.ForeColor = Color.White;
            lblLastName.Location = new Point(194, 464);
            lblLastName.Name = "lblLastName";
            lblLastName.Size = new Size(99, 25);
            lblLastName.TabIndex = 17;
            lblLastName.Text = "Last Name:";
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(337, 464);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(203, 31);
            txtLastName.TabIndex = 16;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.White;
            label5.Location = new Point(270, 694);
            label5.Name = "label5";
            label5.Size = new Size(137, 25);
            label5.TabIndex = 15;
            label5.Text = "Already A User?";
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.ForeColor = Color.White;
            lblPhoneNumber.Location = new Point(194, 518);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(66, 25);
            lblPhoneNumber.TabIndex = 12;
            lblPhoneNumber.Text = "Phone:";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(337, 518);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(203, 31);
            txtPhoneNumber.TabIndex = 10;
            // 
            // btnSignUp
            // 
            btnSignUp.Location = new Point(428, 585);
            btnSignUp.Name = "btnSignUp";
            btnSignUp.Size = new Size(112, 34);
            btnSignUp.TabIndex = 9;
            btnSignUp.Text = "Sign Up";
            btnSignUp.UseVisualStyleBackColor = true;
            btnSignUp.Click += btnSignUp_Click;
            // 
            // pictureBoxLogo
            // 
            pictureBoxLogo.Location = new Point(251, 61);
            pictureBoxLogo.Name = "pictureBoxLogo";
            pictureBoxLogo.Size = new Size(250, 250);
            pictureBoxLogo.TabIndex = 7;
            pictureBoxLogo.TabStop = false;
            // 
            // lblFirstName
            // 
            lblFirstName.AutoSize = true;
            lblFirstName.ForeColor = Color.White;
            lblFirstName.Location = new Point(194, 413);
            lblFirstName.Name = "lblFirstName";
            lblFirstName.Size = new Size(101, 25);
            lblFirstName.TabIndex = 6;
            lblFirstName.Text = "First Name:";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.ForeColor = Color.White;
            lblEmail.Location = new Point(194, 361);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(58, 25);
            lblEmail.TabIndex = 5;
            lblEmail.Text = "Email:";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(337, 413);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(203, 31);
            txtFirstName.TabIndex = 4;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(337, 361);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(203, 31);
            txtEmail.TabIndex = 3;
            // 
            // SignUp
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 763);
            Controls.Add(panel1);
            Name = "SignUp";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sign Up";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lblPhoneNumber;
        private TextBox txtPhoneNumber;
        private Button btnSignUp;
        private PictureBox pictureBoxLogo;
        private Label lblFirstName;
        private Label lblEmail;
        private TextBox txtFirstName;
        private TextBox txtEmail;
        private Label label5;
        private Label lblLastName;
        private TextBox txtLastName;
        private Label labelLogIn;
    }
}