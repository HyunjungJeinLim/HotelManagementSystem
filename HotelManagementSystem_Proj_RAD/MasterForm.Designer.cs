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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblDashboard = new System.Windows.Forms.Label();
            this.lblManageRooms = new System.Windows.Forms.Label();
            this.lblManageCustomers = new System.Windows.Forms.Label();
            this.lblManageBookings = new System.Windows.Forms.Label();
            this.lblReports = new System.Windows.Forms.Label();
            this.lblWelcomeUser = new System.Windows.Forms.Label();
            this.lblClock = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage(); // Dashboard

            this.panelSoldRms = new System.Windows.Forms.Panel();
            this.lblSoldRmsTitle = new System.Windows.Forms.Label();
            this.lblSoldRmsValue = new System.Windows.Forms.Label();

            this.panelRmsForSale = new System.Windows.Forms.Panel();
            this.lblRmsForSaleTitle = new System.Windows.Forms.Label();
            this.lblRmsForSaleValue = new System.Windows.Forms.Label();

            this.panelCleanVacant = new System.Windows.Forms.Panel();
            this.lblCleanVacantTitle = new System.Windows.Forms.Label();
            this.lblCleanVacantValue = new System.Windows.Forms.Label();

            this.panelDirtyRms = new System.Windows.Forms.Panel();
            this.lblDirtyRmsTitle = new System.Windows.Forms.Label();
            this.lblDirtyRmsValue = new System.Windows.Forms.Label();

            this.tabPage2 = new System.Windows.Forms.TabPage(); // Manage Rooms
            this.tabPage3 = new System.Windows.Forms.TabPage(); // Manage Customers
            this.tabPage4 = new System.Windows.Forms.TabPage(); // Reports
            this.tabPage5 = new System.Windows.Forms.TabPage(); // Manage Bookings
            this.dataGridViewRooms = new System.Windows.Forms.DataGridView();
            this.dataGridViewCustomers = new System.Windows.Forms.DataGridView();
            this.dataGridViewBookings = new System.Windows.Forms.DataGridView();
            this.btnAddRoom = new System.Windows.Forms.Button();
            this.btnUpdateRoom = new System.Windows.Forms.Button();
            this.btnDeleteRoom = new System.Windows.Forms.Button();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.btnUpdateCustomer = new System.Windows.Forms.Button();
            this.btnDeleteCustomer = new System.Windows.Forms.Button();
            this.btnAddBooking = new System.Windows.Forms.Button();
            this.btnUpdateBooking = new System.Windows.Forms.Button();
            this.btnDeleteBooking = new System.Windows.Forms.Button();
            this.checkedListBoxTasks = new System.Windows.Forms.CheckedListBox();
            this.lblTaskTitle = new System.Windows.Forms.Label();

            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblDashboard);
            this.panel1.Controls.Add(this.lblManageRooms);
            this.panel1.Controls.Add(this.lblManageCustomers);
            this.panel1.Controls.Add(this.lblManageBookings);
            this.panel1.Controls.Add(this.lblReports);
            this.panel1.Controls.Add(this.lblWelcomeUser);
            this.panel1.Controls.Add(this.lblClock);
            this.panel1.Controls.Add(this.btnLogout);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 768);
            this.panel1.BackColor = System.Drawing.Color.FromArgb(230, 230, 250);
            this.panel1.TabIndex = 0;

            // 
            // lblDashboard
            // 
            this.lblDashboard.AutoSize = true;
            this.lblDashboard.Location = new System.Drawing.Point(20, 150);
            this.lblDashboard.Name = "lblDashboard";
            this.lblDashboard.Size = new System.Drawing.Size(81, 20);
            this.lblDashboard.TabIndex = 0;
            this.lblDashboard.Text = "Dashboard";
            this.lblDashboard.Cursor = Cursors.Hand;
            this.lblDashboard.Click += new System.EventHandler(this.lblDashboard_Click);

            // 
            // panelSoldRms
            // 
            this.panelSoldRms.BackColor = System.Drawing.Color.LightBlue;
            this.panelSoldRms.Controls.Add(this.lblSoldRmsTitle);
            this.panelSoldRms.Controls.Add(this.lblSoldRmsValue);
            this.panelSoldRms.Location = new System.Drawing.Point(20, 50);
            this.panelSoldRms.Name = "panelSoldRms";
            this.panelSoldRms.Size = new System.Drawing.Size(180, 100);
            this.panelSoldRms.TabIndex = 0;

            // 
            // lblSoldRmsTitle
            // 
            this.lblSoldRmsTitle.AutoSize = true;
            this.lblSoldRmsTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSoldRmsTitle.Location = new System.Drawing.Point(10, 10);
            this.lblSoldRmsTitle.Name = "lblSoldRmsTitle";
            this.lblSoldRmsTitle.Size = new System.Drawing.Size(120, 24);
            this.lblSoldRmsTitle.TabIndex = 1;
            this.lblSoldRmsTitle.Text = "Sold Rms";

            // 
            // lblSoldRmsValue
            // 
            this.lblSoldRmsValue.AutoSize = true;
            this.lblSoldRmsValue.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblSoldRmsValue.Location = new System.Drawing.Point(10, 50);
            this.lblSoldRmsValue.Name = "lblSoldRmsValue";
            this.lblSoldRmsValue.Size = new System.Drawing.Size(40, 46);
            this.lblSoldRmsValue.TabIndex = 2;
            this.lblSoldRmsValue.Text = "0";

            // 
            // panelRmsForSale
            // 
            this.panelRmsForSale.BackColor = System.Drawing.Color.LightBlue;
            this.panelRmsForSale.Controls.Add(this.lblRmsForSaleTitle);
            this.panelRmsForSale.Controls.Add(this.lblRmsForSaleValue);
            this.panelRmsForSale.Location = new System.Drawing.Point(220, 50);
            this.panelRmsForSale.Name = "panelRmsForSale";
            this.panelRmsForSale.Size = new System.Drawing.Size(180, 100);
            this.panelRmsForSale.TabIndex = 1;

            // 
            // lblRmsForSaleTitle
            // 
            this.lblRmsForSaleTitle.AutoSize = true;
            this.lblRmsForSaleTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRmsForSaleTitle.Location = new System.Drawing.Point(10, 10);
            this.lblRmsForSaleTitle.Name = "lblRmsForSaleTitle";
            this.lblRmsForSaleTitle.Size = new System.Drawing.Size(150, 24);
            this.lblRmsForSaleTitle.TabIndex = 1;
            this.lblRmsForSaleTitle.Text = "Rms for Sale";

            // 
            // lblRmsForSaleValue
            // 
            this.lblRmsForSaleValue.AutoSize = true;
            this.lblRmsForSaleValue.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblRmsForSaleValue.Location = new System.Drawing.Point(10, 50);
            this.lblRmsForSaleValue.Name = "lblRmsForSaleValue";
            this.lblRmsForSaleValue.Size = new System.Drawing.Size(40, 46);
            this.lblRmsForSaleValue.TabIndex = 2;
            this.lblRmsForSaleValue.Text = "0";

            // 
            // panelDirtyRms
            // 
            this.panelDirtyRms.BackColor = System.Drawing.Color.LightGreen;
            this.panelDirtyRms.Controls.Add(this.lblDirtyRmsTitle);
            this.panelDirtyRms.Controls.Add(this.lblDirtyRmsValue);
            this.panelDirtyRms.Location = new System.Drawing.Point(420, 50);
            this.panelDirtyRms.Name = "panelDirtyRms";
            this.panelDirtyRms.Size = new System.Drawing.Size(180, 100);
            this.panelDirtyRms.TabIndex = 2;

            // 
            // lblDirtyRmsTitle
            // 
            this.lblDirtyRmsTitle.AutoSize = true;
            this.lblDirtyRmsTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDirtyRmsTitle.Location = new System.Drawing.Point(10, 10);
            this.lblDirtyRmsTitle.Name = "lblDirtyRmsTitle";
            this.lblDirtyRmsTitle.Size = new System.Drawing.Size(120, 24);
            this.lblDirtyRmsTitle.TabIndex = 4;
            this.lblDirtyRmsTitle.Text = "Dirty Rms";

            // 
            // lblDirtyRmsValue
            // 
            this.lblDirtyRmsValue.AutoSize = true;
            this.lblDirtyRmsValue.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblDirtyRmsValue.Location = new System.Drawing.Point(10, 50);
            this.lblDirtyRmsValue.Name = "lblDirtyRmsValue";
            this.lblDirtyRmsValue.Size = new System.Drawing.Size(40, 46);
            this.lblDirtyRmsValue.TabIndex = 5;
            this.lblDirtyRmsValue.Text = "0";

            // 
            // panelCleanVacant
            // 
            this.panelCleanVacant.BackColor = System.Drawing.Color.LightGreen;
            this.panelCleanVacant.Controls.Add(this.lblCleanVacantTitle);
            this.panelCleanVacant.Controls.Add(this.lblCleanVacantValue);
            this.panelCleanVacant.Location = new System.Drawing.Point(620, 50);
            this.panelCleanVacant.Name = "panelCleanVacant";
            this.panelCleanVacant.Size = new System.Drawing.Size(180, 100);
            this.panelCleanVacant.TabIndex = 3;

            // 
            // lblCleanVacantTitle
            // 
            this.lblCleanVacantTitle.AutoSize = true;
            this.lblCleanVacantTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCleanVacantTitle.Location = new System.Drawing.Point(10, 10);
            this.lblCleanVacantTitle.Name = "lblCleanVacantTitle";
            this.lblCleanVacantTitle.Size = new System.Drawing.Size(140, 24);
            this.lblCleanVacantTitle.TabIndex = 4;
            this.lblCleanVacantTitle.Text = "Clean Vacant";

            // 
            // lblCleanVacantValue
            // 
            this.lblCleanVacantValue.AutoSize = true;
            this.lblCleanVacantValue.Font = new System.Drawing.Font("Arial", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCleanVacantValue.Location = new System.Drawing.Point(10, 50);
            this.lblCleanVacantValue.Name = "lblCleanVacantValue";
            this.lblCleanVacantValue.Size = new System.Drawing.Size(40, 46);
            this.lblCleanVacantValue.TabIndex = 5;
            this.lblCleanVacantValue.Text = "0";


            // 
            // lblManageRooms
            // 
            this.lblManageRooms.AutoSize = true;
            this.lblManageRooms.Location = new System.Drawing.Point(20, 200);
            this.lblManageRooms.Name = "lblManageRooms";
            this.lblManageRooms.Size = new System.Drawing.Size(108, 20);
            this.lblManageRooms.TabIndex = 1;
            this.lblManageRooms.Text = "Manage Rooms";
            this.lblManageRooms.Cursor = Cursors.Hand;
            this.lblManageRooms.Click += new System.EventHandler(this.lblManageRooms_Click);

            // 
            // lblManageCustomers
            // 
            this.lblManageCustomers.AutoSize = true;
            this.lblManageCustomers.Location = new System.Drawing.Point(20, 250);
            this.lblManageCustomers.Name = "lblManageCustomers";
            this.lblManageCustomers.Size = new System.Drawing.Size(135, 20);
            this.lblManageCustomers.TabIndex = 2;
            this.lblManageCustomers.Text = "Manage Customers";
            this.lblManageCustomers.Cursor = Cursors.Hand;
            this.lblManageCustomers.Click += new System.EventHandler(this.lblManageCustomers_Click);

            // 
            // lblManageBookings
            // 
            this.lblManageBookings.AutoSize = true;
            this.lblManageBookings.Location = new System.Drawing.Point(20, 300);
            this.lblManageBookings.Name = "lblManageBookings";
            this.lblManageBookings.Size = new System.Drawing.Size(130, 20);
            this.lblManageBookings.TabIndex = 3;
            this.lblManageBookings.Text = "Manage Bookings";
            this.lblManageBookings.Cursor = Cursors.Hand;
            this.lblManageBookings.Click += new System.EventHandler(this.lblManageBookings_Click);

            // 
            // lblReports
            // 
            this.lblReports.AutoSize = true;
            this.lblReports.Location = new System.Drawing.Point(20, 350);
            this.lblReports.Name = "lblReports";
            this.lblReports.Size = new System.Drawing.Size(60, 20);
            this.lblReports.TabIndex = 4;
            this.lblReports.Text = "Reports";
            this.lblReports.Cursor = Cursors.Hand;
            this.lblReports.Click += new System.EventHandler(this.lblReports_Click);

            // 
            // lblWelcomeUser
            // 
            this.lblWelcomeUser.AutoSize = true;
            this.lblWelcomeUser.Location = new System.Drawing.Point(20, 50);
            this.lblWelcomeUser.Name = "lblWelcomeUser";
            this.lblWelcomeUser.Size = new System.Drawing.Size(113, 20);
            this.lblWelcomeUser.TabIndex = 5;
            this.lblWelcomeUser.Text = "Welcome Admin";

            // 
            // lblClock
            // 
            this.lblClock.AutoSize = true;
            this.lblClock.Location = new System.Drawing.Point(20, 660); // btnLogout 위로 이동
            this.lblClock.Name = "lblClock";
            this.lblClock.Size = new System.Drawing.Size(100, 20);
            this.lblClock.TabIndex = 6;
            this.lblClock.Text = "Clock";
            this.panel1.Controls.Add(this.lblClock);

            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(20, 700);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(100, 40);
            this.btnLogout.TabIndex = 7;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);

            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1); // Dashboard
            this.tabControl1.Controls.Add(this.tabPage2); // Manage Rooms
            this.tabControl1.Controls.Add(this.tabPage3); // Manage Customers
            this.tabControl1.Controls.Add(this.tabPage4); // Reports
            this.tabControl1.Controls.Add(this.tabPage5); // Manage Bookings
            this.tabControl1.Location = new System.Drawing.Point(200, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1080, 768);
            this.tabControl1.TabIndex = 1;

            // 
            // tabPage1 - Dashboard
            // 
            this.tabPage1.Controls.Add(this.checkedListBoxTasks);
            this.tabPage1.Controls.Add(this.lblTaskTitle);
            this.tabPage1.Text = "Dashboard";

            // 
            // lblTaskTitle
            // 
            this.lblTaskTitle.AutoSize = true;
            this.lblTaskTitle.Location = new System.Drawing.Point(850, 20);
            this.lblTaskTitle.Name = "lblTaskTitle";
            this.lblTaskTitle.Size = new System.Drawing.Size(155, 20);
            this.lblTaskTitle.TabIndex = 1;
            this.lblTaskTitle.Text = "Manager's To-Do List";

            // 
            // checkedListBoxTasks
            // 
            this.checkedListBoxTasks.FormattingEnabled = true;
            this.checkedListBoxTasks.Items.AddRange(new object[] {
            "Volunteer at Carewest",
            "Finish RAD Project",
            "Eat HotPot",
            "Laundry",
            "Do Assignments",
            "Shovel Snow"});
            this.checkedListBoxTasks.Location = new System.Drawing.Point(850, 50);
            this.checkedListBoxTasks.Name = "checkedListBoxTasks";
            this.checkedListBoxTasks.Size = new System.Drawing.Size(200, 150);
            this.checkedListBoxTasks.TabIndex = 2;

            // 
            // tabPage2 - Manage Rooms
            // 
            this.tabPage2.Controls.Add(this.dataGridViewRooms);
            this.tabPage2.Controls.Add(this.btnAddRoom);
            this.tabPage2.Controls.Add(this.btnUpdateRoom);
            this.tabPage2.Controls.Add(this.btnDeleteRoom);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1072, 735);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Manage Rooms";
            this.tabPage2.UseVisualStyleBackColor = true;

            // 
            // dataGridViewRooms
            // 
            this.dataGridViewRooms.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewRooms.Location = new System.Drawing.Point(20, 20);
            this.dataGridViewRooms.Name = "dataGridViewRooms";
            this.dataGridViewRooms.RowHeadersWidth = 51;
            this.dataGridViewRooms.RowTemplate.Height = 29;
            this.dataGridViewRooms.Size = new System.Drawing.Size(1000, 600);
            this.dataGridViewRooms.TabIndex = 0;

            // 
            // btnAddRoom
            // 
            this.btnAddRoom.Location = new System.Drawing.Point(20, 650);
            this.btnAddRoom.Name = "btnAddRoom";
            this.btnAddRoom.Size = new System.Drawing.Size(150, 40);
            this.btnAddRoom.TabIndex = 1;
            this.btnAddRoom.Text = "Add Room";
            this.btnAddRoom.UseVisualStyleBackColor = true;
            this.btnAddRoom.Click += new System.EventHandler(this.btnAddRoom_Click);

            // 
            // btnUpdateRoom
            // 
            this.btnUpdateRoom.Location = new System.Drawing.Point(190, 650);
            this.btnUpdateRoom.Name = "btnUpdateRoom";
            this.btnUpdateRoom.Size = new System.Drawing.Size(150, 40);
            this.btnUpdateRoom.TabIndex = 2;
            this.btnUpdateRoom.Text = "Update Room";
            this.btnUpdateRoom.UseVisualStyleBackColor = true;
            this.btnUpdateRoom.Click += new System.EventHandler(this.btnUpdateRoom_Click);

            // 
            // btnDeleteRoom
            // 
            this.btnDeleteRoom.Location = new System.Drawing.Point(360, 650);
            this.btnDeleteRoom.Name = "btnDeleteRoom";
            this.btnDeleteRoom.Size = new System.Drawing.Size(150, 40);
            this.btnDeleteRoom.TabIndex = 3;
            this.btnDeleteRoom.Text = "Delete Room";
            this.btnDeleteRoom.UseVisualStyleBackColor = true;
            this.btnDeleteRoom.Click += new System.EventHandler(this.btnDeleteRoom_Click);

            // 
            // tabPage3 - Manage Customers
            // 
            this.tabPage3.Controls.Add(this.dataGridViewCustomers);
            this.tabPage3.Controls.Add(this.btnAddCustomer);
            this.tabPage3.Controls.Add(this.btnUpdateCustomer);
            this.tabPage3.Controls.Add(this.btnDeleteCustomer);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1072, 735);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Manage Customers";
            this.tabPage3.UseVisualStyleBackColor = true;

            // 
            // dataGridViewCustomers
            // 
            this.dataGridViewCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCustomers.Location = new System.Drawing.Point(20, 20);
            this.dataGridViewCustomers.Name = "dataGridViewCustomers";
            this.dataGridViewCustomers.RowHeadersWidth = 51;
            this.dataGridViewCustomers.RowTemplate.Height = 29;
            this.dataGridViewCustomers.Size = new System.Drawing.Size(1000, 600);
            this.dataGridViewCustomers.TabIndex = 0;

            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Location = new System.Drawing.Point(20, 650);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(150, 40);
            this.btnAddCustomer.TabIndex = 1;
            this.btnAddCustomer.Text = "Add Customer";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);

            // 
            // btnUpdateCustomer
            // 
            this.btnUpdateCustomer.Location = new System.Drawing.Point(190, 650);
            this.btnUpdateCustomer.Name = "btnUpdateCustomer";
            this.btnUpdateCustomer.Size = new System.Drawing.Size(150, 40);
            this.btnUpdateCustomer.TabIndex = 2;
            this.btnUpdateCustomer.Text = "Update Customer";
            this.btnUpdateCustomer.UseVisualStyleBackColor = true;
            this.btnUpdateCustomer.Click += new System.EventHandler(this.btnUpdateCustomer_Click);

            // 
            // btnDeleteCustomer
            // 
            this.btnDeleteCustomer.Location = new System.Drawing.Point(360, 650);
            this.btnDeleteCustomer.Name = "btnDeleteCustomer";
            this.btnDeleteCustomer.Size = new System.Drawing.Size(150, 40);
            this.btnDeleteCustomer.TabIndex = 3;
            this.btnDeleteCustomer.Text = "Delete Customer";
            this.btnDeleteCustomer.UseVisualStyleBackColor = true;
            this.btnDeleteCustomer.Click += new System.EventHandler(this.btnDeleteCustomer_Click);

            // 
            // tabPage4 - Reports
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1072, 735);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Reports";
            this.tabPage4.UseVisualStyleBackColor = true;

            // Add the panels to the tabPage4
            this.tabPage4.Controls.Add(this.panelSoldRms);
            this.tabPage4.Controls.Add(this.panelRmsForSale);
            this.tabPage4.Controls.Add(this.panelDirtyRms);
            this.tabPage4.Controls.Add(this.panelCleanVacant);

            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(1072, 735);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Report";
            this.tabPage4.UseVisualStyleBackColor = true;

            // 
            // tabPage5 - Manage Bookings
            // 
            this.tabPage5.Controls.Add(this.dataGridViewBookings);
            this.tabPage5.Controls.Add(this.btnAddBooking);
            this.tabPage5.Controls.Add(this.btnUpdateBooking);
            this.tabPage5.Controls.Add(this.btnDeleteBooking);
            this.tabPage5.Location = new System.Drawing.Point(4, 29);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1072, 735);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Manage Bookings";
            this.tabPage5.UseVisualStyleBackColor = true;

            // 
            // dataGridViewBookings
            // 
            this.dataGridViewBookings.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBookings.Location = new System.Drawing.Point(20, 20);
            this.dataGridViewBookings.Name = "dataGridViewBookings";
            this.dataGridViewBookings.RowHeadersWidth = 51;
            this.dataGridViewBookings.RowTemplate.Height = 29;
            this.dataGridViewBookings.Size = new System.Drawing.Size(1000, 600);
            this.dataGridViewBookings.TabIndex = 0;

            // 
            // btnAddBooking
            // 
            this.btnAddBooking.Location = new System.Drawing.Point(20, 650);
            this.btnAddBooking.Name = "btnAddBooking";
            this.btnAddBooking.Size = new System.Drawing.Size(150, 40);
            this.btnAddBooking.TabIndex = 1;
            this.btnAddBooking.Text = "Add Booking";
            this.btnAddBooking.UseVisualStyleBackColor = true;
            this.btnAddBooking.Click += new System.EventHandler(this.btnAddBooking_Click);

            // 
            // btnUpdateBooking
            // 
            this.btnUpdateBooking.Location = new System.Drawing.Point(190, 650);
            this.btnUpdateBooking.Name = "btnUpdateBooking";
            this.btnUpdateBooking.Size = new System.Drawing.Size(150, 40);
            this.btnUpdateBooking.TabIndex = 2;
            this.btnUpdateBooking.Text = "Update Booking";
            this.btnUpdateBooking.UseVisualStyleBackColor = true;
            this.btnUpdateBooking.Click += new System.EventHandler(this.btnUpdateBooking_Click);

            // 
            // btnDeleteBooking
            // 
            this.btnDeleteBooking.Location = new System.Drawing.Point(360, 650);
            this.btnDeleteBooking.Name = "btnDeleteBooking";
            this.btnDeleteBooking.Size = new System.Drawing.Size(150, 40);
            this.btnDeleteBooking.TabIndex = 3;
            this.btnDeleteBooking.Text = "Delete Booking";
            this.btnDeleteBooking.UseVisualStyleBackColor = true;
            this.btnDeleteBooking.Click += new System.EventHandler(this.btnDeleteBooking_Click);

            // 
            // MasterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 768);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.Name = "MasterForm";
            this.Text = "Hotel Management System";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewRooms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBookings)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
    }
}