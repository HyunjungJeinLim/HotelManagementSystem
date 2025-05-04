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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Customer_Access));
            tabControl1 = new TabControl();
            tabPageHome = new TabPage();
            lblIncomingBooking = new Label();
            label6 = new Label();
            axWindowsMediaPlayer = new AxWMPLib.AxWindowsMediaPlayer();
            tabPageBookARoom = new TabPage();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            cbAmenities = new ComboBox();
            btnSearchRooms = new Button();
            cbRoomType = new ComboBox();
            btnBookRoom = new Button();
            dtpCheckOutDate = new DateTimePicker();
            dtpCheckInDate = new DateTimePicker();
            dataGridViewAvailableRooms = new DataGridView();
            tabPageManageYourBookings = new TabPage();
            btnCancelBooking = new Button();
            dataGridViewManageYourBookings = new DataGridView();
            panel1 = new Panel();
            pictureBoxLogo3 = new PictureBox();
            label1 = new Label();
            btnLogout = new Button();
            lblClock = new Label();
            lblHome = new Label();
            lblFindARoom = new Label();
            lblManageYourBookings = new Label();
            lblWelcomeUser = new Label();
            tabControl1.SuspendLayout();
            tabPageHome.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer).BeginInit();
            tabPageBookARoom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAvailableRooms).BeginInit();
            tabPageManageYourBookings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewManageYourBookings).BeginInit();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo3).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageHome);
            tabControl1.Controls.Add(tabPageBookARoom);
            tabControl1.Controls.Add(tabPageManageYourBookings);
            tabControl1.Location = new Point(256, 0);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1350, 960);
            tabControl1.TabIndex = 0;
            // 
            // tabPageHome
            // 
            tabPageHome.BackColor = Color.FromArgb(14, 36, 66);
            tabPageHome.Controls.Add(lblIncomingBooking);
            tabPageHome.Controls.Add(label6);
            tabPageHome.Controls.Add(axWindowsMediaPlayer);
            tabPageHome.Location = new Point(4, 34);
            tabPageHome.Name = "tabPageHome";
            tabPageHome.Padding = new Padding(3);
            tabPageHome.Size = new Size(1342, 922);
            tabPageHome.TabIndex = 0;
            tabPageHome.Text = "Home";
            // 
            // lblIncomingBooking
            // 
            lblIncomingBooking.AutoSize = true;
            lblIncomingBooking.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblIncomingBooking.ForeColor = Color.White;
            lblIncomingBooking.Location = new Point(215, 35);
            lblIncomingBooking.Name = "lblIncomingBooking";
            lblIncomingBooking.Size = new Size(215, 25);
            lblIncomingBooking.TabIndex = 3;
            lblIncomingBooking.Text = "No upcoming bookings.";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label6.ForeColor = Color.White;
            label6.Location = new Point(29, 35);
            label6.Name = "label6";
            label6.Size = new Size(180, 25);
            label6.TabIndex = 2;
            label6.Text = "Upcoming Booking:";
            // 
            // axWindowsMediaPlayer
            // 
            axWindowsMediaPlayer.Enabled = true;
            axWindowsMediaPlayer.Location = new Point(0, 86);
            axWindowsMediaPlayer.Name = "axWindowsMediaPlayer";
            axWindowsMediaPlayer.OcxState = (AxHost.State)resources.GetObject("axWindowsMediaPlayer.OcxState");
            axWindowsMediaPlayer.Size = new Size(1343, 755);
            axWindowsMediaPlayer.TabIndex = 1;
            // 
            // tabPageBookARoom
            // 
            tabPageBookARoom.BackColor = Color.FromArgb(14, 36, 66);
            tabPageBookARoom.Controls.Add(label5);
            tabPageBookARoom.Controls.Add(label4);
            tabPageBookARoom.Controls.Add(label3);
            tabPageBookARoom.Controls.Add(label2);
            tabPageBookARoom.Controls.Add(cbAmenities);
            tabPageBookARoom.Controls.Add(btnSearchRooms);
            tabPageBookARoom.Controls.Add(cbRoomType);
            tabPageBookARoom.Controls.Add(btnBookRoom);
            tabPageBookARoom.Controls.Add(dtpCheckOutDate);
            tabPageBookARoom.Controls.Add(dtpCheckInDate);
            tabPageBookARoom.Controls.Add(dataGridViewAvailableRooms);
            tabPageBookARoom.Location = new Point(4, 34);
            tabPageBookARoom.Name = "tabPageBookARoom";
            tabPageBookARoom.Padding = new Padding(3);
            tabPageBookARoom.Size = new Size(1342, 922);
            tabPageBookARoom.TabIndex = 1;
            tabPageBookARoom.Text = "Book A Room";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.White;
            label5.Location = new Point(842, 713);
            label5.Name = "label5";
            label5.Size = new Size(85, 25);
            label5.TabIndex = 10;
            label5.Text = "Check-In:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.White;
            label4.Location = new Point(842, 764);
            label4.Name = "label4";
            label4.Size = new Size(100, 25);
            label4.TabIndex = 9;
            label4.Text = "Check-Out:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.White;
            label3.Location = new Point(422, 766);
            label3.Name = "label3";
            label3.Size = new Size(94, 25);
            label3.TabIndex = 8;
            label3.Text = "Amenities:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.White;
            label2.Location = new Point(422, 713);
            label2.Name = "label2";
            label2.Size = new Size(106, 25);
            label2.TabIndex = 7;
            label2.Text = "Room Type:";
            // 
            // cbAmenities
            // 
            cbAmenities.FormattingEnabled = true;
            cbAmenities.Location = new Point(548, 766);
            cbAmenities.Name = "cbAmenities";
            cbAmenities.Size = new Size(182, 33);
            cbAmenities.TabIndex = 6;
            // 
            // btnSearchRooms
            // 
            btnSearchRooms.Location = new Point(897, 836);
            btnSearchRooms.Name = "btnSearchRooms";
            btnSearchRooms.Size = new Size(160, 50);
            btnSearchRooms.TabIndex = 5;
            btnSearchRooms.Text = "Search Room";
            btnSearchRooms.UseVisualStyleBackColor = true;
            btnSearchRooms.Click += btnSearchRooms_Click;
            // 
            // cbRoomType
            // 
            cbRoomType.FormattingEnabled = true;
            cbRoomType.Location = new Point(548, 713);
            cbRoomType.Name = "cbRoomType";
            cbRoomType.Size = new Size(182, 33);
            cbRoomType.TabIndex = 4;
            // 
            // btnBookRoom
            // 
            btnBookRoom.Location = new Point(1103, 836);
            btnBookRoom.Name = "btnBookRoom";
            btnBookRoom.Size = new Size(158, 50);
            btnBookRoom.TabIndex = 3;
            btnBookRoom.Text = "Book Room";
            btnBookRoom.UseVisualStyleBackColor = true;
            btnBookRoom.Click += btnBookRoom_Click;
            // 
            // dtpCheckOutDate
            // 
            dtpCheckOutDate.Location = new Point(961, 764);
            dtpCheckOutDate.Name = "dtpCheckOutDate";
            dtpCheckOutDate.Size = new Size(300, 31);
            dtpCheckOutDate.TabIndex = 2;
            // 
            // dtpCheckInDate
            // 
            dtpCheckInDate.Location = new Point(961, 713);
            dtpCheckInDate.Name = "dtpCheckInDate";
            dtpCheckInDate.Size = new Size(300, 31);
            dtpCheckInDate.TabIndex = 1;
            // 
            // dataGridViewAvailableRooms
            // 
            dataGridViewAvailableRooms.AllowUserToAddRows = false;
            dataGridViewAvailableRooms.AllowUserToDeleteRows = false;
            dataGridViewAvailableRooms.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewAvailableRooms.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewAvailableRooms.BackgroundColor = Color.FromArgb(14, 36, 66);
            dataGridViewAvailableRooms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewAvailableRooms.Location = new Point(3, 3);
            dataGridViewAvailableRooms.Name = "dataGridViewAvailableRooms";
            dataGridViewAvailableRooms.ReadOnly = true;
            dataGridViewAvailableRooms.RowHeadersWidth = 62;
            dataGridViewAvailableRooms.Size = new Size(1333, 626);
            dataGridViewAvailableRooms.TabIndex = 0;
            // 
            // tabPageManageYourBookings
            // 
            tabPageManageYourBookings.BackColor = Color.FromArgb(14, 36, 66);
            tabPageManageYourBookings.Controls.Add(btnCancelBooking);
            tabPageManageYourBookings.Controls.Add(dataGridViewManageYourBookings);
            tabPageManageYourBookings.Location = new Point(4, 34);
            tabPageManageYourBookings.Name = "tabPageManageYourBookings";
            tabPageManageYourBookings.Size = new Size(1342, 922);
            tabPageManageYourBookings.TabIndex = 2;
            tabPageManageYourBookings.Text = "Booking History";
            // 
            // btnCancelBooking
            // 
            btnCancelBooking.Location = new Point(1080, 836);
            btnCancelBooking.Margin = new Padding(4);
            btnCancelBooking.Name = "btnCancelBooking";
            btnCancelBooking.Size = new Size(200, 50);
            btnCancelBooking.TabIndex = 14;
            btnCancelBooking.Text = "Cancel Booking";
            btnCancelBooking.UseVisualStyleBackColor = true;
            btnCancelBooking.Click += btnCancelBooking_Click;
            // 
            // dataGridViewManageYourBookings
            // 
            dataGridViewManageYourBookings.AllowUserToAddRows = false;
            dataGridViewManageYourBookings.AllowUserToDeleteRows = false;
            dataGridViewManageYourBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridViewManageYourBookings.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewManageYourBookings.BackgroundColor = Color.FromArgb(14, 36, 66);
            dataGridViewManageYourBookings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewManageYourBookings.Location = new Point(4, 4);
            dataGridViewManageYourBookings.Margin = new Padding(4);
            dataGridViewManageYourBookings.Name = "dataGridViewManageYourBookings";
            dataGridViewManageYourBookings.ReadOnly = true;
            dataGridViewManageYourBookings.RowHeadersWidth = 51;
            dataGridViewManageYourBookings.RowTemplate.Height = 29;
            dataGridViewManageYourBookings.Size = new Size(1334, 750);
            dataGridViewManageYourBookings.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(14, 36, 66);
            panel1.Controls.Add(pictureBoxLogo3);
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
            // pictureBoxLogo3
            // 
            pictureBoxLogo3.Location = new Point(30, 34);
            pictureBoxLogo3.Name = "pictureBoxLogo3";
            pictureBoxLogo3.Size = new Size(181, 181);
            pictureBoxLogo3.TabIndex = 15;
            pictureBoxLogo3.TabStop = false;
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
            lblHome.Location = new Point(26, 330);
            lblHome.Margin = new Padding(4, 0, 4, 0);
            lblHome.Name = "lblHome";
            lblHome.Size = new Size(63, 25);
            lblHome.TabIndex = 6;
            lblHome.Text = "Home";
            lblHome.Click += lblHome_Click;
            // 
            // lblFindARoom
            // 
            lblFindARoom.AutoSize = true;
            lblFindARoom.BackColor = Color.FromArgb(14, 36, 66);
            lblFindARoom.Cursor = Cursors.Hand;
            lblFindARoom.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblFindARoom.ForeColor = Color.White;
            lblFindARoom.Location = new Point(26, 389);
            lblFindARoom.Margin = new Padding(4, 0, 4, 0);
            lblFindARoom.Name = "lblFindARoom";
            lblFindARoom.Size = new Size(129, 25);
            lblFindARoom.TabIndex = 7;
            lblFindARoom.Text = "Book A Room";
            lblFindARoom.Click += lblFindARoom_Click;
            // 
            // lblManageYourBookings
            // 
            lblManageYourBookings.AutoSize = true;
            lblManageYourBookings.BackColor = Color.FromArgb(14, 36, 66);
            lblManageYourBookings.Cursor = Cursors.Hand;
            lblManageYourBookings.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblManageYourBookings.ForeColor = Color.White;
            lblManageYourBookings.Location = new Point(26, 451);
            lblManageYourBookings.Margin = new Padding(4, 0, 4, 0);
            lblManageYourBookings.Name = "lblManageYourBookings";
            lblManageYourBookings.Size = new Size(151, 25);
            lblManageYourBookings.TabIndex = 8;
            lblManageYourBookings.Text = "Booking History";
            lblManageYourBookings.Click += lblManageYourBookings_Click;
            // 
            // lblWelcomeUser
            // 
            lblWelcomeUser.AutoSize = true;
            lblWelcomeUser.FlatStyle = FlatStyle.Flat;
            lblWelcomeUser.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblWelcomeUser.ForeColor = Color.White;
            lblWelcomeUser.Location = new Point(13, 253);
            lblWelcomeUser.Margin = new Padding(4, 0, 4, 0);
            lblWelcomeUser.Name = "lblWelcomeUser";
            lblWelcomeUser.Size = new Size(120, 32);
            lblWelcomeUser.TabIndex = 11;
            lblWelcomeUser.Text = "Hi, Name";
            lblWelcomeUser.TextAlign = ContentAlignment.TopCenter;
            // 
            // Customer_Access
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1600, 960);
            Controls.Add(panel1);
            Controls.Add(tabControl1);
            Name = "Customer_Access";
            Text = "Hyarriot Hotel";
            tabControl1.ResumeLayout(false);
            tabPageHome.ResumeLayout(false);
            tabPageHome.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)axWindowsMediaPlayer).EndInit();
            tabPageBookARoom.ResumeLayout(false);
            tabPageBookARoom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewAvailableRooms).EndInit();
            tabPageManageYourBookings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewManageYourBookings).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo3).EndInit();
            ResumeLayout(false);
<<<<<<< HEAD
            this.StartPosition = FormStartPosition.CenterScreen;
=======
>>>>>>> 528293c2466e8ae475319c324346c9c86ec8a6c4
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPageHome;
        private TabPage tabPageBookARoom;
        private Panel panel1;
        private Label lblHome;
        private Label lblFindARoom;
        private Label lblManageYourBookings;
        private Label lblWelcomeUser;
        private Label label1;
        private Button btnLogout;
        private Label lblClock;
        private TabPage tabPageManageYourBookings;
        private PictureBox pictureBoxLogo3;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer;
        private Button btnCancelBooking;
        private DataGridView dataGridViewManageYourBookings;
        private DateTimePicker dtpCheckOutDate;
        private DateTimePicker dtpCheckInDate;
        private DataGridView dataGridViewAvailableRooms;
        private ComboBox cbRoomType;
        private Button btnBookRoom;
        private Button btnSearchRooms;
        private ComboBox cbAmenities;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label5;
        private Label lblIncomingBooking;
        private Label label6;
    }
}