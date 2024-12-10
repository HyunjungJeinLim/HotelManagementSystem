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
        //private string connectionString = "Server=PL\\SQLEXPRESS;Database=HotelManagement;Integrated Security=True; TrustServerCertificate=true;";
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
            // Ensure that the user has provided all required data before proceeding
            if (dataGridViewRooms.CurrentRow == null)
            {
                MessageBox.Show("Please add room details in the grid before saving.");
                return;
            }

            var currentRow = dataGridViewRooms.CurrentRow;

            // Retrieve RoomType
            string roomType = currentRow.Cells["RoomType"].Value?.ToString();
            if (string.IsNullOrWhiteSpace(roomType))
            {
                MessageBox.Show("Room Type cannot be empty. Please provide a valid value.");
                return;
            }

            // Retrieve Price
            if (!decimal.TryParse(currentRow.Cells["Price"].Value?.ToString(), out decimal price))
            {
                MessageBox.Show("Invalid Price. Please provide a valid numeric value.");
                return;
            }

            // Retrieve Amenities
            string amenities = currentRow.Cells["Amenities"].Value?.ToString();
            if (string.IsNullOrWhiteSpace(amenities))
            {
                MessageBox.Show("Amenities cannot be empty. Please provide a valid value.");
                return;
            }

            // Retrieve Availability
            if (!bool.TryParse(currentRow.Cells["Availability"].Value?.ToString(), out bool availability))
            {
                MessageBox.Show("Invalid Availability value. Please provide a valid value.");
                return;
            }

            // Retrieve RoomNumber
            string roomNumber = currentRow.Cells["RoomNumber"].Value?.ToString();
            if (string.IsNullOrWhiteSpace(roomNumber))
            {
                MessageBox.Show("Room Number cannot be empty. Please provide a valid value.");
                return;
            }

            // SQL INSERT QUERY
            string query = "INSERT INTO Rooms (RoomType, Price, Amenities, Availability, RoomNumber) " +
                           "VALUES (@RoomType, @Price, @Amenities, @Availability, @RoomNumber)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@RoomType", roomType);
                command.Parameters.AddWithValue("@Price", price);
                command.Parameters.AddWithValue("@Amenities", amenities);
                command.Parameters.AddWithValue("@Availability", availability);
                command.Parameters.AddWithValue("@RoomNumber", roomNumber);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show($"Room {roomNumber} added successfully.");
                    LoadRooms(); // Refresh the data grid
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
                var currentRow = dataGridViewRooms.SelectedRows[0];

                // Retrieve RoomID
                if (!int.TryParse(currentRow.Cells["RoomID"].Value?.ToString(), out int roomId))
                {
                    MessageBox.Show("Invalid RoomID. Please select a valid room.");
                    return;
                }

                // Retrieve RoomNumber
                string roomNumber = currentRow.Cells["RoomNumber"].Value?.ToString();
                if (string.IsNullOrWhiteSpace(roomNumber))
                {
                    MessageBox.Show("Room Number cannot be empty. Please provide a valid value.");
                    return;
                }

                // Retrieve RoomType as string
                string roomType = currentRow.Cells["RoomType"].Value?.ToString();
                if (string.IsNullOrWhiteSpace(roomType))
                {
                    MessageBox.Show("Room Type cannot be empty. Please provide a valid value.");
                    return;
                }

                // Retrieve Availability
                if (!bool.TryParse(currentRow.Cells["Availability"].Value?.ToString(), out bool availability))
                {
                    MessageBox.Show("Invalid Availability value. Please provide a valid value.");
                    return;
                }

                // SQL Update Query
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

                        // Reload data to reflect the update
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
            AddCustomer addCustomerForm = new AddCustomer(connectionString);
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
                AddCustomer addCustomerForm = new AddCustomer(connectionString, customerId);
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

        private void btnAddBooking_Click(object sender, EventArgs e)
        {
            if (dataGridViewBookings.CurrentRow == null)
            {
                MessageBox.Show("Please enter booking details in the grid before saving.");
                return;
            }

            var currentRow = dataGridViewBookings.CurrentRow;

            // Retrieve CustomerID
            if (!int.TryParse(currentRow.Cells["CustomerID"].Value?.ToString(), out int customerId))
            {
                MessageBox.Show("Invalid CustomerID. Please provide a valid value.");
                return;
            }

            // Retrieve RoomID
            if (!int.TryParse(currentRow.Cells["RoomID"].Value?.ToString(), out int roomId))
            {
                MessageBox.Show("Invalid RoomID. Please provide a valid value.");
                return;
            }

            // Retrieve CheckInDate
            if (!DateTime.TryParse(currentRow.Cells["CheckInDate"].Value?.ToString(), out DateTime checkInDate))
            {
                MessageBox.Show("Invalid Check-In Date. Please provide a valid date.");
                return;
            }

            // Retrieve CheckOutDate
            if (!DateTime.TryParse(currentRow.Cells["CheckOutDate"].Value?.ToString(), out DateTime checkOutDate))
            {
                MessageBox.Show("Invalid Check-Out Date. Please provide a valid date.");
                return;
            }

            // Ensure CheckOutDate is after CheckInDate
            if (checkOutDate <= checkInDate)
            {
                MessageBox.Show("Check-Out Date must be after Check-In Date.");
                return;
            }

            // Retrieve TotalPrice
            if (!decimal.TryParse(currentRow.Cells["TotalPrice"].Value?.ToString(), out decimal totalPrice))
            {
                MessageBox.Show("Invalid Total Price. Please provide a valid numeric value.");
                return;
            }

            // Retrieve BookingStatus
            string bookingStatus = currentRow.Cells["BookingStatus"].Value?.ToString();
            if (string.IsNullOrWhiteSpace(bookingStatus))
            {
                MessageBox.Show("Booking Status cannot be empty. Please provide a valid value.");
                return;
            }

            // SQL INSERT QUERY
            string query = "INSERT INTO Bookings (CustomerID, RoomID, CheckInDate, CheckOutDate, TotalPrice, BookingStatus) " +
                           "VALUES (@CustomerID, @RoomID, @CheckInDate, @CheckOutDate, @TotalPrice, @BookingStatus)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@CustomerID", customerId);
                command.Parameters.AddWithValue("@RoomID", roomId);
                command.Parameters.AddWithValue("@CheckInDate", checkInDate);
                command.Parameters.AddWithValue("@CheckOutDate", checkOutDate);
                command.Parameters.AddWithValue("@TotalPrice", totalPrice);
                command.Parameters.AddWithValue("@BookingStatus", bookingStatus);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    MessageBox.Show("Booking added successfully.");
                    LoadBookings(); // Refresh the bookings data
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding booking: {ex.Message}");
                }
            }
        }



        private void btnUpdateBooking_Click(object sender, EventArgs e)
        {
            if (dataGridViewBookings.SelectedRows.Count > 0)
            {
                // Commit any pending edits in the DataGridView
                dataGridViewBookings.EndEdit();

                var selectedRow = dataGridViewBookings.SelectedRows[0];

                // Retrieve BookingID
                if (!int.TryParse(selectedRow.Cells["BookingID"].Value?.ToString(), out int bookingId))
                {
                    MessageBox.Show("Invalid BookingID. Please select a valid booking.");
                    return;
                }

                // Retrieve RoomID
                if (!int.TryParse(selectedRow.Cells["RoomID"].Value?.ToString(), out int roomId))
                {
                    MessageBox.Show("Invalid RoomID. Please provide a valid value.");
                    return;
                }

                // Retrieve CheckInDate
                if (!DateTime.TryParse(selectedRow.Cells["CheckInDate"].Value?.ToString(), out DateTime checkInDate))
                {
                    MessageBox.Show("Invalid Check-In Date. Please provide a valid date.");
                    return;
                }

                // Retrieve CheckOutDate
                if (!DateTime.TryParse(selectedRow.Cells["CheckOutDate"].Value?.ToString(), out DateTime checkOutDate))
                {
                    MessageBox.Show("Invalid Check-Out Date. Please provide a valid date.");
                    return;
                }

                // Ensure CheckOutDate is after CheckInDate
                if (checkOutDate <= checkInDate)
                {
                    MessageBox.Show("Check-Out Date must be after Check-In Date.");
                    return;
                }

                // Retrieve TotalPrice
                if (!decimal.TryParse(selectedRow.Cells["TotalPrice"].Value?.ToString(), out decimal totalPrice))
                {
                    MessageBox.Show("Invalid Total Price. Please provide a valid numeric value.");
                    return;
                }

                // Retrieve BookingStatus
                string bookingStatus = selectedRow.Cells["BookingStatus"].Value?.ToString();
                if (string.IsNullOrWhiteSpace(bookingStatus))
                {
                    MessageBox.Show("Booking Status cannot be empty. Please provide a valid value.");
                    return;
                }

                // SQL UPDATE Query
                string query = @"UPDATE Bookings 
                         SET RoomID = @RoomID, CheckInDate = @CheckInDate, CheckOutDate = @CheckOutDate, 
                             TotalPrice = @TotalPrice, BookingStatus = @BookingStatus
                         WHERE BookingID = @BookingID";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@BookingID", bookingId);
                    command.Parameters.AddWithValue("@RoomID", roomId);
                    command.Parameters.AddWithValue("@CheckInDate", checkInDate);
                    command.Parameters.AddWithValue("@CheckOutDate", checkOutDate);
                    command.Parameters.AddWithValue("@TotalPrice", totalPrice);
                    command.Parameters.AddWithValue("@BookingStatus", bookingStatus);

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Booking updated successfully.");
                        LoadBookings(); // Refresh the bookings data
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