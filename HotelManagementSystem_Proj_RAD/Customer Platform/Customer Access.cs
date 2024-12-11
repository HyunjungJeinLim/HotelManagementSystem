using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using HotelManagementSystem_Proj_RAD;
using Microsoft.Data.SqlClient;
using AxWMPLib;

namespace HotelManagementSystem_Proj.Customer_Platform
{
    public partial class Customer_Access : Form
    {
        private readonly string userEmail;

        public Customer_Access(string email)
        {
            InitializeComponent();
            userEmail = email;

            // Logo image
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string projectDirectory = Directory.GetParent(baseDirectory).Parent.Parent.Parent.FullName;
            string imagePath = Path.Combine(projectDirectory, "Images", "hyarriot-hotel-logo.png");

            if (File.Exists(imagePath))
            {
                pictureBoxLogo3.Image = Image.FromFile(imagePath);
                pictureBoxLogo3.SizeMode = PictureBoxSizeMode.Zoom;
            }
            else
            {
                MessageBox.Show($"Image not found at: {imagePath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Cover video
            string videoPath = Path.Combine(projectDirectory, "Images", "cover-video.mp4");

            if (File.Exists(videoPath))
            {
                axWindowsMediaPlayer.uiMode = "none";
                axWindowsMediaPlayer.stretchToFit = true;
                axWindowsMediaPlayer.settings.setMode("loop", true);
                axWindowsMediaPlayer.URL = videoPath;
                axWindowsMediaPlayer.Ctlcontrols.play();
            }
            else
            {
                MessageBox.Show($"Video not found at: {videoPath}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Initialize Clock
            lblClock.Text = DateTime.Now.ToString("hh:mm:ss tt");
            System.Windows.Forms.Timer clockTimer = new System.Windows.Forms.Timer
            {
                Interval = 1000
            };
            clockTimer.Tick += ClockTimer_Tick;
            clockTimer.Start();


            this.Load += new EventHandler(Customer_Access_Load);


        }

        private void ClockTimer_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("hh:mm:ss tt");
        }

        private async void Customer_Access_Load(object sender, EventArgs e)
        {
            await LoadUserDataAsync();
            await LoadUserBookingsAsync();
            
            LoadRoomTypes();
            LoadAmenities();
            LoadAllAvailableRooms();
            await LoadIncomingBookingAsync();
        }




        private async Task LoadUserDataAsync()
        {
            string query = "SELECT FirstName FROM Customers WHERE Email = @Email";

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString)) // Use global connection string
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", userEmail);
                        await connection.OpenAsync();
                        var firstName = await command.ExecuteScalarAsync() as string;

                        lblWelcomeUser.Text = !string.IsNullOrEmpty(firstName) ? $"Hi, {firstName}!" : "Hi, Guest!";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadUserBookingsAsync()
        {
            string query = @"
    SELECT 
        B.BookingID,
        R.RoomID,
        R.RoomType AS [Room Type],
        R.Amenities,
        R.RoomNumber AS [Room Number],
        CONCAT(C.FirstName, ' ', C.LastName) AS [Customer Name],
        B.CheckInDate AS [Check-In Date],
        B.CheckOutDate AS [Check-Out Date],
        B.TotalPrice AS [Total Price],
        B.BookingStatus AS [Booking Status]
    FROM 
        Bookings B
    INNER JOIN 
        Customers C ON B.CustomerID = C.CustomerID
    INNER JOIN 
        Rooms R ON B.RoomID = R.RoomID
    WHERE 
        C.Email = @Email";

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString)) // Use global connection string
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", userEmail);

                        await connection.OpenAsync();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            DataTable bookingsTable = new DataTable();
                            bookingsTable.Load(reader);
                            dataGridViewManageYourBookings.DataSource = bookingsTable;

                            // Hide BookingID and RoomID columns
                            if (dataGridViewManageYourBookings.Columns["BookingID"] != null)
                            {
                                dataGridViewManageYourBookings.Columns["BookingID"].Visible = false;
                            }
                            if (dataGridViewManageYourBookings.Columns["RoomID"] != null)
                            {
                                dataGridViewManageYourBookings.Columns["RoomID"].Visible = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading bookings: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void btnCancelBooking_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewManageYourBookings.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a booking to cancel.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int bookingId = Convert.ToInt32(dataGridViewManageYourBookings.SelectedRows[0].Cells["BookingID"].Value);

            DialogResult result = MessageBox.Show(
                "Are you sure you want to cancel this booking?",
                "Confirm Cancellation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.No)
            {
                return;
            }

            string query = "UPDATE Bookings SET BookingStatus = @Status WHERE BookingID = @BookingID";

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString)) // Use global connection string
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Status", "Cancelled");
                        command.Parameters.AddWithValue("@BookingID", bookingId);

                        await connection.OpenAsync();
                        int rowsAffected = await command.ExecuteNonQueryAsync();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Booking cancelled successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Refresh the bookings grid and available rooms
                            await LoadUserBookingsAsync();
                            RefreshAvailableRooms();
                            await LoadIncomingBookingAsync();
                        }
                        else
                        {
                            MessageBox.Show("Failed to cancel the booking.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while cancelling the booking: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLogout_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Login loginDashboard = new Login();
            loginDashboard.Show();
        }

        private void lblHome_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageHome;
        }

        private void lblFindARoom_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageBookARoom;
        }

        private void lblManageYourBookings_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPageManageYourBookings;
        }

        // Book A Room Tab

        private void LoadAllAvailableRooms()
        {
            string query = @"
    SELECT RoomID, RoomType, Price AS [Price per night], Amenities, RoomNumber
    FROM Rooms
    WHERE Availability = 1
      AND CleaningStatus = 1
      AND RoomID NOT IN (
          SELECT RoomID
          FROM Bookings
          WHERE 
              (GETDATE() BETWEEN CheckInDate AND CheckOutDate)
      )";

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable roomsTable = new DataTable();
                        adapter.Fill(roomsTable);

                        dataGridViewAvailableRooms.DataSource = roomsTable;

                        // Hide the RoomID column
                        if (dataGridViewAvailableRooms.Columns["RoomID"] != null)
                        {
                            dataGridViewAvailableRooms.Columns["RoomID"].Visible = false;
                        }

                        // Rename the "Price" column header to "Price per night"
                        if (dataGridViewAvailableRooms.Columns["Price per night"] != null)
                        {
                            dataGridViewAvailableRooms.Columns["Price per night"].HeaderText = "Price per night";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading available rooms: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void LoadRoomTypes()
        {
            string query = "SELECT DISTINCT RoomType FROM Rooms";

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString)) // Use global connection string
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<string> roomTypes = new List<string>
                    {
                        "All" // Add "All" option to the list
                    };
                            while (reader.Read())
                            {
                                roomTypes.Add(reader["RoomType"].ToString());
                            }

                            // Bind room types to ComboBox
                            cbRoomType.DataSource = roomTypes;
                            cbRoomType.SelectedIndex = 0; // Select "All" by default
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading room types: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadAmenities()
        {
            string query = "SELECT DISTINCT Amenities FROM Rooms";

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            List<string> amenitiesList = new List<string> { "All" }; // Add "All" option

                            while (reader.Read())
                            {
                                // Split amenities by comma and add them individually
                                string[] amenities = reader["Amenities"].ToString().Split(',');
                                foreach (string amenity in amenities)
                                {
                                    string trimmedAmenity = amenity.Trim();
                                    if (!amenitiesList.Contains(trimmedAmenity))
                                    {
                                        amenitiesList.Add(trimmedAmenity);
                                    }
                                }
                            }

                            // Bind amenities to ComboBox
                            cbAmenities.DataSource = amenitiesList;
                            cbAmenities.SelectedIndex = 0; // Select "All" by default
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading amenities: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnSearchRooms_Click(object sender, EventArgs e)
        {
            string roomType = cbRoomType.SelectedItem?.ToString() == "All" ? null : cbRoomType.SelectedItem?.ToString();
            string selectedAmenity = cbAmenities.SelectedItem?.ToString() == "All" ? null : cbAmenities.SelectedItem?.ToString();
            DateTime checkInDate = dtpCheckInDate.Value;
            DateTime checkOutDate = dtpCheckOutDate.Value;

            if (checkOutDate <= checkInDate)
            {
                MessageBox.Show("Check-out date must be after check-in date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"
    SELECT RoomID, RoomType, Price AS [Price per night], Amenities, RoomNumber
    FROM Rooms
    WHERE Availability = 1
      AND CleaningStatus = 1
      AND (@RoomType IS NULL OR RoomType = @RoomType)
      AND (@Amenity IS NULL OR Amenities LIKE '%' + @Amenity + '%')
      AND RoomID NOT IN (
          SELECT RoomID
          FROM Bookings
          WHERE 
              (@CheckInDate BETWEEN CheckInDate AND CheckOutDate)
              OR
              (@CheckOutDate BETWEEN CheckInDate AND CheckOutDate)
              OR
              (CheckInDate BETWEEN @CheckInDate AND @CheckOutDate)
      )";

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RoomType", (object)roomType ?? DBNull.Value);
                        command.Parameters.AddWithValue("@Amenity", (object)selectedAmenity ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CheckInDate", checkInDate);
                        command.Parameters.AddWithValue("@CheckOutDate", checkOutDate);

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable roomsTable = new DataTable();
                        adapter.Fill(roomsTable);

                        dataGridViewAvailableRooms.DataSource = roomsTable;

                        // Hide the RoomID column
                        if (dataGridViewAvailableRooms.Columns["RoomID"] != null)
                        {
                            dataGridViewAvailableRooms.Columns["RoomID"].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching rooms: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private async void btnBookRoom_Click(object sender, EventArgs e)
        {
            if (dataGridViewAvailableRooms.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a room to book.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int roomId = Convert.ToInt32(dataGridViewAvailableRooms.SelectedRows[0].Cells["RoomID"].Value);
            DateTime checkInDate = dtpCheckInDate.Value;
            DateTime checkOutDate = dtpCheckOutDate.Value;

            if (checkOutDate <= checkInDate)
            {
                MessageBox.Show("Check-out date must be after check-in date.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Calculate the number of days
            int numberOfDays = (checkOutDate - checkInDate).Days+1;

            if (numberOfDays <= 0)
            {
                MessageBox.Show("The stay duration must be at least one day.", "Invalid Date Range", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string query = @"
    DECLARE @PricePerNight DECIMAL(10, 2);
    SELECT @PricePerNight = Price FROM Rooms WHERE RoomID = @RoomID;

    INSERT INTO Bookings (CustomerID, RoomID, CheckInDate, CheckOutDate, TotalPrice, BookingStatus)
    VALUES (@CustomerID, @RoomID, @CheckInDate, @CheckOutDate, @PricePerNight * @NumberOfDays, 'Confirmed');";

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        int customerId = GetCustomerIdByEmail(userEmail); // Replace with your logic to fetch customer ID
                        command.Parameters.AddWithValue("@CustomerID", customerId);
                        command.Parameters.AddWithValue("@RoomID", roomId);
                        command.Parameters.AddWithValue("@CheckInDate", checkInDate);
                        command.Parameters.AddWithValue("@CheckOutDate", checkOutDate);
                        command.Parameters.AddWithValue("@NumberOfDays", numberOfDays);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Room booked successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Refresh the bookings grid and available rooms
                            await LoadUserBookingsAsync();
                            RefreshAvailableRooms();
                            await LoadIncomingBookingAsync();
                        }
                        else
                        {
                            MessageBox.Show("Failed to book the room.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error booking room: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void RefreshAvailableRooms()
        {
            string roomType = cbRoomType.SelectedItem?.ToString() == "All" ? null : cbRoomType.SelectedItem?.ToString();
            DateTime checkInDate = dtpCheckInDate.Value;
            DateTime checkOutDate = dtpCheckOutDate.Value;

            string query = @"
    SELECT RoomID, RoomType, Price AS [Price per night], Amenities, RoomNumber
    FROM Rooms
    WHERE Availability = 1
      AND CleaningStatus = 1
      AND (@RoomType IS NULL OR RoomType = @RoomType)
      AND RoomID NOT IN (
          SELECT RoomID
          FROM Bookings
          WHERE 
              (@CheckInDate BETWEEN CheckInDate AND CheckOutDate)
              OR
              (@CheckOutDate BETWEEN CheckInDate AND CheckOutDate)
              OR
              (CheckInDate BETWEEN @CheckInDate AND @CheckOutDate)
      )";

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@RoomType", (object)roomType ?? DBNull.Value);
                        command.Parameters.AddWithValue("@CheckInDate", checkInDate);
                        command.Parameters.AddWithValue("@CheckOutDate", checkOutDate);

                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable roomsTable = new DataTable();
                        adapter.Fill(roomsTable);

                        dataGridViewAvailableRooms.DataSource = roomsTable;

                        // Hide the RoomID column
                        if (dataGridViewAvailableRooms.Columns["RoomID"] != null)
                        {
                            dataGridViewAvailableRooms.Columns["RoomID"].Visible = false;
                        }

                        // Rename the "Price" column header to "Price per night"
                        if (dataGridViewAvailableRooms.Columns["Price per night"] != null)
                        {
                            dataGridViewAvailableRooms.Columns["Price per night"].HeaderText = "Price per night";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error fetching rooms: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private int GetCustomerIdByEmail(string email)
        {
            string query = "SELECT CustomerID FROM Customers WHERE Email = @Email";

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", email);
                        connection.Open();

                        object result = command.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving customer ID: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 0;
            }
        }

        // Home Tab
        private async Task LoadIncomingBookingAsync()
        {
            string query = @"
        SELECT TOP 1 
            B.CheckInDate, 
            B.CheckOutDate, 
            R.RoomNumber, 
            R.RoomType 
        FROM Bookings B
        INNER JOIN Rooms R ON B.RoomID = R.RoomID
        INNER JOIN Customers C ON B.CustomerID = C.CustomerID
        WHERE C.Email = @Email 
          AND B.CheckInDate >= CAST(GETDATE() AS DATE)
          AND B.BookingStatus = 'Confirmed'
        ORDER BY B.CheckInDate ASC";

            try
            {
                using (SqlConnection connection = new SqlConnection(DatabaseConfig.ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Email", userEmail);

                        await connection.OpenAsync();
                        using (SqlDataReader reader = await command.ExecuteReaderAsync())
                        {
                            if (reader.Read())
                            {
                                DateTime checkInDate = reader.GetDateTime(0);
                                DateTime checkOutDate = reader.GetDateTime(1);
                                string roomNumber = reader.GetString(2);
                                string roomType = reader.GetString(3);

                                lblIncomingBooking.Text = $"Room {roomNumber}, {roomType}, Check-in: {checkInDate:d}, Check-out: {checkOutDate:d}";
                            }
                            else
                            {
                                lblIncomingBooking.Text = "No upcoming bookings.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading upcoming booking: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                lblIncomingBooking.Text = "Unable to load upcoming bookings.";
            }
        }


    }
}
