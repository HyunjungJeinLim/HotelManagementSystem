using HotelManagementSystem_Proj_RAD;

namespace HotelManagementSystem_Proj_RAD
{
    partial class MasterForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblDashboard;
        private System.Windows.Forms.Label lblManageRooms;
        private System.Windows.Forms.Label lblManageCustomers;
        private System.Windows.Forms.Label lblManageBookings;
        private System.Windows.Forms.Label lblReports;
        private System.Windows.Forms.Label lblWelcomeUser;
        private System.Windows.Forms.Label lblClock;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1; // Dashboard

        // Additional UI elements for the dashboard
        private System.Windows.Forms.Panel panelSoldRms;
        private System.Windows.Forms.Label lblSoldRmsTitle;
        private System.Windows.Forms.Label lblSoldRmsValue;

        private System.Windows.Forms.Panel panelRmsForSale;
        private System.Windows.Forms.Label lblRmsForSaleTitle;
        private System.Windows.Forms.Label lblRmsForSaleValue;

        private System.Windows.Forms.Panel panelCleanVacant;
        private System.Windows.Forms.Label lblCleanVacantTitle;
        private System.Windows.Forms.Label lblCleanVacantValue;

        private System.Windows.Forms.Panel panelDirtyRms;
        private System.Windows.Forms.Label lblDirtyRmsTitle;
        private System.Windows.Forms.Label lblDirtyRmsValue;


        private System.Windows.Forms.TabPage tabPage2; // Manage Rooms
        private System.Windows.Forms.TabPage tabPage3; // Manage Customers
        private System.Windows.Forms.TabPage tabPage4; // Reports
        private System.Windows.Forms.TabPage tabPage5; // Manage Bookings
        private System.Windows.Forms.DataGridView dataGridViewRooms;
        private System.Windows.Forms.DataGridView dataGridViewCustomers;
        private System.Windows.Forms.DataGridView dataGridViewBookings;
        private System.Windows.Forms.Button btnAddRoom;
        private System.Windows.Forms.Button btnUpdateRoom;
        private System.Windows.Forms.Button btnDeleteRoom;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.Button btnUpdateCustomer;
        private System.Windows.Forms.Button btnDeleteCustomer;
        private System.Windows.Forms.Button btnAddBooking;
        private System.Windows.Forms.Button btnUpdateBooking;
        private System.Windows.Forms.Button btnDeleteBooking;
        private System.Windows.Forms.CheckedListBox checkedListBoxTasks;
        private System.Windows.Forms.Label lblTaskTitle;

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
            lblDashboard = new Label();
            lblManageRooms = new Label();
            lblManageCustomers = new Label();
            lblManageBookings = new Label();
            lblReports = new Label();
            lblWelcomeUser = new Label();
            btnLogout = new Button();
            lblClock = new Label();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            checkedListBoxTasks = new CheckedListBox();
            lblTaskTitle = new Label();
            tabPage2 = new TabPage();
            dataGridViewRooms = new DataGridView();
            btnAddRoom = new Button();
            btnUpdateRoom = new Button();
            btnDeleteRoom = new Button();
            tabPage3 = new TabPage();
            dataGridViewCustomers = new DataGridView();
            btnAddCustomer = new Button();
            btnUpdateCustomer = new Button();
            btnDeleteCustomer = new Button();
            tabPage4 = new TabPage();
            panelSoldRms = new Panel();
            lblSoldRmsTitle = new Label();
            lblSoldRmsValue = new Label();
            panelRmsForSale = new Panel();
            lblRmsForSaleTitle = new Label();
            lblRmsForSaleValue = new Label();
            panelDirtyRms = new Panel();
            lblDirtyRmsTitle = new Label();
            lblDirtyRmsValue = new Label();
            panelCleanVacant = new Panel();
            lblCleanVacantTitle = new Label();
            lblCleanVacantValue = new Label();
            tabPage5 = new TabPage();
            dataGridViewBookings = new DataGridView();
            btnAddBooking = new Button();
            btnUpdateBooking = new Button();
            btnDeleteBooking = new Button();
            panel1.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRooms).BeginInit();
            tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCustomers).BeginInit();
            tabPage4.SuspendLayout();
            panelSoldRms.SuspendLayout();
            panelRmsForSale.SuspendLayout();
            panelDirtyRms.SuspendLayout();
            panelCleanVacant.SuspendLayout();
            tabPage5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBookings).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(230, 230, 250);
            panel1.Controls.Add(lblDashboard);
            panel1.Controls.Add(lblManageRooms);
            panel1.Controls.Add(lblManageCustomers);
            panel1.Controls.Add(lblManageBookings);
            panel1.Controls.Add(lblReports);
            panel1.Controls.Add(lblWelcomeUser);
            panel1.Controls.Add(btnLogout);
            panel1.Controls.Add(lblClock);
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 960);
            panel1.TabIndex = 0;
            // 
            // lblDashboard
            // 
            lblDashboard.AutoSize = true;
            lblDashboard.BackColor = Color.FromArgb(192, 192, 255);
            lblDashboard.Cursor = Cursors.Hand;
            lblDashboard.Location = new Point(102, 242);
            lblDashboard.Margin = new Padding(4, 0, 4, 0);
            lblDashboard.Name = "lblDashboard";
            lblDashboard.Size = new Size(100, 25);
            lblDashboard.TabIndex = 0;
            lblDashboard.Text = "Dashboard";
            lblDashboard.Click += lblDashboard_Click;
            // 
            // lblManageRooms
            // 
            lblManageRooms.AutoSize = true;
            lblManageRooms.BackColor = Color.FromArgb(192, 192, 255);
            lblManageRooms.Cursor = Cursors.Hand;
            lblManageRooms.Location = new Point(65, 327);
            lblManageRooms.Margin = new Padding(4, 0, 4, 0);
            lblManageRooms.Name = "lblManageRooms";
            lblManageRooms.Size = new Size(137, 25);
            lblManageRooms.TabIndex = 1;
            lblManageRooms.Text = "Manage Rooms";
            lblManageRooms.Click += lblManageRooms_Click;
            // 
            // lblManageCustomers
            // 
            lblManageCustomers.AutoSize = true;
            lblManageCustomers.BackColor = Color.FromArgb(192, 192, 255);
            lblManageCustomers.Cursor = Cursors.Hand;
            lblManageCustomers.Location = new Point(36, 417);
            lblManageCustomers.Margin = new Padding(4, 0, 4, 0);
            lblManageCustomers.Name = "lblManageCustomers";
            lblManageCustomers.Size = new Size(166, 25);
            lblManageCustomers.TabIndex = 2;
            lblManageCustomers.Text = "Manage Customers";
            lblManageCustomers.Click += lblManageCustomers_Click;
            // 
            // lblManageBookings
            // 
            lblManageBookings.AutoSize = true;
            lblManageBookings.BackColor = Color.FromArgb(192, 192, 255);
            lblManageBookings.Cursor = Cursors.Hand;
            lblManageBookings.Location = new Point(47, 499);
            lblManageBookings.Margin = new Padding(4, 0, 4, 0);
            lblManageBookings.Name = "lblManageBookings";
            lblManageBookings.Size = new Size(155, 25);
            lblManageBookings.TabIndex = 3;
            lblManageBookings.Text = "Manage Bookings";
            lblManageBookings.Click += lblManageBookings_Click;
            // 
            // lblReports
            // 
            lblReports.AutoSize = true;
            lblReports.BackColor = Color.FromArgb(192, 192, 255);
            lblReports.Cursor = Cursors.Hand;
            lblReports.Location = new Point(129, 590);
            lblReports.Margin = new Padding(4, 0, 4, 0);
            lblReports.Name = "lblReports";
            lblReports.Size = new Size(73, 25);
            lblReports.TabIndex = 4;
            lblReports.Text = "Reports";
            lblReports.Click += lblReports_Click;
            // 
            // lblWelcomeUser
            // 
            lblWelcomeUser.AutoSize = true;
            lblWelcomeUser.Font = new Font("Arial Rounded MT Bold", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWelcomeUser.Location = new Point(47, 81);
            lblWelcomeUser.Margin = new Padding(4, 0, 4, 0);
            lblWelcomeUser.Name = "lblWelcomeUser";
            lblWelcomeUser.Size = new Size(167, 23);
            lblWelcomeUser.TabIndex = 5;
            lblWelcomeUser.Text = "Welcome Admin";
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(66, 871);
            btnLogout.Margin = new Padding(4);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(125, 50);
            btnLogout.TabIndex = 7;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = true;
            btnLogout.Click += btnLogout_Click;
            // 
            // lblClock
            // 
            lblClock.AutoSize = true;
            lblClock.Location = new Point(81, 815);
            lblClock.Margin = new Padding(4, 0, 4, 0);
            lblClock.Name = "lblClock";
            lblClock.Size = new Size(55, 25);
            lblClock.TabIndex = 6;
            lblClock.Text = "Clock";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Location = new Point(250, 0);
            tabControl1.Margin = new Padding(4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1350, 960);
            tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(checkedListBoxTasks);
            tabPage1.Controls.Add(lblTaskTitle);
            tabPage1.Location = new Point(4, 34);
            tabPage1.Margin = new Padding(4);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(1342, 922);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Dashboard";
            // 
            // checkedListBoxTasks
            // 
            checkedListBoxTasks.FormattingEnabled = true;
            checkedListBoxTasks.Items.AddRange(new object[] { "Volunteer at Carewest", "Finish RAD Project", "Eat HotPot", "Laundry", "Do Assignments", "Shovel Snow" });
            checkedListBoxTasks.Location = new Point(1020, 114);
            checkedListBoxTasks.Margin = new Padding(4);
            checkedListBoxTasks.Name = "checkedListBoxTasks";
            checkedListBoxTasks.Size = new Size(249, 536);
            checkedListBoxTasks.TabIndex = 2;
            // 
            // lblTaskTitle
            // 
            lblTaskTitle.AutoSize = true;
            lblTaskTitle.Location = new Point(1020, 77);
            lblTaskTitle.Margin = new Padding(4, 0, 4, 0);
            lblTaskTitle.Name = "lblTaskTitle";
            lblTaskTitle.Size = new Size(179, 25);
            lblTaskTitle.TabIndex = 1;
            lblTaskTitle.Text = "Manager's To-Do List";
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dataGridViewRooms);
            tabPage2.Controls.Add(btnAddRoom);
            tabPage2.Controls.Add(btnUpdateRoom);
            tabPage2.Controls.Add(btnDeleteRoom);
            tabPage2.Location = new Point(4, 34);
            tabPage2.Margin = new Padding(4);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(4);
            tabPage2.Size = new Size(1342, 922);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Manage Rooms";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // dataGridViewRooms
            // 
            dataGridViewRooms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRooms.Location = new Point(25, 25);
            dataGridViewRooms.Margin = new Padding(4);
            dataGridViewRooms.Name = "dataGridViewRooms";
            dataGridViewRooms.RowHeadersWidth = 51;
            dataGridViewRooms.RowTemplate.Height = 29;
            dataGridViewRooms.Size = new Size(1250, 750);
            dataGridViewRooms.TabIndex = 0;
            // 
            // btnAddRoom
            // 
            btnAddRoom.Location = new Point(238, 812);
            btnAddRoom.Margin = new Padding(4);
            btnAddRoom.Name = "btnAddRoom";
            btnAddRoom.Size = new Size(188, 50);
            btnAddRoom.TabIndex = 1;
            btnAddRoom.Text = "Add Room";
            btnAddRoom.UseVisualStyleBackColor = true;
            btnAddRoom.Click += btnAddRoom_Click;
            // 
            // btnUpdateRoom
            // 
            btnUpdateRoom.Location = new Point(593, 812);
            btnUpdateRoom.Margin = new Padding(4);
            btnUpdateRoom.Name = "btnUpdateRoom";
            btnUpdateRoom.Size = new Size(188, 50);
            btnUpdateRoom.TabIndex = 2;
            btnUpdateRoom.Text = "Update Room";
            btnUpdateRoom.UseVisualStyleBackColor = true;
            btnUpdateRoom.Click += btnUpdateRoom_Click;
            // 
            // btnDeleteRoom
            // 
            btnDeleteRoom.Location = new Point(938, 812);
            btnDeleteRoom.Margin = new Padding(4);
            btnDeleteRoom.Name = "btnDeleteRoom";
            btnDeleteRoom.Size = new Size(188, 50);
            btnDeleteRoom.TabIndex = 3;
            btnDeleteRoom.Text = "Delete Room";
            btnDeleteRoom.UseVisualStyleBackColor = true;
            btnDeleteRoom.Click += btnDeleteRoom_Click;
            // 
            // tabPage3
            // 
            tabPage3.Controls.Add(dataGridViewCustomers);
            tabPage3.Controls.Add(btnAddCustomer);
            tabPage3.Controls.Add(btnUpdateCustomer);
            tabPage3.Controls.Add(btnDeleteCustomer);
            tabPage3.Location = new Point(4, 34);
            tabPage3.Margin = new Padding(4);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(4);
            tabPage3.Size = new Size(1342, 922);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "Manage Customers";
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // dataGridViewCustomers
            // 
            dataGridViewCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCustomers.Location = new Point(25, 25);
            dataGridViewCustomers.Margin = new Padding(4);
            dataGridViewCustomers.Name = "dataGridViewCustomers";
            dataGridViewCustomers.RowHeadersWidth = 51;
            dataGridViewCustomers.RowTemplate.Height = 29;
            dataGridViewCustomers.Size = new Size(1250, 750);
            dataGridViewCustomers.TabIndex = 0;
            // 
            // btnAddCustomer
            // 
            btnAddCustomer.Location = new Point(238, 812);
            btnAddCustomer.Margin = new Padding(4);
            btnAddCustomer.Name = "btnAddCustomer";
            btnAddCustomer.Size = new Size(188, 50);
            btnAddCustomer.TabIndex = 1;
            btnAddCustomer.Text = "Add Customer";
            btnAddCustomer.UseVisualStyleBackColor = true;
            btnAddCustomer.Click += btnAddCustomer_Click;
            // 
            // btnUpdateCustomer
            // 
            btnUpdateCustomer.Location = new Point(593, 812);
            btnUpdateCustomer.Margin = new Padding(4);
            btnUpdateCustomer.Name = "btnUpdateCustomer";
            btnUpdateCustomer.Size = new Size(188, 50);
            btnUpdateCustomer.TabIndex = 2;
            btnUpdateCustomer.Text = "Update Customer";
            btnUpdateCustomer.UseVisualStyleBackColor = true;
            btnUpdateCustomer.Click += btnUpdateCustomer_Click;
            // 
            // btnDeleteCustomer
            // 
            btnDeleteCustomer.Location = new Point(938, 812);
            btnDeleteCustomer.Margin = new Padding(4);
            btnDeleteCustomer.Name = "btnDeleteCustomer";
            btnDeleteCustomer.Size = new Size(188, 50);
            btnDeleteCustomer.TabIndex = 3;
            btnDeleteCustomer.Text = "Delete Customer";
            btnDeleteCustomer.UseVisualStyleBackColor = true;
            btnDeleteCustomer.Click += btnDeleteCustomer_Click;
            // 
            // tabPage4
            // 
            tabPage4.Controls.Add(panelSoldRms);
            tabPage4.Controls.Add(panelRmsForSale);
            tabPage4.Controls.Add(panelDirtyRms);
            tabPage4.Controls.Add(panelCleanVacant);
            tabPage4.Location = new Point(4, 34);
            tabPage4.Margin = new Padding(4);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(4);
            tabPage4.Size = new Size(1342, 922);
            tabPage4.TabIndex = 0;
            tabPage4.Text = "Report";
            tabPage4.UseVisualStyleBackColor = true;
            // 
            // panelSoldRms
            // 
            panelSoldRms.BackColor = Color.LightBlue;
            panelSoldRms.Controls.Add(lblSoldRmsTitle);
            panelSoldRms.Controls.Add(lblSoldRmsValue);
            panelSoldRms.Location = new Point(72, 108);
            panelSoldRms.Margin = new Padding(4);
            panelSoldRms.Name = "panelSoldRms";
            panelSoldRms.Size = new Size(225, 125);
            panelSoldRms.TabIndex = 0;
            // 
            // lblSoldRmsTitle
            // 
            lblSoldRmsTitle.AutoSize = true;
            lblSoldRmsTitle.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblSoldRmsTitle.Location = new Point(12, 12);
            lblSoldRmsTitle.Margin = new Padding(4, 0, 4, 0);
            lblSoldRmsTitle.Name = "lblSoldRmsTitle";
            lblSoldRmsTitle.Size = new Size(124, 29);
            lblSoldRmsTitle.TabIndex = 1;
            lblSoldRmsTitle.Text = "Sold Rms";
            // 
            // lblSoldRmsValue
            // 
            lblSoldRmsValue.AutoSize = true;
            lblSoldRmsValue.Font = new Font("Arial", 24F, FontStyle.Bold);
            lblSoldRmsValue.Location = new Point(12, 62);
            lblSoldRmsValue.Margin = new Padding(4, 0, 4, 0);
            lblSoldRmsValue.Name = "lblSoldRmsValue";
            lblSoldRmsValue.Size = new Size(51, 56);
            lblSoldRmsValue.TabIndex = 2;
            lblSoldRmsValue.Text = "0";
            // 
            // panelRmsForSale
            // 
            panelRmsForSale.BackColor = Color.LightBlue;
            panelRmsForSale.Controls.Add(lblRmsForSaleTitle);
            panelRmsForSale.Controls.Add(lblRmsForSaleValue);
            panelRmsForSale.Location = new Point(384, 108);
            panelRmsForSale.Margin = new Padding(4);
            panelRmsForSale.Name = "panelRmsForSale";
            panelRmsForSale.Size = new Size(225, 125);
            panelRmsForSale.TabIndex = 1;
            // 
            // lblRmsForSaleTitle
            // 
            lblRmsForSaleTitle.AutoSize = true;
            lblRmsForSaleTitle.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblRmsForSaleTitle.Location = new Point(12, 12);
            lblRmsForSaleTitle.Margin = new Padding(4, 0, 4, 0);
            lblRmsForSaleTitle.Name = "lblRmsForSaleTitle";
            lblRmsForSaleTitle.Size = new Size(159, 29);
            lblRmsForSaleTitle.TabIndex = 1;
            lblRmsForSaleTitle.Text = "Rms for Sale";
            // 
            // lblRmsForSaleValue
            // 
            lblRmsForSaleValue.AutoSize = true;
            lblRmsForSaleValue.Font = new Font("Arial", 24F, FontStyle.Bold);
            lblRmsForSaleValue.Location = new Point(12, 62);
            lblRmsForSaleValue.Margin = new Padding(4, 0, 4, 0);
            lblRmsForSaleValue.Name = "lblRmsForSaleValue";
            lblRmsForSaleValue.Size = new Size(51, 56);
            lblRmsForSaleValue.TabIndex = 2;
            lblRmsForSaleValue.Text = "0";
            // 
            // panelDirtyRms
            // 
            panelDirtyRms.BackColor = Color.LightGreen;
            panelDirtyRms.Controls.Add(lblDirtyRmsTitle);
            panelDirtyRms.Controls.Add(lblDirtyRmsValue);
            panelDirtyRms.Location = new Point(722, 108);
            panelDirtyRms.Margin = new Padding(4);
            panelDirtyRms.Name = "panelDirtyRms";
            panelDirtyRms.Size = new Size(225, 125);
            panelDirtyRms.TabIndex = 2;
            // 
            // lblDirtyRmsTitle
            // 
            lblDirtyRmsTitle.AutoSize = true;
            lblDirtyRmsTitle.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblDirtyRmsTitle.Location = new Point(12, 12);
            lblDirtyRmsTitle.Margin = new Padding(4, 0, 4, 0);
            lblDirtyRmsTitle.Name = "lblDirtyRmsTitle";
            lblDirtyRmsTitle.Size = new Size(125, 29);
            lblDirtyRmsTitle.TabIndex = 4;
            lblDirtyRmsTitle.Text = "Dirty Rms";
            // 
            // lblDirtyRmsValue
            // 
            lblDirtyRmsValue.AutoSize = true;
            lblDirtyRmsValue.Font = new Font("Arial", 24F, FontStyle.Bold);
            lblDirtyRmsValue.Location = new Point(12, 62);
            lblDirtyRmsValue.Margin = new Padding(4, 0, 4, 0);
            lblDirtyRmsValue.Name = "lblDirtyRmsValue";
            lblDirtyRmsValue.Size = new Size(51, 56);
            lblDirtyRmsValue.TabIndex = 5;
            lblDirtyRmsValue.Text = "0";
            // 
            // panelCleanVacant
            // 
            panelCleanVacant.BackColor = Color.LightGreen;
            panelCleanVacant.Controls.Add(lblCleanVacantTitle);
            panelCleanVacant.Controls.Add(lblCleanVacantValue);
            panelCleanVacant.Location = new Point(1040, 108);
            panelCleanVacant.Margin = new Padding(4);
            panelCleanVacant.Name = "panelCleanVacant";
            panelCleanVacant.Size = new Size(225, 125);
            panelCleanVacant.TabIndex = 3;
            // 
            // lblCleanVacantTitle
            // 
            lblCleanVacantTitle.AutoSize = true;
            lblCleanVacantTitle.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblCleanVacantTitle.Location = new Point(12, 12);
            lblCleanVacantTitle.Margin = new Padding(4, 0, 4, 0);
            lblCleanVacantTitle.Name = "lblCleanVacantTitle";
            lblCleanVacantTitle.Size = new Size(162, 29);
            lblCleanVacantTitle.TabIndex = 4;
            lblCleanVacantTitle.Text = "Clean Vacant";
            // 
            // lblCleanVacantValue
            // 
            lblCleanVacantValue.AutoSize = true;
            lblCleanVacantValue.Font = new Font("Arial", 24F, FontStyle.Bold);
            lblCleanVacantValue.Location = new Point(12, 62);
            lblCleanVacantValue.Margin = new Padding(4, 0, 4, 0);
            lblCleanVacantValue.Name = "lblCleanVacantValue";
            lblCleanVacantValue.Size = new Size(51, 56);
            lblCleanVacantValue.TabIndex = 5;
            lblCleanVacantValue.Text = "0";
            // 
            // tabPage5
            // 
            tabPage5.Controls.Add(dataGridViewBookings);
            tabPage5.Controls.Add(btnAddBooking);
            tabPage5.Controls.Add(btnUpdateBooking);
            tabPage5.Controls.Add(btnDeleteBooking);
            tabPage5.Location = new Point(4, 34);
            tabPage5.Margin = new Padding(4);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(4);
            tabPage5.Size = new Size(1342, 922);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Manage Bookings";
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // dataGridViewBookings
            // 
            dataGridViewBookings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBookings.Location = new Point(25, 25);
            dataGridViewBookings.Margin = new Padding(4);
            dataGridViewBookings.Name = "dataGridViewBookings";
            dataGridViewBookings.RowHeadersWidth = 51;
            dataGridViewBookings.RowTemplate.Height = 29;
            dataGridViewBookings.Size = new Size(1250, 750);
            dataGridViewBookings.TabIndex = 0;
            // 
            // btnAddBooking
            // 
            btnAddBooking.Location = new Point(238, 812);
            btnAddBooking.Margin = new Padding(4);
            btnAddBooking.Name = "btnAddBooking";
            btnAddBooking.Size = new Size(188, 50);
            btnAddBooking.TabIndex = 1;
            btnAddBooking.Text = "Add Booking";
            btnAddBooking.UseVisualStyleBackColor = true;
            btnAddBooking.Click += btnAddBooking_Click;
            // 
            // btnUpdateBooking
            // 
            btnUpdateBooking.Location = new Point(593, 812);
            btnUpdateBooking.Margin = new Padding(4);
            btnUpdateBooking.Name = "btnUpdateBooking";
            btnUpdateBooking.Size = new Size(188, 50);
            btnUpdateBooking.TabIndex = 2;
            btnUpdateBooking.Text = "Update Booking";
            btnUpdateBooking.UseVisualStyleBackColor = true;
            btnUpdateBooking.Click += btnUpdateBooking_Click;
            // 
            // btnDeleteBooking
            // 
            btnDeleteBooking.Location = new Point(938, 812);
            btnDeleteBooking.Margin = new Padding(4);
            btnDeleteBooking.Name = "btnDeleteBooking";
            btnDeleteBooking.Size = new Size(188, 50);
            btnDeleteBooking.TabIndex = 3;
            btnDeleteBooking.Text = "Delete Booking";
            btnDeleteBooking.UseVisualStyleBackColor = true;
            btnDeleteBooking.Click += btnDeleteBooking_Click;
            // 
            // MasterForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1600, 960);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            Margin = new Padding(4);
            Name = "MasterForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hotel Management System";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewRooms).EndInit();
            tabPage3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewCustomers).EndInit();
            tabPage4.ResumeLayout(false);
            panelSoldRms.ResumeLayout(false);
            panelSoldRms.PerformLayout();
            panelRmsForSale.ResumeLayout(false);
            panelRmsForSale.PerformLayout();
            panelDirtyRms.ResumeLayout(false);
            panelDirtyRms.PerformLayout();
            panelCleanVacant.ResumeLayout(false);
            panelCleanVacant.PerformLayout();
            tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewBookings).EndInit();
            ResumeLayout(false);
        }

        #endregion
    }
}