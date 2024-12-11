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
        private System.Windows.Forms.TabPage tabPageDashboard; // Dashboard

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


        private System.Windows.Forms.TabPage tabPageRooms; // Manage Rooms
        private System.Windows.Forms.TabPage tabPageCustomers; // Manage Customers
        private System.Windows.Forms.TabPage tabPageReport; // Reports
        private System.Windows.Forms.TabPage tabPageBookings; // Manage Bookings
        private System.Windows.Forms.DataGridView dataGridViewRooms;
        private System.Windows.Forms.DataGridView dataGridViewCustomers;
        private System.Windows.Forms.DataGridView dataGridViewBookings;
        private System.Windows.Forms.Button btnAddRoom;
        private System.Windows.Forms.Button btnUpdateRoom;
        private System.Windows.Forms.Button btnDeleteRoom;
        private System.Windows.Forms.Button btnUpdateCustomer;
        private System.Windows.Forms.Button btnDeleteCustomer;
        private System.Windows.Forms.Button btnUpdateBooking;
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
            label1 = new Label();
            pictureBoxLogo2 = new PictureBox();
            lblDashboard = new Label();
            lblManageRooms = new Label();
            lblManageCustomers = new Label();
            lblManageBookings = new Label();
            lblReports = new Label();
            lblWelcomeUser = new Label();
            btnLogout = new Button();
            lblClock = new Label();
            tabControl1 = new TabControl();
            tabPageDashboard = new TabPage();
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
            tabPageRooms = new TabPage();
            dataGridViewRooms = new DataGridView();
            btnAddRoom = new Button();
            btnUpdateRoom = new Button();
            btnDeleteRoom = new Button();
            tabPageCustomers = new TabPage();
            dataGridViewCustomers = new DataGridView();
            btnUpdateCustomer = new Button();
            btnDeleteCustomer = new Button();
            tabPageBookings = new TabPage();
            dataGridViewBookings = new DataGridView();
            btnUpdateBooking = new Button();
            tabPageReport = new TabPage();
            dgvReport = new DataGridView();
            btnGenerateReport = new Button();
            cbReportType = new ComboBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo2).BeginInit();
            tabControl1.SuspendLayout();
            tabPageDashboard.SuspendLayout();
            panelSoldRms.SuspendLayout();
            panelRmsForSale.SuspendLayout();
            panelDirtyRms.SuspendLayout();
            panelCleanVacant.SuspendLayout();
            tabPageRooms.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewRooms).BeginInit();
            tabPageCustomers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewCustomers).BeginInit();
            tabPageBookings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewBookings).BeginInit();
            tabPageReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvReport).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(14, 36, 66);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(pictureBoxLogo2);
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
            // label1
            // 
            label1.AutoSize = true;
            label1.ForeColor = Color.White;
            label1.Location = new Point(36, 801);
            label1.Name = "label1";
            label1.Size = new Size(54, 25);
            label1.TabIndex = 9;
            label1.Text = "Time:";
            // 
            // pictureBoxLogo2
            // 
            pictureBoxLogo2.Location = new Point(36, 34);
            pictureBoxLogo2.Name = "pictureBoxLogo2";
            pictureBoxLogo2.Size = new Size(181, 181);
            pictureBoxLogo2.TabIndex = 8;
            pictureBoxLogo2.TabStop = false;
            // 
            // lblDashboard
            // 
            lblDashboard.AutoSize = true;
            lblDashboard.BackColor = Color.FromArgb(14, 36, 66);
            lblDashboard.Cursor = Cursors.Hand;
            lblDashboard.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblDashboard.ForeColor = Color.White;
            lblDashboard.Location = new Point(36, 344);
            lblDashboard.Margin = new Padding(4, 0, 4, 0);
            lblDashboard.Name = "lblDashboard";
            lblDashboard.Size = new Size(104, 25);
            lblDashboard.TabIndex = 0;
            lblDashboard.Text = "Dashboard";
            lblDashboard.Click += lblDashboard_Click;
            // 
            // lblManageRooms
            // 
            lblManageRooms.AutoSize = true;
            lblManageRooms.BackColor = Color.FromArgb(14, 36, 66);
            lblManageRooms.Cursor = Cursors.Hand;
            lblManageRooms.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblManageRooms.ForeColor = Color.White;
            lblManageRooms.Location = new Point(36, 403);
            lblManageRooms.Margin = new Padding(4, 0, 4, 0);
            lblManageRooms.Name = "lblManageRooms";
            lblManageRooms.Size = new Size(144, 25);
            lblManageRooms.TabIndex = 1;
            lblManageRooms.Text = "Manage Rooms";
            lblManageRooms.Click += lblManageRooms_Click;
            // 
            // lblManageCustomers
            // 
            lblManageCustomers.AutoSize = true;
            lblManageCustomers.BackColor = Color.FromArgb(14, 36, 66);
            lblManageCustomers.Cursor = Cursors.Hand;
            lblManageCustomers.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblManageCustomers.ForeColor = Color.White;
            lblManageCustomers.Location = new Point(36, 465);
            lblManageCustomers.Margin = new Padding(4, 0, 4, 0);
            lblManageCustomers.Name = "lblManageCustomers";
            lblManageCustomers.Size = new Size(175, 25);
            lblManageCustomers.TabIndex = 2;
            lblManageCustomers.Text = "Manage Customers";
            lblManageCustomers.Click += lblManageCustomers_Click;
            // 
            // lblManageBookings
            // 
            lblManageBookings.AutoSize = true;
            lblManageBookings.BackColor = Color.FromArgb(14, 36, 66);
            lblManageBookings.Cursor = Cursors.Hand;
            lblManageBookings.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblManageBookings.ForeColor = Color.White;
            lblManageBookings.Location = new Point(36, 523);
            lblManageBookings.Margin = new Padding(4, 0, 4, 0);
            lblManageBookings.Name = "lblManageBookings";
            lblManageBookings.Size = new Size(165, 25);
            lblManageBookings.TabIndex = 3;
            lblManageBookings.Text = "Manage Bookings";
            lblManageBookings.Click += lblManageBookings_Click;
            // 
            // lblReports
            // 
            lblReports.AutoSize = true;
            lblReports.BackColor = Color.FromArgb(14, 36, 66);
            lblReports.Cursor = Cursors.Hand;
            lblReports.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblReports.ForeColor = Color.White;
            lblReports.Location = new Point(36, 582);
            lblReports.Margin = new Padding(4, 0, 4, 0);
            lblReports.Name = "lblReports";
            lblReports.Size = new Size(79, 25);
            lblReports.TabIndex = 4;
            lblReports.Text = "Reports";
            lblReports.Click += lblReports_Click;
            // 
            // lblWelcomeUser
            // 
            lblWelcomeUser.AutoSize = true;
            lblWelcomeUser.FlatStyle = FlatStyle.Flat;
            lblWelcomeUser.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblWelcomeUser.ForeColor = Color.White;
            lblWelcomeUser.Location = new Point(23, 268);
            lblWelcomeUser.Margin = new Padding(4, 0, 4, 0);
            lblWelcomeUser.Name = "lblWelcomeUser";
            lblWelcomeUser.Size = new Size(217, 32);
            lblWelcomeUser.TabIndex = 5;
            lblWelcomeUser.Text = "Welcome, Admin!";
            // 
            // btnLogout
            // 
            btnLogout.Location = new Point(62, 860);
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
            lblClock.ForeColor = Color.White;
            lblClock.Location = new Point(97, 801);
            lblClock.Margin = new Padding(4, 0, 4, 0);
            lblClock.Name = "lblClock";
            lblClock.Size = new Size(55, 25);
            lblClock.TabIndex = 6;
            lblClock.Text = "Clock";
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPageDashboard);
            tabControl1.Controls.Add(tabPageRooms);
            tabControl1.Controls.Add(tabPageCustomers);
            tabControl1.Controls.Add(tabPageBookings);
            tabControl1.Controls.Add(tabPageReport);
            tabControl1.Location = new Point(250, 0);
            tabControl1.Margin = new Padding(4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1350, 960);
            tabControl1.TabIndex = 1;
            // 
            // tabPageDashboard
            // 
            tabPageDashboard.BackColor = Color.FromArgb(14, 36, 66);
            tabPageDashboard.Controls.Add(panelSoldRms);
            tabPageDashboard.Controls.Add(panelRmsForSale);
            tabPageDashboard.Controls.Add(panelDirtyRms);
            tabPageDashboard.Controls.Add(panelCleanVacant);
            tabPageDashboard.Location = new Point(4, 34);
            tabPageDashboard.Margin = new Padding(4);
            tabPageDashboard.Name = "tabPageDashboard";
            tabPageDashboard.Size = new Size(1342, 922);
            tabPageDashboard.TabIndex = 0;
            tabPageDashboard.Text = "Dashboard";
            // 
            // panelSoldRms
            // 
            panelSoldRms.BackColor = Color.White;
            panelSoldRms.Controls.Add(lblSoldRmsTitle);
            panelSoldRms.Controls.Add(lblSoldRmsValue);
            panelSoldRms.Location = new Point(68, 91);
            panelSoldRms.Margin = new Padding(4);
            panelSoldRms.Name = "panelSoldRms";
            panelSoldRms.Size = new Size(225, 125);
            panelSoldRms.TabIndex = 4;
            // 
            // lblSoldRmsTitle
            // 
            lblSoldRmsTitle.AutoSize = true;
            lblSoldRmsTitle.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblSoldRmsTitle.Location = new Point(12, 12);
            lblSoldRmsTitle.Margin = new Padding(4, 0, 4, 0);
            lblSoldRmsTitle.Name = "lblSoldRmsTitle";
            lblSoldRmsTitle.Size = new Size(154, 29);
            lblSoldRmsTitle.TabIndex = 1;
            lblSoldRmsTitle.Text = "Sold Rooms";
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
            panelRmsForSale.BackColor = Color.White;
            panelRmsForSale.Controls.Add(lblRmsForSaleTitle);
            panelRmsForSale.Controls.Add(lblRmsForSaleValue);
            panelRmsForSale.Location = new Point(380, 91);
            panelRmsForSale.Margin = new Padding(4);
            panelRmsForSale.Name = "panelRmsForSale";
            panelRmsForSale.Size = new Size(225, 125);
            panelRmsForSale.TabIndex = 5;
            // 
            // lblRmsForSaleTitle
            // 
            lblRmsForSaleTitle.AutoSize = true;
            lblRmsForSaleTitle.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblRmsForSaleTitle.Location = new Point(12, 12);
            lblRmsForSaleTitle.Margin = new Padding(4, 0, 4, 0);
            lblRmsForSaleTitle.Name = "lblRmsForSaleTitle";
            lblRmsForSaleTitle.Size = new Size(189, 29);
            lblRmsForSaleTitle.TabIndex = 1;
            lblRmsForSaleTitle.Text = "Rooms for Sale";
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
            panelDirtyRms.BackColor = Color.White;
            panelDirtyRms.Controls.Add(lblDirtyRmsTitle);
            panelDirtyRms.Controls.Add(lblDirtyRmsValue);
            panelDirtyRms.Location = new Point(718, 91);
            panelDirtyRms.Margin = new Padding(4);
            panelDirtyRms.Name = "panelDirtyRms";
            panelDirtyRms.Size = new Size(225, 125);
            panelDirtyRms.TabIndex = 6;
            // 
            // lblDirtyRmsTitle
            // 
            lblDirtyRmsTitle.AutoSize = true;
            lblDirtyRmsTitle.Font = new Font("Arial", 12F, FontStyle.Bold);
            lblDirtyRmsTitle.Location = new Point(12, 12);
            lblDirtyRmsTitle.Margin = new Padding(4, 0, 4, 0);
            lblDirtyRmsTitle.Name = "lblDirtyRmsTitle";
            lblDirtyRmsTitle.Size = new Size(155, 29);
            lblDirtyRmsTitle.TabIndex = 4;
            lblDirtyRmsTitle.Text = "Dirty Rooms";
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
            panelCleanVacant.BackColor = Color.White;
            panelCleanVacant.Controls.Add(lblCleanVacantTitle);
            panelCleanVacant.Controls.Add(lblCleanVacantValue);
            panelCleanVacant.Location = new Point(1036, 91);
            panelCleanVacant.Margin = new Padding(4);
            panelCleanVacant.Name = "panelCleanVacant";
            panelCleanVacant.Size = new Size(225, 125);
            panelCleanVacant.TabIndex = 7;
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
            // tabPageRooms
            // 
            tabPageRooms.BackColor = Color.FromArgb(14, 36, 66);
            tabPageRooms.Controls.Add(dataGridViewRooms);
            tabPageRooms.Controls.Add(btnAddRoom);
            tabPageRooms.Controls.Add(btnUpdateRoom);
            tabPageRooms.Controls.Add(btnDeleteRoom);
            tabPageRooms.Location = new Point(4, 34);
            tabPageRooms.Margin = new Padding(4);
            tabPageRooms.Name = "tabPageRooms";
            tabPageRooms.Padding = new Padding(4);
            tabPageRooms.Size = new Size(1342, 922);
            tabPageRooms.TabIndex = 1;
            tabPageRooms.Text = "Manage Rooms";
            // 
            // dataGridViewRooms
            // 
            dataGridViewRooms.BackgroundColor = Color.FromArgb(14, 36, 66);
            dataGridViewRooms.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewRooms.Location = new Point(8, 8);
            dataGridViewRooms.Margin = new Padding(4);
            dataGridViewRooms.Name = "dataGridViewRooms";
            dataGridViewRooms.RowHeadersWidth = 51;
            dataGridViewRooms.RowTemplate.Height = 29;
            dataGridViewRooms.Size = new Size(1325, 750);
            dataGridViewRooms.TabIndex = 0;
            // 
            // btnAddRoom
            // 
            btnAddRoom.Location = new Point(675, 826);
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
            btnUpdateRoom.Location = new Point(892, 826);
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
            btnDeleteRoom.Location = new Point(1110, 826);
            btnDeleteRoom.Margin = new Padding(4);
            btnDeleteRoom.Name = "btnDeleteRoom";
            btnDeleteRoom.Size = new Size(188, 50);
            btnDeleteRoom.TabIndex = 3;
            btnDeleteRoom.Text = "Delete Room";
            btnDeleteRoom.UseVisualStyleBackColor = true;
            btnDeleteRoom.Click += btnDeleteRoom_Click;
            // 
            // tabPageCustomers
            // 
            tabPageCustomers.BackColor = Color.FromArgb(14, 36, 66);
            tabPageCustomers.Controls.Add(dataGridViewCustomers);
            tabPageCustomers.Controls.Add(btnUpdateCustomer);
            tabPageCustomers.Controls.Add(btnDeleteCustomer);
            tabPageCustomers.Location = new Point(4, 34);
            tabPageCustomers.Margin = new Padding(4);
            tabPageCustomers.Name = "tabPageCustomers";
            tabPageCustomers.Padding = new Padding(4);
            tabPageCustomers.Size = new Size(1342, 922);
            tabPageCustomers.TabIndex = 2;
            tabPageCustomers.Text = "Manage Customers";
            // 
            // dataGridViewCustomers
            // 
            dataGridViewCustomers.AllowUserToAddRows = false;
            dataGridViewCustomers.AllowUserToDeleteRows = false;
            dataGridViewCustomers.BackgroundColor = Color.FromArgb(14, 36, 66);
            dataGridViewCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCustomers.Location = new Point(8, 8);
            dataGridViewCustomers.Margin = new Padding(4);
            dataGridViewCustomers.Name = "dataGridViewCustomers";
            dataGridViewCustomers.ReadOnly = true;
            dataGridViewCustomers.RowHeadersWidth = 51;
            dataGridViewCustomers.RowTemplate.Height = 29;
            dataGridViewCustomers.Size = new Size(1325, 750);
            dataGridViewCustomers.TabIndex = 0;
            // 
            // btnUpdateCustomer
            // 
            btnUpdateCustomer.Location = new Point(881, 826);
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
            btnDeleteCustomer.Location = new Point(1099, 826);
            btnDeleteCustomer.Margin = new Padding(4);
            btnDeleteCustomer.Name = "btnDeleteCustomer";
            btnDeleteCustomer.Size = new Size(188, 50);
            btnDeleteCustomer.TabIndex = 3;
            btnDeleteCustomer.Text = "Delete Customer";
            btnDeleteCustomer.UseVisualStyleBackColor = true;
            btnDeleteCustomer.Click += btnDeleteCustomer_Click;
            // 
            // tabPageBookings
            // 
            tabPageBookings.BackColor = Color.FromArgb(14, 36, 66);
            tabPageBookings.Controls.Add(dataGridViewBookings);
            tabPageBookings.Controls.Add(btnUpdateBooking);
            tabPageBookings.Location = new Point(4, 34);
            tabPageBookings.Margin = new Padding(4);
            tabPageBookings.Name = "tabPageBookings";
            tabPageBookings.Padding = new Padding(4);
            tabPageBookings.Size = new Size(1342, 922);
            tabPageBookings.TabIndex = 4;
            tabPageBookings.Text = "Manage Bookings";
            // 
            // dataGridViewBookings
            // 
            dataGridViewBookings.BackgroundColor = Color.FromArgb(14, 36, 66);
            dataGridViewBookings.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewBookings.Location = new Point(8, 8);
            dataGridViewBookings.Margin = new Padding(4);
            dataGridViewBookings.Name = "dataGridViewBookings";
            dataGridViewBookings.RowHeadersWidth = 51;
            dataGridViewBookings.RowTemplate.Height = 29;
            dataGridViewBookings.Size = new Size(1326, 750);
            dataGridViewBookings.TabIndex = 0;
            // 
            // btnUpdateBooking
            // 
            btnUpdateBooking.Location = new Point(1097, 826);
            btnUpdateBooking.Margin = new Padding(4);
            btnUpdateBooking.Name = "btnUpdateBooking";
            btnUpdateBooking.Size = new Size(182, 50);
            btnUpdateBooking.TabIndex = 2;
            btnUpdateBooking.Text = "Update Booking";
            btnUpdateBooking.UseVisualStyleBackColor = true;
            btnUpdateBooking.Click += btnUpdateBooking_Click;
            // 
            // tabPageReport
            // 
            tabPageReport.BackColor = Color.FromArgb(14, 36, 66);
            tabPageReport.Controls.Add(dgvReport);
            tabPageReport.Controls.Add(btnGenerateReport);
            tabPageReport.Controls.Add(cbReportType);
            tabPageReport.Location = new Point(4, 34);
            tabPageReport.Margin = new Padding(4);
            tabPageReport.Name = "tabPageReport";
            tabPageReport.Padding = new Padding(4);
            tabPageReport.Size = new Size(1342, 922);
            tabPageReport.TabIndex = 0;
            tabPageReport.Text = "Report";
            // 
            // dgvReport
            // 
            dgvReport.BackgroundColor = Color.FromArgb(14, 36, 66);
            dgvReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvReport.Location = new Point(7, 8);
            dgvReport.Name = "dgvReport";
            dgvReport.RowHeadersWidth = 62;
            dgvReport.Size = new Size(1327, 656);
            dgvReport.TabIndex = 3;
            // 
            // btnGenerateReport
            // 
            btnGenerateReport.Location = new Point(1129, 826);
            btnGenerateReport.Name = "btnGenerateReport";
            btnGenerateReport.Size = new Size(127, 50);
            btnGenerateReport.TabIndex = 2;
            btnGenerateReport.Text = "Generate";
            btnGenerateReport.UseVisualStyleBackColor = true;
            btnGenerateReport.Click += btnGenerateReport_Click;
            // 
            // cbReportType
            // 
            cbReportType.FormattingEnabled = true;
            cbReportType.Location = new Point(1097, 759);
            cbReportType.Name = "cbReportType";
            cbReportType.Size = new Size(182, 33);
            cbReportType.TabIndex = 1;
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
            Text = "Hyarriot Hotel Management System";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxLogo2).EndInit();
            tabControl1.ResumeLayout(false);
            tabPageDashboard.ResumeLayout(false);
            panelSoldRms.ResumeLayout(false);
            panelSoldRms.PerformLayout();
            panelRmsForSale.ResumeLayout(false);
            panelRmsForSale.PerformLayout();
            panelDirtyRms.ResumeLayout(false);
            panelDirtyRms.PerformLayout();
            panelCleanVacant.ResumeLayout(false);
            panelCleanVacant.PerformLayout();
            tabPageRooms.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewRooms).EndInit();
            tabPageCustomers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewCustomers).EndInit();
            tabPageBookings.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridViewBookings).EndInit();
            tabPageReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvReport).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvReport;
        private Button btnGenerateReport;
        private ComboBox cbReportType;
        private DateTimePicker dtpReportTime;
        private PictureBox pictureBoxLogo2;
        private Label label1;
    }
}