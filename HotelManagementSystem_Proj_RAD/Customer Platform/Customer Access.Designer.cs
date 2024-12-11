namespace HotelManagementSystem_Proj.Customer_Platform
{
    partial class Customer_Access
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
            tabControl1 = new TabControl();
            tabPageHome = new TabPage();
            tabPageFindARoom = new TabPage();
            tabPageManageYourBookings = new TabPage();
            btnCancelBooking = new Button();
            dataGridViewManageYourBookings = new DataGridView();
            panel1 = new Panel();
            label1 = new Label();
            btnLogout = new Button();
            lblClock = new Label();
            lblHome = new Label();
            lblFindARoom = new Label();
            lblManageYourBookings = new Label();
            lblWelcomeUser = new Label();
            dataGridViewFindARoom = new DataGridView();
            tabControl1.SuspendLayout();
            tabPageFindARoom.SuspendLayout();
            tabPageManageYourBookings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewManageYourBookings).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFindARoom).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageHome);
            tabControl1.Controls.Add(tabPageFindARoom);
            tabControl1.Controls.Add(tabPageManageYourBookings);
            tabControl1.Location = new Point(256, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1350, 960);
            tabControl1.TabIndex = 0;
            // 
            // tabPageHome
            // 
            tabPageHome.Location = new Point(4, 34);
            tabPageHome.Name = "tabPageHome";
            tabPageHome.Padding = new Padding(3);
            tabPageHome.Size = new Size(1342, 922);
            tabPageHome.TabIndex = 0;
            tabPageHome.Text = "Home";
            tabPageHome.UseVisualStyleBackColor = true;
            // 
            // tabPageFindARoom
            // 
            tabPageFindARoom.Controls.Add(dataGridViewFindARoom);
            tabPageFindARoom.Location = new Point(4, 34);
            tabPageFindARoom.Name = "tabPageFindARoom";
            tabPageFindARoom.Padding = new Padding(3);
            tabPageFindARoom.Size = new Size(1342, 922);
            tabPageFindARoom.TabIndex = 1;
            tabPageFindARoom.Text = "Find A Room";
            tabPageFindARoom.UseVisualStyleBackColor = true;
            // 
            // tabPageManageYourBookings
            // 
            tabPageManageYourBookings.Controls.Add(btnCancelBooking);
            tabPageManageYourBookings.Controls.Add(dataGridViewManageYourBookings);
            tabPageManageYourBookings.Location = new Point(4, 34);
            tabPageManageYourBookings.Name = "tabPageManageYourBookings";
            tabPageManageYourBookings.Size = new Size(1342, 922);
            tabPageManageYourBookings.TabIndex = 2;
            tabPageManageYourBookings.Text = "Manage Your Bookings";
            tabPageManageYourBookings.UseVisualStyleBackColor = true;
            // 
            // btnCancelBooking
            // 
            btnCancelBooking.Location = new Point(1031, 836);
            btnCancelBooking.Margin = new Padding(4);
            btnCancelBooking.Name = "btnCancelBooking";
            btnCancelBooking.Size = new Size(191, 50);
            btnCancelBooking.TabIndex = 14;
            btnCancelBooking.Text = "Cancel Booking";
            btnCancelBooking.UseVisualStyleBackColor = true;
            btnCancelBooking.Click += btnCancelBooking_Click;
            // 
            // dataGridViewManageYourBookings
            // 
            dataGridViewManageYourBookings.BackgroundColor = Color.FromArgb(14, 36, 66);
            dataGridViewManageYourBookings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewManageYourBookings.Location = new Point(4, 0);
            dataGridViewManageYourBookings.Margin = new Padding(4);
            dataGridViewManageYourBookings.Name = "dataGridViewManageYourBookings";
            dataGridViewManageYourBookings.RowHeadersWidth = 51;
            dataGridViewManageYourBookings.RowTemplate.Height = 29;
            dataGridViewManageYourBookings.Size = new Size(1326, 750);
            dataGridViewManageYourBookings.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(14, 36, 66);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(btnLogout);
            panel1.Controls.Add(lblClock);
            panel1.Controls.Add(lblHome);
            panel1.Controls.Add(lblFindARoom);
            panel1.Controls.Add(lblManageYourBookings);
            panel1.Controls.Add(lblWelcomeUser);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 960);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(44, 811);
            label1.Name = "label1";
            label1.Size = new Size(54, 25);
            label1.TabIndex = 14;
            label1.Text = "Time:";
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(70, 870);
            btnLogout.Margin = new Padding(4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(125, 50);
            btnLogout.TabIndex = 13;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // lblClock
            // 
            lblClock.AutoSize = true;
            lblClock.ForeColor = Color.White;
            lblClock.Location = new Point(105, 811);
            lblClock.Margin = new Padding(4, 0, 4, 0);
            lblClock.Name = "lblClock";
            lblClock.Size = new Size(55, 25);
            lblClock.TabIndex = 12;
            lblClock.Text = "Clock";
            // 
            // lblHome
            // 
            lblHome.AutoSize = true;
            lblHome.BackColor = Color.FromArgb(14, 36, 66);
            lblHome.Cursor = Cursors.Hand;
            lblHome.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblHome.ForeColor = Color.White;
            lblHome.Location = new Point(30, 387);
            lblHome.Margin = new Padding(4, 0, 4, 0);
            lblHome.Name = "lblHome";
            lblHome.Size = new Size(63, 25);
            lblHome.TabIndex = 6;
            lblHome.Text = "Home";
            // 
            // lblFindARoom
            // 
            lblFindARoom.AutoSize = true;
            lblFindARoom.BackColor = Color.FromArgb(14, 36, 66);
            lblFindARoom.Cursor = Cursors.Hand;
            lblFindARoom.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFindARoom.ForeColor = Color.White;
            lblFindARoom.Location = new Point(30, 446);
            lblFindARoom.Margin = new Padding(4, 0, 4, 0);
            lblFindARoom.Name = "lblFindARoom";
            lblFindARoom.Size = new Size(121, 25);
            lblFindARoom.TabIndex = 7;
            lblFindARoom.Text = "Find A Room";
            // 
            // lblManageYourBookings
            // 
            lblManageYourBookings.AutoSize = true;
            lblManageYourBookings.BackColor = Color.FromArgb(14, 36, 66);
            lblManageYourBookings.Cursor = Cursors.Hand;
            lblManageYourBookings.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblManageYourBookings.ForeColor = Color.White;
            lblManageYourBookings.Location = new Point(30, 508);
            lblManageYourBookings.Margin = new Padding(4, 0, 4, 0);
            lblManageYourBookings.Name = "lblManageYourBookings";
            lblManageYourBookings.Size = new Size(208, 25);
            lblManageYourBookings.TabIndex = 8;
            lblManageYourBookings.Text = "Manage Your Bookings";
            // 
            // lblWelcomeUser
            // 
            lblWelcomeUser.AutoSize = true;
            lblWelcomeUser.FlatStyle = FlatStyle.Flat;
            lblWelcomeUser.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblWelcomeUser.ForeColor = Color.White;
            lblWelcomeUser.Location = new Point(17, 311);
            lblWelcomeUser.Margin = new Padding(4, 0, 4, 0);
            lblWelcomeUser.Name = "lblWelcomeUser";
            lblWelcomeUser.Size = new Size(126, 32);
            lblWelcomeUser.TabIndex = 11;
            lblWelcomeUser.Text = "Welcome,";
            // 
            // dataGridViewFindARoom
            // 
            dataGridViewFindARoom.BackgroundColor = Color.FromArgb(14, 36, 66);
            dataGridViewFindARoom.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewFindARoom.Location = new Point(4, 0);
            dataGridViewFindARoom.Margin = new Padding(4);
            dataGridViewFindARoom.Name = "dataGridViewFindARoom";
            dataGridViewFindARoom.RowHeadersWidth = 51;
            dataGridViewFindARoom.RowTemplate.Height = 29;
            dataGridViewFindARoom.Size = new Size(1326, 750);
            dataGridViewFindARoom.TabIndex = 2;
            // 
            // Customer_Access
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1600, 960);
            Controls.Add(panel1);
            Controls.Add(tabControl1);
            Name = "Customer_Access";
            Text = "Customer_Access";
            tabControl1.ResumeLayout(false);
            tabPageFindARoom.ResumeLayout(false);
            tabPageManageYourBookings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewManageYourBookings).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewFindARoom).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPageHome;
        private TabPage tabPageFindARoom;
        private Panel panel1;
        private Label lblHome;
        private Label lblFindARoom;
        private Label lblManageYourBookings;
        private Label lblWelcomeUser;
        private Label label1;
        private Button btnLogout;
        private Label lblClock;
        private TabPage tabPageManageYourBookings;
        private DataGridView dataGridViewManageYourBookings;
        private Button btnCancelBooking;
        private DataGridView dataGridViewFindARoom;
    }
}