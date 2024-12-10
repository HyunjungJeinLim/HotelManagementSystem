using HotelManagementSystem_Proj;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Reflection.Metadata;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace HotelManagementSystem_Proj_RAD
{
    public partial class MasterForm : Form
    {
        //private string connectionString = "Server=JEIN\\SQLEXPRESS;Database=HotelManagement;Trusted_Connection=True;";
        private string connectionString = "Server=PL\\SQLEXPRESS;Database=HotelManagement;Integrated Security=True; TrustServerCertificate=true;";
       // private string connectionString = "Server=STEPH-LAPTOP\\SQLEXPRESS;Database=HotelManagement;Integrated Security=True; TrustServerCertificate=true;";
        private Chart roomSalesChart;
        private Chart cleaningStatusChart;
        private readonly Reports _reports;

        public MasterForm()
        {
            InitializeComponent();

            //Configure the pictureBoxLogo
           // pictureBoxLogo2.Image = Image.FromFile("Images\\hyarriot-hotel-logo.png"); // Provide the path to your logo
           // pictureBoxLogo2.SizeMode = PictureBoxSizeMode.Zoom;

            // Initialize Clock
            lblClock.Text = DateTime.Now.ToString("hh:mm:ss tt");
            System.Windows.Forms.Timer clockTimer = new System.Windows.Forms.Timer
            {
                Interval = 1000 // Update every second
            };
            clockTimer.Tick += ClockTimer_Tick;
            clockTimer.Start();

            // Initialize Tabs and Data
            AddPieChartsToReport();
            LoadRooms();
            LoadCustomers();
            LoadBookings();
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;

            // TabControl Design
         
            tabControl1.ItemSize = new Size(150, 40);
            tabControl1.Padding = new Point(10, 10);

            MainForm_Load(this, EventArgs.Empty);
            _reports = new Reports(connectionString);

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Initialize ComboBox items and set default selection
            cbReportType.Items.Clear();
            cbReportType.Items.AddRange(new string[] { "Monthly Sales", "Booking Rates", "Cancellation Rates" });

            if (cbReportType.Items.Count > 0)
            {
                cbReportType.SelectedIndex = 0; // Default selection
            }
            LoadReportData(); // Load report data when the form loads
        }

        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private void AddPieChartsToReport()
        {
            Dictionary<string, int> roomSalesData = GetRoomSalesData();
            Dictionary<string, int> cleaningStatusData = GetCleaningStatusData();

            // Room Sales Chart
            roomSalesChart = new Chart
            {
                Size = new Size(450, 450), // Set chart size to 400x400
                Location = new Point(150, 400), // Adjust position if needed
                BackColor = Color.Transparent // Set entire chart background to transparent
            };

            ChartArea roomSalesArea = new ChartArea("RoomSalesArea")
            {
                BackColor = Color.Transparent // Set chart area background to transparent
            };
            roomSalesChart.ChartAreas.Add(roomSalesArea);

            Series roomSalesSeries = new Series("RoomSales")
            {
                ChartType = SeriesChartType.Pie,
                LabelForeColor = Color.White // Set label color to white
            };

            foreach (var item in roomSalesData)
            {
                roomSalesSeries.Points.AddXY(item.Key, item.Value);
            }

            roomSalesChart.Series.Add(roomSalesSeries);
            roomSalesChart.Titles.Add(new Title
            {
                Text = "Room Sales",
                ForeColor = Color.White // Set title color to white
            });

            // Cleaning Status Chart
            cleaningStatusChart = new Chart
            {
                Size = new Size(450, 450), // Set chart size to 400x400
                Location = new Point(750, 400), // Adjust position if needed
                BackColor = Color.Transparent // Set entire chart background to transparent
            };

            ChartArea cleaningStatusArea = new ChartArea("CleaningStatusArea")
            {
                BackColor = Color.Transparent // Set chart area background to transparent
            };
            cleaningStatusChart.ChartAreas.Add(cleaningStatusArea);

            Series cleaningStatusSeries = new Series("CleaningStatus")
            {
                ChartType = SeriesChartType.Pie,
                LabelForeColor = Color.White // Set label color to white
            };

            foreach (var item in cleaningStatusData)
            {
                cleaningStatusSeries.Points.AddXY(item.Key, item.Value);
            }

            cleaningStatusChart.Series.Add(cleaningStatusSeries);
            cleaningStatusChart.Titles.Add(new Title
            {
                Text = "Cleaning Status",
                ForeColor = Color.White // Set title color to white
            });

            // Add charts to the dashboard tab
            tabPageDashboard.Controls.Add(roomSalesChart);
            tabPageDashboard.Controls.Add(cleaningStatusChart);
        }



        private Dictionary<string, int> GetRoomSalesData()
        {
            Dictionary<string, int> data = new Dictionary<string, int>();
            string query = @"
        SELECT 
            SUM(CASE WHEN Availability = 0 THEN 1 ELSE 0 END) AS SoldRooms,
            SUM(CASE WHEN Availability = 1 THEN 1 ELSE 0 END) AS AvailableRooms
        FROM Rooms";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        data["Sold Rooms"] = reader.GetInt32(0);
                        data["Available Rooms"] = reader.GetInt32(1);
                        // Debug log
                        Console.WriteLine($"Sold Rooms: {data["Sold Rooms"]}, Available Rooms: {data["Available Rooms"]}");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading room sales data: {ex.Message}");
                }
            }
            return data;
        }


        private Dictionary<string, int> GetCleaningStatusData()
        {
            Dictionary<string, int> data = new Dictionary<string, int>();
            string query = @"
                SELECT 
                    SUM(CASE WHEN CleaningStatus = 0 THEN 1 ELSE 0 END) AS DirtyRooms,
                    SUM(CASE WHEN CleaningStatus = 1 THEN 1 ELSE 0 END) AS CleanRooms,
                    SUM(CASE WHEN CleaningStatus = 2 THEN 1 ELSE 0 END) AS MaintenanceRooms
                FROM Rooms";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        data["Dirty Rooms"] = reader.GetInt32(0);
                        data["Clean Rooms"] = reader.GetInt32(1);
                        data["Under Maintenance"] = reader.GetInt32(2);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading cleaning status data: {ex.Message}");
                }
            }
            return data;
        }

        private void LoadReportData()
        {
            Dictionary<string, int> roomSalesData = GetRoomSalesData();
            Dictionary<string, int> cleaningStatusData = GetCleaningStatusData();

            lblSoldRmsValue.Text = roomSalesData.ContainsKey("Sold Rooms") ? roomSalesData["Sold Rooms"].ToString() : "0";
            lblSoldRmsValue.Refresh(); // Force UI to update immediately

            lblRmsForSaleValue.Text = roomSalesData.ContainsKey("Available Rooms") ? roomSalesData["Available Rooms"].ToString() : "0";
            lblRmsForSaleValue.Refresh();

            lblDirtyRmsValue.Text = cleaningStatusData.ContainsKey("Dirty Rooms") ? cleaningStatusData["Dirty Rooms"].ToString() : "0";
            lblDirtyRmsValue.Refresh();

            lblCleanVacantValue.Text = cleaningStatusData.ContainsKey("Clean Rooms") ? cleaningStatusData["Clean Rooms"].ToString() : "0";
            lblCleanVacantValue.Refresh();

            // Update Chart data
            UpdatePieChart(roomSalesChart, roomSalesData, "Room Sales");
            UpdatePieChart(cleaningStatusChart, cleaningStatusData, "Cleaning Status");
        }


        private void UpdatePieChart(Chart chart, Dictionary<string, int> data, string title)
        {
            // Clear existing series and titles
            chart.Series.Clear();
            chart.Titles.Clear();

            // Create a new series for the pie chart
            Series series = new Series
            {
                ChartType = SeriesChartType.Pie,
                LabelForeColor = Color.White // Explicitly set label color to white
            };

            // Add data points to the series
            foreach (var item in data)
            {
                series.Points.AddXY(item.Key, item.Value);
            }

            // Add the series to the chart
            chart.Series.Add(series);

            // Add a title with white font color
            chart.Titles.Add(new Title
            {
                Text = title,
                ForeColor = Color.White // Explicitly set title color to white
            });
        }




        private void LoadRooms()
        {
            string query = "SELECT RoomID, RoomType, Price, Amenities, Availability, RoomNumber, CleaningStatus FROM Rooms";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    // Add a new column for the descriptive cleaning status
                    table.Columns.Add("CleaningStatusDescription", typeof(string));

                    // Map numeric CleaningStatus values to descriptions
                    foreach (DataRow row in table.Rows)
                    {
                        int cleaningStatus = Convert.ToInt32(row["CleaningStatus"]);
                        row["CleaningStatusDescription"] = cleaningStatus switch
                        {
                            0 => "Dirty",
                            1 => "Clean",
                            2 => "Under Maintenance",
                            _ => "Unknown"
                        };
                    }

                    dataGridViewRooms.DataSource = table;

                    // Hide the numeric CleaningStatus column
                    if (dataGridViewRooms.Columns["CleaningStatus"] != null)
                    {
                        dataGridViewRooms.Columns["CleaningStatus"].Visible = false;
                    }

                    // Optionally, rename the descriptive column header
                    if (dataGridViewRooms.Columns["CleaningStatusDescription"] != null)
                    {
                        dataGridViewRooms.Columns["CleaningStatusDescription"].HeaderText = "Cleaning Status";
                    }

                    // Hide RoomID column
                    if (dataGridViewRooms.Columns["RoomID"] != null)
                    {
                        dataGridViewRooms.Columns["RoomID"].Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading rooms: {ex.Message}");
                }
            }
        }



        private void LoadCustomers()
        {
            string query = "SELECT CustomerID, FirstName, LastName, Phone, Email, IsActive FROM Customers";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridViewCustomers.DataSource = table;

                    // Hide CustomerID column
                    if (dataGridViewCustomers.Columns["CustomerID"] != null)
                    {
                        dataGridViewCustomers.Columns["CustomerID"].Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading customers: {ex.Message}");
                }
            }
        }

        private void LoadBookings()
        {
            string query = @"
        SELECT 
            BookingID, 
            CustomerID, 
            RoomID, 
            CheckInDate, 
            CheckOutDate, 
            TotalPrice, 
            BookingStatus 
        FROM Bookings";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    // Add columns for CustomerName and RoomNumber
                    table.Columns.Add("CustomerName", typeof(string));
                    table.Columns.Add("RoomNumber", typeof(string));

                    foreach (DataRow row in table.Rows)
                    {
                        row["CustomerName"] = GetCustomerName((int)row["CustomerID"]);
                        row["RoomNumber"] = GetRoomNumber((int)row["RoomID"]);
                    }

                    dataGridViewBookings.DataSource = table;

                    // Hide internal IDs
                    if (dataGridViewBookings.Columns["BookingID"] != null)
                        dataGridViewBookings.Columns["BookingID"].Visible = false;
                    if (dataGridViewBookings.Columns["CustomerID"] != null)
                        dataGridViewBookings.Columns["CustomerID"].Visible = false;
                    if (dataGridViewBookings.Columns["RoomID"] != null)
                        dataGridViewBookings.Columns["RoomID"].Visible = false;

                    // Set BookingStatus to be editable
                    if (dataGridViewBookings.Columns["BookingStatus"] != null)
                        dataGridViewBookings.Columns["BookingStatus"].ReadOnly = false;

                    // Rename columns for better readability
                    if (dataGridViewBookings.Columns["CustomerName"] != null)
                        dataGridViewBookings.Columns["CustomerName"].HeaderText = "Customer Name";
                    if (dataGridViewBookings.Columns["RoomNumber"] != null)
                        dataGridViewBookings.Columns["RoomNumber"].HeaderText = "Room Number";

                    // Rearrange columns
                    if (dataGridViewBookings.Columns["RoomNumber"] != null)
                        dataGridViewBookings.Columns["RoomNumber"].DisplayIndex = 0; // Set RoomNumber as the first column
                    if (dataGridViewBookings.Columns["CustomerName"] != null)
                        dataGridViewBookings.Columns["CustomerName"].DisplayIndex = 1; // Set CustomerName as the second column
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading bookings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private string GetCustomerName(int customerId)
        {
            string query = "SELECT FirstName + ' ' + LastName AS FullName FROM Customers WHERE CustomerID = @CustomerID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", customerId);

                try
                {
                    connection.Open();
                    return command.ExecuteScalar()?.ToString() ?? "Unknown";
                }
                catch
                {
                    return "Unknown";
                }
            }
        }

        private string GetRoomNumber(int roomId)
        {
            string query = "SELECT RoomNumber FROM Rooms WHERE RoomID = @RoomID";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RoomID", roomId);

                try
                {
                    connection.Open();
                    return command.ExecuteScalar()?.ToString() ?? "Unknown";
                }
                catch
                {
                    return "Unknown";
                }
            }
        }



        // Event Handlers
        private void lblDashboard_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageDashboard;
        }

        private void lblManageRooms_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageRooms;
        }

        private void lblManageCustomers_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageCustomers;
        }

        private void lblManageBookings_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageBookings;
        }

        private void lblReports_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageReport;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            Login loginForm = new Login();
            loginForm.Show();
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            RoomInfo addRoomForm = new RoomInfo(connectionString);
            addRoomForm.ShowDialog(); // Open as modal dialog
            LoadRooms(); // Refresh the grid after adding a room
        }


        private void btnUpdateRoom_Click(object sender, EventArgs e)
        {
            if (dataGridViewRooms.SelectedRows.Count > 0)
            {
                // Get the selected RoomID
                int roomId = Convert.ToInt32(dataGridViewRooms.SelectedRows[0].Cells["RoomID"].Value);

                // Open the AddRoomForm for editing
                RoomInfo addRoomForm = new RoomInfo(connectionString, roomId);
                addRoomForm.ShowDialog();

                // Refresh the DataGridView after the form closes
                LoadRooms();
            }
            else
            {
                MessageBox.Show("Please select a room to update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            if (dataGridViewRooms.SelectedRows.Count > 0)
            {
                // Get the selected RoomID
                int roomId = Convert.ToInt32(dataGridViewRooms.SelectedRows[0].Cells["RoomID"].Value);

                // Confirm deletion
                DialogResult confirmResult = MessageBox.Show(
                    "Deleting this room may affect related records (e.g., bookings). Are you sure you want to delete this room?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    string query = "DELETE FROM Rooms WHERE RoomID = @RoomID";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@RoomID", roomId);

                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            MessageBox.Show("Room deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Refresh the DataGridView
                            LoadRooms();
                        }
                        catch (SqlException sqlEx)
                        {
                            // Check if the error is related to foreign key constraints
                            if (sqlEx.Number == 547) // Foreign key violation
                            {
                                MessageBox.Show(
                                    "This room is linked to existing bookings and cannot be deleted. Please delete associated bookings first.",
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show($"Error deleting room: {sqlEx.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Unexpected error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a room to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            CustomerInfo addCustomerForm = new CustomerInfo(connectionString);
            addCustomerForm.ShowDialog(); // Show as a modal dialog
            LoadCustomers(); // Refresh the DataGridView after adding a customer
        }


        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            if (dataGridViewCustomers.SelectedRows.Count > 0)
            {
                // Get the selected customer's ID
                int customerId = Convert.ToInt32(dataGridViewCustomers.SelectedRows[0].Cells["CustomerID"].Value);

                // Open the AddCustomerForm for editing
                CustomerInfo addCustomerForm = new CustomerInfo(connectionString, customerId);
                addCustomerForm.ShowDialog();

                // Refresh the customer data grid after the form closes
                LoadCustomers();
            }
            else
            {
                MessageBox.Show("Please select a customer to update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (dataGridViewCustomers.SelectedRows.Count > 0)
            {
                // Get the selected CustomerID
                int customerId = Convert.ToInt32(dataGridViewCustomers.SelectedRows[0].Cells["CustomerID"].Value);

                // Confirm deletion
                DialogResult confirmResult = MessageBox.Show(
                    "Are you sure you want to delete this customer?",
                    "Confirm Delete",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (confirmResult == DialogResult.Yes)
                {
                    // SQL DELETE Query
                    string query = "DELETE FROM Customers WHERE CustomerID = @CustomerID";

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@CustomerID", customerId);

                        try
                        {
                            connection.Open();
                            command.ExecuteNonQuery();
                            MessageBox.Show("Customer deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Refresh the DataGridView
                            LoadCustomers();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Error deleting customer: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

 



        private void btnUpdateBooking_Click(object sender, EventArgs e)
        {
            if (dataGridViewBookings.SelectedRows.Count > 0)
            {
                // Get the selected BookingID
                int bookingId = Convert.ToInt32(dataGridViewBookings.SelectedRows[0].Cells["BookingID"].Value);

                // Open the BookingInfo form for editing
                BookingInfo bookingInfoForm = new BookingInfo(connectionString, bookingId);
                bookingInfoForm.ShowDialog();

                // Refresh the bookings data grid after the form closes
                LoadBookings();
            }
            else
            {
                MessageBox.Show("Please select a booking to update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }




        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPageDashboard)
            {
                LoadReportData();
            }
        }

        // Reports tab

        private void btnGenerateReport_Click(object sender, EventArgs e)
        {
            // Check if cbReportType is initialized
            if (cbReportType == null)
            {
                MessageBox.Show("ComboBox is not initialized", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get selected report type from ComboBox
            string reportType = cbReportType.SelectedItem?.ToString();
            if (string.IsNullOrEmpty(reportType))
            {
                MessageBox.Show("Please select a report type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Check if _reports is initialized
            if (_reports == null)
            {
                MessageBox.Show("_reports is not initialized", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Fetch the report data from the Reports class (using the selected report type)
                DataTable reportData = _reports.GenerateReport(reportType); // Using DateTime.Now as default if no date is needed

                // Display the report data in the DataGridView if data is available
                if (reportData != null && reportData.Rows.Count > 0)
                {
                    dgvReport.DataSource = reportData;
                }
                else
                {
                    MessageBox.Show("No data found for the selected report.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error generating report: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}