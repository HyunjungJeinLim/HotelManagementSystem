﻿namespace HotelManagementSystem_Proj
{
    partial class CustomerInfo
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtFirstName = new TextBox();
            txtLastName = new TextBox();
            txtPhone = new TextBox();
            txtEmail = new TextBox();
            chkIsActive = new CheckBox();
            btnSaveCustomer = new Button();
            btnCancel = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(65, 49);
            label1.Name = "label1";
            label1.Size = new Size(101, 25);
            label1.TabIndex = 0;
            label1.Text = "First Name:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(65, 101);
            label2.Name = "label2";
            label2.Size = new Size(94, 25);
            label2.TabIndex = 1;
            label2.Text = "LastName:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(65, 153);
            label3.Name = "label3";
            label3.Size = new Size(66, 25);
            label3.TabIndex = 2;
            label3.Text = "Phone:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(65, 205);
            label4.Name = "label4";
            label4.Size = new Size(58, 25);
            label4.TabIndex = 3;
            label4.Text = "Email:";
            // 
            // txtFirstName
            // 
            txtFirstName.Location = new Point(200, 49);
            txtFirstName.Name = "txtFirstName";
            txtFirstName.Size = new Size(199, 31);
            txtFirstName.TabIndex = 4;
            // 
            // txtLastName
            // 
            txtLastName.Location = new Point(200, 101);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(199, 31);
            txtLastName.TabIndex = 5;
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(200, 153);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(199, 31);
            txtPhone.TabIndex = 6;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(200, 205);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(199, 31);
            txtEmail.TabIndex = 7;
            // 
            // chkIsActive
            // 
            chkIsActive.AutoSize = true;
            chkIsActive.ForeColor = Color.White;
            chkIsActive.Location = new Point(200, 256);
            chkIsActive.Name = "chkIsActive";
            chkIsActive.Size = new Size(86, 29);
            chkIsActive.TabIndex = 8;
            chkIsActive.Text = "Active";
            chkIsActive.UseVisualStyleBackColor = true;
            // 
            // btnSaveCustomer
            // 
            btnSaveCustomer.Location = new Point(219, 319);
            btnSaveCustomer.Name = "btnSaveCustomer";
            btnSaveCustomer.Size = new Size(112, 34);
            btnSaveCustomer.TabIndex = 9;
            btnSaveCustomer.Text = "Save";
            btnSaveCustomer.UseVisualStyleBackColor = true;
            btnSaveCustomer.Click += btnSaveCustomer_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(349, 319);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(112, 34);
            btnCancel.TabIndex = 10;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // CustomerInfo
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(14, 36, 66);
            ClientSize = new Size(521, 395);
            Controls.Add(btnCancel);
            Controls.Add(btnSaveCustomer);
            Controls.Add(chkIsActive);
            Controls.Add(txtEmail);
            Controls.Add(txtPhone);
            Controls.Add(txtLastName);
            Controls.Add(txtFirstName);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "CustomerInfo";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Customer Information";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtFirstName;
        private TextBox txtLastName;
        private TextBox txtPhone;
        private TextBox txtEmail;
        private CheckBox chkIsActive;
        private Button btnCancel;
        private Button btnSaveCustomer;
    }
}