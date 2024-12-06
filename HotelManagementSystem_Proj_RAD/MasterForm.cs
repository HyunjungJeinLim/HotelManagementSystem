using HotelManagementSystem_Proj;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace HotelManagementSystem_Proj_RAD
{
    public partial class MasterForm : Form
    {
        //private string connectionString = "Server=JEIN\\SQLEXPRESS;Database=HotelManagement;Trusted_Connection=True;";
        private string connectionString = "Server=STEPH-LAPTOP\\SQLEXPRESS;Database=HotelManagement;Integrated Security=True; TrustServerCertificate=true;";
        private Chart roomSalesChart;
        private Chart cleaningStatusChart;
        private readonly Reports _reports;

        public MasterForm()
        {
            InitializeComponent();

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
            LoadToDoList();
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;

            // TabControl Design
            tabControl1.Font = new Font("Arial", 10);
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
                Size = new Size(350, 350),
                Location = new Point(160, 430)
            };
            ChartArea roomSalesArea = new ChartArea("RoomSalesArea");
            roomSalesChart.ChartAreas.Add(roomSalesArea);
            Series roomSalesSeries = new Series("RoomSales") { ChartType = SeriesChartType.Pie };
            foreach (var item in roomSalesData)
            {
                roomSalesSeries.Points.AddXY(item.Key, item.Value);
            }
            roomSalesChart.Series.Add(roomSalesSeries);
            roomSalesChart.Titles.Add("Room Sales");

            // Cleaning Status Chart
            cleaningStatusChart = new Chart
            {
                Size = new Size(350, 350),
                Location = new Point(800, 430)
            };
            ChartArea cleaningStatusArea = new ChartArea("CleaningStatusArea");
            cleaningStatusChart.ChartAreas.Add(cleaningStatusArea);
            Series cleaningStatusSeries = new Series("CleaningStatus") { ChartType = SeriesChartType.Pie };
            foreach (var item in cleaningStatusData)
            {
                cleaningStatusSeries.Points.AddXY(item.Key, item.Value);
            }
            cleaningStatusChart.Series.Add(cleaningStatusSeries);
            cleaningStatusChart.Titles.Add("Cleaning Status");

            tabPage1.Controls.Add(roomSalesChart);
            tabPage1.Controls.Add(cleaningStatusChart);
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
            // get data
            Dictionary<string, int> roomSalesData = GetRoomSalesData();
            Dictionary<string, int> cleaningStatusData = GetCleaningStatusData();

            // Update Panel data
            lblSoldRmsValue.Text = roomSalesData.ContainsKey("Sold Rooms") ? roomSalesData["Sold Rooms"].ToString() : "0";
            lblRmsForSaleValue.Text = roomSalesData.ContainsKey("Available Rooms") ? roomSalesData["Available Rooms"].ToString() : "0";
            lblDirtyRmsValue.Text = cleaningStatusData.ContainsKey("Dirty Rooms") ? cleaningStatusData["Dirty Rooms"].ToString() : "0";
            lblCleanVacantValue.Text = cleaningStatusData.ContainsKey("Clean Rooms") ? cleaningStatusData["Clean Rooms"].ToString() : "0";

            // Update Chart data
            UpdatePieChart(roomSalesChart, roomSalesData, "Room Sales");
            UpdatePieChart(cleaningStatusChart, cleaningStatusData, "Cleaning Status");


        }

        private void UpdatePieChart(Chart chart, Dictionary<string, int> data, string title)
        {
            // chart Clear
            chart.Series.Clear();
            chart.Titles.Clear();

            Series series = new Series
            {
                ChartType = SeriesChartType.Pie
            };
            //Add data
            foreach (var item in data)
            {
                series.Points.AddXY(item.Key, item.Value);
            }

            chart.Series.Add(series);
            chart.Titles.Add(title);
        }



        private void LoadRooms()
        {
            string query = "SELECT * FROM Rooms";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridViewRooms.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading rooms: {ex.Message}");
                }
            }
        }

        private void LoadCustomers()
        {
            string query = "SELECT * FROM Customers";
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
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading customers: {ex.Message}");
                }
            }
        }

        private void LoadBookings()
        {
            string query = "SELECT * FROM Bookings";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);
                    dataGridViewBookings.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading bookings: {ex.Message}");
                }
            }
        }

        private void LoadToDoList()
        {

        }

        // Event Handlers
        private void lblDashboard_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void lblManageRooms_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void lblManageCustomers_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage3;
        }

        private void lblManageBookings_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage5;
        }

        private void lblReports_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage1;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            Login loginForm = new Login();
            loginForm.Show();
        }

        private void btnAddRoom_Click(object sender, EventArgs e)
        {
            int nextRoomID = GetNextRoomID();

            //default data
            string defaultRoomType = "Single";
            decimal defaultPrice = 100.00m;
            string defaultAmenities = "Wi-Fi";
            bool defaultAvailability = true;
            string defaultRoomNumber = "R" + nextRoomID.ToString("D3");

            // SQL INSERT QUERY
            string query = "INSERT INTO Rooms (RoomType, Price, Amenities, Availability, RoomNumber) " +
                           "VALUES (@RoomType, @Price, @Amenities, @Availability, @RoomNumber)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RoomType", defaultRoomType);
                command.Parameters.AddWithValue("@Price", defaultPrice);
                command.Parameters.AddWithValue("@Amenities", defaultAmenities);
                command.Parameters.AddWithValue("@Availability", defaultAvailability);
                command.Parameters.AddWithValue("@RoomNumber", defaultRoomNumber);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show($"Room {defaultRoomNumber} added successfully with default values.");
                    LoadRooms(); // 테이블 갱신
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding room: {ex.Message}");
                }
            }
        }

        //Room ID calculate
        private int GetNextRoomID()
        {
            int nextRoomID = 1;
            string query = "SELECT MAX(RoomID) FROM Rooms";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != DBNull.Value)
                    {
                        nextRoomID = Convert.ToInt32(result) + 1;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error fetching next RoomID: {ex.Message}");
                }
            }

            return nextRoomID;
        }


        private void btnUpdateRoom_Click(object sender, EventArgs e)
        {
            if (dataGridViewRooms.SelectedRows.Count > 0)
            {
                int roomId = Convert.ToInt32(dataGridViewRooms.SelectedRows[0].Cells["RoomID"].Value);
                string roomNumber = "104"; // Replace with input values
                int roomType = 2; // Replace with input values
                bool availability = false; // Replace with input values

                string query = @"UPDATE Rooms 
                         SET RoomNumber = @RoomNumber, RoomType = @RoomType, Availability = @Availability
                         WHERE RoomID = @RoomID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@RoomID", roomId);
                    command.Parameters.AddWithValue("@RoomNumber", roomNumber);
                    command.Parameters.AddWithValue("@RoomType", roomType);
                    command.Parameters.AddWithValue("@Availability", availability);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Room updated successfully.");
                        LoadRooms();
                        LoadReportData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating room: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a room to update.");
            }
        }

        private void btnDeleteRoom_Click(object sender, EventArgs e)
        {
            if (dataGridViewRooms.SelectedRows.Count > 0)
            {
                int roomId = Convert.ToInt32(dataGridViewRooms.SelectedRows[0].Cells["RoomID"].Value);
                string query = "DELETE FROM Rooms WHERE RoomID = @RoomID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@RoomID", roomId);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Room deleted successfully.");
                        LoadRooms();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting room: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a room to delete.");
            }
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            // default
            string defaultFirstName = "New";
            string defaultLastName = "Customer";
            string defaultPhone = "0000000000";
            string defaultEmail = "new.customer@example.com";
            bool defaultIsActive = true;

            // SQL INSERT Query
            string query = "INSERT INTO Customers (FirstName, LastName, Phone, Email, IsActive) " +
                           "VALUES (@FirstName, @LastName, @Phone, @Email, @IsActive)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FirstName", defaultFirstName);
                command.Parameters.AddWithValue("@LastName", defaultLastName);
                command.Parameters.AddWithValue("@Phone", defaultPhone);
                command.Parameters.AddWithValue("@Email", defaultEmail);
                command.Parameters.AddWithValue("@IsActive", defaultIsActive);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show($"Customer '{defaultFirstName} {defaultLastName}' added successfully.");
                    LoadCustomers();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding customer: {ex.Message}");
                }
            }
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            if (dataGridViewCustomers.SelectedRows.Count > 0)
            {
                int customerId = Convert.ToInt32(dataGridViewCustomers.SelectedRows[0].Cells["CustomerID"].Value);
                string firstName = "Updated"; // Replace with input values
                string lastName = "Customer"; // Replace with input values
                string phone = "0987654321"; // Replace with input values
                string email = "updated.customer@example.com"; // Replace with input values

                string query = @"UPDATE Customers 
                         SET FirstName = @FirstName, LastName = @LastName, Phone = @Phone, Email = @Email
                         WHERE CustomerID = @CustomerID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CustomerID", customerId);
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@Phone", phone);
                    command.Parameters.AddWithValue("@Email", email);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Customer updated successfully.");
                        LoadCustomers(); // Refresh the DataGridView
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating customer: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to update.");
            }
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (dataGridViewCustomers.SelectedRows.Count > 0)
            {
                int customerId = Convert.ToInt32(dataGridViewCustomers.SelectedRows[0].Cells["CustomerID"].Value);
                string query = "DELETE FROM Customers WHERE CustomerID = @CustomerID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@CustomerID", customerId);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Customer deleted successfully.");
                        LoadCustomers(); // Refresh the DataGridView
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting customer: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to delete.");
            }
        }

        private void btnAddBooking_Click(object sender, EventArgs e)
        {
            // default
            int defaultCustomerID = GetFirstCustomerID();
            int defaultRoomID = GetFirstAvailableRoomID();
            DateTime defaultCheckInDate = DateTime.Today;
            DateTime defaultCheckOutDate = DateTime.Today.AddDays(1);
            decimal defaultTotalPrice = 100.00m;
            string defaultBookingStatus = "Pending";

            if (defaultCustomerID == -1 || defaultRoomID == -1)
            {
                MessageBox.Show("Unable to add booking. Ensure customers and available rooms exist.");
                return;
            }

            // SQL INSERT QUERY
            string query = "INSERT INTO Bookings (CustomerID, RoomID, CheckInDate, CheckOutDate, TotalPrice, BookingStatus) " +
                           "VALUES (@CustomerID, @RoomID, @CheckInDate, @CheckOutDate, @TotalPrice, @BookingStatus)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", defaultCustomerID);
                command.Parameters.AddWithValue("@RoomID", defaultRoomID);
                command.Parameters.AddWithValue("@CheckInDate", defaultCheckInDate);
                command.Parameters.AddWithValue("@CheckOutDate", defaultCheckOutDate);
                command.Parameters.AddWithValue("@TotalPrice", defaultTotalPrice);
                command.Parameters.AddWithValue("@BookingStatus", defaultBookingStatus);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Booking added successfully.");
                    LoadBookings();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding booking: {ex.Message}");
                }
            }
        }

        private int GetFirstAvailableRoomID()
        {
            string query = "SELECT TOP 1 RoomID FROM Rooms WHERE Availability = 1 ORDER BY RoomID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error fetching available RoomID: {ex.Message}");
                    return -1;
                }
            }
        }

        private int GetFirstCustomerID()
        {
            string query = "SELECT TOP 1 CustomerID FROM Customers ORDER BY CustomerID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error fetching first CustomerID: {ex.Message}");
                    return -1;
                }
            }
        }


        private void btnUpdateBooking_Click(object sender, EventArgs e)
        {
            if (dataGridViewBookings.SelectedRows.Count > 0)
            {
                int bookingId = Convert.ToInt32(dataGridViewBookings.SelectedRows[0].Cells["BookingID"].Value);
                string roomNumber = "202"; // Replace with input values
                DateTime checkInDate = DateTime.Now; // Replace with input values
                DateTime checkOutDate = DateTime.Now.AddDays(2); // Replace with input values

                string query = @"UPDATE Bookings 
                         SET RoomNumber = @RoomNumber, CheckInDate = @CheckInDate, CheckOutDate = @CheckOutDate
                         WHERE BookingID = @BookingID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@BookingID", bookingId);
                    command.Parameters.AddWithValue("@RoomNumber", roomNumber);
                    command.Parameters.AddWithValue("@CheckInDate", checkInDate);
                    command.Parameters.AddWithValue("@CheckOutDate", checkOutDate);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Booking updated successfully.");
                        LoadBookings(); // Refresh the DataGridView
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating booking: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a booking to update.");
            }
        }

        private void btnDeleteBooking_Click(object sender, EventArgs e)
        {
            if (dataGridViewBookings.SelectedRows.Count > 0)
            {
                int bookingId = Convert.ToInt32(dataGridViewBookings.SelectedRows[0].Cells["BookingID"].Value);
                string query = "DELETE FROM Bookings WHERE BookingID = @BookingID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@BookingID", bookingId);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Booking deleted successfully.");
                        LoadBookings(); // Refresh the DataGridView
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting booking: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a booking to delete.");
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabPage1)
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
